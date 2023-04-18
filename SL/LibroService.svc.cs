using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LibroService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LibroService.svc or LibroService.svc.cs at the Solution Explorer and start debugging.
    public class LibroService : ILibroService
    {
        public ML.Result Add(ML.Libro libro)
        {
            ML.Result result = BL.Libro.Add(libro);

            if (result.Correct)
            {
                return result;
            }
            else
            {
                return null;
            }

        }

        public ML.Result Update(ML.Libro libro)
        {
            ML.Result result = BL.Libro.Update(libro);

            if (result.Correct)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public ML.Result Delete(int IdLibro)
        {
            ML.Result result = BL.Libro.Delete(IdLibro);

            if (result.Correct)
            {
                return result;
            }
            else
            {
                return null;
            }
        }




        public ML.Result GetAll()
        {
            ML.Result result = BL.Libro.GetAll();

            if (result.Correct)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public ML.Result GetById(int IdLibro)
        {
            ML.Result result = BL.Libro.GetById(IdLibro);

            if (result.Correct)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
