using Booky.Domain.Entities;

namespace Booky.Service.Services.Reviews;

public interface IReviewService
{
    public ValueTask<Review> CreateAsync(Review review);
    public ValueTask<Review> UpdateAsync(long id, Review review);
    public ValueTask<bool> DeleteAsync(long id);
    public ValueTask<Review> GetByidAsync(long id);
    public ValueTask<IEnumerable<Review>> GetAllsync();
}
