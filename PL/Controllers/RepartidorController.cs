using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class RepartidorController : Controller
    {
        // GET: Repartidor
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Repartidor repartidor = new ML.Repartidor();
            repartidor.UnidadEntrega = new ML.UnidadEntrega();

            ServiceReferenceRepartidor.RepartidorServicioClient repartidorWCF = new ServiceReferenceRepartidor.RepartidorServicioClient();
            var result = repartidorWCF.GetAll();

            if (result.Correct)
            {
                repartidor.Repartidores = result.Objects.ToList();
                repartidor.UnidadEntrega.Unidades = BL.Unidad.GetAllUnidadesAsignadas();
            }
            else
            {
                ViewBag.Mensaje = result.ErrorMessage;
            }

            return View(repartidor);
        }




        [HttpPost]
        public ActionResult GetAll(ML.Repartidor repartidor)
        {
            ServiceReferenceRepartidor.RepartidorServicioClient repartidorWCF = new ServiceReferenceRepartidor.RepartidorServicioClient();
            var result = repartidorWCF.GetAll();

            
            repartidor.Repartidores = result.Objects.ToList();

            return View(repartidor);
        }


        [HttpGet]
        public ActionResult Form(int? IdRepartidor)
        {
            ML.Repartidor repartidor = new ML.Repartidor();
            repartidor.UnidadEntrega = new ML.UnidadEntrega();

            
             if(IdRepartidor != 0) //update
            {
                ServiceReferenceRepartidor.RepartidorServicioClient repartidorWCF = new ServiceReferenceRepartidor.RepartidorServicioClient();
                var result = repartidorWCF.GetById(IdRepartidor.Value);

                if (result.Correct)
                {
                    repartidor = (ML.Repartidor)result.Object;
                    repartidor.UnidadEntrega.Unidades = BL.Unidad.GetAllUnidadesAsignadas();
                }
            }
            else //add
            {
                repartidor.UnidadEntrega.Unidades = BL.Unidad.GetAllUnidadesAsignadas();
            }
             return View(repartidor);
        }

        [HttpPost]
        public ActionResult Form(ML.Repartidor repartidor)
        {
            HttpPostedFileBase file = Request.Files["Imagen"];
            if (file.ContentLength > 0)
            {
                repartidor.Fotografia = ConvertirBase64(file);
            }

            if (repartidor.IdRepartidor != 0) //update
            {
                ServiceReferenceRepartidor.RepartidorServicioClient repartidorWCF = new ServiceReferenceRepartidor.RepartidorServicioClient();
                var result = repartidorWCF.Update(repartidor);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se actualizo correctamente";
                }
                else
                {
                    ViewBag.Error = result.ErrorMessage;
                }
            }
            else //add
            {
                ServiceReferenceRepartidor.RepartidorServicioClient repartidorWCF = new ServiceReferenceRepartidor.RepartidorServicioClient();
                var result = repartidorWCF.Add(repartidor);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se incerto correcto";
                }
                else
                {
                    ViewBag.Error = result.ErrorMessage;
                }
            }
            return PartialView("Modal");
        }

        [HttpDelete]
        public ActionResult Delete(int IdRepartidor)
        {
            ServiceReferenceRepartidor.RepartidorServicioClient repartidorWCF = new ServiceReferenceRepartidor.RepartidorServicioClient();
            var result = repartidorWCF.Delete(IdRepartidor);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Se elimino correctamente";
            }
            else
            {
                ViewBag.Error = result.ErrorMessage;
            }
            return PartialView("Modal");
        }

        public string ConvertirBase64(HttpPostedFileBase foto)
        {
            System.IO.BinaryReader reader = new System.IO.BinaryReader(foto.InputStream);
            byte[] data = reader.ReadBytes((int)foto.ContentLength);
            string imagen = Convert.ToBase64String(data);
            return imagen;
        }
    }
}