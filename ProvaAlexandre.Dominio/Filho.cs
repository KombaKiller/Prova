using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAlexandre.Dominio
{
    public class Filho
    {
        public int FilhoId { get; set; }
        [Required]
        public int MaeId { get; set; }
        [Required]
        public int FuncionarioId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(30)]
        public string Sexo { get; set; }
    }
}
