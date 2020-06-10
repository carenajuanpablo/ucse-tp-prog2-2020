using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contratos;
using Lógica;


namespace Servicios.Transformaciones
{
    public static class MétodosExtensión
    {
        public static Lógica.Director ConvertirDirector(Contratos.Directora director)
        {
            Lógica.Director Director = new Lógica.Director();
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
        public static Lógica.Docente ConvertirDocente(Contratos.Docente docente)
        {
            Lógica.Docente Docente = new Lógica.Docente();
            List<Lógica.Sala> salas = new List<Lógica.Sala>();
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
        public static Lógica.Sala ConvertirSala(Contratos.Sala sala)
        {
            Lógica.Sala Sala = new Lógica.Sala();
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
        public static Contratos.Sala[] ConvertirSalas(Lógica.Sala[] salas)
        {
            Contratos.Sala[] Salas = new Contratos.Sala[salas.Length];
            for (int i = 0; i < salas.Length; i++)
            {
                Salas[i] = ConvertirSala(salas[i]);
            }
            return Salas;
        }
        public static Lógica.Padre ConvertirPadre(Contratos.Padre padre)
        {
            Lógica.Padre Padre = new Lógica.Padre();
            List<Lógica.Hijo> hijos = new List<Lógica.Hijo>();
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
            foreach (var item in padre.ListaHijos)
            {
                Hijos[i] = ConvertirHijo(item);
                i++;
            }
            Padre.Hijos = Hijos;
            return Padre;
        }
        public static Lógica.Nota ConvertirNota(Contratos.Nota nota)
        {
            Lógica.Nota Nota = new Lógica.Nota();
            Nota.Id = nota.Id;
            Nota.Titulo = nota.Titulo;
            Nota.Descripcion = nota.Descripcion;
            Nota.FechaEventoAsociado = nota.FechaEventoAsociado;
            Nota.Leida = nota.Leida;
            Lógica.Comentario[] comentarios = new Lógica.Comentario[nota.Comentarios.Length];
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
        public static Lógica.Comentario ConvertirComentario(Contratos.Comentario comentario)
        {
            Lógica.Comentario Comentario = new Lógica.Comentario();
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
        public static Lógica.Hijo ConvertirHijo(Contratos.Hijo hijo)
        {
            Lógica.Hijo Hijo = new Lógica.Hijo();
            Hijo.Institucion = ConvertirInstitución(hijo.Institucion);
            Hijo.FechaNacimiento = hijo.FechaNacimiento;
            Hijo.ResultadoUltimaEvaluacionAnual = hijo.ResultadoUltimaEvaluacionAnual;
            Hijo.Sala = ConvertirSala(hijo.Sala);
            List<Lógica.Nota> notas = new List<Lógica.Nota>();
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
        public static Contratos.Hijo[] ConvertirHijos(Lógica.Hijo[] hijos)
        {
            Contratos.Hijo[] Hijos = new Contratos.Hijo[hijos.Length];
            for (int i = 0; i < hijos.Length; i++)
            {
                Hijos[i] = ConvertirHijo(hijos[i]);
            }
            return Hijos;
        }

        public static Lógica.Institucion ConvertirInstitución(Contratos.Institucion institucion)
        {
            Lógica.Institucion Institución = new Lógica.Institucion();
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
        public static Contratos.Institucion[] ConvertirInstituciones(Lógica.Institucion[] instituciones)
        {
            Contratos.Institucion[] Instituciones = new Contratos.Institucion[instituciones.Length];
            for (int i = 0; i < instituciones.Length; i++)
            {
                Instituciones[i] = ConvertirInstitución(instituciones[i]);
            }
            return Instituciones;
        }
        public static Lógica.Usuario ConvertirUsuario(Contratos.Usuario usuario)
        {
            Lógica.Usuario Usuario = new Lógica.Usuario();
            Usuario.ID = usuario.Id;
            Usuario.Nombre = usuario.Nombre;
            Usuario.Apellido = usuario.Apellido;
            Usuario.Email = usuario.Email;

            return Usuario;
        }
        public static Lógica.Usuario ConvertirUsuario(Contratos.UsuarioLogueado usuario)
        {
            Lógica.Usuario Usuario = new Lógica.Usuario();
            Usuario.Nombre = usuario.Nombre;
            Usuario.Apellido = usuario.Apellido;
            Usuario.Email = usuario.Email;
            Usuario.Roles = ConvertirRoles(usuario);
            Usuario.RolSeleccionado = (Lógica.Roles)usuario.RolSeleccionado;
            return Usuario;
        }
        
        public static Contratos.UsuarioLogueado ConvertirUsuarioLogueado(Lógica.Usuario usuario)
        {
            Contratos.UsuarioLogueado Usuario = new Contratos.UsuarioLogueado();
            Usuario.Nombre = usuario.Nombre;
            Usuario.Apellido = usuario.Apellido;
            Usuario.Email = usuario.Email;
            //REVISAR ROLES
            return Usuario;
        }        
        public static Contratos.Grilla<Directora> ConvertirGrillaDirectores(Grilla<Director> directores)
        {
            Contratos.Grilla<Directora> GrillaDir = new Contratos.Grilla<Directora>();
            int i = 0;
            foreach (var item in directores.Lista)
            {
                GrillaDir.Lista[i] = ConvertirDirector(item);
                i++;
            }
            GrillaDir.CantidadRegistros = directores.CantidadRegistros;
            return GrillaDir;

        }        
        public static Contratos.Grilla<Contratos.Docente> ConvertirGrillaDocentes(Grilla<Lógica.Docente> docentes)
        {
            Contratos.Grilla<Contratos.Docente> GrillaDoc = new Contratos.Grilla<Contratos.Docente>();
            int i = 0;
            foreach (var item in docentes.Lista)
            {
                GrillaDoc.Lista[i] = ConvertirDocente(item);
                i++;
            }
            GrillaDoc.CantidadRegistros = docentes.CantidadRegistros;
            return GrillaDoc;
        }        
        public static Contratos.Grilla<Contratos.Padre> ConvertirGrillaPadres(Grilla<Lógica.Padre> padres)
        {
            Contratos.Grilla<Contratos.Padre> GrillaPad = new Contratos.Grilla<Contratos.Padre>();
            int i = 0;
            foreach (var item in padres.Lista)
            {
                GrillaPad.Lista[i] = ConvertirPadre(item);
                i++;
            }
            GrillaPad.CantidadRegistros = padres.CantidadRegistros;
            return GrillaPad;
        }
        public static Contratos.Grilla<Contratos.Hijo> ConvertirGrillaHijos(Grilla<Lógica.Hijo> hijos)
        {
            Contratos.Grilla<Contratos.Hijo> GrillaHijo = new Contratos.Grilla<Contratos.Hijo>();
            int i = 0;
            foreach (var item in hijos.Lista)
            {
                GrillaHijo.Lista[i] = ConvertirHijo(item);
                i++;
            }
            GrillaHijo.CantidadRegistros = hijos.CantidadRegistros;
            return GrillaHijo;
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
            Lógica.Roles Rol = new Lógica.Roles();
            Rol = (Lógica.Roles)rol;
            return Rol;
        }
        public static Lógica.Roles[] ConvertirRoles(Contratos.UsuarioLogueado usuario)
        {
            Lógica.Roles[] Roles = new Lógica.Roles[usuario.Roles.Length];
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
