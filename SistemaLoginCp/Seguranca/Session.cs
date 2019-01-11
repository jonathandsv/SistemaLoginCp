using SistemaLoginCp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaLoginCp.Seguranca
{
    public class Session
    {
        private static string Name = "Session";
        public Session(UsuarioLogado usuario) => HttpContext.Current.Session[Name] = usuario;

        public static UsuarioLogado UsuarioLogado
        {
            get
            {
                if (HttpContext.Current == null) return null;

                var session = HttpContext.Current.Session[Name];
                return session as UsuarioLogado;
            }
            set { HttpContext.Current.Session[Name] = value; }
        }

        public static void Sair()
        {
            HttpContext.Current.Session.Remove(Name);
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.Clear();
        }
    }
}