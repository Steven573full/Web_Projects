using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Mail;
using SistemaVenta.BLL.Interfaces;
using SistemaVenta.DAL.Interfaces;
using SistemaVenta.Entity;

namespace SistemaVenta.BLL.Implementacion
{
    //Clase publica y le quitamos el internal, heredamos interfaz y ctrl + . e implementamos
    public class CorreoService : ICorreoService
    {
        //Creamos contexto
        private readonly IGenericRepository<Configuracion> _repositorio;

        //Creamos un constructor
        public CorreoService(IGenericRepository<Configuracion> repositorio)
        {
            _repositorio = repositorio;
        }

        //Implementamos interfaz pero asincrono
        public async Task<bool> EnviarCorreo(string CorreoDestino, string Asunto, string Mensaje)
        {
            try
            {
                //Usamos el repositorio para obtener credenciales
                IQueryable<Configuracion> query = await _repositorio.Consultar(c => c.Recurso.Equals("Servicio_Correo"));
                //Crear un diccionario para llamar las propiedades y el valor
                Dictionary<string, string> Config = query.ToDictionary(keySelector: c => c.Propiedad, elementSelector: c => c.Valor);
                //Configurar correo, creamos credencial
                var credenciales = new NetworkCredential(Config["correo"], Config["clave"]);
                //Objeto correo, cuerpo de mensaje
                var correo = new MailMessage()
                {
                    From = new MailAddress(Config["correo"], Config["alias"]),
                    Subject = Asunto,
                    Body = Mensaje,
                    IsBodyHtml = true
                };
                //a quien le va a llegar
                correo.To.Add(new MailAddress(CorreoDestino));
                //Configurar el cliente servidor
                var clienteServidor = new SmtpClient()
                {
                    Host = Config["host"],
                    Port = int.Parse(Config["puerto"]),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    EnableSsl = true
                };
                //Enviar el correo que hemos creado
                clienteServidor.Send(correo);
                return true;
            } catch
            {
                return false;
            }
        }
    }
}
