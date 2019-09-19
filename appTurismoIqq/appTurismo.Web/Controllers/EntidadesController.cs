using appTurismo.Web.Helpers;
using appTurismo.Web.Models;
using appTurismoIqq.Modelo;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace appTurismo.Web.Controllers
{
    public class EntidadesController : Controller
    {
        string conec = "mongodb+srv://user:tesis123456@tesis1-7onzc.azure.mongodb.net/test";
        string bdname = "bdTurismo";
        // GET: Entidades
        public ActionResult Index()
        {
            var cliente = new MongoClient(conec);

            var database = cliente.GetDatabase(bdname);
            var listaentidades = database.GetCollection<Entidad>("entidad").Find(new BsonDocument()).ToList();
            return View(listaentidades);
        }

        // GET: Entidades/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Entidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Entidades/Create
        [HttpPost]
        public ActionResult Create(EntidadVista entidadvista)
        {
            try
            {
                var pic = string.Empty;
                var folder = "~/Content/ImagenesEntidades";

                if (entidadvista.fotoFile != null)
                {
                    pic = FilesHelpers.UploadPhoto(entidadvista.fotoFile, folder);
                    pic = $"{folder}/{pic}";
                }
                //almaceno los datos en la variable local
                var entidad = this.ToEntidad(entidadvista, pic);

                // comienza la conexión
                var cliente = new MongoClient(conec);

                var database = cliente.GetDatabase(bdname);
                var listaentidades = database.GetCollection<Entidad>("entidad");
                //termina la conexión

                listaentidades.InsertOneAsync(entidad);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        private Entidad ToEntidad(EntidadVista vistaEntidad, string pic)
        {
            return new Entidad
            {

                id = vistaEntidad.id,
                foto = pic,
                nombre = vistaEntidad.nombre,
                pagWeb = vistaEntidad.pagWeb,
                descripcion = vistaEntidad.descripcion,
                descripcionEng = vistaEntidad.descripcionEng,
                telefono = vistaEntidad.telefono,
                //direccion = vistaEntidad.direccion,
                //latitud = vistaEntidad.latitud,
               // longitud = vistaEntidad.longitud,
                categoria = vistaEntidad.categoria,
            };
        }
        // GET: Entidades/Edit/5
        public ActionResult Edit(string id)
        {
            var cliente = new MongoClient(conec);

            var database = cliente.GetDatabase(bdname);
            var entidad= database.GetCollection<Entidad>("entidad").Find(new BsonDocument()).ToList().AsQueryable<Entidad>().SingleOrDefault(x =>x.id== id);
            //var result = from d in entidad.AsQueryable<Entidad>() where d.id == id select d;
           // var view = this.ToView(result);
            return View(entidad);
        }

        private EntidadVista ToView(Entidad entidad)
        {
            return new EntidadVista
            {
                id = entidad.id,
                foto = entidad.foto,
                nombre = entidad.nombre,
                pagWeb = entidad.pagWeb,
                descripcion = entidad.descripcion,
                descripcionEng = entidad.descripcionEng,
                telefono = entidad.telefono,
               
                categoria = entidad.categoria,
            };
        }

        // POST: Entidades/Edit/5
        [HttpPost]
        public ActionResult Edit(Entidad Empdet)

        {
            
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var cliente = new MongoClient(conec);

                    var database = cliente.GetDatabase(bdname);
                    var listaentidades = database.GetCollection<Entidad>("entidad");


                    var update = listaentidades.FindOneAndUpdateAsync(Builders<Entidad>.Filter.Eq("id", Empdet.id),
                        Builders<Entidad>.Update.Set("foto", Empdet.foto).Set("nombre", Empdet.nombre).Set("pagWeb", Empdet.pagWeb).
                        Set("descripcion", Empdet.descripcion).Set("descripcionEng", Empdet.descripcionEng).Set("telefono",Empdet.telefono)
                        
                        .Set("categoria",Empdet.categoria));
                    return RedirectToAction("Index");
                }

               
           
                return View();
            
        }

        // GET: Entidades/Delete/5
        public ActionResult Delete(String id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cliente = new MongoClient(conec);

            var database = cliente.GetDatabase(bdname);
            var entidad = database.GetCollection<Entidad>("entidad").Find(new BsonDocument()).ToList().AsQueryable<Entidad>().SingleOrDefault(x => x.id == id);
            if (entidad == null)
            {
                return HttpNotFound();
            }
            return View(entidad);
        }

        // POST: Entidades/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(String id)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    var cliente = new MongoClient(conec);

                    var database = cliente.GetDatabase(bdname);
                    var listaentidades = database.GetCollection<Entidad>("entidad");

                    var DeleteRecord = listaentidades.DeleteOneAsync(
                        Builders<Entidad>.Filter.Eq("id", id));
                    
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
