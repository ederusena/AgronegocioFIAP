using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Agronegocio.Models
{
    public class PlanoModel
    {
        [HiddenInput]
        [Key]
        [Column("id_plano")]
        public int PlanoId { get; set; }

        [Column("dt_plano")]
        public DateTime DataPlano { get; set; }

        [Column("ds_plano")]
        public string DescricaoPlano { get; set; }

        [Column("tp_plano")]
        public string TipoPlano { get; set; }

        [Column("id_fazenda")]
        public int FazendaId { get; set; }

        public FazendaModel? Fazenda { get; set; }

    }
}
