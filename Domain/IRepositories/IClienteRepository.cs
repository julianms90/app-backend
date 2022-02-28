using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Domain.Models;

namespace Backend.Domain.IRepositories
{
    public interface IClienteRepository
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
