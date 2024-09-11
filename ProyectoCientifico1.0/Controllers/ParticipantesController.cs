using System;
using System.Web.Mvc;
using MongoDB.Driver;
using CapaEntidad;
using MongoDB.Bson;
using System.Collections.Generic;

namespace ProyectoCientifico1._0.Controllers
{
    public class ParticipantesController : Controller
    {
        private readonly IMongoCollection<Participantes> participantesCollection;

        public ParticipantesController()
        {
            var cadena = new MongoClient("mongodb+srv://admin:rSiFPfQYuVVeahbh@feriacientifica.sjxdr.mongodb.net/");
            var database = cadena.GetDatabase("FeriaCientifica");
            participantesCollection = database.GetCollection<Participantes>("Participantes");
        }

        // GET: Participantes
        public ActionResult Index()
        {
            try
            {
                var participantes = participantesCollection.Find(Builders<Participantes>.Filter.Empty).ToList();
                return View(participantes);
            }
            catch (Exception ex)
            {
                // Manejo de errores - se puede registrar el error y mostrar un mensaje al usuario
                ViewBag.Error = "Ocurrió un error al cargar la lista de participantes. Inténtelo de nuevo más tarde.";
                return View(new List<Participantes>()); // Retorna una lista vacía en caso de error
            }
        }

        // GET: Participantes/Details/5
        public ActionResult Details(string id)
        {
            var participante = participantesCollection.Find(p => p.Id == id).FirstOrDefault();
            return View(participante);
        }

        // GET: Participantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Participantes/Create
        [HttpPost]
        public ActionResult Create(Participantes participante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    participantesCollection.InsertOne(participante);
                    return RedirectToAction("Index");
                }
                return View(participante);
            }
            catch
            {
                ViewBag.Error = "Ocurrió un error al crear el participante. Inténtelo de nuevo más tarde.";
                return View(participante);
            }
        }

        // GET: Participantes/Edit/5
        public ActionResult Edit(string id)
        {
            var participante = participantesCollection.Find(p => p.Id == id).FirstOrDefault();
            return View(participante);
        }

        // POST: Participantes/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Participantes participante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    participantesCollection.ReplaceOne(p => p.Id == id, participante);
                    return RedirectToAction("Index");
                }
                return View(participante);
            }
            catch
            {
                ViewBag.Error = "Ocurrió un error al editar el participante. Inténtelo de nuevo más tarde.";
                return View(participante);
            }
        }

        // GET: Participantes/Delete/5
        public ActionResult Delete(string id)
        {
            var participante = participantesCollection.Find(p => p.Id == id).FirstOrDefault();
            return View(participante);
        }

        // POST: Participantes/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                participantesCollection.DeleteOne(p => p.Id == id);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Error = "Ocurrió un error al eliminar el participante. Inténtelo de nuevo más tarde.";
                return View();
            }
        }
    }
}
