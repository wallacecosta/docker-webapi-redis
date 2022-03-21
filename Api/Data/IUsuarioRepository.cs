using Api.Models;

namespace Api.Data; 

public interface IUsuarioRepository 
{
   void Create(Usuario usuario);
   Usuario? GetById(string id);

   IEnumerable<Usuario?>? GetAll();
   Usuario? Update(Usuario usuario);
   bool Delete(string id);
   
}