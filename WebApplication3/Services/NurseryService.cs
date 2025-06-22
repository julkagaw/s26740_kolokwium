using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.DTOs;
using WebApplication3.Models;

namespace WebApplication3.Services;

public class NurseryService : INurseryService
{
    private readonly AppDbContext _context;

    public NurseryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<NurseryDetailsDto?> GetNurseryDetails(int id)
    {
        var nursery = await _context.Nurseries
            .Include(n => n.Batches)
                .ThenInclude(b => b.Species)
            .Include(n => n.Batches)
                .ThenInclude(b => b.Responsibles)
                    .ThenInclude(r => r.Employee)
            .FirstOrDefaultAsync(n => n.NurseryId == id);

        if (nursery == null) return null;

        return new NurseryDetailsDto
        {
            NurseryId = nursery.NurseryId,
            Name = nursery.Name,
            EstablishedDate = nursery.EstablishedDate,
            Batches = nursery.Batches.Select(b => new SeedlingBatchDto
            {
                BatchId = b.BatchId,
                Quantity = b.Quantity,
                SownDate = b.SownDate,
                ReadyDate = b.ReadyDate,
                Species = new TreeSpeciesDto
                {
                    LatinName = b.Species.LatinName,
                    GrowthTimeInYears = b.Species.GrowthTimeInYears
                },
                Responsible = b.Responsibles.Select(r => new ResponsibleDto
                {
                    FirstName = r.Employee.FirstName,
                    LastName = r.Employee.LastName,
                    Role = r.Role
                }).ToList()
            }).ToList()
        };
    }

    public async Task<int> AddBatchAsync(CreateBatchDto dto)
    {
        var nursery = await _context.Nurseries.FirstOrDefaultAsync(n => n.Name == dto.Nursery);
        if (nursery == null) throw new Exception("Nursery not found");

        var species = await _context.TreeSpecies.FirstOrDefaultAsync(s => s.LatinName == dto.Species);
        if (species == null) throw new Exception("Species not found");

        foreach (var r in dto.Responsible)
        {
            var emp = await _context.Employees.FindAsync(r.EmployeeId);
            if (emp == null) throw new Exception("Employee not found: " + r.EmployeeId);
        }

        var batch = new SeedlingBatch
        {
            NurseryId = nursery.NurseryId,
            SpeciesId = species.SpeciesId,
            Quantity = dto.Quantity,
            SownDate = DateTime.Now,
            ReadyDate = DateTime.Now.AddYears(species.GrowthTimeInYears),
            Responsibles = new List<Responsible>()
        };

        _context.SeedlingBatches.Add(batch);
        await _context.SaveChangesAsync();

        foreach (var r in dto.Responsible)
        {
            batch.Responsibles.Add(new Responsible
            {
                BatchId = batch.BatchId,
                EmployeeId = r.EmployeeId,
                Role = r.Role
            });
        }

        await _context.SaveChangesAsync();
        return batch.BatchId;
    }
}
