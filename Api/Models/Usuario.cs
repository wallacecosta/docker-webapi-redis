using System.Text.Json;

namespace Api.Models;

public class Usuario
{    
    public string Id { get; private set; }
    public string Nome { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public string Cpf { get; private set; }

    public Usuario(string nome, DateTime dataNascimento, string cpf)
    {
        Id = $"usuario:{Guid.NewGuid().ToString()}";
        Nome = nome;
        DataNascimento = dataNascimento;
        Cpf = cpf;
    }
    
}
