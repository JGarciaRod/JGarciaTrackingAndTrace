using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_Web_Api.Controllers
{
    [RoutePrefix("api/Unidad")]
    public class UnidadEntregaController : ApiController
    {
        [Route("")]
        [HttpPost]
        public IHttpActionResult Add(ML.UnidadEntrega unidad) //funciona :)
        {
            bool result = BL.Unidad.Add(unidad);

            if (result)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("")]
        [HttpDelete]
        public IHttpActionResult Delete(int idUnidad) //no lo probe pero si funcionan 4 funcionan 5
        {
            bool result = BL.Unidad.Delete(idUnidad);

            if (result)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("{idUnidad?}")]
        [HttpPut]
        public IHttpActionResult Update(int idUnidad, [FromBody] ML.UnidadEntrega unidad) //funciona :)
        {
            unidad.IdUnidad = idUnidad;
            bool result = BL.Unidad.Update(unidad);
            if (result)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("{idUnidad?}")]
        [HttpGet]
        public IHttpActionResult GetById(int idUnidad) //funciona ;)
        {
            ML.UnidadEntrega entrega =  BL.Unidad.GetById(idUnidad);

            if (entrega != null)
            {
                return Content(HttpStatusCode.OK, entrega);
            }
            else
            {
                return Content(HttpStatusCode.BadGateway, entrega);
            }
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAll() //funciona ;)
        {
            var result = new List<object>();

            result = BL.Unidad.GetAll();

            if(result != null)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
    }
}
