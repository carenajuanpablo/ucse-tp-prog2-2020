using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lógica
{
    public class Docente : Usuario
    {
        public List<Sala> Salas { get; set; }
        public Institucion Institucion { get; set; }
    }
}
