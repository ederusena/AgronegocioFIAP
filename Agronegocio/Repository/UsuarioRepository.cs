using Agronegocio.Models;
using Agronegocio.Repository.Context;

namespace Agronegocio.Repository
{
    public class UsuarioRepository
    {

        private readonly DataBaseContext dataBaseContext;

        public UsuarioRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public IList<UsuarioModel> Listar()
        {
            var lista = new List<UsuarioModel>();
            lista = dataBaseContext.Usuario.ToList<UsuarioModel>();
            return lista;
        }

        public UsuarioModel Consultar(int id)
        {
            var usuario = dataBaseContext.Usuario.Find(id);
            return usuario;
        }

        public void Inserir(UsuarioModel usuario)
        {
            dataBaseContext.Usuario.Add(usuario);
            dataBaseContext.SaveChanges();
        }

        public void Alterar(UsuarioModel usuario)
        {
            dataBaseContext.Usuario.Update(usuario);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var usuario = new UsuarioModel { UsuarioId = id };

            dataBaseContext.Usuario.Remove(usuario);
            dataBaseContext.SaveChanges();
        }
    }
}
