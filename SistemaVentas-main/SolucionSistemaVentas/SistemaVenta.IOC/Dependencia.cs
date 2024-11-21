using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Dependencias que agregamos
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaVenta.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using SistemaVenta.DAL.Implementacion;
using SistemaVenta.DAL.Interfaces;
using SistemaVenta.BLL.Interfaces;
using SistemaVenta.BLL.Implementacion;

namespace SistemaVenta.IOC
{
    public static class Dependencia
    {
        //Metodo para inyectar dependencias
        public static void InyectarDependencia(this IServiceCollection services, IConfiguration Configuration)
        {
            //Referencia de la conexion al contexto de EntityFramework
            services.AddDbContext<DBVENTAContext>(options =>
            {
                //Leer configuracion desde cadena de configuracion
                options.UseSqlServer(Configuration.GetConnectionString("CadenaSQL"));
            });
            //Implementamos el servicio en donde se pone el tipo de interfaz y la clase
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //Utilizamos inyeccion de indepencias
            services.AddScoped<IVentaRepository, VentaRepository>();
            //Dependencia de envio de correo
            services.AddScoped<ICorreoService, CorreoService>();
            //Dependencia para encriptar
            services.AddScoped<IUtilidadesService, UtilidadesService>();
        }
    }
}
