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
        public ActionResult Form(int? idMateria)
        {
            if(idMateria != null)
                //Editar
            {
                ML.Result result = BL.Materia.GetById(idMateria.Value);
                ML.Materia materia = new ML.Materia();

                materia = (ML.Materia)result.Object;
                return View(materia);
            }
            else
            {
                return View();
            }

        }
        [HttpPost] //Hacer el registro
        public ActionResult Form(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            if(materia.IdMateria != null)
            {
                //Update
                ViewBag.Message = "Se ha actualizado el registro";
            }
            else
            {
                //Add
                result = BL.Materia.AddEF(materia);
                ViewBag.Message = "se ha agregado el registro";
            }
            if (result.Correct)
            {              
                return PartialView("Modal");
            }
            else
            {               
                return PartialView("Modal");
            }



        }
        public ActionResult Delete(int IdMateria)
        {
            ML.Result result = BL.Materia.DeleteEF(IdMateria);

            if (result.Correct)
            {
                ViewBag.Message = "Se ha eliminado el registro";
            return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "No se ha podido registrar el usuario" + result.ErrorMessage;
                return PartialView("Modal");
            }
        }
    }
}