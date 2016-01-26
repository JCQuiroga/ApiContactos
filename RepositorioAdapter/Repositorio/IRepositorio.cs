using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepositorioAdapter.Repositorio
{
    public interface IRepositorio<TEntity, TModel, TAdapter>
    {
        TModel Add(TModel model);

        int Delete(TModel model);
        int Delete(params object[] keys);
        int Delete(Expression<Func<TEntity,bool>> consulta);

        int Update(TModel model);

        TModel Get(params object[] keys);
        ICollection<TModel> Get(Expression<Func<TEntity, bool>> consulta);
        ICollection<TModel> Get();

    }
}