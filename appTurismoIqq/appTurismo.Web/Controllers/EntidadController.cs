using appTurismo.Web.App_Start;
using appTurismo.Web.Helpers;
using appTurismo.Web.Models;
using appTurismoIqq.Modelo;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appTurismo.Web.Controllers
{
    public class EntidadController : Controller
    {
        private readonly MongoContext db = new MongoContext();
        string conec = "mongodb+srv://user:tesis123456@tesis1-7onzc.azure.mongodb.net/test";
        string bdname = "bdTurismo";
        // GET: Entidad
        public ActionResult Index()
        {
            var cliente = new MongoClient(conec);

            var database = cliente.GetDatabase(bdname);
            var entidades = database.GetCollection<Entidad>("entidades").Find(new BsonDocument()).ToList();
            return View(entidades);
        }

        // GET: Entidad/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Entidad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Entidad/Create
        [HttpPost]
        public ActionResult Create(Entidad entidadvista)
        {
            try { 
                
              /* var pic = string.Empty;
                var folder = "~/Content/ImagenesEntidades";

                if (entidadvista.fotoFile != null)
                {
                    pic = FilesHelpers.UploadPhoto(entidadvista.fotoFile, folder);
                    pic = $"{folder}/{pic}";
                }
                //almaceno los datos en la variable local
               var entidad = this.ToEntidad(entidadvista, pic);
               */

                var cliente = new MongoClient(conec);

                var database = cliente.GetDatabase(bdname);
                var entidades = database.GetCollection<Entidad>("entidades");
                entidades.InsertOneAsync(entidadvista);
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
                direccion = vistaEntidad.direccion,
                latitud = vistaEntidad.latitud,
                longitud = vistaEntidad.longitud,
                categoria = vistaEntidad.categoria,
            };
        }
        // GET: Entidad/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Entidad/Edit/5
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

        // GET: Entidad/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Entidad/Delete/5
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
