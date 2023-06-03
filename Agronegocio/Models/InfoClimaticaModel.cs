using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Agronegocio.Models
{
    public class InfoClimaticaModel
    {
        [HiddenInput]
        [Key]
        [Column("id_climatico")]
        public int InfoClimaticaId { get; set; }

        [Column("temperatura")]
        public int Temperatura { get; set; }

        [Column("umidade")]
        public int Umidade { get; set; }

        [Column("intensidade_vento")]
        public int IntensideVento { get; set; }

        [Column("dt_ultimo_registro")]
        public DateTime DataUltimoRegistro { get; set; }

        [Column("id_fazenda")]
        
        public int FazendaId { get; set; }

        public FazendaModel Fazenda { get; set; }

    }
}
