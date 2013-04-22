using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Framework;

namespace ProvaAlexandre.Dominio
{
    public class Cliente
    {
        public int Cliente_id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Idade { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public String Telefone { get; set; }
    }
}
