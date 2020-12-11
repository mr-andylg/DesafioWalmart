using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.Models
{
    [BsonIgnoreExtraElements]
    public class Producto
    {
        [BsonId]
        public ObjectId ObjId { get; set; }
        [BsonElement("id")]
        public int Id { get; set; }
        [BsonElement("brand")]
        public string Brand { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("image")]
        public string Image { get; set; }
        [BsonElement("price")]
        public int Price { get; set; }
    }
}