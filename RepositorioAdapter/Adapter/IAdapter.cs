using System.Collections.Generic;

namespace RepositorioAdapter.Adapter
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">Objeto de entidad de la base de datos</typeparam>
    /// <typeparam name="TModel">Objeto de transferencia, es lo que mando al movil</typeparam>
    public interface IAdapter<TEntity, TModel>
    {
        TEntity FromViewModel(TModel model);
        TModel FromModel(TEntity model);

        ICollection<TEntity> FromViewModel(ICollection<TModel> model);
        ICollection<TModel> FromModel(ICollection<TEntity> model);

    }
}