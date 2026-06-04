using MetalERP.Domain.Entities;

namespace MetalERP.Application.Contracts;
public interface IFuncionarioRepository
{
    Task<List<Funcionario>> GetAllAsync();

    Task<Funcionario?> GetByIdAsync(int id);

    Task<Funcionario?> GetByIdReadOnlyAsync(int id);

    Task AddAsync(Funcionario funcionario);

    Task UpdateAsync(Funcionario funcionario);
}