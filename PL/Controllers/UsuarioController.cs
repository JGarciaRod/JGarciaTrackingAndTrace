using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            List<Object> list = BL.Usuario.GetAll();

            if (list != null)
            {
                usuario.Usuarios = list;
            }
            else
            {
                ViewBag.Mensaje = "Vacio";
            }

            return View(usuario);
        }

        [HttpPost]
        public ActionResult GetAll(ML.Usuario usuario)
        {
            List<object> list = BL.Usuario.GetAll();

            if (list != null)
            {
                usuario.Usuarios = list;
            }
            else
            {
                ViewBag.Mensaje = "Vacio";
            }
            return View(usuario);
        }

        [HttpGet]
        public ActionResult Form(int? IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();

            if (IdUsuario != 0)
            {
                usuario = BL.Usuario.GetById(IdUsuario.Value);
                usuario.Rol.Roles = BL.Rol.GetAll();
            }
            else
            {
                usuario.Rol.Roles = BL.Rol.GetAll();
            }
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            if (usuario.IdUsuario == 0) //add
            {
                bool result = BL.Usuario.Add(usuario);
                if (result)
                {
                    ViewBag.Mensaje = "Se incerto correctamente";
                    ViewBag.Login = true;
                }
                else
                {
                    ViewBag.Mensaje = "Error";
                    ViewBag.Login = true;
                }
            }
            else //update
            {
                bool result = BL.Usuario.Update(usuario);
                if (result)
                {
                    ViewBag.Mensaje = "Se actualizo correctamente";
                    ViewBag.Login = false;
                }
                else
                {
                    ViewBag.Mensaje = "Error";
                    ViewBag.Login = false;
                }
            }
            return PartialView("Modal");
        }

        [HttpDelete]
        public ActionResult Delete(int IdUsuario)
        {
            bool result = BL.Usuario.Delete(IdUsuario);
            if (result)
            {
                ViewBag.Mensaje = "Se elimio correctamente";
            }
            else
            {
                ViewBag.Mensaje = "Error";
            }
            return PartialView("Modal");
        }


        // GET: Usuario LOGIN 
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string pass)
        {
            ML.Usuario usuario = new ML.Usuario();

            //byte[] encriptada = BL.Usuario.EcriptaString(pass);

            usuario = BL.Usuario.GetByEmail(email);

            if (usuario.Email != null)
            {
                if(usuario.Contra == pass)
                {
                    ViewBag.Login = true;
                    Session["Rol"] = usuario.Rol.Tipo;
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ViewBag.Login = false;
                    ViewBag.Mensaje = "Error en su contraseña";
                    return PartialView("Modal");
                }
            }
            else
            {
                ViewBag.Login = false;
                ViewBag.Mensaje = "Error en su correo";
                return PartialView("Modal");
            }

        }
    }
}