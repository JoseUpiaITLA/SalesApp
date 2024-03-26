﻿using SalesApp.Domain.Entities;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Models;

namespace SalesApp.Infraestructure.Interfaces
{
    public interface IVentaDb : IDaoBase<Venta, int>
    {
        public Task<List<VentaUsuario>> GetVentaUsuarios(int usuarioId);
    }
}
