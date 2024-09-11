using System.Web.Mvc;
using MongoDB.Driver;
using CapaEntidad;
using System.Collections.Generic;

namespace ProyectoCientifico1._0.Controllers
{
    public class EventoController : Controller
    {
        private readonly IMongoCollection<Evento> eventoCollection;

        public EventoController()
        {
            var cadena = new MongoClient("mongodb+srv://admin:rSiFPfQYuVVeahbh@feriacientifica.sjxdr.mongodb.net/");
            var database = cadena.GetDatabase("FeriaCientifica");
            eventoCollection = database.GetCollection<Evento>("Evento");
        }

        // GET: Evento
        public ActionResult Index()
        {
            var eventos = eventoCollection.Find(_ => true).ToList(); // Obtiene todos los eventos
            return View(eventos);
        }

        // GET: Evento/Details/5
        public ActionResult Details(string id)
        {
            var Evento = eventoCollection.Find(a => a.Id_Evento == id).FirstOrDefault();
            if (Evento == null)
            {
                return HttpNotFound();
            }
            return View(Evento);
        }

        // GET: Evento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Evento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Evento model)
        {
            if (ModelState.IsValid)
            {
                eventoCollection.InsertOne(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Evento/Edit/5
        public ActionResult Edit(string id)
        {
            var Evento = eventoCollection.Find(a => a.Id_Evento == id).FirstOrDefault();
            if (Evento == null)
            {
                return HttpNotFound();
            }
            return View(Evento);
        }

        // POST: Evento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Evento model)
        {
            if (ModelState.IsValid)
            {
                var filter = Builders<Evento>.Filter.Eq(e => e.Id_Evento, id);
                var update = Builders<Evento>.Update
                    .Set(e => e.Nombre_Evento, model.Nombre_Evento)
                    .Set(e => e.Descripcion_Evento, model.Descripcion_Evento)
                    .Set(e => e.Fecha_Evento, model.Fecha_Evento)
                    .Set(e => e.Lugar_Evento, model.Lugar_Evento)
                    .Set(e => e.Activo_Evento, model.Activo_Evento);

                eventoCollection.UpdateOne(filter, update);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Evento/Delete/5
        public ActionResult Delete(string id)
        {
            var Evento = eventoCollection.Find(a => a.Id_Evento == id).FirstOrDefault();
            if (Evento == null)
            {
                return HttpNotFound();
            }
            return View(Evento);
        }

        // POST: Evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            eventoCollection.DeleteOne(e => e.Id_Evento == id);
            return RedirectToAction("Index");
        }
    }
}
