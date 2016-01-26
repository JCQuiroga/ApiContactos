using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApiContactos.Repositorios;
using ContactosModel.Model;
using Microsoft.Practices.Unity;

namespace ApiContactos.Controllers
{
    public class MensajeController : ApiController
    {
        [Dependency]
        public MensajeRepositorio MensajeRepositorio { get; set; }

        public ICollection<MensajeModel> Get(int id)
        {
            return MensajeRepositorio.GetByDestino(id);
        }

        //añadimos este booleano para evitar cambiar el routing. Asi, cuando queramos variar el metodo , simplemente añadimnos un "enviado=true".
        public ICollection<MensajeModel> Get(int id, bool enviado)
        {
            return MensajeRepositorio.GetByOrigen(id);
        }

        [ResponseType(typeof(UsuarioModel))]
        public IHttpActionResult Post(MensajeModel model)
        {
            var data = MensajeRepositorio.Add(model);
            if (data == null) return BadRequest();
            return Ok(data);
        }

        [ResponseType(typeof(bool))]
        public IHttpActionResult Put(MensajeModel model)
        {
            var data = MensajeRepositorio.Update(model);
            if (data < 1) return BadRequest();
            return Ok();
        }
    }
}
