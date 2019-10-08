using appTurismo.Web.Helpers;
using appTurismo.Web.Models;
using appTurismoIqq.Modelo;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Web;
using System.Web.Mvc;

namespace appTurismo.Web.Controllers
{
    public class CategoriaController : Controller
    {
        string conec = "mongodb+srv://user:tesis123456@tesis1-7onzc.azure.mongodb.net/test";
        string bdname = "bdTurismo";

        string connectionString =

 @"mongodb://servidor:5wrPsCPPQAiNGJ0IGnQP2mhfjLp59NgH1Q30l5avlxVZiGXkaJZYwadRRCQWPax22F23YooD6GDAp5aO1jsxpw==@servidor.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";

        // GET: Categoria
        public ActionResult Index()
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(
         new MongoUrl(connectionString));

            settings.SslSettings =
                         new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);
            //var client = new MongoClient(conec);
            var db = mongoClient.GetDatabase(bdname);
            var collectionSettings = new MongoCollectionSettings { ReadPreference = ReadPreference.Nearest };



            // var cliente = new MongoClient(conec);

            //var database = cliente.GetDatabase(bdname);
            var listaCategorias = db.GetCollection<Categoria>("Categoria").Find(new BsonDocument()).ToList();

            return View(listaCategorias);
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        public ActionResult Create(CategoriaVista categoriavista)
        {
            try
            {
                var pic = string.Empty;
                var folder = "~/Content/ImagenesCategorias";

                if (categoriavista.fotoFile != null)
                {
                    pic = FilesHelpers.UploadPhoto(categoriavista.fotoFile, folder);
                    pic = $"{folder}/{pic}";
                }
                //almaceno los datos en la variable local
                var categoria = this.ToCategoria(categoriavista, pic);

                // comienza la conexión
                MongoClientSettings settings = MongoClientSettings.FromUrl(
          new MongoUrl(connectionString)
        );
                settings.SslSettings =
                              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
                var mongoClient = new MongoClient(settings);
                //var client = new MongoClient(conec);
                var db = mongoClient.GetDatabase(bdname);
                var collectionSettings = new MongoCollectionSettings { ReadPreference = ReadPreference.Nearest };



                // var cliente = new MongoClient(conec);

                //var database = cliente.GetDatabase(bdname);
                var listacategorias = db.GetCollection<Categoria>("Categoria");
                //termina la conexión

                listacategorias.InsertOneAsync(categoria);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private Categoria ToCategoria(CategoriaVista categoriavista, string pic)
        {
            return new Categoria
            {
                id=categoriavista.id,
                fotoCategoria=pic,
                nombre=categoriavista.nombre,
                nombreEng=categoriavista.nombreEng,
            };
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Categoria/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
