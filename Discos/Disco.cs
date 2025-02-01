using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemplo_ado_net
{
    internal class Disco
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public int CantidadCanciones { get; set; }
        public DatoDisco Estilo { get; set; }
        public DatoDisco Edicion { get; set; }
        public string UrlImagen { get; set; }
    }
}
