namespace WebApplication3.DTOs;

public class SeedlingBatchDto
{
    public int BatchId { get; set; }
    public int Quantity { get; set; }
    public DateTime SownDate { get; set; }
    public DateTime? ReadyDate { get; set; }

    public TreeSpeciesDto Species { get; set; }
    public List<ResponsibleDto> Responsible { get; set; }
}
