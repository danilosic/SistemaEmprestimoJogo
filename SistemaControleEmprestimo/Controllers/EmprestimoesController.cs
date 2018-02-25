using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaControleEmprestimo.Models;

namespace SistemaControleEmprestimo.Controllers
{
    public class EmprestimoesController : Controller
    {
        private SistemaControleEmprestimoContext db = new SistemaControleEmprestimoContext();

        // GET: Emprestimoes
        public ActionResult Index()
        {
            var emprestimos = db.Emprestimos.Include(e => e.Amigo).Include(e => e.Jogo);
            return View(emprestimos.ToList());
        }

        // GET: Emprestimoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimos.Find(id);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            return View(emprestimo);
        }

        // GET: Emprestimoes/Create
        public ActionResult Create()
        {
            ViewBag.IdAmigo = new SelectList(db.Amigos, "Id", "Nome");
            ViewBag.IdJogo = new SelectList(db.Jogos, "Id", "Nome");
            return View();
        }

        // POST: Emprestimoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,DataEmprestimo,IdAmigo,IdJogo")] Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                db.Emprestimos.Add(emprestimo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAmigo = new SelectList(db.Amigos, "Id", "Nome", emprestimo.IdAmigo);
            ViewBag.IdJogo = new SelectList(db.Jogos, "Id", "Nome", emprestimo.IdJogo);
            return View(emprestimo);
        }

        // GET: Emprestimoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimos.Find(id);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAmigo = new SelectList(db.Amigos, "Id", "Nome", emprestimo.IdAmigo);
            ViewBag.IdJogo = new SelectList(db.Jogos, "Id", "Nome", emprestimo.IdJogo);
            return View(emprestimo);
        }

        // POST: Emprestimoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,DataEmprestimo,IdAmigo,IdJogo")] Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emprestimo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAmigo = new SelectList(db.Amigos, "Id", "Nome", emprestimo.IdAmigo);
            ViewBag.IdJogo = new SelectList(db.Jogos, "Id", "Nome", emprestimo.IdJogo);
            return View(emprestimo);
        }

        // GET: Emprestimoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimos.Find(id);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            return View(emprestimo);
        }

        // POST: Emprestimoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emprestimo emprestimo = db.Emprestimos.Find(id);
            db.Emprestimos.Remove(emprestimo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
