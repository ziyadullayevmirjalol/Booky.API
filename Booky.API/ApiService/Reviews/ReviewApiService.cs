using Booky.Domain.Models.Review;

namespace Booky.API.ApiService.Reviews;

public class ReviewApiService : IReviewApiService
{
    public ValueTask<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<ReviewViewModel> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<ReviewViewModel>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<ReviewViewModel> PostAsync(ReviewCreateModel model)
    {
        throw new NotImplementedException();
    }

    public ValueTask<ReviewViewModel> PutAsync(long id, ReviewUpdateModel model)
    {
        throw new NotImplementedException();
    }
}
