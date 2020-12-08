using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioWalmart.DB
{
    public static class MongoDBConnect
    {
        private static MongoClient cliente;

        public static MongoClient Cliente { get
            {
                if (MongoDBConnect.cliente == null)
                {
                    //leer del webconfig
                    MongoDBConnect.cliente = new MongoClient(System.Web.Configuration.WebConfigurationManager.AppSettings["MongoDB_Connect"]);
                    cliente.StartSession();
                }
                return MongoDBConnect.cliente;
            }
        }

        public static IMongoDatabase GetDatabase(string database)
        {            
            {
                return MongoDBConnect.Cliente.GetDatabase(database);
            }
        }
    }
}