namespace Api.Models;

public class Usuario
{    
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public string Cpf { get; private set; }

    public Usuario(string nome, DateTime dataNascimento, string cpf)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        DataNascimento = dataNascimento;
        Cpf = cpf;
    }
}
