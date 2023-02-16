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

    }
}