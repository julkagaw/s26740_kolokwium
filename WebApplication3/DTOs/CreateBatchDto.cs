namespace WebApplication3.DTOs;

public class CreateBatchDto
{
    public int Quantity { get; set; }
    public string Species { get; set; }
    public string Nursery { get; set; }
    public List<CreateResponsibleDto> Responsible { get; set; }
}
