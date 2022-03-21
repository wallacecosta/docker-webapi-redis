using System.Text.Json;
using Api.Models;
using StackExchange.Redis;

namespace Api.Data;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly IConnectionMultiplexer _redis;

    public UsuarioRepository(IConnectionMultiplexer redis)
    {
        _redis = redis;
    }

    public void Create(Usuario usuario)
    {
        if (usuario == null) throw new NotImplementedException();

        var db = _redis.GetDatabase();
        db.HashSet($"Usuarios", new HashEntry[]{new HashEntry(usuario.Id, JsonSerializer.Serialize(usuario))});
    }

    public Usuario? GetById(string id)
    {        
        var db = _redis.GetDatabase();
        var usuarioDB = db.HashGet("Usuarios", id);

        return string.IsNullOrEmpty(usuarioDB) ? null : JsonSerializer.Deserialize<Usuario>(usuarioDB);
    }

    public IEnumerable<Usuario?>? GetAll()
    {
        var db = _redis.GetDatabase();
        var usuarioList = db.HashGetAll("Usuarios");
        
        return usuarioList.Any() 
                ? Array.ConvertAll(usuarioList, usuario => JsonSerializer.Deserialize<Usuario>(usuario.Value)).ToList()
                : null;
    }

    public Usuario? Update(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public bool Delete(string id)
    {
        throw new NotImplementedException();
    }
    
}