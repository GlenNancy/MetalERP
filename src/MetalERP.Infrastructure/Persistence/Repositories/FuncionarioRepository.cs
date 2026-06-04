using MetalERP.Application.Contracts;
using MetalERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MetalERP.Infrastructure.Persistence.Repositories;

public class FuncionarioRepository : IFuncionarioRepository
{
    private readonly ApplicationDbContext _context;

    public FuncionarioRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Funcionario>> GetAllAsync()
    {
        return await _context.Funcionarios
            .AsNoTracking()
            .OrderBy(f => f.Nome)
            .ToListAsync();
    }

    public async Task<Funcionario?> GetByIdAsync(int id)
    {
        return await _context.Funcionarios
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<Funcionario?> GetByIdReadOnlyAsync(int id)
    {
        return await _context.Funcionarios
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task AddAsync(Funcionario funcionario)
    {
        await _context.Funcionarios.AddAsync(funcionario);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Funcionario funcionario)
    {
        _context.Funcionarios.Update(funcionario);
        await _context.SaveChangesAsync();
    }
}