using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lógica
{
    public class ClasePrincipal
    {
        List<Institución> instituciones = new List<Institución>();
        List<Hijo> hijos = new List<Hijo>();
        List<Padre> padres = new List<Padre>();
        List<Docente> docentes = new List<Docente>();
        List<Director> directores = new List<Director>();
        /// <summary>
        /// Nombre de los integrantes del grupo de trabajo
        /// </summary>
        /// <returns></returns>
        string ObtenerNombreGrupo()
        {
            return $"Integrantes: Pedro Fassanelli - Juan Pablo Carena";
        }

        private List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> res = new List<Usuario>();
            res.AddRange(hijos);
            res.AddRange(padres);
            res.AddRange(docentes);
            res.AddRange(directores);
            foreach (var item in res)
            {
                if (item.Activo)
                {
                    res.Add(item);
                }
            }
            return res;
        }
        /// <summary>
        /// Retorna un usuario logueado a partir de sus credenciales
        /// </summary>
        /// <param name="email"></param>
        /// <param name="clave"></param>
        /// <returns></returns>
        Usuario ObtenerUsuario(string email, string clave)
        {
            List<Usuario> Usuarios = ObtenerUsuarios();
            Usuario UsuarioEncontrado = null;

            foreach (var item in Usuarios)
            {
                if ((item.Email == email) && (item.Contraseña == clave))
                {
                    UsuarioEncontrado = item;
                    break;
                }
            }

            return UsuarioEncontrado;
        }

        /// <summary>
        /// Obtiene un listado de instituciones guardada
        /// </summary>
        /// <returns></returns>
        Institucion[] ObtenerInstituciones();


        /// <summary>
        /// El usuario logueado debe ser una directora del mismo institucion
        /// </summary>
        /// <param name="directora"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado AltaDirector(Director director, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            if (usuarioLogueado.RolSeleccionado == Roles.Director)
            {
                //COMPROBAR INSTITUCION
                Director directorLogged = usuarioLogueado as Director;
                if (directorLogged.Institucion == director.Institucion)
                {
                    var Existe = directores.First(x => x.ID == director.ID);
                    if (Existe == null)
                    {
                        director.ID = directores.Count + 1;
                        directores.Add(director);
                    }
                    else
                    {
                        res.Errores.Add("Director existente");
                    }

                }
                else
                {
                    res.Errores.Add("La institucion no coincide");
                }
            }
            else
            {
                res.Errores.Add("El usuario logueado no es director.");
            }
            return res;
        }

        /// <summary>
        /// El usuario logueado debe ser una directora
        /// </summary>
        /// <param name="hijo"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado AltaAlumno(Hijo hijo, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            if (usuarioLogueado.RolSeleccionado == Roles.Director)
            {
                Director directorLogged = usuarioLogueado as Director;
                if (directorLogged.Institucion == hijo.Institucion)
                {
                    var Existe = hijos.First(x => x.ID == hijo.ID);
                    if (Existe == null)
                    {
                        hijo.ID = hijos.Count + 1;
                        hijos.Add(hijo);
                    }
                    else
                    {
                        res.Errores.Add("Alumno existente");
                    }
                }
                else
                {
                    res.Errores.Add("La institucion no coincide.");
                }
            }
            else
            {
                res.Errores.Add("El usuario logueado no es directora.");
            }
            return res;
        }

        /// <summary>
        /// El usuario logueado debe ser una directora
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hijo"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado EditarAlumno(int id, Hijo hijo, UsuarioLogueado usuarioLogueado);

        /// <summary>
        /// El usuario logueado debe ser una directora
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hijo"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado EliminarAlumno(int id, Hijo hijo, UsuarioLogueado usuarioLogueado);

        /// <summary>
        /// El usuario logueado debe ser una directora del mismo institucion
        /// </summary>
        /// <param name="directora"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado EditarDirectora(int id, Directora directora, UsuarioLogueado usuarioLogueado);
        /// <summary>
        /// El usuario logueado debe ser una directora del mismo institucion
        /// </summary>
        /// <param name="directora"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado EliminarDirectora(int id, Directora directora, UsuarioLogueado usuarioLogueado);
        /// <summary>
        /// Las salas son de la institucion del usuario logueado
        /// </summary>
        /// <param name="institucion"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Sala[] ObtenerSalasPorInstitucion(UsuarioLogueado usuarioLogueado);
        /// <summary>
        /// El usuario logueado debe ser una directora del mismo institucion
        /// </summary>
        /// <param name="docente"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado AltaDocente(Docente docente, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            if (usuarioLogueado.RolSeleccionado == Roles.Director)
            {

                //COMPROBAR INSTITUCION
                Director directorLogged = usuarioLogueado as Director;                
                if (directorLogged.Institucion == docente.Institucion)
                {
                    var Existe = docentes.First(x => x.ID == docente.ID);
                    if (Existe == null)
                    {
                        docente.ID = docentes.Count + 1;
                        docentes.Add(docente);
                    }
                    else
                    {
                        res.Errores.Add("Docente existente");
                    }
                }
                else
                {
                    res.Errores.Add("La institucion no coincide.");
                }
            }
            else
            {
                res.Errores.Add("El usuario logueado no es directora.");
            }
            return res;
        }
        /// <summary>
        /// El usuario logueado debe ser una directora del mismo institucion
        /// </summary>
        /// <param name="id"></param>
        /// <param name="docente"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado EditarDocente(int id, Docente docente, UsuarioLogueado usuarioLogueado);
        /// <summary>
        /// El usuario logueado debe ser una directora del mismo institucion
        /// </summary>
        /// <param name="id"></param>
        /// <param name="docente"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado EliminarDocente(int id, Docente docente, UsuarioLogueado usuarioLogueado);
        /// <summary>
        /// El usuario debe ser directora del mismo institucion
        /// </summary>
        /// <param name="padre"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado AltaPadreMadre(Padre padre, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            if (usuarioLogueado.RolSeleccionado == Roles.Director)
            {
                var Existe = padres.First(x => x.ID == padre.ID);
                if (Existe == null)
                {
                    padre.ID = padres.Count + 1;
                    padres.Add(padre);
                }
                else
                {
                    res.Errores.Add("Padre existente");
                }
            }
            else
            {
                res.Errores.Add("El usuario logueado no es director.");
            }
            return res;
        }
        /// <summary>
        /// El usuario debe ser directora del mismo institucion
        /// </summary>
        /// <param name="padre"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado EditarPadreMadre(int id, Padre padre, UsuarioLogueado usuarioLogueado);
        /// <summary>
        /// El usuario debe ser directora del mismo institucion
        /// </summary>
        /// <param name="padre"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado EliminarPadreMadre(int id, Padre padre, UsuarioLogueado usuarioLogueado);
        /// <summary>
        /// El usuario debe ser directora, y tanto la sala como el docente deben pertenecer a su institucion.
        /// </summary>
        /// <param name="docente"></param>
        /// <param name="sala"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado AsignarDocenteSala(Docente docente, Sala sala, UsuarioLogueado usuarioLogueado);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="docente"></param>
        /// <param name="sala"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado DesasignarDocenteSala(Docente docente, Sala sala, UsuarioLogueado usuarioLogueado);
        /// <summary>
        /// El usuario debe ser directora, y el hijo debe estar asociado a una sala de su institucion
        /// </summary>
        /// <param name="hijo"></param>
        /// <param name="padre"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado AsignarHijoPadre(Hijo hijo, Padre padre, UsuarioLogueado usuarioLogueado);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hijo"></param>
        /// <param name="padre"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado DesasignarHijoPadre(Hijo hijo, Padre padre, UsuarioLogueado usuarioLogueado);
        /// <summary>
        /// Si el usuario es directora, retornar alumnos de la institucion, si es docente los de sus salas, y si es padre solo sus hijos.
        /// </summary>        
        /// <returns></returns>
        Hijo[] ObtenerPersonas(UsuarioLogueado usuarioLogueado);
        /// <summary>
        /// Obtiene las notas de un cuaderno, si el usuario es padre solo puede obtener cuadernos de sus hijos, si es docente de alumnos de sus salas
        /// y si es directora de cualquier alumno de la institucion
        /// </summary>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Nota[] ObtenerCuadernoComunicaciones(int idPersona, UsuarioLogueado usuarioLogueado);
        /// <summary>
        /// Alta de una nota, la nota puede estar dirigida a 1 o varias salas, o 1 o varios alumnos. Si el usuario es padre solamente podra enviar a sus hijos.
        /// </summary>
        /// <param name="nota"></param>
        /// <param name="salas"></param>
        /// <param name="hijos"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado AltaNota(Nota nota, Sala[] salas, Hijo[] hijos, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado { Errores = new List<string>() };
            switch (usuarioLogueado.RolSeleccionado)
            {
                case Roles.Profesor:
                    {
                        Docente docente = usuarioLogueado as Docente;
                        if (salas.Length > 0)
                        {
                            foreach (Sala sala in salas)
                            {
                                foreach (Hijo hijo in sala.alumnos)
                                {
                                    var Coincide = docente.Salas.FirstOrDefault(x => x.Id == hijo.Sala.Id);
                                    if (Coincide != null)
                                    {
                                        hijo.Notas.Add(nota);
                                    }
                                    else
                                    {
                                        res.Errores.Add($"El alumno cuyo ID es {hijo.ID} no pertenece a una sala del profesor");
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach (Hijo hijo in hijos)
                            {
                                var Coincide = docente.Salas.FirstOrDefault(x => x.Id == hijo.Sala.Id);
                                if (Coincide != null)
                                {
                                    hijo.Notas.Add(nota);
                                }
                                else
                                {
                                    res.Errores.Add($"El alumno cuyo ID es {hijo.ID} no pertenece a una sala del profesor");

                                }
                            }
                        }
                    }
                    break;
                case Roles.Director:
                    {
                        Director director = usuarioLogueado as Director;
                        if (salas.Length > 0)
                        {
                            foreach (var sala in salas)
                            {
                                foreach (var hijo in sala.alumnos)
                                {
                                    if (hijo.Institucion == director.Institucion)
                                    {
                                        hijo.Notas.Add(nota);
                                    }
                                    else
                                    {
                                        res.Errores.Add($"El alumno cuyo ID es {hijo.ID} no pertenece a la institución del Director");
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach (Hijo hijo in hijos)
                            {
                                if (hijo.Institucion == director.Institucion)
                                {
                                    hijo.Notas.Add(nota);
                                }
                                else
                                {
                                    res.Errores.Add($"El alumno cuyo ID es {hijo.ID} no pertenece a la institución del Director");
                                }
                            }
                        }
                    }
                    break;
                    //case Roles.Padre:
                    //    break;
            }
            return res;
        }
        /// <summary>
        /// Respuesta a una nota. Si es docente la nota debe ser de un alumno de la sala
        /// </summary>
        /// <param name="nota"></param>
        /// <param name="nuevoComentario"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado ResponderNota(Nota nota, Comentario nuevoComentario, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado { Errores = new List<string>() };
            switch (usuarioLogueado.RolSeleccionado)
            {
                case Roles.Profesor:
                    Docente docente = usuarioLogueado as Docente;
                    var esAlumno = docente.Salas.FirstOrDefault(x => x.alumnos.Any(y => y.Notas.Any(z => z.Id == nota.Id)));
                    if (esAlumno != null)
                    {
                        var comment = nota.Comentarios == null ? new List<Comentario>() : nota.Comentarios.ToList();
                        comment.Add(nuevoComentario);
                        nota.Comentarios = comment.ToArray();
                    }
                    else
                    {
                        res.Errores.Add($"La nota {nota.Id} no corresponde a un alumno del profesor");
                    }
                    break;
                case Roles.Padre:
                    Padre padre = usuarioLogueado as Padre;
                    var esHijo = padre.ListaHijos.First(x => x.Notas.Any(y => y.Id == nota.Id));
                    if (esHijo != null)
                    {
                        var comment = nota.Comentarios == null ? new List<Comentario>() : nota.Comentarios.ToList();
                        comment.Add(nuevoComentario);
                        nota.Comentarios = comment.ToArray();
                    }
                    else
                    {
                        res.Errores.Add($"La nota {nota.Id} no corresponde a un hijo del usuario logueado");
                    }
                    break;
                case Roles.Director:
                    Director director = usuarioLogueado as Director;
                    var alumno = hijos.First(x => x.Notas.Any(y => y.Id == nota.Id));
                    if (director.Institucion == alumno.Institucion)
                    {
                        var comment = nota.Comentarios == null ? new List<Comentario>() : nota.Comentarios.ToList();
                        comment.Add(nuevoComentario);
                        nota.Comentarios = comment.ToArray();
                    }
                    else
                    {
                        res.Errores.Add($"La nota {nota.Id} no corresponde a un alumno de la institución del director");
                    }
                    break;
            }
            return res;
        }
        /// <summary>
        /// Marca la nota como leida si le corresponde.
        /// </summary>
        /// <param name="nota"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado MarcarNotaComoLeida(Nota nota, UsuarioLogueado usuarioLogueado);

        /// <summary>
        /// Grilla de directoras
        /// </summary>
        /// <param name="usuarioLogueado"></param>
        /// <param name="paginaActual"></param>
        /// <param name="totalPorPagina"></param>
        /// <param name="busquedaGlobal"></param>
        /// <returns></returns>
        Grilla<Directora> ObtenerDirectoras(UsuarioLogueado usuarioLogueado, int paginaActual, int totalPorPagina, string busquedaGlobal);

        /// <summary>
        /// Grilla de docentes
        /// </summary>
        /// <param name="usuarioLogueado"></param>
        /// <param name="paginaActual"></param>
        /// <param name="totalPorPagina"></param>
        /// <param name="busquedaGlobal"></param>
        /// <returns></returns>
        Grilla<Docente> ObtenerDocentes(UsuarioLogueado usuarioLogueado, int paginaActual, int totalPorPagina, string busquedaGlobal);

        /// <summary>
        /// Grilla de padres
        /// </summary>
        /// <param name="usuarioLogueado"></param>
        /// <param name="paginaActual"></param>
        /// <param name="totalPorPagina"></param>
        /// <param name="busquedaGlobal"></param>
        /// <returns></returns>
        Grilla<Padre> ObtenerPadres(UsuarioLogueado usuarioLogueado, int paginaActual, int totalPorPagina, string busquedaGlobal);

        /// <summary>
        /// Grilla de alumnos
        /// </summary>
        /// <param name="usuarioLogueado"></param>
        /// <param name="paginaActual"></param>
        /// <param name="totalPorPagina"></param>
        /// <param name="busquedaGlobal"></param>
        /// <returns></returns>
        Grilla<Hijo> ObtenerAlumnos(UsuarioLogueado usuarioLogueado, int paginaActual, int totalPorPagina, string busquedaGlobal);

        /// <summary>
        /// Obtener directora por ID
        /// </summary>
        /// <param name="usuarioLogueado"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Director ObtenerDirectoraPorId(Usuario usuarioLogueado, int id)
        {
            return directores.First(x => x.ID == id);
        }

        /// <summary>
        /// Obtener docente por ID
        /// </summary>
        /// <param name="usuarioLogueado"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Docente ObtenerDocentePorId(Usuario usuarioLogueado, int id)
        {
            return docentes.First(x => x.ID == id);
        }

        /// <summary>
        /// Obtener padre por ID
        /// </summary>
        /// <param name="usuarioLogueado"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Padre ObtenerPadrePorId(Usuario usuarioLogueado, int id)
        {
            return padres.First(x => x.ID == id);
        }

        /// <summary>
        /// Obtener hijo por ID
        /// </summary>
        /// <param name="usuarioLogueado"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Hijo ObtenerAlumnoPorId(Usuario usuarioLogueado, int id)
        {
            return hijos.First(x => x.ID == id);
        }
    }
}
