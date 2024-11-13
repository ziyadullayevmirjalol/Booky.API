using AutoMapper;
using Booky.DataAccess.UnitOfWorks;
using Booky.Domain.Entities;
using Booky.Domain.Models.Review;
using Booky.Service.Exceptions;
using Booky.Service.Services.Books;

namespace Booky.Service.Services.Reviews;

public class ReviewService(IBookService bookService, IUnitOfWork unitOfWork, IMapper mapper) : IReviewService
{
    public async ValueTask<ReviewViewModel> CreateAsync(ReviewCreateModel review)
    {
        var existBook = await unitOfWork.Books.SelectAsync(
            expression: b => b.Id == review.BookId && !b.IsDeleted)
            ?? throw new NotFoundException($"Book is not found with Id ({review.BookId})");

        var created = await unitOfWork.Reviews.InsertAsync(mapper.Map<Review>(review));
        await unitOfWork.SaveAsync();

        return mapper.Map<ReviewViewModel>(created);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existReview = await unitOfWork.Reviews.SelectAsync(
            expression: r => r.Id == id && !r.IsDeleted)
            ?? throw new NotFoundException($"Review is not found with Id ({id})");

        await unitOfWork.Reviews.DeleteAsync(existReview);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<ReviewViewModel>> GetAllsync()
    {
        var Reviews = await unitOfWork.Reviews.SelectAsEnumerableAsync(
            expression: r => !r.IsDeleted,
            isTracked: false,
            includes: ["Book"]);

        var result = Reviews.Select(review => new ReviewViewModel
        {
            Id = review.Id,
            Content = review.Content,
            Rating = review.Rating,
            BookTitle = review.Book.Title
        }).ToList();

        return mapper.Map<IEnumerable<ReviewViewModel>>(Reviews);
    }

    public async ValueTask<ReviewViewModel> GetByidAsync(long id)
    {
        var existReview = await unitOfWork.Reviews.SelectAsync(
           expression: r => r.Id == id && !r.IsDeleted)
           ?? throw new NotFoundException($"Review is not found with Id ({id})");

        var result = new ReviewViewModel
        {
            Id = existReview.Id,
            Content = existReview.Content,
            Rating = existReview.Rating,
            BookTitle = existReview.Book.Title
        };
        return result;
    }

    public async ValueTask<ReviewViewModel> UpdateAsync(long id, ReviewUpdateModel review)
    {
        var existReview = await unitOfWork.Reviews.SelectAsync(
           expression: r => r.Id == id && !r.IsDeleted)
           ?? throw new NotFoundException($"Review is not found with Id ({id})");

        if (review.Content != "" || review.Content is not null)
            existReview.Content = review.Content;

        if (review.Rating != 0 || review.Content is not null)
            existReview.Rating = review.Rating;

        existReview.UpdatedAt = DateTime.UtcNow;

        var updated = await unitOfWork.Reviews.UpdateAsync(existReview);
        await unitOfWork.SaveAsync();

        return mapper.Map<ReviewViewModel>(updated);
    }
}
