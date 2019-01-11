using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaLoginCp.Data
{
    public class LoginBO
    {
        public bool Autenticar(string cpf, string senha)
        {
            try
            {
                var pessoa = new UsuarioBO().GetUsuario(cpf);
                if (pessoa.id == 0) return false;

                if (pessoa.Cpf == cpf && pessoa.Senha == senha)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}