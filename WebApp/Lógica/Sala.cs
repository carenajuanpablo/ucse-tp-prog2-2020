using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lógica
{
    public class Sala
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Hijo> alumnos = new List<Hijo>();
        public Institucion institucion = new Institucion();
    }
}
