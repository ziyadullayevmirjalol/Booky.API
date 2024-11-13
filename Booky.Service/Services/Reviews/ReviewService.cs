using Booky.Domain.Entities;

namespace Booky.Service.Services.Reviews;

public class ReviewService : IReviewService
{
    public ValueTask<Review> CreateAsync(Review review)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<Review>> GetAllsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<Review> GetByidAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Review> UpdateAsync(long id, Review review)
    {
        throw new NotImplementedException();
    }
}
