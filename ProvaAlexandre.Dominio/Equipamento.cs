using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAlexandre.Dominio
{
    public class Equipamento
    {
        public int Equipamento_id { get; set; }
        [Required]
        public int Cliente_id { get; set; }
        [Required]
        public int Funcionario_id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Marca { get; set; }
        [Required]
        [MaxLength(50)]
        public string Modelo { get; set; }
        [Required]
        [MaxLength(50)]
        public string NSerie { get; set; }
    }
}
