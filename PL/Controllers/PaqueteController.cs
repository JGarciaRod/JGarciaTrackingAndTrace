using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class PaqueteController : Controller
    {
        // GET: Paquete
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Form(ML.Paquete paquete)
        {
            bool result = BL.Paquete.Add(paquete);
            string email  = paquete.Email;
            if(result)
            {
                ViewBag.Mensaje = "Se creo su pedido correctamente";
                EnviarEmail(email);
            }
            else
            {
                ViewBag.Error = "Error al incertar";
            }
            return PartialView("Modal");
        }

        [HttpPost]
        public ActionResult EnviarEmail(string Email)
        {
            ML.Paquete paquete = BL.Paquete.Ultimoañadido();

            string emailOrigen = "jgarciar271@gmail.com";

            string cuerpo = $"<h1>Bienvenido</h1>" + "<h1>Su Envio ya esta en camino</h1>" + "<br />" + "<p>Este atento a cualquier aviso su codigo de rastreo es: "+ paquete.CodigoRastreo +"</p>";

            MailMessage mailMessage = new MailMessage(emailOrigen, Email, "Envio de paquete", cuerpo);
            mailMessage.IsBodyHtml = true;

            string url = "http://localhost:53791/" + HttpUtility.UrlEncode(Email);

            mailMessage.Body = mailMessage.Body.Replace("{Url}", url);

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Port = 587;
            smtpClient.Credentials = new System.Net.NetworkCredential(emailOrigen, "yubzutshntvzsnup");

            smtpClient.Send(mailMessage);
            smtpClient.Dispose();

            ViewBag.Modal = "show";
            ViewBag.Mensaje = "Se ha enviado un correo de confirmación a tu correo electronico";
            return RedirectToAction("Olvide", "Usuario");
        }
    }
}