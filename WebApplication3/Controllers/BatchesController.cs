using Microsoft.AspNetCore.Mvc;
using WebApplication3.DTOs;
using WebApplication3.Services;

namespace WebApplication3.Controllers;

[ApiController]
[Route("api/batches")]
public class BatchesController : ControllerBase
{
    private readonly INurseryService _service;

    public BatchesController(INurseryService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> AddBatch([FromBody] CreateBatchDto dto)
    {
        try
        {
            var id = await _service.AddBatchAsync(dto);
            return Created($"api/batches/{id}", null);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
