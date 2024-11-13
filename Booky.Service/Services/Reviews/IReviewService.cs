using Booky.Domain.Entities;
using Booky.Domain.Models.Review;

namespace Booky.Service.Services.Reviews;

public interface IReviewService
{
    public ValueTask<ReviewViewModel> CreateAsync(ReviewCreateModel review);
    public ValueTask<ReviewViewModel> UpdateAsync(long id, ReviewUpdateModel review);
    public ValueTask<bool> DeleteAsync(long id);
    public ValueTask<ReviewViewModel> GetByidAsync(long id);
    public ValueTask<IEnumerable<ReviewViewModel>> GetAllsync();
}
