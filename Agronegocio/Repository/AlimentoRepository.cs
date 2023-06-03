using Agronegocio.Models;
using Agronegocio.Repository.Context;
using System.Linq;

namespace Agronegocio.Repository
{
    public class AlimentoRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public AlimentoRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public IList<AlimentoModel> Listar()
        {
            var lista = new List<AlimentoModel>();
            lista = dataBaseContext.Alimento.ToList<AlimentoModel>();
            return lista;
        }

        public AlimentoModel Consultar(int id)
        {
            var alimento = dataBaseContext.Alimento.Find(id);
            return alimento;
        }

        public void Inserir(AlimentoModel alimento)
        {
            dataBaseContext.Alimento.Add(alimento);
            dataBaseContext.SaveChanges();
        }

        public void Alterar(AlimentoModel alimento)
        {
            dataBaseContext.Alimento.Update(alimento);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var alimento = new AlimentoModel { AlimentoId = id };

            dataBaseContext.Alimento.Remove(alimento);
            dataBaseContext.SaveChanges();
        }
    }
}
