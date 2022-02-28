using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Domain.Models;

namespace Backend.Domain.IServices
{
    public interface IClienteService
    {
        Task AddClient(Cliente cliente);
        Task<bool> ValidateExistence(Cliente cliente);
        Task UpdateClient(Cliente cliente);
        Task DeleteClient(int clienteId);
        Task<List<Cliente>> GetClients();
        Task<Cliente> GetClientById(int clienteId);
        Task<List<Cliente>> GetClientFilter(string nombreCliente);
        
    }
}
