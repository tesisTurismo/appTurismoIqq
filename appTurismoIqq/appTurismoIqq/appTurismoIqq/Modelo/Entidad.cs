using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace appTurismoIqq.Modelo
{
    public class Entidad
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        [BsonElement ("foto")]
        public string foto { get; set; }
        [BsonElement("nombre")]
        public string nombre { get; set; }
        [BsonElement("pagWeb")]
        public string pagWeb { get; set; }
        [BsonElement("descripcion")]
        public string descripcion { get; set; }
        [BsonElement("descripcionEng")]
        public string descripcionEng { get; set; }
        [BsonElement("telefono")]
        public string telefono { get; set; }
        [BsonElement("direccion")]
        public string direccion { get; set; }
        [BsonElement("latitud")]
        public double latitud { get; set; }
        [BsonElement("longitud")]
        public double longitud { get; set; }
        [BsonElement("categoria")]
        public string categoria { get; set; }
    }
}
