using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RES_CONTROL.Models;

namespace RES_CONTROL.Clases
{
    public class AyudanteVacunas
    {
        GANADERAEntities db = new GANADERAEntities();

        public IEnumerable<VACUNAS> ReporteVacunasPorNombre(string parte)
        {

            IEnumerable<VACUNAS> resultado = db.VACUNAS.Where(a => a.NOMBRE_VACUNA.Contains(parte));

            return resultado;
        }

        public IEnumerable<VACUNAS> ReporteVacunasPorFecha(string parte)
        {
            IEnumerable<VACUNAS> resultado = db.VACUNAS.Where(a => a.FECHA.ToString().Contains(parte));
            return resultado;
        }



    }
}