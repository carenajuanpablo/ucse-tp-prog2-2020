using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lógica
{
    class Docente : Usuario
    {
        public Sala[] Salas { get; set; }
        public Institucion Institucion { get; set; }
    }
}
