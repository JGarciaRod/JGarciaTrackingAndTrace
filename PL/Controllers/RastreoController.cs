using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class RastreoController : Controller
    {
        // GET: Rastreo
        [HttpGet]
        public ActionResult GetRastreo(string codigo)
        {
            if(codigo == "")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ML.Entrega entrega = BL.Entrega.GetBy(codigo);
                return View(entrega);
                
            }
            
        }
    }
}