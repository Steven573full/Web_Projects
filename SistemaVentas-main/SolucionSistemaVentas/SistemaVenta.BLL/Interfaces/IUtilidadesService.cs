using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.BLL.Interfaces
{
    //Interfaz de internal a publica
    public interface IUtilidadesService
    {
        //Metodo generar clave
        string GenerarClave();

        //Metodo para encriptar texto
        string ConvertirSha256(string texto);
    }
}
