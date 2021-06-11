using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Usuario_Practica.Utitlities
{
    public class Utils
    {
        public static string ErrorException(Exception ex)
        {
            string Mensaje = ex.Message.ToString();
            string Inner = ex.InnerException != null ? ex.InnerException.Message.ToString() : "";
            return Mensaje + " " + Inner;
        }
    }
}