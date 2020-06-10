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
        public static Contratos.Directora ConvertirDirector(Lógica.Director director)
        {
            Contratos.Directora Director = new Contratos.Directora();
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
        public static Contratos.Docente ConvertirDocente(Lógica.Docente docente)
        {
            Contratos.Docente Docente = new Contratos.Docente();
            Contratos.Sala[] salas = new Contratos.Sala[docente.Salas.Count];
            for (int i = 0; i < docente.Salas.Count; i++)
            {
                salas[i] = ConvertirSala(docente.Salas[i]);
            }
            Docente.Salas = salas;
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
        public static Contratos.Sala ConvertirSala(Lógica.Sala sala)
        {
            Contratos.Sala Sala = new Contratos.Sala();
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
        public static Contratos.Padre ConvertirPadre(Lógica.Padre padre)
        {
            Contratos.Padre Padre = new Contratos.Padre();
            Contratos.Hijo[] Hijos = new Contratos.Hijo[padre.ListaHijos.Count];
            int i = 0;
            foreach (Hijo item in padre.ListaHijos)
            {
                Hijos[i] = ConvertirHijo(item);
                i++;
            }
            Padre.Hijos = Hijos;
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
        public static Contratos.Nota ConvertirNota(Lógica.Nota nota)
        {
            Contratos.Nota Nota = new Contratos.Nota();
            Nota.Id = nota.Id;
            Nota.Titulo = nota.Titulo;
            Nota.Descripcion = nota.Descripcion;
            Nota.FechaEventoAsociado = nota.FechaEventoAsociado;
            Nota.Leida = nota.Leida;
            Contratos.Comentario[] comentarios = new Contratos.Comentario[nota.Comentarios.Length];
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
        public static Contratos.Comentario ConvertirComentario(Lógica.Comentario comentario)
        {
            Contratos.Comentario Comentario = new Contratos.Comentario();
            Comentario.Usuario = ConvertirUsuario(comentario.Usuario);
            ConvertirUsuario(comentario.Usuario);
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
        public static Contratos.Hijo ConvertirHijo(Lógica.Hijo hijo)
        {
            Contratos.Hijo Hijo = new Contratos.Hijo();
            Hijo.Institucion = ConvertirInstitución(hijo.Institucion);
            Hijo.FechaNacimiento = hijo.FechaNacimiento;
            Hijo.ResultadoUltimaEvaluacionAnual = hijo.ResultadoUltimaEvaluacionAnual;
            Hijo.Sala = ConvertirSala(hijo.Sala);
            Contratos.Nota[] Notas = new Contratos.Nota[hijo.Notas.Count];
            int i = 0;
            foreach (var item in hijo.Notas)
            {
                Notas[i] = ConvertirNota(item);
                i++;
            }
            Hijo.Notas = Notas;
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
        public static Contratos.Institucion ConvertirInstitución(Lógica.Institucion institucion)
        {
            Contratos.Institucion Institución = new Contratos.Institucion();
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
        
        public static Contratos.Usuario ConvertirUsuario(Lógica.Usuario usuario)
        {
            Contratos.Usuario Usuario = new Contratos.Usuario();
            Usuario.Nombre = usuario.Nombre;
            Usuario.Apellido = usuario.Apellido;
            Usuario.Email = usuario.Email;
            Usuario.Id = usuario.ID;            
            //REVISAR ROLES, ROLSELECCIONADO
            return Usuario;
        }
        
        public static Lógica.Roles ConvertirRol(Contratos.Roles rol)
        {
            Roles Rol = new Roles();
            Rol = rol;
            return Rol;
        }
        public static Lógica.Roles[] ConvertirRoles(Contratos.UsuarioLogueado usuario)
        {
            Roles[] Roles = new Roles[usuario.Roles.Length];
            for (int i = 0; i < usuario.Roles.Length; i++)
            {
                Roles[i] = ConvertirRol(usuario.Roles[i]);
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
