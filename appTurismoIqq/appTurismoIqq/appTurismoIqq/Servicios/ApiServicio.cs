using appTurismoIqq.Modelo;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace appTurismoIqq.Servicios
{
    
    public class ApiServicio
    {
        MongoClient cliente;
        IMongoDatabase database;
        public string conec = "mongodb+srv://user:tesis123456@tesis1-7onzc.azure.mongodb.net/test";
        public string bdname = "bdTurismo";
        string collectionName = "entidad";

        public string error { get; set; }
        public string coleccionSeleccionada { get; set; }

        /*
        private IMongoCollection<T> lista() => database.GetCollection<T>(typeof(T).Name);
        public IMongoCollection<T> mostrarLista<T>(string entidad)
        {
            try
            {
                var entidades = database.GetCollection<T>(entidad);
                return entidades;
            }
            catch
            {
                return null;
            }
 

        }
        */
        List<Entidad> lista { get; set; }

         IMongoCollection<Entidad> coleccion;
         IMongoCollection<Entidad> Coleccion
        
        {
            get
            {
                if (coleccion==null)
                {
                    string connectionString =
                    @"mongodb://servidorapp:sTlyoKhJrg0znWt2CP92NLVtIT6OHtWd9YKntpOFsClf8LKFwaStAImTdg2nLJIn9PbxXz2xv9yBShypAXvgzA==@servidorapp.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
                    MongoClientSettings settings = MongoClientSettings.FromUrl(
                      new MongoUrl(connectionString)
                    );
                    settings.SslSettings =
                      new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
                    var mongoClient = new MongoClient(settings);
                    //var client = new MongoClient(conec);
                    var db = mongoClient.GetDatabase(bdname);
                    var collectionSettings = new MongoCollectionSettings { ReadPreference = ReadPreference.Nearest };
                    coleccion = db.GetCollection<Entidad>("Entidad", collectionSettings);
                }
                
                return coleccion;
            }
            
        }

        public async Task<List<Entidad>> listaEntidades()
        {
            try
            {
                var lista = await Coleccion
                .Find(new BsonDocument())
                .ToListAsync();
                Console.WriteLine(lista);

                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine("NO SE PUDO CAPTURAR LOS DATOS : " + e.Message);
            }
            return null;
        }
        /*
        public IEnumerable<T> listar
        {
            get
            {
                try
                {
                    error = "";
                    return lista().Find(new BsonDocument()).ToList();
                }
                catch(Exception ex)
                {
                    error = ex.Message;
                    return null;
                }
            }
        }

    */









    }
}
