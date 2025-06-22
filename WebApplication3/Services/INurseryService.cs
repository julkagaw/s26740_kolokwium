using WebApplication3.DTOs;

namespace WebApplication3.Services;

public interface INurseryService
{
    Task<NurseryDetailsDto?> GetNurseryDetails(int id);
    Task<int> AddBatchAsync(CreateBatchDto dto);
}