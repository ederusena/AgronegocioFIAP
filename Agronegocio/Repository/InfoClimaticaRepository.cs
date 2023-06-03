using Agronegocio.Models;
using Agronegocio.Repository.Context;

namespace Agronegocio.Repository
{
    public class InfoClimaticaRepository
    {

        private readonly DataBaseContext dataBaseContext;

        public InfoClimaticaRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public IList<InfoClimaticaModel> Listar()
        {
            var lista = new List<InfoClimaticaModel>();
            lista = dataBaseContext.InfoClimatica.ToList<InfoClimaticaModel>();
            return lista;
        }

        public InfoClimaticaModel Consultar(int id)
        {
            var infoClimatica = dataBaseContext.InfoClimatica.Find(id);
            return infoClimatica;
        }

        public void Inserir(InfoClimaticaModel infoClimatica)
        {
            dataBaseContext.InfoClimatica.Add(infoClimatica);
            dataBaseContext.SaveChanges();
        }

        public void Alterar(InfoClimaticaModel infoClimatica)
        {
            dataBaseContext.InfoClimatica.Update(infoClimatica);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var infoClimatica = new InfoClimaticaModel { InfoClimaticaId = id };

            dataBaseContext.InfoClimatica.Remove(infoClimatica);
            dataBaseContext.SaveChanges();
        }
    

    }
}
