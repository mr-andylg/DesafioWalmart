using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer
{
    public static class MongoDBConnect
    {
        private static MongoClient cliente = null;

        
        /// <summary>
        /// Inicializa el cliente mongo y su conexion a la bd usando el string de conexion proporcionado
        /// </summary>
        /// <param name="connectionString">El string de conexion</param>
        public static void IniciarConexion(string connectionString)
        {
            if (MongoDBConnect.cliente == null)
            {
                //leer del webconfig
                MongoDBConnect.cliente = new MongoClient(connectionString);
                cliente.StartSession();
            }            
        }

        /// <summary>
        /// Retorna directamente el cliente. Debe ser inicializado primero
        /// </summary>
        public static MongoClient Cliente
        {
            get
            {
                return MongoDBConnect.cliente;
            }
        }

        /// <summary>
        /// Obtiene la colleccion consultada en el cliente previamente inicializado
        /// </summary>
        /// <param name="database">Nombre de la collection</param>
        /// <returns>Un IMongoDatabase para realizar las consultas necesarias</returns>
        public static IMongoDatabase GetDatabase(string database)
        {            
            {
                return MongoDBConnect.Cliente.GetDatabase(database);
            }
        }
    }
}