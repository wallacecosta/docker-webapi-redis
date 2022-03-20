using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    public IEnumerable<Usuario> Get()
    {
        return Enumerable.Range(1, 1).Select(index 
            => new Usuario("Wallace Costa", new DateTime(1980, 10, 01), "12312312307"))
        .ToArray();
    }
}
