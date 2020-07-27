using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Site01.Models
{
    public class Usuario
    {

        [Required(ErrorMessage = "O campo 'E-mail' é obrigatorio!")]
        [EmailAddress(ErrorMessage = "O campo 'E-mail' está Inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' é obrigatorio!")]
        public string Senha { get; set; }


    }
}
