using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLMVC.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        //ActionResult, Action Method, Razor, Bootstrap
        //ActionVerb //GET, POST, PUT, DELETE
        [HttpGet] //Decorador
        public ActionResult GetAll()
        {
            ML.Materia materia = new ML.Materia();
            ML.Result result = BL.Materia.GetAllEF();

            materia.Materias = result.Objects;
            return View(materia);
        }
        [HttpGet] //mostrar la vista
        public ActionResult Form()
        {
            return View();
        }
        [HttpPost] //Hacer el registro
        public ActionResult Form(ML.Materia materia)
        {
            ML.Result result = BL.Materia.AddEF(materia);
            if (result.Correct)
            {
                ViewBag.Message = "Se ha realizado el registro";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "No se ha realizado el registro";
                return PartialView("Modal");
            }

           
        }
    }
}