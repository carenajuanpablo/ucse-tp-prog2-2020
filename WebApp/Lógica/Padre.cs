using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lógica
{
    class Padre : Usuario
    {
        public List<Hijo> ListaHijos { get; set; }

    }
}
