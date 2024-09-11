using System;
using System.Web.Mvc;
using MongoDB.Driver;
using CapaEntidad;
using MongoDB.Bson;

namespace ProyectoCientifico1._0.Controllers
{
    public class AdministradorController : Controller
    {
        private readonly IMongoCollection<Administrador> admin;

        public AdministradorController()
        {
            var cadena = new MongoClient("mongodb+srv://admin:rSiFPfQYuVVeahbh@feriacientifica.sjxdr.mongodb.net/");
            var Database = cadena.GetDatabase("FeriaCientifica");
            admin = Database.GetCollection<Administrador>("Administrador");
        }

        // GET: Administrador
        public ActionResult Index()
        {
            var administradores = admin.Find(Builders<Administrador>.Filter.Empty).ToList();
            return View(administradores);
        }

        // GET: Administrador/Details/5
        public ActionResult Details(string id)
        {
            var objectId = ObjectId.Parse(id);
            var administrador = admin.Find(a => a.Id == id).FirstOrDefault();
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }

        // GET: Administrador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrador/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Administrador model)
        {
            if (ModelState.IsValid)
            {
                admin.InsertOne(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Administrador/Edit/5
        public ActionResult Edit(string id)
        {
            var objectId = ObjectId.Parse(id);
            var administrador = admin.Find(a => a.Id == id).FirstOrDefault();
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }

        // POST: Administrador/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Administrador model)
        {
            if (ModelState.IsValid)
            {
                var filter = Builders<Administrador>.Filter.Eq(a => a.Id, id);
                var update = Builders<Administrador>.Update
                    .Set(a => a.Nombre_Administrador, model.Nombre_Administrador)
                    .Set(a => a.Email, model.Email)
                    .Set(a => a.Contraseña, model.Contraseña)
                    .Set(a => a.Rol, model.Rol)
                    .Set(a => a.Telefono, model.Telefono);

                admin.UpdateOne(filter, update);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Administrador/Delete/5
        public ActionResult Delete(string id)
        {
            var objectId = ObjectId.Parse(id);
            var administrador = admin.Find(a => a.Id == id).FirstOrDefault();
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }

        // POST: Administrador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var objectId = ObjectId.Parse(id);
            admin.DeleteOne(a => a.Id == id);
            return RedirectToAction("Index");
        }
    }
}

