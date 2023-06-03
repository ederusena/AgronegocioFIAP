using Agronegocio.Models;
using Agronegocio.Repository.Context;
using System.Linq;

namespace Agronegocio.Repository
{
    public class FazendaRepository
    {

        private readonly DataBaseContext dataBaseContext;

        public FazendaRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public IList<FazendaModel> Listar()
        {
            var lista = new List<FazendaModel>();
            lista = dataBaseContext.Fazenda.ToList<FazendaModel>();
            return lista;
        }

        public FazendaModel Consultar(int id)
        {
            var fazenda = dataBaseContext.Fazenda.Find(id);
            return fazenda;
        }

        public void Inserir(FazendaModel fazenda)
        {
            dataBaseContext.Fazenda.Add(fazenda);
            dataBaseContext.SaveChanges();
        }

        public void Alterar(FazendaModel fazenda)
        {
            dataBaseContext.Fazenda.Update(fazenda);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var areaDeRisco = new FazendaModel { FazendaId = id };

            dataBaseContext.Fazenda.Remove(areaDeRisco);
            dataBaseContext.SaveChanges();
        }

    }
}
