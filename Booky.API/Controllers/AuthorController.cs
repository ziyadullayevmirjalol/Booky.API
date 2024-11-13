using Booky.API.ApiService.Authors;
using Booky.API.Models.Author;
using Booky.API.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Booky.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController(IAuthorApiService authorApiService) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await authorApiService.GetAsync()
        });
    }
    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await authorApiService.GetAsync(id)
        });
    }
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync([FromBody] AuthorCreateModel author)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await authorApiService.PostAsync(author)
        });
    }
    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await authorApiService.DeleteAsync(id)
        });
    }
    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, [FromBody] AuthorUpdateModel author)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await authorApiService.PutAsync(id, author)
        });
    }
}
