using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agronegocio.Models
{
    [Table("ALIMENTO")]
    public class AlimentoModel
    {
        [HiddenInput]
        [Key]
        [Column("id_alimento")]
        public int AlimentoId { get; set; }

        [Column("nm_alimento")]
        public string AlimentoName { get; set; }

        [Column("tp_alimento")]
        public string TipoAlimento { get; set; }

        [Column("tp_plantio")]
        public string TipoPlantio { get; set; }

        [Column("id_fazenda")]
        public int FazendaId { get; set; }

        public FazendaModel? Fazenda { get; set; }
    }
}
