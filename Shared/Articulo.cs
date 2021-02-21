using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appBlazorIntro.Shared
{
   public class Articulo
    {
        public string Categoria { get; set; }
        public string NombreArticulo { get; set; }
        public bool IsConsumo { get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}
