using MetalERP.Application.Contracts;
using MetalERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MetalERP.Infrastructure.Persistence.Repositories;

public class SetorRepository : ISetorRepository
{
    private readonly ApplicationDbContext _context;

    public SetorRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Setor>> GetAllAsync()
    {
        return await _context.Setores
            .AsNoTracking()
            .OrderBy(s => s.Nome)
            .ToListAsync();
    }

    public async Task<Setor?> GetByIdAsync(int id)
    {
        return await _context.Setores
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Setor?> GetByIdReadOnlyAsync(int id)
    {
        return await _context.Setores
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task AddAsync(Setor setor)
    {
        await _context.Setores.AddAsync(setor);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Setor setor)
    {
        _context.Setores.Update(setor);
        await _context.SaveChangesAsync();
    }
}