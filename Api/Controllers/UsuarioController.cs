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
    public IActionResult Create(Usuario usuario)
    {
        _usuarioRepository.Create(usuario);

        return CreatedAtRoute(nameof(GetByCpf), new {Cpf = usuario.Cpf}, usuario);
    }

    [HttpGet("{cpf}", Name="GetByCpf")]
    public IActionResult GetByCpf(string cpf)
    {
        var usuario = _usuarioRepository.GetByCpf(cpf);

        if (usuario != null) return Ok(usuario);

        return NotFound();

    }

    [HttpDelete("{cpf}", Name = "DeleteCpf" )]
    public IActionResult DeleteCpf(string cpf)
    {
        _usuarioRepository.Delete(cpf);

        return NoContent();
    }
}
