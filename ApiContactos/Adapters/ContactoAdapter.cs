using System.Data.Entity.Core.Mapping;
using ApiContactos.Models;
using ContactosModel.Model;
using RepositorioAdapter.Adapter;

namespace ApiContactos.Adapters
{
    public class ContactoAdapter : BaseAdapter<Usuario,ContactoModel>
    {
        public override Usuario FromViewModel(ContactoModel model)
        {
            //return new Usuario()
            //{
            //    id = model.idDestino
            //};
            return null;
        }

        public override ContactoModel FromModel(Usuario model)
        {
            return null;
        }
    }
}