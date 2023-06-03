using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Agronegocio.Models
{
    public class SoloModel
    {
        [HiddenInput]
        [Key]
        [Column("id_solo")]
        public int SoloId { get; set; }

        [Column("tp_solo")]
        public string TipoSolo { get; set; }

        [Column("ph_solo")]
        public int PhSolo { get; set; }

        [Column("umidade_solo")]
        public int UmidadeSolo { get; set; }

        [Column("id_fazenda")]
        public int FazendaId { get; set; }

        public FazendaModel? Fazenda { get; set; }
    }
}
