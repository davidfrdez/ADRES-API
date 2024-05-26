using ADRES_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace ADRES_API.DAOs
{
    public class DAO
    {
        private readonly ApplicationDbContextFactory _contextFactory;

        public DAO(IConfiguration configuration)
        {
            _contextFactory = new ApplicationDbContextFactory(configuration);
        }

        public int SavePresupuestos(PresupuestoDTO presupuesto)
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    context.Presupuestos.Add(new PresupuestoDTO
                    {
                        Cantidad = presupuesto.Cantidad,
                        Documentacion= presupuesto.Documentacion,
                        FechaDeAdquisicion=DateTime.Now,
                        TipoDeBienOServicio=presupuesto.TipoDeBienOServicio,
                        Presupuesto=presupuesto.Presupuesto,
                        Proveedor=presupuesto.Proveedor,
                        Unidad=presupuesto.Unidad,
                        ValorTotal=presupuesto.ValorTotal,
                        ValorUnitario = presupuesto.ValorUnitario   
                    });
                    context.SaveChanges();
                    return StatusCodes.Status200OK;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<PresupuestoDTO> GetPresupuestos()
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    var presupuestos = context.Presupuestos.ToList();
                    return presupuestos;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
