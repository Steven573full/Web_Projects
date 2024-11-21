using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RES_CONTROL.Models;

namespace RES_CONTROL.Clases
{
    public class AyudanteReses
    {

        GANADERAEntities db = new GANADERAEntities();

        public IEnumerable<RESES> ReporteResesPorFierro(string parte)
        {
            IEnumerable<RESES> resultado = db.RESES.Where(a => a.FIERRO.Contains(parte));
            return resultado;
        }

        public IEnumerable<RESES> ReporteResesPorEdad(string parte)
        {
            List<RESES> todo = db.RESES.ToList();
            List<RESES> resultado = new List<RESES>();

            foreach (RESES vaca in todo) {
                if (vaca.EDAD_MESES.ToString().Contains(parte))
                {
                    resultado.Add(vaca);
                }
            }
            return resultado;
        }

        public IEnumerable<RESES> ReporteResesPorRaza(string parte)
        {
            IEnumerable<RESES> resultado = db.RESES.Where(a => a.RAZA.Contains(parte));
            return resultado;
        }

        public IEnumerable<RESES> ReporteResesPorSennasPotrero(string parte)
        {
            IEnumerable<RESES> resultado = db.RESES.Where(a => a.POTREROS.DESCRIPCION_POTRERO.Contains(parte));
            return resultado;
        }

        public IEnumerable<RESES> ReporteResesPorSexo(string parte)
        {
            IEnumerable<RESES> resultado = db.RESES.Where(a => a.SEXO.ToLower() == parte.ToLower());
            return resultado;
        }

    }
}