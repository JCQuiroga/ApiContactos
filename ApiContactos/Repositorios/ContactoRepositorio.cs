using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using ApiContactos.Adapters;
using ApiContactos.Models;
using ContactosModel.Model;
using RepositorioAdapter.Repositorio;

namespace ApiContactos.Repositorios
{
    public class ContactoRepositorio : BaseRepositorioEntity<Usuario, ContactoModel, ContactoAdapter>
    {
        public ContactoRepositorio(DbContext context) : base(context)
        {
        }

        public ICollection<ContactoModel> GetByOrigen(int id)
        {
            var data = DbSet.Find(id).Amigo;
            var ret = new List<ContactoModel>();
            foreach (var usuario in data)
            {
                ret.Add(new ContactoModel()
                {
                    idOrigen = id,
                    idDestino = usuario.id,
                    nombreCompleto = $"{usuario.nombre} {usuario.apellidos}"
                });
            }
            return ret;
        }

        public ICollection<ContactoModel> GetNoContactosByOrigen(int id)
        {
            var data = DbSet.Find(id).Amigo.Select(o=>o.id);
            var nocont = DbSet.Where(o=>!data.Contains(o.id));
            var ret = new List<ContactoModel>();
            foreach (var usuario in nocont)
            {
                ret.Add(new ContactoModel()
                {
                    idOrigen = id,
                    idDestino = usuario.id,
                    nombreCompleto = $"{usuario.nombre} {usuario.apellidos}"
                });
            }
            return ret;
        }

        public override ContactoModel Add(ContactoModel model)
        {
            var yo = DbSet.Find(model.idOrigen);
            var tu = DbSet.Find(model.idDestino);
            yo.Amigo.Add(tu);
            try
            {
                Context.SaveChanges();
                return model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public override int Delete(ContactoModel model)
        {

            var yo = DbSet.Find(model.idOrigen);
            var tu = DbSet.Find(model.idDestino);
            yo.Amigo.Remove(tu);
            try
            {
                return Context.SaveChanges();
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}