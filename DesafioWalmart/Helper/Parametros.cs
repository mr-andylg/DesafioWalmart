using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioWalmart.Helper
{
    public static class Parametros
    {
        /// <summary>
        /// Leemos desde el webconfig el parametro relacionado con el valor minimo de caracteres antes de iniciar una busqueda
        /// </summary>
        /// <returns></returns>
        public static int MinCharToSearch()
        {
            int minCharSearch;
            if (!int.TryParse(System.Web.Configuration.WebConfigurationManager.AppSettings["MinCharToSearch"], out minCharSearch))
            {
                minCharSearch = 4; //valor default
            }

            return minCharSearch;
        }
    }
}