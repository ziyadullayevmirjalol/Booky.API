using Booky.API.Extensions;
using Booky.API.Validators.Reviiews;
using Booky.Domain.Models.Review;
using Booky.Service.Services.Reviews;

namespace Booky.API.ApiService.Reviews;

public class ReviewApiService(
    IReviewService reviewService,
    ReviewCreateModelValidator createModelValidator,
    ReviewUpdateModelValidator updateModelValidator) : IReviewApiService
{
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await reviewService.DeleteAsync(id);
    }

    public async ValueTask<ReviewViewModel> GetAsync(long id)
    {
        return await reviewService.GetByidAsync(id);
    }

    public async ValueTask<IEnumerable<ReviewViewModel>> GetAsync()
    {
        return await reviewService.GetAllsync();
    }

    public async ValueTask<ReviewViewModel> PostAsync(ReviewCreateModel model)
    {
        await createModelValidator.EnsureValidatedAsync(model);
        return await reviewService.CreateAsync(model);
    }

    public async ValueTask<ReviewViewModel> PutAsync(long id, ReviewUpdateModel model)
    {
        await updateModelValidator.EnsureValidatedAsync(model);
        return await reviewService.UpdateAsync(id, model);
    }
}
