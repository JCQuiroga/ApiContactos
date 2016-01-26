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
    public class UsuarioController : ApiController
    {
        [Dependency]
        public UsuarioRepositorio UsuarioRepositorio { get; set; }


        [ResponseType(typeof(UsuarioModel))]
        public IHttpActionResult GetValido(string login, string password)
        {
            var data = UsuarioRepositorio.Validar(login, password);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [ResponseType(typeof(bool))]
        public IHttpActionResult GetUnico(string login)
        {
            var data = UsuarioRepositorio.isUnico(login);
            return Ok(data);
        }

        [ResponseType(typeof(UsuarioModel))]
        public IHttpActionResult Post(UsuarioModel model)
        {
            var data = UsuarioRepositorio.Add(model);
            if (data == null) return BadRequest();
            return Ok(data);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, UsuarioModel model)
        {
            var d = UsuarioRepositorio.Get(id);
            if (d == null || d.id!=model.id) return NotFound();
            var data = UsuarioRepositorio.Update(model);
            if (data < 1) return BadRequest();
            return Ok();
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            var data = UsuarioRepositorio.Delete(id);
            if (data < 1) return BadRequest();
            return Ok();
        }


    }
}
