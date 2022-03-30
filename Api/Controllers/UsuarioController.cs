using System.Text;
using System.Text.Json;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IDistributedCache _cache;

    public UsuariosController(IDistributedCache cache)
    {
        _cache = cache;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Usuario usuario)
    {
        if (usuario == null) throw new NotImplementedException();

        var usuarioByte = Encoding.UTF8.GetBytes(JsonSerializer.Serialize<Usuario>(usuario));
        var options = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(1));

        await _cache.SetAsync(usuario.Cpf, usuarioByte, options);

        return CreatedAtAction(nameof(GetByCpf), new {Cpf = usuario.Cpf}, usuario);
    }

    [HttpGet("{cpf}", Name="GetByCpf")]
    public async Task<IActionResult> GetByCpf(string cpf)
    {
        var usuarioByte = await _cache.GetAsync(cpf);

        if (usuarioByte is null) return NotFound();

        return Ok(JsonSerializer.Deserialize<Usuario>(usuarioByte));

    }

    [HttpDelete("{cpf}", Name = "DeleteCpf" )]
    public async Task<IActionResult> DeleteCpf(string cpf)
    {
        await _cache.RemoveAsync(cpf);

        return NoContent();
    }
}
