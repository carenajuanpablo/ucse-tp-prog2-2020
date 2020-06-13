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
            if (director.Institucion != null)
            {
                Director.Institucion = ConvertirInstitución(director.Institucion);
            }
            Director.Cargo = director.Cargo;
            Director.FechaIngreso = director.FechaIngreso;
            Director.Nombre = director.Nombre;
            Director.Apellido = director.Apellido;
            Director.Email = director.Email;
            Director.ID = director.Id;

            return Director;
        }
        public static Contratos.Directora ConvertirDirector(Lógica.Director director)
        {
            Contratos.Directora Director = new Contratos.Directora();
            if (director.Institucion != null)
            {
                Director.Institucion = ConvertirInstitución(director.Institucion);
            }
            Director.Nombre = director.Nombre;
            Director.Apellido = director.Apellido;
            Director.Email = director.Email;
            Director.Id = director.ID;
            Director.Cargo = director.Cargo;
            Director.FechaIngreso = director.FechaIngreso;
            return Director;
        }
        public static Lógica.Docente ConvertirDocente(Contratos.Docente docente)
        {
            Lógica.Docente Docente = new Lógica.Docente();
            Docente.Nombre = docente.Nombre;
            Docente.Apellido = docente.Apellido;
            Docente.Email = docente.Email;
            Docente.ID = docente.Id;
            if (docente.Salas != null)
            {
                List<Lógica.Sala> salas = new List<Lógica.Sala>();
                foreach (var item in docente.Salas)
                {
                    salas.Add(ConvertirSala(item));
                }
                Docente.Salas = salas;
            }

            //FALTA INSTITUCION

            return Docente;
        }
        public static Contratos.Docente ConvertirDocente(Lógica.Docente docente)
        {
            Contratos.Docente Docente = new Contratos.Docente();
            Docente.Nombre = docente.Nombre;
            Docente.Apellido = docente.Apellido;
            Docente.Email = docente.Email;
            Docente.Id = docente.ID;
            if (docente.Salas!=null)
            {
                Contratos.Sala[] salas = new Contratos.Sala[docente.Salas.Count];
                for (int i = 0; i < docente.Salas.Count; i++)
                {
                    salas[i] = ConvertirSala(docente.Salas[i]);
                }
                Docente.Salas = salas;
            }

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
            if (padre.Hijos != null)
            {
                foreach (var item in padre.Hijos)
                {
                    hijos.Add(ConvertirHijo(item));
                    
                }
                Padre.ListaHijos = hijos;
            }
            Padre.Nombre = padre.Nombre;
            Padre.Apellido = padre.Apellido;
            Padre.Email = padre.Email;
            Padre.ID = padre.Id;
            
            return Padre;
        }
        public static Contratos.Padre ConvertirPadre(Lógica.Padre padre)
        {
            Contratos.Padre Padre = new Contratos.Padre();
            if (padre.ListaHijos != null)
            {
                Contratos.Hijo[] Hijos = new Contratos.Hijo[padre.ListaHijos.Count];
                int i = 0;
                foreach (var item in padre.ListaHijos)
                {
                    Hijos[i] = ConvertirHijo(item);
                    i++;
                }
                Padre.Hijos = Hijos;
            }
            Padre.Nombre = padre.Nombre;
            Padre.Apellido = padre.Apellido;
            Padre.Email = padre.Email;
            Padre.Id = padre.ID;
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
          //  Hijo.Institucion = ConvertirInstitución(hijo.Institucion);
            Hijo.FechaNacimiento = hijo.FechaNacimiento;
            Hijo.Nombre = hijo.Nombre;
            Hijo.Apellido = hijo.Apellido;
            Hijo.Email = hijo.Email;            
            Hijo.ID = hijo.Id;
            Hijo.ResultadoUltimaEvaluacionAnual = hijo.ResultadoUltimaEvaluacionAnual;
            if (hijo.Sala != null)
            {
                Hijo.Sala = ConvertirSala(hijo.Sala);
            }

            if (hijo.Notas != null)
            {
                List<Lógica.Nota> notas = new List<Lógica.Nota>();
                foreach (var item in hijo.Notas)
                {
                    notas.Add(ConvertirNota(item));
                }
                Hijo.Notas = notas;
            }


            return Hijo;
        }
        public static Contratos.Hijo ConvertirHijo(Lógica.Hijo hijo)
        {
            Contratos.Hijo Hijo = new Contratos.Hijo();
            //Hijo.Institucion = ConvertirInstitución(hijo.Institucion);
            Hijo.FechaNacimiento = hijo.FechaNacimiento;
            Hijo.Nombre = hijo.Nombre;
            Hijo.Apellido = hijo.Apellido;
            Hijo.Email = hijo.Email;
            Hijo.Id = hijo.ID;
            Hijo.ResultadoUltimaEvaluacionAnual = hijo.ResultadoUltimaEvaluacionAnual;
            if (hijo.Sala != null)
            {
                Hijo.Sala = ConvertirSala(hijo.Sala);
            }
            if (hijo.Notas != null)
            {
                Contratos.Nota[] Notas = new Contratos.Nota[hijo.Notas.Count];
                int i = 0;
                foreach (var item in hijo.Notas)
                {
                    Notas[i] = ConvertirNota(item);
                    i++;
                }
                Hijo.Notas = Notas;
            }
            
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
            Usuario.ID = usuario.Id;
            
            return Usuario;
        }
        public static Lógica.Usuario ConvertirUsuario(Contratos.UsuarioLogueado usuario)
        {
            Lógica.Usuario Usuario = new Lógica.Usuario();
            Usuario.Nombre = usuario.Nombre;
            Usuario.Apellido = usuario.Apellido;                
            Usuario.Email = usuario.Email;
            Usuario.Roles = ConvertirRoles(usuario);
            Usuario.RolSeleccionado = ConvertirRolSeleccionado(usuario.RolSeleccionado);

            return Usuario;
        }
        
        public static Contratos.UsuarioLogueado ConvertirUsuarioLogueado(Lógica.Usuario usuario)
        {
            Contratos.UsuarioLogueado Usuario = new Contratos.UsuarioLogueado();
            Usuario.Nombre = usuario.Nombre;
            Usuario.Apellido = usuario.Apellido;
            Usuario.Email = usuario.Email;
            Usuario.Roles = ConvertirRoles(usuario);
            Usuario.RolSeleccionado = ConvertirRolSeleccionado(usuario.RolSeleccionado);
            //REVISAR ROLES
            return Usuario;
        }     
        public static Contratos.Roles ConvertirRolSeleccionado(Lógica.Roles rol)
        {
            Contratos.Roles Rol = new Contratos.Roles();
            Rol = (Contratos.Roles)rol;
            return Rol;
        }
        public static Lógica.Roles ConvertirRolSeleccionado(Contratos.Roles rol)
        {
            Lógica.Roles Rol = new Lógica.Roles();
            Rol = (Lógica.Roles)rol;
            return Rol;
        }
        public static Contratos.Grilla<Directora> ConvertirGrillaDirectores(Grilla<Director> directores)
        {
            Contratos.Grilla<Directora> GrillaDir = new Contratos.Grilla<Directora>();
            Directora[] Dir = new Directora[directores.CantidadRegistros];
            /*
            for (int i = 0; i < directores.CantidadRegistros; i++)
            {
                GrillaDir.Lista[i] = ConvertirDirector(directores.Lista[i]);
            }
            */
            int i = 0;
            foreach (var item in directores.Lista)
            {
                Dir[i] = ConvertirDirector(item);
                //GrillaDir.Lista[i] = ConvertirDirector(item);
                i = i +1;
            }
            GrillaDir.Lista = Dir;
            GrillaDir.CantidadRegistros = directores.CantidadRegistros;
            return GrillaDir;

        }        
        public static Contratos.Grilla<Contratos.Docente> ConvertirGrillaDocentes(Grilla<Lógica.Docente> docentes)
        {
            Contratos.Grilla<Contratos.Docente> GrillaDoc = new Contratos.Grilla<Contratos.Docente>();
            Contratos.Docente[] Doc = new Contratos.Docente[docentes.CantidadRegistros];

            int i = 0;
            foreach (var item in docentes.Lista)
            {
                Doc[i] = ConvertirDocente(item);
                i = i +1;
            }
            GrillaDoc.CantidadRegistros = docentes.CantidadRegistros;
            GrillaDoc.Lista = Doc;
            return GrillaDoc;
        }        
        public static Contratos.Grilla<Contratos.Padre> ConvertirGrillaPadres(Grilla<Lógica.Padre> padres)
        {
            Contratos.Grilla<Contratos.Padre> GrillaPad = new Contratos.Grilla<Contratos.Padre>();
            Contratos.Padre[] Pad = new Contratos.Padre[padres.CantidadRegistros];
            int i = 0;
            foreach (var item in padres.Lista)
            {
                Pad[i] = ConvertirPadre(item);
                i++;
            }
            GrillaPad.CantidadRegistros = padres.CantidadRegistros;
            GrillaPad.Lista = Pad;
            return GrillaPad;
        }
        public static Contratos.Grilla<Contratos.Hijo> ConvertirGrillaHijos(Grilla<Lógica.Hijo> hijos)
        {
            Contratos.Grilla<Contratos.Hijo> GrillaHijo = new Contratos.Grilla<Contratos.Hijo>();
            Contratos.Hijo[] Hij = new Contratos.Hijo[hijos.CantidadRegistros];

            int i = 0;
            foreach (var item in hijos.Lista)
            {
                Hij[i] = ConvertirHijo(item);
                i++;
            }
            GrillaHijo.CantidadRegistros = hijos.CantidadRegistros;
            GrillaHijo.Lista = Hij;
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
        public static Contratos.Roles ConvertirRol(Lógica.Roles rol)
        {
            Contratos.Roles Rol = new Contratos.Roles();
            Rol = (Contratos.Roles)rol;
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
        public static Contratos.Roles[] ConvertirRoles(Lógica.Usuario usuario)
        {
            Contratos.Roles[] Roles = new Contratos.Roles[usuario.Roles.Length];
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
