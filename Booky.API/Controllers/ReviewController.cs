using Booky.API.ApiService.Reviews;
using Booky.API.Models.Response;
using Booky.Domain.Models.Review;
using Microsoft.AspNetCore.Mvc;

namespace Booky.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewController(IReviewApiService reviewApiService) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await reviewApiService.GetAsync()
        });
    }
    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await reviewApiService.GetAsync(id)
        });
    }
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync([FromBody] ReviewCreateModel book)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await reviewApiService.PostAsync(book)
        });
    }
    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await reviewApiService.DeleteAsync(id)
        });
    }
    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, [FromBody] ReviewUpdateModel book)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await reviewApiService.PutAsync(id, book)
        });
    }
}
