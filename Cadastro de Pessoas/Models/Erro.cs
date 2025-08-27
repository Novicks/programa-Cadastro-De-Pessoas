using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_de_Pessoas.Models
{
    internal class Erro
    {
        private static String msg;
        private static bool erro;
        public static void setMsg(String msg_)
        {
            msg = msg_;
            erro = true;
        }
        public static void setErro(bool erro_)
        {
            erro = erro_;
        }
        public static String getMsg() { return msg; }
        public static bool getErro() { return erro; }
    }
}
