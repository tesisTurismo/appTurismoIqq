using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace appTurismoIqq.Modelo
{
    public class Usuario
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        [BsonElement("Nombre de Usuario")]
        public string nombreU { get; set; }
        [BsonElement("Apellido de Usuario")]
        public string apellidoU { get; set; }
        [BsonElement("Password")]
        public string passwordU { get; set; }
        [BsonElement("Pais de Origen")]
        public string PaisOrigen { get; set; }
        [BsonElement("Ciudad de Origen")]
        public string CiudadOrigen { get; set; }
        [BsonElement("Nacionalidad")]
        public string Nacionalidad { get; set; }
        [BsonElement("Correo Electronico")]
        public string email { get; set; }
        [BsonElement("Búsqueda")]
        public string busqueda { get; set; }
    }
}
