using Site01.Database;
using Site01.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site01.Library.Validation
{
    public class UnicoNomePalavraAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Palavra palavra = validationContext.ObjectInstance as Palavra;

            var _db = (DatabaseContext)validationContext.GetService(typeof(DatabaseContext));

            //Já exste no banco de dados um registro:
            // Verificar se nome já existe
            //Verificar se o ID e o mesmo do registro no Banco

            var palavraBanco = _db.Palvras.Where(a=> a.Nome == palavra.Nome && a.Id != palavra.Id).FirstOrDefault();

            if (palavraBanco == null)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("A palavra " + palavra.Nome + " já está sendo utilizada");
            }
        }

    }
}
