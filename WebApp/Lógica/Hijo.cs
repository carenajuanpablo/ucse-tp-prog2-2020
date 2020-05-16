using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lógica
{
    class Hijo : Usuario
    {
        public Institucion Institucion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int ResultadoUltimaEvaluacionAnual { get; set; }
        public Sala Sala { get; set; }
        public List<Nota> Notas { get; set; }
    }
}
