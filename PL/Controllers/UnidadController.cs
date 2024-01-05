using BL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UnidadController : Controller
    {
        // GET: Unidad
        public ActionResult GetAll()
        {
            ML.UnidadEntrega unidad = new ML.UnidadEntrega();
            unidad.Unidades = new List<object>();

            using (var Client = new HttpClient())
            {
                Client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);

                var responseTask = Client.GetAsync("Unidad");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync< List<object> >();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result)
                    {
                        ML.UnidadEntrega unidadItem = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.UnidadEntrega>(resultItem.ToString());
                        unidad.Unidades.Add(unidadItem);
                    }

                }

            }
            return View(unidad);
        }

        [HttpPost]
        public ActionResult GetAll(ML.UnidadEntrega unidad)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);

                var responseTask = client.GetAsync($"Unidad");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.UnidadEntrega>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Unidades)
                    {
                        ML.UnidadEntrega unidadItem = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.UnidadEntrega>(resultItem.ToString());
                        unidad.Unidades.Add(unidadItem);
                    }

                }
            }
            return View(unidad);
        }

        [HttpGet]
        public ActionResult Form(int? IdUnidad)
        {
            ML.UnidadEntrega unidad = new ML.UnidadEntrega();
            unidad.IdUnidad = IdUnidad.Value;
            unidad.Estatus = new ML.EstatusUnidad();
            

            unidad.Unidades = new List<object>();

            if(IdUnidad != 0) //update
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);

                    var responseTask = client.GetAsync("Unidad?idUnidad=" + IdUnidad);
                    responseTask.Wait();

                    var resultService = responseTask.Result;

                    if (resultService.IsSuccessStatusCode)
                    {
                        var readTask = resultService.Content.ReadAsAsync<ML.UnidadEntrega>();
                        readTask.Wait();

                        ML.UnidadEntrega resultItem = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.UnidadEntrega>(readTask.Result.Unidades.ToString());
                        unidad = resultItem;
                    }
                    unidad.Estatus.EstatusObject = BL.EstatusUnidad.GetAllEstatusUnidad();
                }
            }
            else //Add
            {
                unidad.Estatus.EstatusObject = BL.EstatusUnidad.GetAllEstatusUnidad();
            }
            return View(unidad);
        }

        [HttpPost]
        public ActionResult Form(ML.UnidadEntrega unidad)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);

                if (unidad.IdUnidad == 0) //add
                {
                    var postTask = client.PostAsJsonAsync<ML.UnidadEntrega>("Unidad",unidad);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "Se incerto correctamente";
                    }
                    else
                    {
                        ViewBag.Error = "Error";
                    }
                }
                else //update 
                {
                    var putTask = client.PutAsJsonAsync<ML.UnidadEntrega>("Unidad?idUnidad="+unidad.IdUnidad, unidad);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "Se actualizo correctamente";
                    }
                    else
                    {
                        ViewBag.Error = "Error";
                    }
                }
            }
            return PartialView("Modal");
        }

        public ActionResult Delete(int IdUnidad)
        {
            ML.UnidadEntrega unidad = new ML.UnidadEntrega();
            unidad.IdUnidad = IdUnidad;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);

                var postTask = client.DeleteAsync("Unidad?idUnidad=" + IdUnidad);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Mensaje = "Se elimino correctamente";
                }
                else
                {
                    ViewBag.Error = "Error";
                }
            }
            return PartialView("Modal");
        }
    }
}