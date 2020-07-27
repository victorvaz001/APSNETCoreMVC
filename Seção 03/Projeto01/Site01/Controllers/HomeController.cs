using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Site01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site01.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            //return new ContentResult() { Content = "Olá Mundo!", ContentType = "txt/plain" };

            return View(); //da classe Controller
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([FromForm] Usuario usuario)
        {
            if (ModelState.IsValid)
            {

                if (usuario.Email == "victorvaz001@gmail.com" && usuario.Senha == "123456")
                {
                    /*
                    * Add Session
                    * HttpContext.Session.SetString("Login", "true");
                    * HttpContext.Session.SetInt32("UserID", 32);
                    * HttpContext.Session.SetString("Login", Serializar Object > String

                    * Ler Session
                    * String login = HttpContext.Session.GetString("Login");
                   */

                    HttpContext.Session.SetString("Login", "true");
                    HttpContext.Session.SetInt32("UserID", 32);

                    return RedirectToAction("index", "Palavra");
                }
                else
                {
                    ViewBag.Messagem = "Usuário ou senha inválidos!";
                    return View();
                }

            }

            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear(); //Limpando todas as sesões do usuario no servidor, somente um usuário

            return RedirectToAction("Index", "Home");
        }
    }
}
