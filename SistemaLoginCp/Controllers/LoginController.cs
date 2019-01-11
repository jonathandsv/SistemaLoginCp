using SistemaLoginCp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaLoginCp.Models;
using SistemaLoginCp.Seguranca;

namespace SistemaLoginCp.Controllers
{
    public class LoginController : Controller
    {
        //capturar ip
        private string _ip;

        public LoginController()
        {
            _ip = Request?.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? Request?.ServerVariables["REMOTE_ADDR"] ?? Request?.UserHostAddress;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //[CaptchaMvc.Attributes.CaptchaVerify("Captcha Inválido")]

        public ActionResult Logar(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var loginBO = new LoginBO();

                    if (loginBO.Autenticar(login.cpf, login.senha))
                    {
                        if (string.IsNullOrEmpty(_ip))
                            _ip = Request?.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? Request?.ServerVariables["REMOTE_ADDR"] ?? Request?.UserHostAddress;

                        //_ip = FormatIP(_ip); necessário implementar o método formatar o ip retirando as vígulas.

                        var usuario = new UsuarioLogado { Nome = "Usuario", Cpf = login.cpf };

                        new Session(usuario);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                        ViewData["Messagem"] = "Dados do candidato não conferem!";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View("Index", "Login");
        }

        public ActionResult NaoAutenticado()
        {
            return View();
        }
        
        public ActionResult Logout()
        {
            Seguranca.Session.Sair();
            return RedirectToAction("Index");
        }

    }
}