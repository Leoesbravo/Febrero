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
        public ActionResult GetAll()
        {
            return View();
        }
    }
}