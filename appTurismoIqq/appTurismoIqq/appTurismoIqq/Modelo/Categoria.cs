using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace appTurismoIqq.Modelo
{
    public class Categoria
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        [BsonElement("fotoCategoria")]
        public string fotoCategoria { get; set; }
        [BsonElement("nombre")]
        public string nombre { get; set; }
        public string fotoCategoriaApp
        {
            get
            {
                if (string.IsNullOrEmpty(this.fotoCategoria))
                {
                    return "CategoriaDefault";
                }

                return "CategoriaDefault";

            }
        }
    }
}
