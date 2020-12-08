using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioWalmart.Helper
{
    public static class Parametros
    {
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