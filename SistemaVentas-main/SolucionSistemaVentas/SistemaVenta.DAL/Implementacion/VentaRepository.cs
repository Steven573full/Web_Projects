using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using SistemaVenta.DAL.DBContext;
using SistemaVenta.DAL.Interfaces;
using SistemaVenta.Entity;

namespace SistemaVenta.DAL.Implementacion
{
    //Que herede de GenericRepository e IVentaRwepository junto con sus metodos
    public class VentaRepository : GenericRepository<Venta>, IVentaRepository
    {
        //Contexto
        private readonly DBVENTAContext _dbContext;

        //Constructor y que se envíe a GenericRepository
        public VentaRepository(DBVENTAContext dbContext):base(dbContext) 
        {
            _dbContext= dbContext;
        }

        public async Task<Venta> Registrar(Venta entidad)
        {
            Venta ventaGenerada = new Venta();

            //Usamos una transacción
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    //Insertamos el detalle de ventas dentro de entidad
                    foreach(DetalleVenta dv in entidad.DetalleVenta)
                    {
                        //Disminuimos el Stock que haya en los productos
                        Producto producto_encontrado = _dbContext.Productos.Where(p => p.IdProducto == dv.IdProducto).First();
                        producto_encontrado.Stock = producto_encontrado.Stock - dv.Cantidad;
                        _dbContext.Productos.Update(producto_encontrado);
                    }
                    await _dbContext.SaveChangesAsync();

                    //Generamos numero correlativo
                    NumeroCorrelativo correlativo = _dbContext.NumeroCorrelativos.Where(n => n.Gestion == "venta").First();

                    //Actualizamos el Correlativo
                    correlativo.UltimoNumero = correlativo.UltimoNumero + 1;
                    correlativo.FechaActualizacion = DateTime.Now;
                    _dbContext.NumeroCorrelativos.Update(correlativo);
                    await _dbContext.SaveChangesAsync();

                    //Creamos los ceros antes del numero
                    string ceros = string.Concat(Enumerable.Repeat("0", correlativo.CantidadDigitos.Value));
                    string numeroVenta = ceros + correlativo.UltimoNumero.ToString();
                    //Actualizamos el numero de venta
                    numeroVenta = numeroVenta.Substring(numeroVenta.Length - correlativo.CantidadDigitos.Value, correlativo.CantidadDigitos.Value);

                    entidad.NumeroVenta = numeroVenta;

                    await _dbContext.Venta.AddAsync(entidad);
                    await _dbContext.SaveChangesAsync();

                    ventaGenerada = entidad;

                    transaction.Commit();
                }
                catch (Exception ex) 
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
            return ventaGenerada;
        }

        public async Task<List<DetalleVenta>> Reporte(DateTime FechaInicio, DateTime FechaFin)
        {
            List<DetalleVenta> listaResumen = await _dbContext.DetalleVenta
                //funcionas para el detalle de venta
                .Include(v => v.IdVentaNavigation)
                //Funciona para el IdVenta
                .ThenInclude(u => u.IdUsuarioNavigation)
                //funciona para regresar a detalle de venta
                .Include(v => v.IdVentaNavigation)
                //Incluir el tipo de documento que se encuentra en venta
                .ThenInclude(tdv => tdv.IdTipoDocumentoVentaNavigation)
                .Where(dv => dv.IdVentaNavigation.FechaRegistro.Value.Date >= FechaInicio.Date &&
                dv.IdVentaNavigation.FechaRegistro.Value.Date <= FechaFin.Date)
                .ToListAsync();
            return listaResumen;
        }

    }
}
