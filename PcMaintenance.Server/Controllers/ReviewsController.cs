using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PcMaintenance.Server.Data;
using PcMaintenance.Server.Data.Entities;

namespace PcMaintenance.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly AppDbContext _db;

    public ReviewsController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReviewDto>>> GetReviews(CancellationToken cancellationToken)
    {
        try
        {
            var list = await _db.Reviews
                .OrderByDescending(r => r.CreatedAt)
                .Select(r => new ReviewDto
                {
                    Id = r.Id,
                    AuthorName = r.AuthorName,
                    Rating = r.Rating,
                    Comment = r.Comment,
                    CreatedAt = r.CreatedAt
                })
                .ToListAsync(cancellationToken);
            return Ok(list);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = "Failed to load reviews.", detail = ex.Message });
        }
    }

    [HttpPost]
    public async Task<ActionResult<ReviewDto>> PostReview([FromBody] CreateReviewRequest? request, CancellationToken cancellationToken)
    {
        if (request == null)
            return BadRequest(new { error = "Request body is required." });

        if (!string.IsNullOrWhiteSpace(request.Website))
            return Ok(new ReviewDto { Id = 0, AuthorName = "", Rating = 0, Comment = "", CreatedAt = DateTime.UtcNow });

        if (string.IsNullOrWhiteSpace(request.AuthorName))
            return BadRequest(new { error = "AuthorName is required." });
        if (request.Rating < 1 || request.Rating > 5)
            return BadRequest(new { error = "Rating must be between 1 and 5." });
        if (string.IsNullOrWhiteSpace(request.Comment))
            return BadRequest(new { error = "Comment is required." });

        var authorName = request.AuthorName.Trim();
        var comment = request.Comment.Trim();
        if (authorName.Length > 200)
            return BadRequest(new { error = "Numele nu poate depăși 200 de caractere." });
        if (comment.Length > 2000)
            return BadRequest(new { error = "Comentariul nu poate depăși 2000 de caractere." });

        var commentNormalized = System.Text.RegularExpressions.Regex.Replace(comment, @"\s+", " ");

        var since = DateTime.UtcNow.AddHours(-24);
        var recentSameAuthor = await _db.Reviews
            .Where(r => r.CreatedAt >= since && r.AuthorName.ToLower() == authorName.ToLower())
            .Select(r => r.Comment)
            .ToListAsync(cancellationToken);
        var duplicateExists = recentSameAuthor
            .Any(c => System.Text.RegularExpressions.Regex.Replace(c, @"\s+", " ") == commentNormalized);
        if (duplicateExists)
            return BadRequest(new { error = "O recenzie identică a fost deja trimisă recent." });

        try
        {
            var review = new Review
            {
                AuthorName = authorName,
                Rating = request.Rating,
                Comment = comment,
                CreatedAt = DateTime.UtcNow
            };
            _db.Reviews.Add(review);
            await _db.SaveChangesAsync(cancellationToken);

            return StatusCode(201, new ReviewDto
            {
                Id = review.Id,
                AuthorName = review.AuthorName,
                Rating = review.Rating,
                Comment = review.Comment,
                CreatedAt = review.CreatedAt
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = "Failed to save review.", detail = ex.Message });
        }
    }
}

public class ReviewDto
{
    public int Id { get; set; }
    public string AuthorName { get; set; } = string.Empty;
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}

public class CreateReviewRequest
{
    [Required]
    [MaxLength(200)]
    public string AuthorName { get; set; } = string.Empty;
    [Required]
    [Range(1, 5)]
    public int Rating { get; set; }
    [Required]
    [MaxLength(2000)]
    public string Comment { get; set; } = string.Empty;
    public string? Website { get; set; }
}
