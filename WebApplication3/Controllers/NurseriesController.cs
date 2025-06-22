using Microsoft.AspNetCore.Mvc;
using WebApplication3.Services;

namespace WebApplication3.Controllers;

[ApiController]
[Route("api/nurseries")]
public class NurseriesController : ControllerBase
{
    private readonly INurseryService _service;

    public NurseriesController(INurseryService service)
    {
        _service = service;
    }

    [HttpGet("{id}/batches")]
    public async Task<IActionResult> GetBatches(int id)
    {
        var result = await _service.GetNurseryDetails(id);
        return result == null ? NotFound() : Ok(result);
    }
}
