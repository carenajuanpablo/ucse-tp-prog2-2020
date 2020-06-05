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
        public static Director ConvertirDirector(Contratos.Directora director)
        {
            Director Director = new Director();
            Director.Institucion = ConvertirInstitución(director.Institucion);
            Director.Cargo = director.Cargo;
            Director.FechaIngreso = director.FechaIngreso;

            return Director;
        }
        public static Docente ConvertirDocente(Contratos.Docente docente)
        {
            Docente Docente = new Docente();
            List<Sala> salas = new List<Sala>();
            foreach (var item in docente.Salas)
            {
                salas.Add(ConvertirSala(item));
            }
            Docente.Salas = salas;
            //FALTA INSTITUCION

            return Docente;
        }
        public static Sala ConvertirSala(Contratos.Sala sala)
        {
            Sala Sala = new Sala();
            Sala.Id = sala.Id;
            Sala.Nombre = sala.Nombre;
            //FALTA LISTA ALUMNOS

            return Sala;
        }
        public static Padre ConvertirPadre(Contratos.Padre padre)
        {
            Padre Padre = new Padre();
            List<Hijo> hijos = new List<Hijo>();
            foreach (var item in padre.Hijos)
            {
                hijos.Add(ConvertirHijo(item));
            }
            Padre.ListaHijos = hijos;

            return Padre;
        }
        public static Nota ConvertirNota(Contratos.Nota nota)
        {
            Nota Nota = new Nota();
            Nota.Id = nota.Id;
            Nota.Titulo = nota.Titulo;
            Nota.Descripcion = nota.Descripcion;
            Nota.FechaEventoAsociado = nota.FechaEventoAsociado;
            Nota.Leida = nota.Leida;
            Comentario[] comentarios = new Comentario[nota.Comentarios.Length];
            for (int i = 0; i < nota.Comentarios.Length; i++)
            {
                comentarios[i] = ConvertirComentario(nota.Comentarios[i]);
            }
            Nota.Comentarios = comentarios;

            return Nota;
        }
        public static Comentario ConvertirComentario(Contratos.Comentario comentario)
        {
            Comentario Comentario = new Comentario();
            Comentario.Usuario = ConvertirUsuario(comentario.Usuario);
            Comentario.Fecha = comentario.Fecha;
            Comentario.Mensaje = comentario.Mensaje;

            return Comentario;
        }
        public static Hijo ConvertirHijo(Contratos.Hijo hijo)
        {
            Hijo Hijo = new Hijo();
            Hijo.Institucion = ConvertirInstitución(hijo.Institucion);
            Hijo.FechaNacimiento = hijo.FechaNacimiento;
            Hijo.ResultadoUltimaEvaluacionAnual = hijo.ResultadoUltimaEvaluacionAnual;
            Hijo.Sala = ConvertirSala(hijo.Sala);
            List<Nota> notas = new List<Nota>();
            foreach (var item in hijo.Notas)
            {
                notas.Add(ConvertirNota(item));
            }
            Hijo.Notas = notas;

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
            //FALTA LISTA DE SALAS

            return Institución;
        }
        public static Usuario ConvertirUsuario(Contratos.Usuario usuario)
        {
            Usuario Usuario = new Usuario();
            Usuario.ID = usuario.Id;
            Usuario.Nombre = usuario.Nombre;
            Usuario.Apellido = usuario.Apellido;
            Usuario.Email = usuario.Email;

            return Usuario;
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
        public static Lógica.Roles[] ConvertirRoles(Contratos.UsuarioLogueado usuario)
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
