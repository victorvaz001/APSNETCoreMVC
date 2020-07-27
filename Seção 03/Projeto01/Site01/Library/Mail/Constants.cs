using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site01.Library.Mail
{
    public class Constants
    {
        /**
         * POP3, IMAP - Permite ler mensagem de e-mail
         * SMTP - Enviar E-mail
        */


        //Autenticação
        public readonly static string Usuario = "victorvaz001@gmail.com";
        public readonly static string Senha = "438796125657";



        //Servidor SMTP
        public readonly static string ServidorSMTP = "smtp.gmail.com";
        public readonly static int PortaSMTP = 587;
    }
}
