using Booky.API.ApiService.Books;
using Booky.API.Models.Response;
using Booky.Domain.Models.Book;
using Microsoft.AspNetCore.Mvc;

namespace Booky.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController(IBookApiService bookApiService) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await bookApiService.GetAsync()
        });
    }
    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await bookApiService.GetAsync(id)
        });
    }
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync([FromBody] BookCreateModel book)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await bookApiService.PostAsync(book)
        });
    }
    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await bookApiService.DeleteAsync(id)
        });
    }
    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, [FromBody] BookUpdateModel book)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await bookApiService.PutAsync(id, book)
        });
    }
}
