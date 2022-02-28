using System.Threading.Tasks;
using Backend.Domain.Models;

namespace Backend.Domain.IServices
{
    public interface IUsuarioService
    {
        Task SaveUser(Usuario usuario);
        Task<bool> ValidateExistence(Usuario usuario);
        Task<Usuario> ValidatePassword(int usuarioId, string passwordAnterior);
        Task UpdatePassword(Usuario usuario);
    }
}
