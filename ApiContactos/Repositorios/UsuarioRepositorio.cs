using System;
using System.Data.Entity;
using System.Linq;
using System.Web.DynamicData;
using ApiContactos.Adapters;
using ApiContactos.Models;
using ContactosModel.Model;
using RepositorioAdapter.Repositorio;

namespace ApiContactos.Repositorios
{
    public class UsuarioRepositorio : BaseRepositorioEntity<Usuario, UsuarioModel, UsuarioAdapter>
    {
        public UsuarioRepositorio(DbContext context) : base(context)
        { //Necesita implementar el constructor para que le pase el context. No hace falta implementar nada aqui dentro.
        }

        public UsuarioModel Validar(string login, string password)
        {
            var data = Get(o => o.login == login && o.password == password);
            if (data.Any()) return data.First();
            return null;
        }

        public bool isUnico(string login) //para saber si ya existe un usuario con ese login (antes de crearlo).
        {
            var data = Get(o => o.login == login);
            return !data.Any();
        }

        public override UsuarioModel Add(UsuarioModel model)
        {
            if (isUnico(model.login)) return base.Add(model);
            return null;
        }
    }
}