using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RES_CONTROL.Models;

namespace RES_CONTROL.Clases
{
    public class Usuario
    {

        GANADERAEntities db = new GANADERAEntities();

        public int ID { set; get; }
        public string EMAIL { set; get; }
        public string ROL { set; get; }
        public string PASSWORD { set; get; }

        public bool Autenticar()
        {
            return db.USUARIOS.Where(
                u => u.EMAIL == this.EMAIL && u.PASSWORD == this.PASSWORD && u.ROL == this.ROL
                ).FirstOrDefault() != null;
        }



    }
}