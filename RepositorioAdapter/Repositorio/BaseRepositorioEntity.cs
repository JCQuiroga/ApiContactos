using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using RepositorioAdapter.Adapter;

namespace RepositorioAdapter.Repositorio
{
    public class BaseRepositorioEntity<TEntity, TModel, TAdapter> : IRepositorio<TEntity, TModel, TAdapter>
        where TAdapter : IAdapter<TEntity, TModel>, new() where TEntity : class where TModel : class
    {
        protected DbContext Context;


        //        protected DbSet<TEntity> DbSet => Context.Set<TEntity>(); // Expresion lambda que equivale al DBSet de abajo.

        protected DbSet<TEntity> DbSet
        {
            get { return Context.Set<TEntity>(); }
        }

        private TAdapter _adapter;

        public TAdapter Adapter
        {
            get
            {
                if (_adapter == null) _adapter = new TAdapter();
                return _adapter;
            }
        }

        public BaseRepositorioEntity(DbContext context)
        {
            Context = context;
        } 

        public virtual TModel Add(TModel model)
        {
            var guardado = Adapter.FromViewModel(model);
            DbSet.Add(guardado);
            try
            {
                Context.SaveChanges();
                return Adapter.FromModel(guardado);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual int Delete(TModel model)
        {
            var guardar = Adapter.FromViewModel(model);
            Context.Entry(guardar).State = EntityState.Deleted;
            try
            {
                return Context.SaveChanges();
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public virtual int Delete(params object[] keys)
        {
            var data = DbSet.Find(keys);
            DbSet.Remove(data);
            try
            {
                return Context.SaveChanges();
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public virtual int Delete(Expression<Func<TEntity, bool>> consulta)
        {
            var guardar = DbSet.Where(consulta);
            DbSet.RemoveRange(guardar);
            try
            {
                return Context.SaveChanges();
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public virtual int Update(TModel model)
        {
            var guardar = Adapter.FromViewModel(model);
            Context.Entry(guardar).State = EntityState.Modified;
            try
            {
                return Context.SaveChanges();
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public virtual TModel Get(params object[] keys)
        {
            var data = DbSet.Find(keys);
            return Adapter.FromModel(data);
        }

        public virtual ICollection<TModel> Get(Expression<Func<TEntity, bool>> consulta)
        {
            var data = DbSet.Where(consulta);
            return Adapter.FromModel(data.ToList());
        }

        public virtual ICollection<TModel> Get()
        {
            return Adapter.FromModel(DbSet.ToList());
        }
    }
}