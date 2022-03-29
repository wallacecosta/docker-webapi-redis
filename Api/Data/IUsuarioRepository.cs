using Api.Models;

namespace Api.Data; 

public interface IUsuarioRepository 
{
   void Create(Usuario usuario);
   Usuario? GetByCpf(string cpf);
   void Delete(string cpf);
   
}