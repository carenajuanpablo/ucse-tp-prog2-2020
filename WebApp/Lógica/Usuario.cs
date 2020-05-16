using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lógica
{
    public enum Roles
    {
        Profesor, Padre, Director
    }
    class Usuario
    {
            public int ID { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Email { get; set; }
            public string Contraseña { get; set; }
            public Roles Roles { get; set; }
            public bool Activo { get; set; }

            public Roles RolSeleccionado { get; set; }
    }
}
