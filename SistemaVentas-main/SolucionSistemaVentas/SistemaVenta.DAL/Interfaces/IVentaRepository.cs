using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaVenta.Entity;
//Repositorio para las ventas
namespace SistemaVenta.DAL.Interfaces
{
    //Que herede de IGeneric de la parte de Venta especificamente
    public interface IVentaRepository : IGenericRepository<Venta>
    {
        Task<Venta> Registrar(Venta entidad);
        Task <List<DetalleVenta>> Reporte(DateTime FechaInicio, DateTime FechaFin);
    }
}
