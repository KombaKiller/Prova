﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAlexandre.Dominio
{
    public class Usuario
    {
        public int UsuarioId { get; set; }


        [Required(ErrorMessage = "Preencha o campo Nome")]
        [StringLength(50, ErrorMessage = "O {0} deve ter no minimo {2} caracteres e no maximo {1}.", MinimumLength = 5)]
        public string UsuarioNome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Senha")]
        [StringLength(50, ErrorMessage = "O {0} deve ter no minimo {2} caracteres e no maximo {1}.", MinimumLength = 4)]
        public string Senha { get; set; }
    }
}
