using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication3.Models;

[Table("TreeSpecies")]
public class TreeSpecies
{
    [Key]
    public int SpeciesId { get; set; }
    public string LatinName { get; set; }
    public int GrowthTimeInYears { get; set; }

    public ICollection<SeedlingBatch> Batches { get; set; }
}
