using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomatizaWeb1.Models;

namespace AutomatizaWeb1.Repositorio
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioDBContext _contexto;

        public UsuarioRepository(UsuarioDBContext ctx)
        {
            _contexto = ctx;
        }
        public void Add(Usuarios usuario)
        {
           _contexto.Usuarios.Add(usuario);
            _contexto.SaveChanges();
        }

        public Usuarios Find(long id)
        {
           return _contexto.Usuarios.FirstOrDefault(u => u.UsuarioId == id);
        }

        public IEnumerable<Usuarios> GetAll()
        {
            return _contexto.Usuarios.ToList();
        }

        public void Remove(long id)
        {
           var entity = _contexto.Usuarios.First(p=> p.UsuarioId == id);
            _contexto.Usuarios.Remove(entity);
            _contexto.SaveChanges();
        }

        public void Update(Usuarios usuario)
        {
          _contexto.Usuarios.Update(usuario);
            _contexto.SaveChanges();
        }
    }
}
