using System;
using System.Collections.Generic;

namespace Biblioteca_HTTP.Models
{
    public partial class Editoriales
    {
        public Editoriales()
        {
            Bibliografias = new HashSet<Bibliografias>();
        }

        public int IdEditorial { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Bibliografias> Bibliografias { get; set; }
    }
}
