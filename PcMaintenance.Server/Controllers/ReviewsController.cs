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

    [HttpPost]
    public async Task<ActionResult<ReviewDto>> PostReview([FromBody] CreateReviewRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.AuthorName))
            return BadRequest(new { error = "AuthorName is required." });
        if (request.Rating < 1 || request.Rating > 5)
            return BadRequest(new { error = "Rating must be between 1 and 5." });
        if (string.IsNullOrWhiteSpace(request.Comment))
            return BadRequest(new { error = "Comment is required." });

        var review = new Review
        {
            AuthorName = request.AuthorName.Trim(),
            Rating = request.Rating,
            Comment = request.Comment.Trim(),
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
    public string AuthorName { get; set; } = string.Empty;
    [Required]
    [Range(1, 5)]
    public int Rating { get; set; }
    [Required]
    public string Comment { get; set; } = string.Empty;
}
