using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agronegocio.Models
{
    [Table("FAZENDA")]
    public class FazendaModel
    {

        [HiddenInput]
        [Key]
        [Column("id_fazenda")]
        public int FazendaId { get; set; }  

        [Column("nm_fazenda")]
        public string FazendaName { get; set; }
        
        [Column("tamanho_metros_2")]
        public int Area { get; set; }

        [Column("localizacao")]
        public string Localizacao { get; set; }

        [Column("id_usuario")]
        public int UsuarioId { get; set; }

        [Column("id_climatico")]
        public int InfoClimaticaId { get; set; }

        public UsuarioModel? Usuario { get; set; }
        public InfoClimaticaModel? InfoClimatica { get; set; }

    }
}
