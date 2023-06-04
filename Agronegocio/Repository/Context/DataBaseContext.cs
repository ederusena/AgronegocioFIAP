using Microsoft.EntityFrameworkCore;
using Agronegocio.Models;
using System.Collections.Generic;

namespace Agronegocio.Repository.Context
{
    public class DataBaseContext : DbContext
    {

        public DbSet<InfoClimaticaModel> InfoClimatica { get; set; }
        public DbSet<AlimentoModel> Alimento { get; set; }
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<FazendaModel> Fazenda { get; set; }
        public DbSet<SoloModel> Solo { get; set; }
        public DbSet<PlanoModel> Plano { get; set; }


        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DataBaseContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FazendaModel>()
                .HasOne(f => f.InfoClimatica)
                .WithOne(i => i.Fazenda)
                .HasForeignKey<InfoClimaticaModel>(i => i.FazendaId);
        }
    }
}