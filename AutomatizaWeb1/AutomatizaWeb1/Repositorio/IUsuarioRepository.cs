using AutomatizaWeb1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatizaWeb1.Repositorio
{
    public interface IUsuarioRepository
    {
        void Add(Usuarios user);
        IEnumerable<Usuarios> GetAll();
        Usuarios Find(long id);
        void Remove(long id);
        void Update(Usuarios user);
    }
}
