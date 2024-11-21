using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RES_CONTROL.Models;

namespace RES_CONTROL.Clases
{
    public class AyudantePotreros
    {

        GANADERAEntities db = new GANADERAEntities();

        public IEnumerable<POTREROS> ReportePotreroPorAlimentacion(string parte)
        {

            IEnumerable<POTREROS> resultado = db.POTREROS.Where(a => a.ALIMENTACION.TIPO_ALIMENTACION.Contains(parte));

            return resultado;
        }

        public IEnumerable<POTREROS> ReportePotrerosPorFinca(string parte)
        {
            IEnumerable<POTREROS> resultado = db.POTREROS.Where(a => a.FINCAS.NOMBRE_FINCA.Contains(parte));
            return resultado;
        }

    }
}