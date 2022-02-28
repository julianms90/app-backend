using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Models;

namespace Backend.Domain.IRepositories
{
    public interface IDatosAdicionalesRepository
    {
        Task<List<DatosAdicionales>> GetDatosByClientId(int clienteId);

    }
}
