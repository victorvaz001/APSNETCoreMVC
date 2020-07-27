using Site01.Library.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site01.Models
{
    public class Palavra
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' é obrigatorio")]
        [MaxLength(70, ErrorMessage = "O campo 'Nome' deve conter o máximo de 70 caracteres")]
        [UnicoNomePalavra]
        public string Nome { get; set; }


        //1-facil, 2-medio, 3-dificil
        public byte? Nivel { get; set; }
    }
}
