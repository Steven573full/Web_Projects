using RES_CONTROL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RES_CONTROL.Clases
{
    public class AyudanteAlimentacion
    {
        GANADERAEntities db = new GANADERAEntities();

        public IEnumerable<ALIMENTACION> ReporteAlimentacionPorTipo(string parte){

            IEnumerable<ALIMENTACION> resultado = db.ALIMENTACION.Where(a => a.TIPO_ALIMENTACION.Contains(parte));

            return resultado;
        }

        public IEnumerable<ALIMENTACION> ReporteAlimentacionPorProposito(string parte)
        {

            IEnumerable<ALIMENTACION> resultado = db.ALIMENTACION.Where(a => a.PROPOSITO.Contains(parte));

            return resultado;
        }

    }
}