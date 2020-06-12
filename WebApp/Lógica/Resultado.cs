using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lógica
{
    public class Resultado
    {
        public List<string> Errores = new List<string>();
        public bool EsValido { get { return this.Errores.Count == 0 ; } }
    }
}
