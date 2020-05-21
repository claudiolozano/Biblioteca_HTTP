using System;
using System.Collections.Generic;

namespace Biblioteca_HTTP.Models
{
    public partial class Bibliografias
    {
        public int IdBlibliografia { get; set; }
        public int? Libro { get; set; }
        public int? Editorial { get; set; }
        public decimal? Precio { get; set; }
        public string Comentarios { get; set; }

        public virtual Editoriales EditorialNavigation { get; set; }
        public virtual Libros LibroNavigation { get; set; }
    }
}
