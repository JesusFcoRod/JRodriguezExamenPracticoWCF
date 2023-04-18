using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {
        public static ML.Result Add(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JRodriguezExamenPracticoLibroEntities contex = new DL.JRodriguezExamenPracticoLibroEntities())
                {
                    var query = contex.LibroAdd(libro.Nombre, DateTime.Parse(libro.FechaPublicacion), libro.NumeroPaginas, libro.Autor.IdAutor);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result Update(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JRodriguezExamenPracticoLibroEntities contex = new DL.JRodriguezExamenPracticoLibroEntities())
                {
                    var query = contex.LibroUpdate(libro.IdLibro, libro.Nombre, DateTime.Parse(libro.FechaPublicacion), libro.NumeroPaginas, libro.Autor.IdAutor);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result Delete(int IdLibro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JRodriguezExamenPracticoLibroEntities contex = new DL.JRodriguezExamenPracticoLibroEntities())
                {
                    var query = contex.LibroDelete(IdLibro);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else { result.Correct = false; }
                }

            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JRodriguezExamenPracticoLibroEntities contex = new DL.JRodriguezExamenPracticoLibroEntities())
                {
                    var query = contex.LibroGetAll().ToList();

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Libro libro = new ML.Libro();

                            libro.IdLibro = item.IdLibro;
                            libro.Nombre = item.NombreLibro;
                            libro.FechaPublicacion = item.FechaPublicacion.Value.ToString("dd-MM-yyyy");
                            libro.NumeroPaginas = item.NumeroPaginas.Value;

                            libro.NombreAutor = item.NombreAutor + " " +
                                                 item.ApellidoPaterno + " " +
                                                 item.ApellidoMaterno;

                            result.Objects.Add(libro);
                            result.Correct = true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }
        public static ML.Result GetById(int IdLibro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JRodriguezExamenPracticoLibroEntities contex = new DL.JRodriguezExamenPracticoLibroEntities())
                {
                    var query = contex.LibroGetById(IdLibro).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Libro libro = new ML.Libro();

                        libro.IdLibro = query.IdLibro;
                        libro.Nombre = query.Nombre;
                        libro.FechaPublicacion = query.FechaPublicacion.Value.ToString("dd-MM-yyyy");
                        libro.NumeroPaginas = query.NumeroPaginas.Value;

                        libro.Autor = new ML.Autor();
                        libro.Autor.IdAutor = query.IdAutor.Value;
                        libro.Autor.Nombre = query.NombreAutor;
                        libro.Autor.ApellidoPaterno = query.ApellidoPaterno;
                        libro.Autor.ApellidoMaterno = query.ApellidoMaterno;

                        result.Object = libro;
                        result.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }
    }
}
