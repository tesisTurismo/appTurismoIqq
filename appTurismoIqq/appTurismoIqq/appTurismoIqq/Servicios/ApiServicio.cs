﻿using appTurismoIqq.Modelo;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
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

         IMongoCollection<Entidad> coleccionEntidades;
         IMongoCollection<Entidad> ColeccionEntidades
        
        {
            get
            {
                if (coleccionEntidades == null)
                {
                    string connectionString =

  @"mongodb://servidor:5wrPsCPPQAiNGJ0IGnQP2mhfjLp59NgH1Q30l5avlxVZiGXkaJZYwadRRCQWPax22F23YooD6GDAp5aO1jsxpw==@servidor.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";

                    MongoClientSettings settings = MongoClientSettings.FromUrl(
                      new MongoUrl(connectionString)
                    );
                    settings.SslSettings =
                      new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
                    var mongoClient = new MongoClient(settings);
                    //var client = new MongoClient(conec);
                    var db = mongoClient.GetDatabase(bdname);
                    var collectionSettings = new MongoCollectionSettings { ReadPreference = ReadPreference.Nearest };
                    coleccionEntidades = db.GetCollection<Entidad>("Entidad", collectionSettings);
                }

                return coleccionEntidades;
            }
        
            
        }


        IMongoCollection<Categoria> coleccionCategoria;
        IMongoCollection<Categoria> ColeccionCategoria

        {
            get
            {
                if (coleccionCategoria == null)
                {
                    string connectionString =

  @"mongodb://servidor:5wrPsCPPQAiNGJ0IGnQP2mhfjLp59NgH1Q30l5avlxVZiGXkaJZYwadRRCQWPax22F23YooD6GDAp5aO1jsxpw==@servidor.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";

    

                    MongoClientSettings settings = MongoClientSettings.FromUrl(
                      new MongoUrl(connectionString)
                    );
                    settings.SslSettings =
                      new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
                    var mongoClient = new MongoClient(settings);
                    //var client = new MongoClient(conec);
                    var db = mongoClient.GetDatabase(bdname);
                    var collectionSettings = new MongoCollectionSettings { ReadPreference = ReadPreference.Nearest };
                    coleccionCategoria = db.GetCollection<Categoria>("Categoria", collectionSettings);
                    


                  

                }

                return coleccionCategoria;
            }

        }

        IMongoCollection<Direccion> coleccionDireccion;
        IMongoCollection<Direccion> ColeccionDireccion

        {
            get
            {
                if (coleccionDireccion == null)
                {
                    string connectionString =

  @"mongodb://servidor:5wrPsCPPQAiNGJ0IGnQP2mhfjLp59NgH1Q30l5avlxVZiGXkaJZYwadRRCQWPax22F23YooD6GDAp5aO1jsxpw==@servidor.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";

                    MongoClientSettings settings = MongoClientSettings.FromUrl(
                      new MongoUrl(connectionString)
                    );
                    settings.SslSettings =
                      new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
                    var mongoClient = new MongoClient(settings);
                    //var client = new MongoClient(conec);
                    var db = mongoClient.GetDatabase(bdname);
                    var collectionSettings = new MongoCollectionSettings { ReadPreference = ReadPreference.Nearest };

                    coleccionDireccion = db.GetCollection<Direccion>("Direccion", collectionSettings);
                }

                return coleccionDireccion;
            }

        }

        public MongoClient clientemongo
        {
            get {
                string connectionString =
      @"mongodb://servidor:5wrPsCPPQAiNGJ0IGnQP2mhfjLp59NgH1Q30l5avlxVZiGXkaJZYwadRRCQWPax22F23YooD6GDAp5aO1jsxpw==@servidor.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
                MongoClientSettings settings = MongoClientSettings.FromUrl(
                  new MongoUrl(connectionString)
                );
                settings.SslSettings =
                  new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
                var mongoClient = new MongoClient(settings);

                return mongoClient;
            }
        }

        public async Task<IEnumerable<Entidad>> listaEntidades()
        {
            try
            {
                var lista = await ColeccionEntidades
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

        public async Task<IEnumerable<Categoria>> listaCategoria()
        {
            try
            {
                var lista = await ColeccionCategoria
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



        public async Task<IEnumerable<Entidad>> listaEntidadesSeleccionada( string id)
        {
            try
            {
                var entidadId = new ObjectId(id);
                var lista = ColeccionEntidades.AsQueryable<Entidad>().Where(e => e.id == id).ToList();
                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine("NO SE PUDO CAPTURAR LOS DATOS : " + e.Message);
            }
            return null;

        }

        public async Task<IEnumerable<Entidad>> CategoriaSeleccionada(string categoria)
        {
            try
            {
                
                var lista = ColeccionEntidades.AsQueryable<Entidad>().Where(e => e.categoria == categoria).ToList();
                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine("NO SE PUDO CAPTURAR LOS DATOS : " + e.Message);
            }
            return null;

        }

        public async Task<IEnumerable<Direccion>> ListaDirecciones(string nombreentidad)
        {
            try
            {

                var lista = ColeccionDireccion.AsQueryable<Direccion>().Where(e => e.entidad == nombreentidad).ToList();
                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine("NO SE PUDO CAPTURAR LOS DATOS : " + e.Message);
            }
            return null;

        }


        public async Task UpdateEntidad(Entidad entidad)
        {
            await ColeccionEntidades.ReplaceOneAsync( e => e.id.Equals(entidad.id),entidad);
        }



    }
}
