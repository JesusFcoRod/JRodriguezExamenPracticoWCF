﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class JRodriguezExamenPracticoLibroEntities : DbContext
    {
        public JRodriguezExamenPracticoLibroEntities()
            : base("name=JRodriguezExamenPracticoLibroEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Autor> Autors { get; set; }
        public virtual DbSet<Libro> Libroes { get; set; }
    
        public virtual ObjectResult<LibroGetAll_Result> LibroGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LibroGetAll_Result>("LibroGetAll");
        }
    
        public virtual int LibroAdd(string nombre, Nullable<System.DateTime> fechaPublicacion, Nullable<int> numeroPaginas, Nullable<int> idAutor)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var fechaPublicacionParameter = fechaPublicacion.HasValue ?
                new ObjectParameter("FechaPublicacion", fechaPublicacion) :
                new ObjectParameter("FechaPublicacion", typeof(System.DateTime));
    
            var numeroPaginasParameter = numeroPaginas.HasValue ?
                new ObjectParameter("NumeroPaginas", numeroPaginas) :
                new ObjectParameter("NumeroPaginas", typeof(int));
    
            var idAutorParameter = idAutor.HasValue ?
                new ObjectParameter("IdAutor", idAutor) :
                new ObjectParameter("IdAutor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LibroAdd", nombreParameter, fechaPublicacionParameter, numeroPaginasParameter, idAutorParameter);
        }
    
        public virtual int LibroDelete(Nullable<int> idLibro)
        {
            var idLibroParameter = idLibro.HasValue ?
                new ObjectParameter("IdLibro", idLibro) :
                new ObjectParameter("IdLibro", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LibroDelete", idLibroParameter);
        }
    
        public virtual ObjectResult<LibroGetById_Result> LibroGetById(Nullable<int> idLibro)
        {
            var idLibroParameter = idLibro.HasValue ?
                new ObjectParameter("IdLibro", idLibro) :
                new ObjectParameter("IdLibro", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LibroGetById_Result>("LibroGetById", idLibroParameter);
        }
    
        public virtual int LibroUpdate(Nullable<int> idLibro, string nombre, Nullable<System.DateTime> fechaPublicacion, Nullable<int> numeroPaginas, Nullable<int> idAutor)
        {
            var idLibroParameter = idLibro.HasValue ?
                new ObjectParameter("IdLibro", idLibro) :
                new ObjectParameter("IdLibro", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var fechaPublicacionParameter = fechaPublicacion.HasValue ?
                new ObjectParameter("FechaPublicacion", fechaPublicacion) :
                new ObjectParameter("FechaPublicacion", typeof(System.DateTime));
    
            var numeroPaginasParameter = numeroPaginas.HasValue ?
                new ObjectParameter("NumeroPaginas", numeroPaginas) :
                new ObjectParameter("NumeroPaginas", typeof(int));
    
            var idAutorParameter = idAutor.HasValue ?
                new ObjectParameter("IdAutor", idAutor) :
                new ObjectParameter("IdAutor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LibroUpdate", idLibroParameter, nombreParameter, fechaPublicacionParameter, numeroPaginasParameter, idAutorParameter);
        }
    }
}
