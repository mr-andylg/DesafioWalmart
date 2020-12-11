using DataLayer.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Web;

namespace DataLayer.Data
{
    
public class ProductosData
    {

        private IMongoDatabase db;
        //el nombre de la collection a usar en este data
        private const string COLLECTION_PRODUCTOS = "products";

        /// <summary>
        /// Inicializacion del objeto data, iniciando la conexion a la bd y a la collecction que vamos a usar
        /// </summary>
        public ProductosData()
        {
            if (MongoDBConnect.Cliente == null)
            {
                MongoDBConnect.IniciarConexion(System.Configuration.ConfigurationManager.AppSettings["MongoDB_Connect"]);
            }
            db = MongoDBConnect.GetDatabase(System.Configuration.ConfigurationManager.AppSettings["MongoDB_DBProductos"]);
        }

        /// <summary>
        /// Busca uno o más productos segun el string de busqueda
        /// Si es un numero, intenta buscar exactamente el string. Si es texto, comienza a bucar con like en los campos Brand y Description
        /// </summary>
        /// <param name="busqueda"></param>
        /// <returns>Lista con los productos encontrados o null en caso de haber error</returns>
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