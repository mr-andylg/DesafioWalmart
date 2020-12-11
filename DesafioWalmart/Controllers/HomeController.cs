
using DataLayer.Data;
using DataLayer.Models;
using DesafioWalmart.Helper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesafioWalmart.Controllers
{
    public class HomeController : Controller
    {

        /// <summary>
        /// Carga nuestra web de inicio
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //cargamos el minimo de caracteres antes de empezar a buscar para ser usado en el js
            ViewData["minCharToSearch"] = Parametros.MinCharToSearch();
            return View();
        }

        /// <summary>
        /// Metodo para ser invocado por ajax
        /// Lista los productos segun la consulta. Valida que se cumplan los largos minimos.
        /// En caso de error devuelve un json con un mensaje.
        /// </summary>
        /// <param name="busqueda"></param>
        /// <returns></returns>
        public ActionResult ListarProductos(string busqueda)
        {
            try
            {
                int minCharToSearch = Parametros.MinCharToSearch();
                string msgErrorGenerico = "Busque un ID numérico o un texto de " + minCharToSearch + " o más caracteres";
                if (string.IsNullOrEmpty(busqueda))
                {
                    return Json(new { Result = false, Cod = 1, Msg = msgErrorGenerico });
                }
                busqueda = busqueda.Trim().ToLower();

                float auxNum;
                bool esNumero = float.TryParse(busqueda, out auxNum);
                

                if (!esNumero && busqueda.Length < minCharToSearch)
                {
                    return Json(new { Result = false, Cod = 1, Msg = msgErrorGenerico });
                }

                ProductosData pd = new ProductosData();
                List<Producto> listaProductos = pd.BuscarProducto(busqueda);

                //Le enviamos datos a la vista para tomar decisiones en el dibujado
                ViewData["busqueda"] = busqueda;
                ViewData["listaProducto"] = listaProductos != null? listaProductos : new List<Producto>();
                ViewData["esPalindromo"] = Utiles.EsPalindromo(busqueda);
                

                return View("Ajax/ListarProductos");
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, Cod = 2, Msg = "Error en la busqueda.\n" + ex.Message });
            }                        
        }
    }
}