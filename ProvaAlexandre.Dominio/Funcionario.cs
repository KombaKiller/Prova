using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAlexandre.Dominio
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "O {0} deve ter no minimo {2} caracteres e no maximo {1}.", MinimumLength = 3)]
        public string Nome { get; set; }

        [Required]
        public int Idade { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "O {0} deve ter no minimo {2} caracteres e no maximo {1}.", MinimumLength = 2)]
        public string Funcao { get; set; }
    }
} ;
