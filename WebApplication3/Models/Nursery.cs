using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models;

[Table("Nursery")]
public class Nursery
{
    [Key]
    public int NurseryId { get; set; }
    public string Name { get; set; }
    public DateTime EstablishedDate { get; set; }

    public ICollection<SeedlingBatch> Batches { get; set; }
}
