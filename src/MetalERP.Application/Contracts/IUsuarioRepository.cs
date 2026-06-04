using MetalERP.Domain.Entities;

namespace MetalERP.Application.Contracts;
public interface IUsuarioRepository
{
    Task<List<Usuario>> GetAllAsync();

    Task<Usuario?> GetByIdAsync(int id);

    Task<Usuario?> GetByIdReadOnlyAsync(int id);

    Task AddAsync(Usuario usuario);

    Task UpdateAsync(Usuario usuario);
}