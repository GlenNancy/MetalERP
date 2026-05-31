using MetalERP.Domain.Entities;

namespace MetalERP.Application.Contracts;
public interface ISetorRepository
{
    Task<List<Setor>> GetAllAsync();

    Task<Setor?> GetByIdAsync(int id);

    Task AddAsync(Setor setor);

    Task UpdateAsync(Setor setor);
}