using DesafioWalmart.Data;
using DesafioWalmart.Helper;
using DesafioWalmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesafioWalmart.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            ViewData["minCharToSearch"] = Parametros.MinCharToSearch();
            return View();
        }

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