using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaLoginCp.Seguranca
{
    public class Authorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (Session.UsuarioLogado == null)
                return false;

            return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            string url = filterContext.HttpContext.Request.Url.Scheme + "://" + filterContext.HttpContext.Request.Url.Authority + filterContext.HttpContext.Request.ApplicationPath + "/Login/NaoAutenticado";
            filterContext.HttpContext.Response.BufferOutput = true;
            filterContext.Result = new RedirectResult(url);
        }
    }
}