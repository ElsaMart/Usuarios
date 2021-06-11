using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Usuario_Practica.Repository;
using Usuario_Practica.Utitlities;
using Usuario_Practica.Models;
namespace Usuario_Practica.Controllers
{
    public class UsuarioController : Controller
    {
        // Devuelve vista
        
        public ActionResult Index()
        {
            var Result = new UsuarioRepository().GetAll();
            return View(Result);
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var Result = new UsuarioRepository().GetAll();
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Get(int Id)
        {
            return Json(new UsuarioRepository().Get(Id), JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult Create(UsuarioDTO usuario)
        {
            var model = new UsuarioRepository().CreateorSave(usuario);
            return Json(model);
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            return Json(new UsuarioRepository().Delete(Id), JsonRequestBehavior.AllowGet);
        }
    }
}