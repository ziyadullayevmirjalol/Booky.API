using Booky.API.ApiService.Publishers;
using Booky.API.Models.Response;
using Booky.Domain.Models.Publisher;
using Microsoft.AspNetCore.Mvc;

namespace Booky.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PublisherController(IPublisherApiServce publisherApiService) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> GetAllAsync()
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await publisherApiService.GetAsync()
        });
    }
    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetByIdAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await publisherApiService.GetAsync(id)
        });
    }
    [HttpPost]
    public async ValueTask<IActionResult> PostAsync([FromBody] PublisherCreateModel book)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await publisherApiService.PostAsync(book)
        });
    }
    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await publisherApiService.DeleteAsync(id)
        });
    }
    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> PutAsync(long id, [FromBody] PublisherUpdateModel book)
    {
        return Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await publisherApiService.PutAsync(id, book)
        });
    }

}