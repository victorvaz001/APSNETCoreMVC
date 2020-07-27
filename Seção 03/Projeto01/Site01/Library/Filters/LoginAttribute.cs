using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site01.Library.Filters
{
    public class LoginAttribute : ActionFilterAttribute
    {
        //tratando a requisição antes de ir pra o controlador
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            if (context.HttpContext.Session.GetString("Login") == null)
            {
                if (context.Controller != null)
                {
                    Controller controllador = context.Controller as Controller;
                    controllador.TempData["MensagemErro"] = "Faço o login para ter permissão de entrar nessa página!";

                }


                context.Result = new RedirectToActionResult("Login", "Home", null);
            }

        }
    }
}
