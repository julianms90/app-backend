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
    public class DatosAdicionalesRepository: IDatosAdicionalesRepository
    {
        private readonly AplicationDbContext _context;
        public DatosAdicionalesRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DatosAdicionales>> GetDatosByClientId(int clienteId)
        {
            var listaDatos = await _context.DatosAdicionales.Where(x => x.Estado && x.ClienteId == clienteId)
                .Select(x => new DatosAdicionales
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    Estado = x.Estado,
                    ClienteId = x.ClienteId
                })
                .ToListAsync();
            return listaDatos;
        }
    }
}
