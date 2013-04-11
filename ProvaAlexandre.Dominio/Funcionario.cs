using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Framework;

namespace ProvaAlexandre.Dominio
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Idade { get; set; }
    }
}
