using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApiContactos.Utils;
using ContactosModel.Model;

namespace ApiContactos.Controllers
{
    public class CameraController : ApiController
    {
        [ResponseType(typeof(string))]
        public IHttpActionResult Post(FotosModel model)
        {
            var cuenta = ConfigurationManager.AppSettings["cuenta"];
            var clave = ConfigurationManager.AppSettings["clave"];
            var contenedor = ConfigurationManager.AppSettings["contenedor"];

            var sto = new AzureStorageUtils(cuenta, clave, contenedor);
            var nombre = Guid.NewGuid() + ".jpg";

            sto.SubirFichero(Convert.FromBase64String(model.Data), nombre);

            return Ok("nombre");
        }
    }
}
