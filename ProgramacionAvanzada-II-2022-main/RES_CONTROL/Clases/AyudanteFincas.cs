using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RES_CONTROL.Models;


namespace RES_CONTROL.Clases
{
    public class AyudanteFincas
    {

        GANADERAEntities db = new GANADERAEntities();

        //reporte por Ubicación

        public IEnumerable<FINCAS> ReporteFincaPorUbicacion(string parte)
        {
            IEnumerable<FINCAS> resultado = db.FINCAS.Where(a => a.LOCACION_FINCA.Contains(parte));
            return resultado;
        }

        public IEnumerable<POTREROS> ReportePotrerosPorFinca(string parte)
        {
            IEnumerable<POTREROS> resultado = db.POTREROS.Where(a => a.FINCAS.NOMBRE_FINCA.Contains(parte));
            return resultado;
        }

    }
}