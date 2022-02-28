using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.IRepositories;
using Backend.Domain.IServices;
using Backend.Domain.Models;

namespace Backend.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task DeleteClient(int clienteId)
        {
            await _clienteRepository.DeleteClient(clienteId);
        }

        public async Task<Cliente> GetClientById(int clienteId)
        {
            return await _clienteRepository.GetClientById(clienteId);
        }

        public async Task<List<Cliente>> GetClients()
        {
            return await _clienteRepository.GetClients();
        }

        public async Task AddClient(Cliente cliente)
        {
            await _clienteRepository.AddClient(cliente);
        }

        public async Task UpdateClient(Cliente cliente)
        {
            await _clienteRepository.UpdateClient(cliente);
        }

        public async Task<bool> ValidateExistence(Cliente cliente)
        {
            return await _clienteRepository.ValidateExistence(cliente);
        }

        public async Task<List<Cliente>> GetClientFilter(string nombreCliente)
        {
            return await _clienteRepository.GetClientFilter(nombreCliente);
        }
    }
}
