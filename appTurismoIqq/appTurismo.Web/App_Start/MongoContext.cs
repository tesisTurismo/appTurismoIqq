using appTurismoIqq.Modelo;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Web;

namespace appTurismo.Web.App_Start
{
    public class MongoContext
    {

        //MongoClient cliente;

        public IMongoDatabase bd;
        public string conec = "mongodb+srv://user:tesis123456@tesis1-7onzc.azure.mongodb.net/test";
        public string bdname="bdTurismo";

        public MongoContext()
        {
           /* 
            string connectionString =
              @"mongodb://servidorapp:sTlyoKhJrg0znWt2CP92NLVtIT6OHtWd9YKntpOFsClf8LKFwaStAImTdg2nLJIn9PbxXz2xv9yBShypAXvgzA==@servidorapp.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
            MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl(connectionString)
            );
            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);

          */
            // bd = mongoClient.GetDatabase("dbTurismo");
            

            
          /*  var cliente = new MongoClient(conec);
            //bd = cliente.GetDatabase(bdname);
            var database = cliente.GetDatabase(bdname);
            var usuarios = database.GetCollection<Usuario>("usuario");
           */ 

        }



        
        public IMongoCollection<Entidad> Entidades
        {

            get {
                var cliente = new MongoClient(conec);
                //bd = cliente.GetDatabase(bdname);
                var database = cliente.GetDatabase(bdname);
                
                var entidades = database.GetCollection<Entidad>("entidad");
                return entidades;
                }
        }

        public IMongoCollection<Usuario> Usuarios
        {
            get
            {
                var usuarios = bd.GetCollection<Usuario>("usuario");
                return usuarios;
            }
        }
        
    }
}