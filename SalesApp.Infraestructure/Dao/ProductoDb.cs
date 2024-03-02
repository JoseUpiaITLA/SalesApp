﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SalesApp.Domain.Entities;
using SalesApp.Infraestructure.Context;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Exceptions;
using SalesApp.Infraestructure.Interfaces;

namespace SalesApp.Infraestructure.Dao
{
    public class ProductoDb : DaoBase<Producto>, IProductoDb
    {
        private readonly SaleContext _saleContext;
        private readonly ILogger<ProductoDb> _logger;
        private readonly IConfiguration _configuration;
        public ProductoDb(SaleContext saleContext, ILogger<ProductoDb> logger, IConfiguration configuration) : base(saleContext)
        {
            this._saleContext = saleContext;
            this._logger = logger;
            this._configuration = configuration;
        }

        public override List<Producto> GetAll()
        {
            return base.GetEntitiesWithFilters(e => !e.Eliminado);
        }

        public override DataResult Save(Producto entity)
        {
            DataResult result = new DataResult();
            try
            {
                if (this.Exists(e => e.Descripcion == entity.Descripcion))
                    throw new CustomException("La Producto se encuentra registrado.");

                base.Save(entity);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió el siguiente error: {ex.Message}";
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public override DataResult Update(Producto entity)
        {
            DataResult result = new DataResult();
            try
            {
                Producto ProductoToUpdate = base.GetById(entity.Id);

                ProductoToUpdate.CodigoBarra = entity.CodigoBarra;
                ProductoToUpdate.Marca = entity.Marca;
                ProductoToUpdate.Descripcion = entity.Descripcion;
                ProductoToUpdate.IdCategoria = entity.IdCategoria;
                ProductoToUpdate.Stock = entity.Stock;
                ProductoToUpdate.UrlImagen = entity.UrlImagen;
                ProductoToUpdate.NombreImagen = entity.NombreImagen;
                ProductoToUpdate.Precio = entity.Precio;
                ProductoToUpdate.IdUsuarioMod = entity.IdUsuarioMod;
                ProductoToUpdate.EsActivo = entity.EsActivo;
                ProductoToUpdate.FechaMod = entity.FechaMod;

                base.Update(ProductoToUpdate);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrio el siguiente error: {ex.Message}";
                this._logger.LogError(result.Message, ex.ToString());
            }
            return base.Update(entity);
        }
    }
}
