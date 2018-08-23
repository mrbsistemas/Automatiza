using AutomatizaWeb1.Models;
using AutomatizaWeb1.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomatizaWeb1.Controllers
{
    [Route("api/[Controller]")]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepositorio;
        public UsuariosController(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepositorio = usuarioRepo;
        }

        [HttpGet]
        public IEnumerable<Usuarios> GetAll()
        {
            return _usuarioRepositorio.GetAll();
        }

        [HttpGet("{id}",Name ="GetUsuario")]
        public IActionResult GetById(long id)
        {
            var usuario = _usuarioRepositorio.Find(id);
            if (usuario == null)
                return NotFound();
            return new ObjectResult(usuario);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Usuarios usuario)
        {
            if (usuario == null)
                   return BadRequest();
            _usuarioRepositorio.Add(usuario);
            return CreatedAtRoute("GetUsuario", new { id = usuario.UsuarioId }, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Usuarios usuario)
        {
            if (usuario == null || usuario.UsuarioId != id)
                return BadRequest();
            var _usuario = _usuarioRepositorio.Find(id);

            if (usuario == null)
                return NotFound();

            _usuario.Email = usuario.Email;
            _usuario.Nome = usuario.Nome;
            _usuarioRepositorio.Update(_usuario);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (long id)
        {
            var usuario = _usuarioRepositorio.Find(id);
            if (usuario == null)
                return NotFound();
            _usuarioRepositorio.Remove(id);
            return new NoContentResult();
        }
    }
}
