using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioWalmart.Helper
{
    public static class Utiles
    {
        public static bool EsPalindromo(string palabra)
        {
            
            if (palabra == null || palabra.Length == 0)
            {
                return false;
            }

            int largo = palabra.Length;
            int verificacionesRestantes = largo;
           
            for (int i = 0; i < largo; i++)
            {
                if (palabra[i] != palabra[largo-(1 + i)])
                {
                    return false;
                }
                verificacionesRestantes -= 2;

                if (verificacionesRestantes <= 1)
                {
                    break;
                }

            }

            return true;
        }
    }
}