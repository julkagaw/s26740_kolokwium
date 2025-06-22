namespace WebApplication3.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
[Table("Responsible")]
public class Responsible
{
    [ForeignKey(nameof(SeedlingBatch))]
    public int BatchId { get; set; }
    public SeedlingBatch Batch { get; set; }
    
    [ForeignKey(nameof(Employee))]
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }

    public string Role { get; set; }
}
