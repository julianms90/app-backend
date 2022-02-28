using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Models;

namespace Backend.Domain.IServices
{
    public interface IDatosAdicionalesService
    {
        Task<List<DatosAdicionales>> GetDatosByClientId(int clienteId);

    }
}
