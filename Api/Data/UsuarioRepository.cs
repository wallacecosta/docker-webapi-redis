using System.Text;
using System.Text.Json;
using Api.Models;
using Microsoft.Extensions.Caching.Distributed;

namespace Api.Data;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly IDistributedCache _redis;

    public UsuarioRepository(IDistributedCache redis)
    {
        _redis = redis;
    }

    public void Create(Usuario usuario)
    {
        if (usuario == null) throw new NotImplementedException();

        var usuarioJson = JsonSerializer.Serialize<Usuario>(usuario);
        var usuarioByte = Encoding.UTF8.GetBytes(usuarioJson);
        var options = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(1));

        _redis.Set(usuario.Cpf, usuarioByte, options);
    }

    public Usuario? GetByCpf(string cpf)
    {        
        var usuarioByte = _redis.Get(cpf);

        if (usuarioByte is null) return null;

        var usuario = JsonSerializer.Deserialize<Usuario>(usuarioByte);

        return  usuario;
    }

    public void Delete(string cpf)
        => _redis.Remove(cpf);
    
}