using Booky.API.Models.Review;

namespace Booky.API.ApiService.Reviews;

public interface IReviewApiService
{
    public ValueTask<ReviewViewModel> PostAsync(ReviewCreateModel model);
    public ValueTask<ReviewViewModel> PutAsync(long id, ReviewUpdateModel model);
    public ValueTask<bool> DeleteAsync(long id);
    public ValueTask<ReviewViewModel> GetAsync(long id);
    public ValueTask<IEnumerable<ReviewViewModel>> GetAsync();

}

