using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lógica;


namespace Servicios.Transformaciones
{
    public static class MétodosExtensión
    {
        public static Hijo ConvertirHijo(Contratos.Hijo hijo)
        {
            Hijo Hijo = new Hijo();
            Hijo.Institucion = ConvertirInstitución(hijo.Institucion);
            Hijo.FechaNacimiento = hijo.FechaNacimiento;
            Hijo.ResultadoUltimaEvaluacionAnual = hijo.ResultadoUltimaEvaluacionAnual;
            hijo.Sala = hijo.Sala;
            hijo.Notas = hijo.Notas;

            return Hijo;
        }
        public static Institucion ConvertirInstitución(Contratos.Institucion institucion)
        {
            Institucion Institución = new Institucion();
            Institución.Id = institucion.Id;
            Institución.Nombre = institucion.Nombre;
            Institución.Direccion = institucion.Direccion;
            Institución.Telefono = institucion.Telefono;
            Institución.Ciudad = institucion.Ciudad;
            Institución.Provincia = institucion.Provincia;

            return Institución;
        }
        public static Usuario ConvertirUsuario(Contratos.UsuarioLogueado usuario)
        {
            Usuario Usuario = new Usuario();
            Usuario.Nombre = usuario.Nombre;
            Usuario.Apellido = usuario.Apellido;
            Usuario.Email = usuario.Email;
            Usuario.Roles = ConvertirRoles(usuario);
            Usuario.RolSeleccionado = (Roles)usuario.RolSeleccionado;
            return Usuario;
        }
        public static Lógica.Roles[] ConvertirRoles (Contratos.UsuarioLogueado usuario)
        {
            Roles[] Roles = new Roles[usuario.Roles.Length];
            for (int i = 0; i < usuario.Roles.Length; i++)
            {
                Roles[i] = usuario.Roles.[i];
            }
            return Roles;
        }      
        
        public static Contratos.Resultado ConvertirResultado(Lógica.Resultado res)
        {
            Contratos.Resultado Res = new Contratos.Resultado();
            Res.Errores = res.Errores;
            return Res;
        }
    }
}
