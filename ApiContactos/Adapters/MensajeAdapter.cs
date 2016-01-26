using ApiContactos.Models;
using ContactosModel.Model;
using RepositorioAdapter.Adapter;

namespace ApiContactos.Adapters
{
    public class MensajeAdapter : BaseAdapter<Mensaje, MensajeModel>
    {
        public override Mensaje FromViewModel(MensajeModel model)
        {
            return new Mensaje()
            {
                id = model.id,
                idDestino = model.idDestino,
                idOrigen = model.idOrigen,
                asunto = model.asunto,
                fecha = model.fecha,
                leido = model.leido,
                contenido = model.contenido
            };
        }

        public override MensajeModel FromModel(Mensaje model)
        {
            return new MensajeModel()
            {
                id = model.id,
                idDestino = model.idDestino,
                idOrigen = model.idOrigen,
                asunto = model.asunto,
                fecha = model.fecha,
                leido = model.leido,
                contenido = model.contenido
            };
        }
    }
}