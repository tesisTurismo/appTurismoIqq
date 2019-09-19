using appTurismo.Web.Helpers;
using appTurismo.Web.Models;
using appTurismoIqq.Modelo;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
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

                var cliente = new MongoClient(conec);

                var database = cliente.GetDatabase(bdname);
                var listaentidades = database.GetCollection<Entidad>("entidad");
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Entidades/Edit/5
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

        // GET: Entidades/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Entidades/Delete/5
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
