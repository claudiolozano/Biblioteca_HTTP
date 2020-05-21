using System;
using System.Collections.Generic;

namespace Biblioteca_HTTP.Models
{
    public partial class Libros
    {
        public Libros()
        {
            Bibliografias = new HashSet<Bibliografias>();
        }

        public int IdLibro { get; set; }
        public string Nombre { get; set; }
        public int? Paginas { get; set; }
        public string Autor { get; set; }
        public string Comentarios { get; set; }

        public virtual Autores AutorNavigation { get; set; }
        public virtual ICollection<Bibliografias> Bibliografias { get; set; }
    }
}
