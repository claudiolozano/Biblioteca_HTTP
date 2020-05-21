using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca_HTTP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Autores>> Get()
        {
            using (EditorialContext context = new EditorialContext())
            {
                return await context.Autores.ToListAsync();
            }
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<Autores>> GetAutorPorID(string id)
        {
            using (EditorialContext context = new EditorialContext())
            {
                return await context.Autores.Where(autor => autor.Dni == id).ToListAsync();
            }
        }
        //[HttpGet("AutorPorID")]
        //public IEnumerable<Autores> GetAutorPorID()
        //{
        //    using (EditorialContext context = new EditorialContext())
        //    {
        //        return context.Autores.Where(autor => autor.Dni == "10547686").ToList();
        //    }
        //}

        [HttpPost]
        public bool postAutor(Autores autor)
        {
            try
            {
                using (EditorialContext context = new EditorialContext())
                {
                    context.Autores.Add(autor);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        [HttpPut]
        public async Task<bool> putAutor(Autores autor)
        {
            try
            {
                using (EditorialContext context = new EditorialContext())
                {
                    List<Autores> varautor = await context.Autores.Where(autor => autor.Dni == autor.Dni).ToListAsync();

                    Autores autorObtenido = varautor.FirstOrDefault<Autores>();

                    if (autorObtenido != null)
                    {
                        autorObtenido.Nombre = autor.Nombre;
                        autorObtenido.Apellido = autor.Apellido;
                        autorObtenido.Direccion = autor.Direccion;
                        autorObtenido.Telefono = autor.Telefono;
                        autorObtenido.Email = autor.Email;
                        autorObtenido.Libros = autor.Libros;

                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete]
        public bool deleteAutor(Autores autor)
        {
            try
            {
                using (EditorialContext context = new EditorialContext())
                {
                    try
                    {
                        context.Autores.Remove(autor);
                        context.SaveChanges();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }


        [HttpGet("readallautores")]
        public List<Autores> ReadAllAutores()
        {
            using (EditorialContext context = new EditorialContext())
            {
                List<Autores> autores= context.Autores.FromSqlRaw("ReadAllAutores").ToList();
                return autores;
            }
        }

        [HttpGet("readallautorespordni")]
        public Autores ReadAllAutoresPorDNI(string dni)
        {
            using (EditorialContext context = new EditorialContext())
            {
                return context.Autores.FromSqlRaw("ReadAllAutores p0", dni).Single();
            }
        }
    }
}