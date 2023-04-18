using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class LibroController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Libro libro = new ML.Libro();
            LibroService.LibroServiceClient libroService = new LibroService.LibroServiceClient();
            ML.Result result = libroService.GetAll();

            libro.Libros = result.Objects;

            return View(libro);
        }

        [HttpGet]

        public ActionResult Form(int? IdLibro)
        {
            ML.Result result = new ML.Result();
            ML.Libro libro = new ML.Libro();

            if (IdLibro != null)
            {
                LibroService.LibroServiceClient libroService = new LibroService.LibroServiceClient();
                result = libroService.GetById(IdLibro.Value);

                if (result.Correct)
                {
                    libro = (ML.Libro)result.Object;
                    return View(libro);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar la informacion del libro";
                }
                return PartialView("Modal");
            }
            else
            {
                return View(libro);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            int idLibro = libro.IdLibro;

            if(idLibro > 0){
                LibroService.LibroServiceClient libroService = new LibroService.LibroServiceClient();
                result = libroService.Update(libro);
               if (result.Correct)
                {
                    ViewBag.Message = "Libro actualizado con exito";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al actualizar los datos del libro";
                }
            }
            else
            {
                LibroService.LibroServiceClient libroService = new LibroService.LibroServiceClient();
                result = libroService.Add(libro);
                 
                if (result.Correct)
                {
                    ViewBag.Message = "Libro agregado con exito";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al agregar los datos del libro";
                }
            }
            return PartialView("Modal");

        }

        [HttpGet]
        public ActionResult Delete(int IdLibro)
        {

            LibroService.LibroServiceClient libroService = new LibroService.LibroServiceClient();
            ML.Result result = libroService.Delete(IdLibro);

            if (result.Correct)
            {
                ViewBag.Message = "Libro eliminado con exito";
            }
            else
            {
                ViewBag.Message = "Error al intentar eliminar el libro";
            }
            
            return PartialView("Modal");
        }
    }
}