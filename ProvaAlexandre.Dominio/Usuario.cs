using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Framework;

namespace ProvaAlexandre.Dominio
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        [Required]
        public string UsuarioNome { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
