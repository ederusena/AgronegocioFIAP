using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Agronegocio.Models
{
    public class UsuarioModel
    {
        [HiddenInput]
        [Key]
        [Column("id_usuario")]
        public int UsuarioId { get; set; }

        [Column("nm_usuario")]
        public string UsuarioName { get; set; }

        [Column("email_usuario")]
        public string EmailUsuario { get; set; }

        [Column("senha_usuario")]
        public string SenhaUsuario { get; set; }

        [Column("idade_usuario")]
        public int IdadeUsuario { get; set; }

        [Column("tp_agricultor")]
        public int TipoAgricultor { get; set; }
    }
}
