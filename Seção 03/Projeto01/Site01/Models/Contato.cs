using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Site01.Models
{
    public class Contato
    {
        //Data anatation
        [Required(ErrorMessage = "O campo 'Nome' é obrigatorio")]
        [MaxLength(50, ErrorMessage = "O campo 'Nome' deve conter o máximo de 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo 'E-mail' é obrigatorio")]
        [MaxLength(70, ErrorMessage = "O campo 'E-mail' deve conter o máximo de 70 caracteres")]
        [EmailAddress(ErrorMessage = "O campo 'E-mail' é inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo 'Assunto' é obrigatorio")]
        [MaxLength(70, ErrorMessage = "O campo 'Assunto' deve conter o máximo de 70 caracteres")]
        public string Assunto { get; set; }

        [Required(ErrorMessage = "O campo 'Mensagem' é obrigatorio")]
        [MaxLength(2000, ErrorMessage = "O campo 'Nome' deve conter o máximo de 2000 caracteres")]
        public string Mensagem { get; set; }
    }
}
