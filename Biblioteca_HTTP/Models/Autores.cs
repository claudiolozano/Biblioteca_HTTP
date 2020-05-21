using System;
using System.Collections.Generic;

namespace Biblioteca_HTTP.Models
{
    public partial class Autores
    {
        public Autores()
        {
            Libros = new HashSet<Libros>();
        }

        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int? Pais { get; set; }

        public virtual ICollection<Libros> Libros { get; set; }
    }
}
