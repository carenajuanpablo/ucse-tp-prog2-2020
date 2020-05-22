using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lógica
{
    public class ClasePrincipal
    {
        List<Institucion> instituciones = new List<Institucion>();
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
        Institucion[] ObtenerInstituciones()
        {
            return instituciones.ToArray();
        }

        private Director ConvertirDirector(Usuario o)
        {
            Director dir = o as Director;
            return o != null ? dir : null;
        }
        private Docente ConvertirDocente(Usuario o)
        {
            Docente doc = o as Docente;
            return o != null ? doc : null;
        }
        private Padre ConvertirPadre(Usuario o)
        {
            Padre pad = o as Padre;
            return o != null ? pad : null;
        }

        /// <summary>
        /// El usuario logueado debe ser un director del mismo institucion
        /// </summary>
        /// <param name="directora"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado AltaDirector(Director director, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            if (usuarioLogueado.RolSeleccionado == Roles.Director)
            {
                Director directorLogged = ConvertirDirector(usuarioLogueado);
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
        /// El usuario logueado debe ser un director
        /// </summary>
        /// <param name="hijo"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado AltaAlumno(Hijo hijo, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            if (usuarioLogueado.RolSeleccionado == Roles.Director)
            {
                Director directorLogged = ConvertirDirector(usuarioLogueado);
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
                res.Errores.Add("El usuario logueado no es director.");
            }
            return res;
        }

        /// <summary>
        /// El usuario logueado debe ser un director
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hijo"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado EditarAlumno(int id, Hijo hijo, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            Hijo alumnoEditar = ObtenerAlumnoPorId(usuarioLogueado,id);
            if (usuarioLogueado.RolSeleccionado == Roles.Director)
            {
                var existe = hijos.First(x => x.ID == alumnoEditar.ID);
                if (existe != null)
                {
                    int indice = hijos.IndexOf(alumnoEditar);
                    hijos[indice] = hijo;
                }
                else
                {
                    res.Errores.Add("El alumno que se quiere editar no existe.");
                }
              
            }
            else
            {
                res.Errores.Add("El usuario logueado no es director.");
            }
            return res;
        }

        /// <summary>
        /// El usuario logueado debe ser un director
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hijo"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado EliminarAlumno(int id, Hijo hijo, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            Hijo alumnoEliminar = ObtenerAlumnoPorId(usuarioLogueado,id);
            if (usuarioLogueado.RolSeleccionado == Roles.Director)
            {
                var existe = hijos.First(x => x.ID == alumnoEliminar.ID);
                if (existe != null)
                {
                    hijos.Remove(alumnoEliminar);
                }
                else
                {
                    res.Errores.Add("El alumno que se quiere eliminar no existe.");
                }
                                           
            }
            else
            {
                res.Errores.Add("El usuario logueado no es director.");
            }
            return res;
        }

        /// <summary>
        /// El usuario logueado debe ser un director del mismo institucion
        /// </summary>
        /// <param name="directora"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado EditarDirector(int id, Director director, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            Director directorEditar = ObtenerDirectorPorId(usuarioLogueado,id);
            if (usuarioLogueado.RolSeleccionado == Roles.Director)
            {
                var existe = directores.First(x => x.ID == directorEditar.ID);
                if (existe != null)
                {
                    Director directorLogged = ConvertirDirector(usuarioLogueado);
                    if (directorLogged.Institucion == directorEditar.Institucion)
                    {
                        int indice = directores.IndexOf(directorEditar);
                        directores[indice] = director;
                    }
                    else
                    {
                        res.Errores.Add("La institucion del director no coincide con la institucion del director a editar.");
                    }
                }
                else
                {
                    res.Errores.Add("El director a editar no existe");
                }
            }
            else
            {
                res.Errores.Add("El usuario logueado no es director.");
            }
            return res;
        }
        /// <summary>
        /// El usuario logueado debe ser un director del mismo institucion
        /// </summary>
        /// <param name="directora"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado EliminarDirector(int id, Director director, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            Director directorEliminar = ObtenerDirectorPorId(usuarioLogueado,id);
            if (usuarioLogueado.RolSeleccionado == Roles.Director)
            {
                var existe = directores.First(x => x.ID == directorEliminar.ID);
                if (existe != null)
                {
                    Director directorLogged = ConvertirDirector(usuarioLogueado);
                    if (directorLogged.Institucion == directorEliminar.Institucion)
                    {
                        directores.Remove(directorEliminar);
                    }
                    else
                    {
                        res.Errores.Add("La institucion no coincide.");
                    }
                }
                else
                {
                    res.Errores.Add("El director a eliminar no existe");
                }     
            }
            else
            {
                res.Errores.Add("El usuario logueado no es director.");
            }
            return res;
        }
        /// <summary>
        /// Las salas son de la institucion del usuario logueado
        /// </summary>
        /// <param name="institucion"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        //Sala[] ObtenerSalasPorInstitucion(Usuario usuarioLogueado);


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
                Director directorLogged = ConvertirDirector(usuarioLogueado);
                var Existe = docentes.First(x => x.ID == docente.ID);
                if (Existe==null)
                {
                    if (directorLogged.Institucion == docente.Institucion)
                    {                                             
                        docente.ID = docentes.Count + 1;
                        docentes.Add(docente);                                           
                    }
                    else
                    {
                        res.Errores.Add("La institucion no coincide.");
                    }
                }
                else
                {
                    res.Errores.Add("Docente existente.");
                }
                
            }
            else
            {
                res.Errores.Add("El usuario logueado no es director.");
            }
            return res;
        }
        /// <summary>
        /// El usuario logueado debe ser un director del mismo institucion
        /// </summary>
        /// <param name="id"></param>
        /// <param name="docente"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado EditarDocente(int id, Docente docente, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            Docente docenteEditar = ObtenerDocentePorId(usuarioLogueado,id);
            if (usuarioLogueado.RolSeleccionado == Roles.Director)
            {
                Director directorLogged = ConvertirDirector(usuarioLogueado);
                var existe = docentes.First(x => x.ID == docenteEditar.ID);
                if (existe!=null)
                {
                    if (directorLogged.Institucion == docenteEditar.Institucion)
                    {
                        int indice = docentes.IndexOf(docenteEditar);
                        docentes[indice] = docente;
                    }
                    else
                    {
                        res.Errores.Add("La institucion del director no coincide con la del docente a editar.");
                    }
                }
                else
                {
                    res.Errores.Add("El docente a editar no existe.");
                }
                
            }
            else
            {
                res.Errores.Add("El usuario logueado no es director.");
            }
            return res;
        }
        /// <summary>
        /// El usuario logueado debe ser un director del mismo institucion
        /// </summary>
        /// <param name="id"></param>
        /// <param name="docente"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado EliminarDocente(int id, Docente docente, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            Docente docenteEliminar = ObtenerDocentePorId(usuarioLogueado,id);
            if (usuarioLogueado.RolSeleccionado == Roles.Director)
            {
                Director directorLogged = ConvertirDirector(usuarioLogueado);
                var existe = docentes.First(x => x.ID == docenteEliminar.ID);
                if (existe != null)
                {
                    if (directorLogged.Institucion == docenteEliminar.Institucion)
                    {
                        docentes.Remove(docenteEliminar);
                    }
                    else
                    {
                        res.Errores.Add("La instucion del director no coincide con la del docente.");
                    }
                }
                else
                {
                    res.Errores.Add("El docente a eliminar no existe.");
                }        
            }
            else
            {
                res.Errores.Add("El usuario logueado no es director.");
            }
            return res;
        }
        /// <summary>
        /// El usuario debe ser director del mismo institucion
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
        /// El usuario debe ser director del mismo institucion
        /// </summary>
        /// <param name="padre"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado EditarPadreMadre(int id, Padre padre, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            Padre padreEditar = ObtenerPadrePorId(usuarioLogueado,id);
            if (usuarioLogueado.RolSeleccionado == Roles.Director)
            {
                Director directorLogged = ConvertirDirector(usuarioLogueado);
                var existe = padres.First(x => x.ID == padreEditar.ID);
                if (existe != null)
                {
                    bool pertenece = false;
                    foreach (var item in padreEditar.ListaHijos)
                    {
                        if (item.Institucion == directorLogged.Institucion)
                        {
                            int indice = padres.IndexOf(padreEditar);
                            padres[indice] = padre;
                            pertenece = true;
                            break;
                        }
                    }
                    if (pertenece == false)
                    {
                        res.Errores.Add("La institucion del director no coincide con la del padre a editar.");
                    }
                }
                else
                {
                    res.Errores.Add("El padre a editar no existe.");
                }

            }
            else
            {
                res.Errores.Add("El usuario logueado no es director.");
            }
            return res;
        }
        /// <summary>
        /// El usuario debe ser director del mismo institucion
        /// </summary>
        /// <param name="padre"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado EliminarPadreMadre(int id, Padre padre, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            Padre padreEliminar = ObtenerPadrePorId(usuarioLogueado,id);
            if (usuarioLogueado.RolSeleccionado == Roles.Director)
            {
                Director directorLogged = ConvertirDirector(usuarioLogueado);
                var existe = padres.First(x => x.ID == padreEliminar.ID);
                if (existe != null)
                {
                    bool pertenece = false;
                    foreach (var item in padreEliminar.ListaHijos)
                    {
                        if (item.Institucion == directorLogged.Institucion)
                        {
                            padres.Remove(padreEliminar);
                            pertenece = true;
                            break;
                        }
                    }
                    if (pertenece == false)
                    {
                        res.Errores.Add("La institucion del director no coincide con la del padre.");
                    }
                }
                else
                {
                    res.Errores.Add("El padre a editar no existe.");
                }
               
            }
            else
            {
                res.Errores.Add("El usuario logueado no es director.");
            }
            return res;
        }
        /// <summary>
        /// El usuario debe ser director, y tanto la sala como el docente deben pertenecer a su institucion.
        /// </summary>
        /// <param name="docente"></param>
        /// <param name="sala"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado AsignarDocenteSala(Docente docente, Sala sala, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            if (usuarioLogueado.RolSeleccionado == Roles.Director)
            {
                var existe = docentes.First(x => x.ID == docente.ID);
                if (existe != null)
                {
                    Director directorLogged = ConvertirDirector(usuarioLogueado);
                    Institucion institucion = directorLogged.Institucion;
                    if (institucion == docente.Institucion && institucion.Salas.Contains(sala))
                    {
                        docente.Salas.Add(sala);
                    }
                    else
                    {
                        res.Errores.Add("La institucion del director no coincide con la del docente o la sala no pertenece al docente.");
                    }
                }
                else
                {
                    res.Errores.Add("El docente no existe.");
                }
                
            }
            else
            {
                res.Errores.Add("EL usuario logueado no es director.");
            }
            return res;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="docente"></param>
        /// <param name="sala"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado DesasignarDocenteSala(Docente docente, Sala sala, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            if (usuarioLogueado.RolSeleccionado == Roles.Director)
            {
                var existe = docentes.First(x => x.ID == docente.ID);
                if (existe!=null)
                {
                    Director directorLogged = ConvertirDirector(usuarioLogueado);
                    Institucion institucion = directorLogged.Institucion;
                    if (institucion == docente.Institucion && docente.Salas.Contains(sala))
                    {
                        docente.Salas.Remove(sala);
                    }
                    else
                    {
                        res.Errores.Add("La institucion del director no coincide con la del docente o la sala no pertenece al docente.");
                    }
                }
                else
                {
                    res.Errores.Add("El docente no existe.");
                }
               
            }
            return res;
        }
        /// <summary>
        /// El usuario debe ser director, y el hijo debe estar asociado a una sala de su institucion
        /// </summary>
        /// <param name="hijo"></param>
        /// <param name="padre"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado AsignarHijoPadre(Hijo hijo, Padre padre, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            bool pertenece = false;
            if (usuarioLogueado.RolSeleccionado == Roles.Director)
            {
                var existe = padres.First(x => x.ID == padre.ID);
                if (existe != null)
                {
                    Director directorLogged = ConvertirDirector(usuarioLogueado);
                    Institucion institucion = directorLogged.Institucion;
                    if (padre.ListaHijos.Contains(hijo))
                    {
                        foreach (Sala item in institucion.Salas)
                        {
                            if (item.alumnos.Contains(hijo))
                            {
                                padre.ListaHijos.Add(hijo);
                                pertenece = true;
                                break;
                            }
                        }
                        if (pertenece == false)
                        {
                            res.Errores.Add("El alumno no pertenece a ninguna sala de la institucion.");
                        }
                    }
                    else
                    {
                        res.Errores.Add("El hijo no pertenece al padre del parametro.");
                    }
                }
                else
                {
                    res.Errores.Add("El padre no existe.");
                }
            }
            else
            {
                res.Errores.Add("El usuario logueado no es director.");
            }
            return res;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hijo"></param>
        /// <param name="padre"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Resultado DesasignarHijoPadre(Hijo hijo, Padre padre, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            bool pertenece = false;
            if (usuarioLogueado.RolSeleccionado == Roles.Director)
            {
                var existe = padres.First(x => x.ID == padre.ID);
                if (existe != null)
                {
                    Director directorLogged = ConvertirDirector(usuarioLogueado);
                    Institucion institucion = directorLogged.Institucion;
                    if (padre.ListaHijos.Contains(hijo))
                    {
                        foreach (Sala item in institucion.Salas)
                        {
                            if (item.alumnos.Contains(hijo))
                            {
                                padre.ListaHijos.Remove(hijo);
                                pertenece = true;
                                break;
                            }
                        }
                        if (pertenece == false)
                        {
                            res.Errores.Add("El alumno no pertenece a ninguna sala de la institucion.");
                        }
                    }
                    else
                    {
                        res.Errores.Add("El hijo no pertenece al padre del parametro.");
                    }
                }
                else
                {
                    res.Errores.Add("El padre no existe.");
                }
               

            }
            else
            {
                res.Errores.Add("El usuario loguado no es director.");
            }
            return res;
        }
        /// <summary>
        /// Si el usuario es directora, retornar alumnos de la institucion, si es docente los de sus salas, y si es padre solo sus hijos.
        /// </summary>        
        /// <returns></returns>
        Hijo[] ObtenerPersonas(Usuario usuarioLogueado)
        {          
            switch (usuarioLogueado.RolSeleccionado)
            {
                case Roles.Profesor:
                    Docente docente = ConvertirDocente(usuarioLogueado);
                    return hijos.Where(x => docente.Salas.Contains(x.Sala)).ToArray();                  
                case Roles.Padre:
                    Padre padre = ConvertirPadre(usuarioLogueado);
                    return padre.ListaHijos.ToArray();                   
                case Roles.Director:
                    Director director = ConvertirDirector(usuarioLogueado);
                    return hijos.Where(x => x.Institucion == director.Institucion).ToArray();
                default:
                    throw new Exception("Rol no implementado");
            }
        }
        /// <summary>
        /// Obtiene las notas de un cuaderno, si el usuario es padre solo puede obtener cuadernos de sus hijos, si es docente de alumnos de sus salas
        /// y si es directora de cualquier alumno de la institucion
        /// </summary>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        Nota[] ObtenerCuadernoComunicaciones(int idPersona, Usuario usuarioLogueado)
        {
            List<Nota> nota = new List<Nota>();
            var alumno = hijos.FirstOrDefault(x => x.ID == idPersona);
            if (alumno != null)
            {
                switch (usuarioLogueado.RolSeleccionado)
                {
                    case Roles.Profesor:
                        {
                            Docente docente = ConvertirDocente(usuarioLogueado);
                            var Coincide = docente.Salas.FirstOrDefault(x => x.alumnos.Any(y => y.ID == idPersona));
                            if (Coincide != null)
                            {
                                foreach (var item in alumno.Notas)
                                {
                                    nota.Add(item);
                                }
                            }
                            else
                            {
                                throw new Exception("Alumno no pertenece a un aula del profesor");
                            }
                            break;
                        }
                    case Roles.Padre:
                        {
                            Padre padre = ConvertirPadre(usuarioLogueado);
                            var esHijo = padre.ListaHijos.FirstOrDefault(x => x.ID == idPersona);
                            if (esHijo != null)
                            {
                                foreach (var item in esHijo.Notas)
                                {
                                    nota.Add(item);
                                }
                            }
                            else
                            {
                                throw new Exception("No es hijo del padre");
                            }
                            break;
                        }
                    case Roles.Director:
                        {
                            Director director = ConvertirDirector(usuarioLogueado);
                            if (director.Institucion == alumno.Institucion)
                            {
                                foreach (var item in alumno.Notas)
                                {
                                    nota.Add(item);
                                }
                            }
                            else
                            {
                                throw new Exception("No pertenece a la misma institución que el director");
                            }
                            break;
                        }
                }
            }
            else
            {
                throw new Exception("Alumno inexistente");
            }
            return nota.ToArray();
        }



        public void GuardarNota(Hijo hijo, Nota nota)
        {
            var notasHijo = hijo.Notas == null ? new List<Nota>() : hijo.Notas.ToList();

            notasHijo.Add(nota);
        }

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
                case Roles.Padre:
                    {
                        Padre padre = ConvertirPadre(usuarioLogueado);
                        if (hijos != null && hijos.Length > 0)
                        {
                            foreach (var item in hijos)
                            {
                                var esHijo = padre.ListaHijos.FirstOrDefault(x => x.ID == item.ID);
                                if (esHijo != null)
                                {
                                    GuardarNota(esHijo, nota);
                                }
                                else
                                {
                                    res.Errores.Add($"El alumno no es hijo del padre");
                                }
                            }
                        }
                        else
                        {
                            List<Hijo> alumnos = new List<Hijo>();
                            foreach (var sala in salas)
                            {
                                alumnos.AddRange(hijos.Where(x => x.Sala.Id == sala.Id));
                            }
                            foreach (var item in alumnos)
                            {
                                var esHijo = padre.ListaHijos.FirstOrDefault(x => x.ID == item.ID);
                                if (esHijo != null)
                                {
                                    GuardarNota(esHijo, nota);
                                }
                                else
                                {
                                    res.Errores.Add($"El alumno no es hijo del padre");
                                }
                            }
                        }
                        break;
                    }
                case Roles.Profesor:
                    {
                        Docente docente = ConvertirDocente(usuarioLogueado);
                        if (hijos != null && hijos.Length > 0)
                        {
                            foreach (var item in hijos)
                            {
                                if (docente.Institucion == item.Institucion)
                                {
                                    GuardarNota(item, nota);
                                }
                                else
                                {
                                    res.Errores.Add($"El alumno no pertenece a la misma institución que el docente");
                                }
                            }
                        }
                        else
                        {
                            List<Hijo> alumnos = new List<Hijo>();
                            foreach (var sala in salas)
                            {
                                alumnos.AddRange(hijos.Where(x => x.Sala.Id == sala.Id));
                            }
                            foreach (var item in alumnos)
                            {
                                if (docente.Institucion == item.Institucion)
                                {
                                    GuardarNota(item, nota);
                                }
                                else
                                {
                                    res.Errores.Add($"El alumno no pertenece a la misma institución que el docente");
                                }
                            }
                        }
                        break;
                    }
                case Roles.Director:
                    {
                        Director director = ConvertirDirector(usuarioLogueado);
                        if (hijos != null && hijos.Length > 0)
                        {
                            foreach (var item in hijos)
                            {
                                if (director.Institucion == item.Institucion)
                                {
                                    GuardarNota(item, nota);
                                }
                                else
                                {
                                    res.Errores.Add($"El alumno no pertenece a la misma institución que el director");
                                }
                            }
                        }
                        else
                        {
                            List<Hijo> alumnos = new List<Hijo>();
                            foreach (var sala in salas)
                            {
                                alumnos.AddRange(hijos.Where(x => x.Sala.Id == sala.Id));
                            }
                            foreach (var item in alumnos)
                            {
                                if (director.Institucion == item.Institucion)
                                {
                                    GuardarNota(item, nota);
                                }
                                else
                                {
                                    res.Errores.Add($"El alumno no pertenece a la misma institución que el director");
                                }
                            }
                        }
                        break;
                    }                    
            }
            return res;
        }


        public void AgregarComentario(Nota nota, Comentario nuevoComentario)
        {
            var comment = nota.Comentarios == null ? new List<Comentario>() : nota.Comentarios.ToList();
            comment.Add(nuevoComentario);
            nota.Comentarios = comment.ToArray();
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
                        AgregarComentario(nota, nuevoComentario);
                    }
                    else
                    {
                        res.Errores.Add($"La nota no corresponde a un alumno del profesor");
                    }
                    break;
                case Roles.Padre:
                    Padre padre = usuarioLogueado as Padre;
                    var esHijo = padre.ListaHijos.First(x => x.Notas.Any(y => y.Id == nota.Id));
                    if (esHijo != null)
                    {
                        AgregarComentario(nota, nuevoComentario);
                    }
                    else
                    {
                        res.Errores.Add($"La nota no corresponde a un hijo del usuario logueado");
                    }
                    break;
                case Roles.Director:
                    Director director = usuarioLogueado as Director;
                    var alumno = hijos.First(x => x.Notas.Any(y => y.Id == nota.Id));
                    if (director.Institucion == alumno.Institucion)
                    {
                        AgregarComentario(nota, nuevoComentario);
                    }
                    else
                    {
                        res.Errores.Add($"La nota no corresponde a un alumno de la institución del director");
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
        Resultado MarcarNotaComoLeida(Nota nota, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado { Errores = new List<string>() };
            switch (usuarioLogueado.RolSeleccionado)
            {
                case Roles.Profesor:
                case Roles.Director:
                    res.Errores.Add("No es usuario Padre");
                    break;
                case Roles.Padre:
                    Padre padre = ConvertirPadre(usuarioLogueado);
                    var esHijo = padre.ListaHijos.FirstOrDefault(x => x.Notas.Any(y => y.Id == nota.Id));
                    if (esHijo != null)
                    {
                        var NOTA = esHijo.Notas.FirstOrDefault(x => x.Id == nota.Id);
                        NOTA.Leida = true;
                    }
                    else
                    {
                        res.Errores.Add("La nota no corresponde a un hijo del padre");
                    }
                    break;
            }
            return res;
        }

        /// <summary>
        /// Grilla de directoras
        /// </summary>
        /// <param name="usuarioLogueado"></param>
        /// <param name="paginaActual"></param>
        /// <param name="totalPorPagina"></param>
        /// <param name="busquedaGlobal"></param>
        /// <returns></returns>
        //Grilla<Directora> ObtenerDirectoras(UsuarioLogueado usuarioLogueado, int paginaActual, int totalPorPagina, string busquedaGlobal);

        /// <summary>
        /// Grilla de docentes
        /// </summary>
        /// <param name="usuarioLogueado"></param>
        /// <param name="paginaActual"></param>
        /// <param name="totalPorPagina"></param>
        /// <param name="busquedaGlobal"></param>
        /// <returns></returns>
       // Grilla<Docente> ObtenerDocentes(UsuarioLogueado usuarioLogueado, int paginaActual, int totalPorPagina, string busquedaGlobal);

        /// <summary>
        /// Grilla de padres
        /// </summary>
        /// <param name="usuarioLogueado"></param>
        /// <param name="paginaActual"></param>
        /// <param name="totalPorPagina"></param>
        /// <param name="busquedaGlobal"></param>
        /// <returns></returns>
       // Grilla<Padre> ObtenerPadres(UsuarioLogueado usuarioLogueado, int paginaActual, int totalPorPagina, string busquedaGlobal);

        /// <summary>
        /// Grilla de alumnos
        /// </summary>
        /// <param name="usuarioLogueado"></param>
        /// <param name="paginaActual"></param>
        /// <param name="totalPorPagina"></param>
        /// <param name="busquedaGlobal"></param>
        /// <returns></returns>
       // Grilla<Hijo> ObtenerAlumnos(UsuarioLogueado usuarioLogueado, int paginaActual, int totalPorPagina, string busquedaGlobal);

        /// <summary>
        /// Obtener director por ID
        /// </summary>
        /// <param name="usuarioLogueado"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Director ObtenerDirectorPorId(Usuario usuarioLogueado, int id)
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
