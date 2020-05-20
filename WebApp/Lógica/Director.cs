using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lógica
{
    public class Director : Usuario
    {
        public Institucion Institucion { get; set; }
        public string Cargo { get; set; }
        public DateTime? FechaIngreso { get; set; }
    }
}
