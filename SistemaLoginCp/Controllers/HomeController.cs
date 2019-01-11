using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaLoginCp.Controllers
{
    [Seguranca.Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult QualquerCoisa()
        {
            if (!SessaoAtiva()) throw new Exception("Sessão Expirada!");
            return (null);
        }

        public bool SessaoAtiva()
        {
            return Seguranca.Session.UsuarioLogado != null && !string.IsNullOrEmpty(Seguranca.Session.UsuarioLogado?.Cpf);
        }
    }
}