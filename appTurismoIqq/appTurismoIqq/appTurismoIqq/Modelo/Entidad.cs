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
        [BsonElement ("Foto de lugar")]
        public string foto { get; set; }
        [BsonElement("Nombre de lugar")]
        public string nombre { get; set; }
        [BsonElement("Pág. Web")]
        
        public string pagWeb { get; set; }
        public string descripcion { get; set; }
        public string descripcionEng { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
        public string categoria { get; set; }
    }
}
