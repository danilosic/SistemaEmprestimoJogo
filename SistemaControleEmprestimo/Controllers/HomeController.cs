using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaControleEmprestimo.Models;

namespace SistemaControleEmprestimo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario objUsuario)
        {
            if (ModelState.IsValid)
            {
                using (DbControleEmprestimoEntities db = new DbControleEmprestimoEntities())
                {
                    var obj = db.Usuario.Where(a => a.Username.Equals(objUsuario.Username) && a.Senha.Equals(objUsuario.Senha)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["Username"] = obj.Username.ToString();
                        Session["Senha"] = obj.Senha.ToString();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(objUsuario);
        }

        public ActionResult Index()
        {
            if (Session["Username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

    }
}