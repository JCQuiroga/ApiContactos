using ApiContactos.Models;
using ContactosModel.Model;
using RepositorioAdapter.Adapter;

namespace ApiContactos.Adapters
{
    public class UsuarioAdapter : BaseAdapter<Usuario, UsuarioModel>
    {
        public override Usuario FromViewModel(UsuarioModel model)
        {
            return new Usuario()
            {
                id = model.id,
                foto = model.foto,
                login = model.login,
                apellidos = model.apellidos,
                nombre = model.nombre,
                password = model.password
            };
        }

        public override UsuarioModel FromModel(Usuario model)
        {
            return new UsuarioModel()
            {
                id = model.id,
                foto = model.foto,
                login = model.login,
                apellidos = model.apellidos,
                nombre = model.nombre,
                password = model.password


            };
        }
    }
}