using Agronegocio.Models;
using Agronegocio.Repository.Context;

namespace Agronegocio.Repository
{
    public class SoloRepository
    {

        private readonly DataBaseContext dataBaseContext;

        public SoloRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public IList<SoloModel> Listar()
        {
            var lista = new List<SoloModel>();
            lista = dataBaseContext.Solo.ToList<SoloModel>();
            return lista;
        }

        public SoloModel Consultar(int id)
        {
            var solo = dataBaseContext.Solo.Find(id);
            return solo;
        }

        public void Inserir(SoloModel solo)
        {
            dataBaseContext.Solo.Add(solo);
            dataBaseContext.SaveChanges();
        }

        public void Alterar(SoloModel solo)
        {
            dataBaseContext.Solo.Update(solo);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var solo = new SoloModel { SoloId = id };

            dataBaseContext.Solo.Remove(solo);
            dataBaseContext.SaveChanges();
        }
    }
}
