using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PcMaintenance.Server.Data;
using PcMaintenance.Server.Data.Entities;
using Xunit;

namespace PcMaintenance.Server.Tests;

public class ReviewsControllerTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;

    public ReviewsControllerTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;
    }

    private static JsonSerializerOptions JsonOptions => new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true
    };

    private static object CreateReviewPayload(string authorName = "Test User", int rating = 5, string comment = "Great service!", string? website = null)
    {
        var payload = new { authorName, rating, comment };
        if (website != null)
            return new { authorName, rating, comment, website };
        return payload;
    }

    [Fact]
    public async Task PostReview_HoneypotFilled_ReturnsOkAndDoesNotSave()
    {
        await ClearReviewsAsync();
        using var client = _factory.CreateClient();
        var payload = CreateReviewPayload(website: "http://spam.com");

        var response = await client.PostAsJsonAsync("/api/reviews", payload, JsonOptions);
        Assert.True(response.IsSuccessStatusCode, "Request with honeypot filled should return success (silent drop).");

        var count = await GetReviewsCount();
        Assert.Equal(0, count);
    }

    [Fact]
    public async Task PostReview_ValidRequest_SavesAndReturns201()
    {
        await ClearReviewsAsync();
        using var client = _factory.CreateClient();
        var payload = CreateReviewPayload("Alice", 5, "Very good!");

        var response = await client.PostAsJsonAsync("/api/reviews", payload, JsonOptions);
        Assert.True(response.StatusCode == HttpStatusCode.Created, "Valid review should return 201 Created.");

        var count = await GetReviewsCount();
        Assert.Equal(1, count);
    }

    [Fact]
    public async Task PostReview_DuplicateWithin24h_ReturnsBadRequest()
    {
        await ClearReviewsAsync();
        await SeedOneReviewAsync("Bob", "Same comment.");
        using var client = _factory.CreateClient();
        var payload = CreateReviewPayload("Bob", 4, "Same comment.");

        var response = await client.PostAsJsonAsync("/api/reviews", payload, JsonOptions);
        Assert.True(response.StatusCode == HttpStatusCode.BadRequest, "Duplicate review (same author + comment in 24h) should return 400.");

        var content = await response.Content.ReadAsStringAsync();
        Assert.True(content.Contains("identică", StringComparison.OrdinalIgnoreCase), "Response body should contain duplicate message.");
    }

    [Fact]
    public async Task PostReview_AuthorNameTooLong_ReturnsBadRequest()
    {
        await ClearReviewsAsync();
        using var client = _factory.CreateClient();
        var payload = CreateReviewPayload(new string('x', 201), 5, "Comment.");

        var response = await client.PostAsJsonAsync("/api/reviews", payload, JsonOptions);
        Assert.True(response.StatusCode == HttpStatusCode.BadRequest, "AuthorName over 200 chars should return 400.");
    }

    [Fact]
    public async Task PostReview_CommentTooLong_ReturnsBadRequest()
    {
        await ClearReviewsAsync();
        using var client = _factory.CreateClient();
        var payload = CreateReviewPayload("User", 5, new string('x', 2001));

        var response = await client.PostAsJsonAsync("/api/reviews", payload, JsonOptions);
        Assert.True(response.StatusCode == HttpStatusCode.BadRequest, "Comment over 2000 chars should return 400.");
    }

    private async Task<int> GetReviewsCount()
    {
        using var scope = _factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        return await db.Reviews.CountAsync();
    }

    private async Task SeedOneReviewAsync(string authorName, string comment)
    {
        using var scope = _factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        db.Reviews.Add(new Review { AuthorName = authorName, Rating = 5, Comment = comment, CreatedAt = DateTime.UtcNow });
        await db.SaveChangesAsync();
    }

    private async Task ClearReviewsAsync()
    {
        using var scope = _factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        db.Reviews.RemoveRange(await db.Reviews.ToListAsync());
        await db.SaveChangesAsync();
    }
}
