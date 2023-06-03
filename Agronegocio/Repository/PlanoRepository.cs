using Agronegocio.Models;
using Agronegocio.Repository.Context;
using System.Linq;
using System.Numerics;

namespace Agronegocio.Repository
{
    public class PlanoRepository
    {

        private readonly DataBaseContext dataBaseContext;

        public PlanoRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public IList<PlanoModel> Listar()
        {
            var lista = new List<PlanoModel>();
            lista = dataBaseContext.Plano.ToList<PlanoModel>();
            return lista;
        }

        public PlanoModel Consultar(int id)
        {
            var plano = dataBaseContext.Plano.Find(id);
            return plano;
        }

        public void Inserir(PlanoModel plano)
        {
            dataBaseContext.Plano.Add(plano);
            dataBaseContext.SaveChanges();
        }

        public void Alterar(PlanoModel plano)
        {
            dataBaseContext.Plano.Update(plano);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var plano = new PlanoModel { PlanoId = id };

            dataBaseContext.Plano.Remove(plano);
            dataBaseContext.SaveChanges();
        }
    }
}
