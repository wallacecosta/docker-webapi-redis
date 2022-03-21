using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    [HttpPost]
    public ActionResult <Usuario> Create(Usuario usuario)
    {
        _usuarioRepository.Create(usuario);

        return CreatedAtRoute(nameof(GetById), new {Id = usuario.Id}, usuario);
    }

    [HttpGet("{id}", Name="GetById")]
    public ActionResult<IEnumerable<Usuario>> GetById(string id)
    {
        var usuario = _usuarioRepository.GetById(id);

        if (usuario != null) return Ok(usuario);

        return NotFound();

    }

    [HttpGet]
    public ActionResult<IEnumerable<Usuario>> GetAll()
    {
        var usuarioList = _usuarioRepository.GetAll();

        return Ok(usuarioList);
    }

}
