using DesafioWalmart.DB;
using DesafioWalmart.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Web;

namespace DesafioWalmart.Data
{
    
public class ProductosData
    {

        private IMongoDatabase db;
        private const string COLLECTION_PRODUCTOS = "products";

        public ProductosData()
        {
            db = MongoDBConnect.GetDatabase(System.Web.Configuration.WebConfigurationManager.AppSettings["MongoDB_DBProductos"]);
        }

        public List<Producto> BuscarProducto(string busqueda)
        {
            List<Producto> listaResultado = null;

            try
            {
                busqueda = busqueda.ToLower();

                int busquedaAsInt;
                if (!int.TryParse(busqueda, out busquedaAsInt))
                {
                    busquedaAsInt = int.MinValue;
                }

                IMongoCollection<Producto> collection = this.db.GetCollection<Producto>(COLLECTION_PRODUCTOS);


                FilterDefinition<Producto> filterDefinition =
                    Builders<Producto>.Filter.Where(obj => obj.Brand.ToLower().Contains(busqueda) || obj.Description.ToLower().Contains(busqueda)
                        || obj.Id == busquedaAsInt);


                listaResultado = collection.FindSync(filterDefinition).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obter datos");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            
            return listaResultado;
        }
    }
}