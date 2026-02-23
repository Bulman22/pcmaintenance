using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Xunit;

namespace PcMaintenance.Server.Tests;

/// <summary>
/// Own fixture so rate limit store is fresh (no other tests consumed quota).
/// </summary>
public class ReviewsRateLimitTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;

    public ReviewsRateLimitTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;
    }

    private static object CreateReviewPayload(string authorName, int rating, string comment) =>
        new { authorName, rating, comment };

    private static JsonSerializerOptions JsonOptions => new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true
    };

    [Fact]
    public async Task PostReview_ExceedsRateLimit_Returns429()
    {
        using var client = _factory.CreateClient();
        HttpStatusCode? fourthStatus = null;
        for (var i = 0; i < 4; i++)
        {
            var payload = CreateReviewPayload($"User{i}", 5, $"Comment {i}");
            var response = await client.PostAsJsonAsync("/api/reviews", payload, JsonOptions);
            if (i < 3)
                Assert.True(response.IsSuccessStatusCode, $"Request {i + 1} should succeed.");
            else
                fourthStatus = response.StatusCode;
        }
        Assert.True(fourthStatus == (HttpStatusCode)429, "Fourth POST from same IP should return 429 Too Many Requests.");
    }
}
