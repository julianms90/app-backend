using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.IRepositories;
using Backend.Domain.Models;
using Backend.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AplicationDbContext _context;
        public ClienteRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteClient(int clienteId)
        {
            var cliente = _context.Cliente.FirstOrDefault(x => x.Id == clienteId);
            cliente.Estado = false;

            var datosAdicionales = _context.DatosAdicionales.Where(x => x.Estado && x.ClienteId == clienteId);
            foreach (var dato in datosAdicionales)
            {
                dato.Estado = false;
                _context.Entry(dato).State = EntityState.Modified;
            }

            _context.Entry(cliente).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public Task<Cliente> GetClientById(int clienteId)
        {
            return _context.Cliente
                .Where(x => x.Id == clienteId)
                .Include(x => x.DatosAdicionales)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Cliente>> GetClients()
        {
            var listaClientes = await _context.Cliente.Where(x => x.Estado)
                .Select(o => new Cliente
                {
                    Id = o.Id,
                    NombreCompleto = o.NombreCompleto,
                    Identificacion = o.Identificacion,
                    Edad = o.Edad,
                    Genero = o.Genero,
                    Maneja = o.Maneja,
                    UsaLentes = o.UsaLentes,
                    Diabetico = o.Diabetico,
                    Enfermedad = o.Enfermedad
                })
                .ToListAsync();
            return listaClientes;
        }

        public async Task AddClient(Cliente cliente)
        {
            _context.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClient(Cliente cliente)
        {
            var cli = _context.Cliente.FirstOrDefault(x => x.Id == cliente.Id);

            cli.NombreCompleto = cliente.NombreCompleto;
            cli.Identificacion = cliente.Identificacion;
            cli.Edad = cliente.Edad;
            cli.Genero = cliente.Genero;
            cli.Maneja = cliente.Maneja;
            cli.UsaLentes = cliente.UsaLentes;
            cli.Diabetico = cliente.Diabetico;
            cli.Enfermedad = cliente.Enfermedad;
            _context.Entry(cli).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistence(Cliente cliente)
        {
            var validateExistence =
                await _context.Cliente.AnyAsync(x =>
                    x.NombreCompleto == cliente.NombreCompleto
                    && x.Estado == true
                    && x.Id != cliente.Id);
            return validateExistence;
        }

        public async Task<List<Cliente>> GetClientFilter(string nombreCliente)
        {
            var listaClientes = await _context.Cliente.Where(x => x.Estado && x.NombreCompleto.ToLower() == nombreCliente)
                .Select(o => new Cliente
                {
                    Id = o.Id,
                    NombreCompleto = o.NombreCompleto,
                    Identificacion = o.Identificacion,
                    Edad = o.Edad,
                    Genero = o.Genero,
                    Maneja = o.Maneja,
                    UsaLentes = o.UsaLentes,
                    Diabetico = o.Diabetico,
                    Enfermedad = o.Enfermedad
                })
                .ToListAsync();
            return listaClientes;
        }
    }
}
