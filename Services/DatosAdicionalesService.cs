using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.IRepositories;
using Backend.Domain.IServices;
using Backend.Domain.Models;
using Backend.Repositories;

namespace Backend.Services
{
    public class DatosAdicionalesService : IDatosAdicionalesService
    {
        private readonly IDatosAdicionalesRepository _datosAdicionalesRepository;

        public DatosAdicionalesService(IDatosAdicionalesRepository datosAdicionalesRepository)
        {
            _datosAdicionalesRepository = datosAdicionalesRepository;
        }

        public async Task<List<DatosAdicionales>> GetDatosByClientId(int clienteId)
        {
            return await _datosAdicionalesRepository.GetDatosByClientId(clienteId);
        }
    }


}
