using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Contratos;
using System.IO;
using Newtonsoft.Json;

namespace Lógica
{
    public class ClasePrincipal
    {
        readonly string pathListaDeInstituciones = Path.GetFullPath("c:\\Users\\jcarena\\Documents\\TP2020\\ListaDeInstituciones.txt");
        readonly string pathListaDeHijos = Path.GetFullPath("c:\\Users\\jcarena\\Documents\\TP2020\\ListaDeHijos.txt");
        readonly string pathListaDePadres = Path.GetFullPath("c:\\Users\\jcarena\\Documents\\TP2020\\ListaDePadres.txt");
        readonly string pathListaDeDocentes = Path.GetFullPath("c:\\Users\\jcarena\\Documents\\TP2020\\ListaDeDocentes.txt");
        readonly string pathListaDeDirectores = Path.GetFullPath("c:\\Users\\jcarena\\Documents\\TP2020\\ListaDeDirectores.txt");


        List<Institucion> instituciones { get; set; }
        List<Hijo> hijos { get; set; }
        List<Padre> padres { get; set; }
        List<Docente> docentes { get; set; }
        List<Director> directores { get; set; }
        List<Sala> salas { get; set; } = new List<Sala>();


        public Usuario UsuarioLogueado;
        public Institucion Institución = new Institucion();

        public ClasePrincipal()
        {
            instituciones = LeerListaDeInstituciones();
            hijos = LeerListaDeHijos();
            padres = LeerListaDePadres();
            docentes = LeerListaDeDocentes();
            directores = LeerListaDeDirectores();


            

            Institucion inst = new Institucion() { Ciudad = "asd", Direccion = "asd", Id = 123, Nombre = "re", Provincia = "sf", Telefono = "123" };
            instituciones.Add(inst);
            Director dir = new Director() { ID = 1, Nombre = "A 1", Apellido = "B", Email = "C", Cargo = "D", Contraseña = "123", Roles = new Roles[] { Roles.Directora }, RolSeleccionado = Roles.Directora, Institucion = inst, FechaIngreso = new DateTime(2020, 01, 02) };
            directores.Add(dir);
            ActualizarArchivo("Director");

            Docente Docente = new Docente() { Institucion = inst, ID = 20, Nombre = "Docente1", Apellido = "apellido1", Email = "sdd", Roles = new Roles[] { Roles.Docente }, RolSeleccionado = Roles.Docente };
            docentes.Add(Docente);
            ActualizarArchivo("Docente");
            
            Padre Padre = new Padre() { Nombre = "Roberto", ID = 45, Apellido = "apellido1", Email = "sdd", Roles = new Roles[] { Roles.Padre }, RolSeleccionado = Roles.Padre , ListaHijos = new List<Hijo>() { new Hijo { ID=1, Nombre="Pedro" } } }   ;
            padres.Add(Padre);
            ActualizarArchivo("Padre");

            Sala Sala1 = new Sala() { Id = 1, Nombre = "1A", institucion = inst };
            Sala Sala2 = new Sala() { Id = 2, Nombre = "2A", institucion = inst };
            salas.Add(Sala1);
            salas.Add(Sala2);
        }

        public List<Institucion> LeerListaDeInstituciones()
        {
            if (!File.Exists(pathListaDeInstituciones))
            {
                TextWriter archivo = new StreamWriter(pathListaDeInstituciones);
                List<Institucion> Lista = new List<Institucion>();
                archivo.Close();
                return Lista;
            }
            else
            {
                using (StreamReader archivo = new StreamReader(pathListaDeInstituciones))
                {
                    string JsonContenido = archivo.ReadToEnd();
                    List<Institucion> Lista = JsonConvert.DeserializeObject<List<Institucion>>(JsonContenido);

                    archivo.Close();

                    if (Lista == null)
                        Lista = new List<Institucion>();
                    return Lista;
                }
            }
        }
        public List<Hijo> LeerListaDeHijos()
        {
            if (!File.Exists(pathListaDeHijos))
            {
                TextWriter archivo = new StreamWriter(pathListaDeHijos);
                List<Hijo> Lista = new List<Hijo>();
                archivo.Close();
                return Lista;
            }
            else
            {
                using (StreamReader archivo = new StreamReader(pathListaDeHijos))
                {
                    string JsonContenido = archivo.ReadToEnd();
                    List<Hijo> Lista = JsonConvert.DeserializeObject<List<Hijo>>(JsonContenido);

                    archivo.Close();

                    if (Lista == null)
                        Lista = new List<Hijo>();
                    return Lista;
                }
            }
        }
        public List<Padre> LeerListaDePadres()
        {
            if (!File.Exists(pathListaDeHijos))
            {
                TextWriter archivo = new StreamWriter(pathListaDePadres);
                List<Padre> Lista = new List<Padre>();
                archivo.Close();
                return Lista;
            }
            else
            {
                using (StreamReader archivo = new StreamReader(pathListaDePadres))
                {
                    string JsonContenido = archivo.ReadToEnd();
                    List<Padre> Lista = JsonConvert.DeserializeObject<List<Padre>>(JsonContenido);

                    archivo.Close();

                    if (Lista == null)
                        Lista = new List<Padre>();
                    return Lista;
                }
            }
        }
        public List<Docente> LeerListaDeDocentes()
        {
            if (!File.Exists(pathListaDeHijos))
            {
                TextWriter archivo = new StreamWriter(pathListaDeDocentes);
                List<Docente> Lista = new List<Docente>();
                archivo.Close();
                return Lista;
            }
            else
            {
                using (StreamReader archivo = new StreamReader(pathListaDeDocentes))
                {
                    string JsonContenido = archivo.ReadToEnd();
                    List<Docente> Lista = JsonConvert.DeserializeObject<List<Docente>>(JsonContenido);

                    archivo.Close();

                    if (Lista == null)
                        Lista = new List<Docente>();
                    return Lista;
                }
            }
        }
        public List<Director> LeerListaDeDirectores()
        {
            if (!File.Exists(pathListaDeHijos))
            {
                TextWriter archivo = new StreamWriter(pathListaDeDirectores);
                List<Director> Lista = new List<Director>();
                archivo.Close();
                return Lista;
            }
            else
            {
                using (StreamReader archivo = new StreamReader(pathListaDeDirectores))
                {
                    string JsonContenido = archivo.ReadToEnd();
                    List<Director> Lista = JsonConvert.DeserializeObject<List<Director>>(JsonContenido);

                    archivo.Close();

                    if (Lista == null)
                        Lista = new List<Director>();
                    return Lista;
                }
            }
        }

        public void ActualizarArchivo(string msg)
        {
            switch (msg)
            {
                case "Institucion":
                    using (StreamWriter archivo = new StreamWriter(pathListaDeInstituciones))
                    {
                        string JsonContenido = JsonConvert.SerializeObject(instituciones);
                        archivo.Write(JsonContenido);
                        archivo.Close();
                    }
                    break;
                case "Director":
                    using (StreamWriter archivo = new StreamWriter(pathListaDeDirectores))
                    {
                        string JsonContenido = JsonConvert.SerializeObject(directores);
                        archivo.Write(JsonContenido);
                        archivo.Close();
                    }
                    break;
                case "Padre":
                    using (StreamWriter archivo = new StreamWriter(pathListaDePadres))
                    {
                        string JsonContenido = JsonConvert.SerializeObject(padres);
                        archivo.Write(JsonContenido);
                        archivo.Close();
                    }
                    break;
                case "Docente":
                    using (StreamWriter archivo = new StreamWriter(pathListaDeDocentes))
                    {
                        string JsonContenido = JsonConvert.SerializeObject(docentes);
                        archivo.Write(JsonContenido);
                        archivo.Close();
                    }
                    break;
                case "Hijo":
                    using (StreamWriter archivo = new StreamWriter(pathListaDeHijos))
                    {
                        string JsonContenido = JsonConvert.SerializeObject(hijos);
                        archivo.Write(JsonContenido);
                        archivo.Close();
                    }
                    break;
            }
        }

        public delegate void AbmUsuarioHandler(AbmUsuarioArgs contexto);
        public event AbmUsuarioHandler AbmUsuario;

        public class AbmUsuarioArgs : EventArgs
        {
            public AbmUsuarioArgs(Padre padre)
            {
                Usuario = padre;
            }
            public AbmUsuarioArgs(Director director)
            {
                Usuario = director;
            }
            public AbmUsuarioArgs(Docente docente)
            {
                Usuario  = docente;
            }
            public AbmUsuarioArgs(Hijo hijo)
            {
                Usuario = hijo;
            }
            public Usuario Usuario { get; set; }
        }

        public delegate void AltaNotaHandler(AltaNotaArgs contexto);
        public event AltaNotaHandler AltNota;

        public class AltaNotaArgs : EventArgs
        {
            public AltaNotaArgs(Hijo hijo, Nota nota)
            {
                Hijo = hijo;
                Nota = nota;
            }
            public Hijo Hijo { get; set; }
            public Nota Nota { get; set; }
        }

        public delegate void AltaComentarioHandler(AltaComentarioArgs contexto);
        public event AltaComentarioHandler AltComentario;

        public class AltaComentarioArgs : EventArgs
        {
            public AltaComentarioArgs(Comentario comentario, Nota nota)
            {
                Comentario = comentario;
                Nota = nota;
            }
            public Comentario Comentario { get; set; }
            public Nota Nota { get; set; }
        }
        /// <summary>
        /// Nombre de los integrantes del grupo de trabajo
        /// </summary>
        /// <returns></returns>
        public string ObtenerNombreGrupo()
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
        /// 
        public Institucion ObtenerInstituciónUsuarioLogueado(Usuario User)
        {
            Institucion Inst = new Institucion();
            switch (User.RolSeleccionado)
            {
                case Roles.Directora:
                    Director Dir = ConvertirDirector(User);
                    Inst = Dir.Institucion;
                    break;
                case Roles.Docente:
                    Docente Doc = new Docente();
                    Inst = Doc.Institucion;
                    break;
                default:
                    break;
            }
            return Inst;
        }
        public Usuario ObtenerUsuario(string email, string clave)
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
            UsuarioLogueado = UsuarioEncontrado;
            Institución = ObtenerInstituciónUsuarioLogueado(UsuarioLogueado);

            return UsuarioEncontrado;
        }

        /// <summary>
        /// Obtiene un listado de instituciones guardada
        /// </summary>
        /// <returns></returns>
        public Institucion[] ObtenerInstituciones()
        {
            return instituciones.ToArray();
        }

        private Director ConvertirDirector(Usuario o)
        {
            Director dir = o as Director;
            return dir != null ? dir : null;
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


        public Resultado AltaInstitucion(Institucion institucion, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            if (usuarioLogueado.RolSeleccionado == Roles.Directora)
            {
                var Existe = instituciones.First(x => x.Id == institucion.Id);
                if (Existe == null)
                {
                    institucion.Id = instituciones.Count + 1;
                    instituciones.Add(institucion);
                    ActualizarArchivo("Institucion");
                }
                else
                {
                    res.Errores.Add("Institución existente");
                }
            }
            else
            {
                res.Errores.Add("El usuario logueado no es director.");
            }
            return res;
        }
        public Resultado EditarInstitucion(int id, Institucion institucion, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            Institucion InstitucionEditar = ObtenerInstitucionPorId(usuarioLogueado, id);
            if (usuarioLogueado.RolSeleccionado == Roles.Directora)
            {
                if (InstitucionEditar != null)
                {
                    int indice = instituciones.IndexOf(InstitucionEditar);
                    instituciones[indice] = institucion;
                    ActualizarArchivo("Institucion");
                }
                else
                {
                    res.Errores.Add("La institución a editar no existe");
                }
            }
            else
            {
                res.Errores.Add("El usuario logueado no es director.");
            }
            return res;
        }
        public Resultado EliminarInstitucion(int id, Institucion institución, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            Institucion InstitucionEliminar = ObtenerInstitucionPorId(usuarioLogueado, id);
            if (usuarioLogueado.RolSeleccionado == Roles.Directora)
            {
                if (InstitucionEliminar != null)
                {
                    instituciones.Remove(InstitucionEliminar);
                    ActualizarArchivo("Institucion");
                }
                else
                {
                    res.Errores.Add("La institución a eliminar no existe");
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
        public Resultado AltaDirector(Director director, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            if (usuarioLogueado.RolSeleccionado == Roles.Directora)
            {
                var Existe = directores.FirstOrDefault(x => x.ID == director.ID);
                if (Existe == null)
                {
                  director.Institucion = Institución;
                  director.ID = directores.Count + 1;
                  if (director.Roles == null)
                  {
                    director.Roles = new Roles[] { Roles.Directora };
                  }
                  else
                  {
                    int i = director.Roles.Length;
                    director.Roles[i] = Roles.Directora;
                  }
                  directores.Add(director);
                  ActualizarArchivo("Director");
               // AbmUsuario(new AbmUsuarioArgs(director));
                }
                else
                {
                  res.Errores.Add("Director existente");
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
        public Resultado AltaAlumno(Hijo hijo, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            if (usuarioLogueado.RolSeleccionado == Roles.Directora)
            {
              var Existe = hijos.FirstOrDefault(x => x.ID == hijo.ID);
              if (Existe == null)
              {
                 hijo.ID = hijos.Count + 1;
                 hijo.Institucion = Institución;
                 hijos.Add(hijo);
                 ActualizarArchivo("Hijo");
              // AbmUsuario(new AbmUsuarioArgs(hijo));
              }
              else
              {
                 res.Errores.Add("Alumno existente");
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
        public Resultado EditarAlumno(int id, Hijo hijo, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            Hijo alumnoEditar = ObtenerAlumnoPorId(usuarioLogueado,id);
            if (usuarioLogueado.RolSeleccionado == Roles.Directora)
            {
                var existe = hijos.First(x => x.ID == alumnoEditar.ID);
                if (existe != null)
                {
                    int indice = hijos.IndexOf(alumnoEditar);
                    hijos[indice] = hijo;
                    ActualizarArchivo("Hijo");
                   // AbmUsuario(new AbmUsuarioArgs(hijo));
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
        public Resultado EliminarAlumno(int id, Hijo hijo, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            Hijo alumnoEliminar = ObtenerAlumnoPorId(usuarioLogueado,id);
            if (usuarioLogueado.RolSeleccionado == Roles.Directora)
            {
                var existe = hijos.First(x => x.ID == alumnoEliminar.ID);
                if (existe != null)
                {
                    hijos.Remove(alumnoEliminar);
                    ActualizarArchivo("Hijo");
                  //  AbmUsuario(new AbmUsuarioArgs(hijo));
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
        public Resultado EditarDirector(int id, Director director, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            Director directorEditar = ObtenerDirectorPorId(usuarioLogueado,id);
            if (usuarioLogueado.RolSeleccionado == Roles.Directora)
            {
                var existe = directores.First(x => x.ID == directorEditar.ID);
                if (existe != null)
                {
                    // Director directorLogged = ConvertirDirector(usuarioLogueado);
                    //  if (directorLogged.Institucion == directorEditar.Institucion)
                    //  {
                    int indice = directores.IndexOf(directorEditar);
                        directores[indice] = director;
                        ActualizarArchivo("Director");
                    //  AbmUsuario(new AbmUsuarioArgs(director));
                    //  }
                    // else
                    //  {
                    //  res.Errores.Add("La institucion del director no coincide con la institucion del director a editar.");
                    //}
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
        public Resultado EliminarDirector(int id, Director director, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            Director directorEliminar = ObtenerDirectorPorId(usuarioLogueado,id);
            if (usuarioLogueado.RolSeleccionado == Roles.Directora)
            {
                var existe = directores.First(x => x.ID == directorEliminar.ID);
                if (existe != null)
                {
                    //Director directorLogged = ConvertirDirector(usuarioLogueado);
                    ////if (directorLogged.Institucion == directorEliminar.Institucion)
                    //{
                    directores.Remove(directorEliminar);
                        ActualizarArchivo("Director");
                      //  AbmUsuario(new AbmUsuarioArgs(director));
                    //}
                    //else
                    //{
                    //res.Errores.Add("La institucion no coincide.");
                    //}
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

        public Sala[] ObtenerSalasPorInstitucion(Usuario usuarioLogueado)
        {
            List<Sala> Salas = new List<Sala>();
            switch (usuarioLogueado.RolSeleccionado)
            {
                case Roles.Docente:
                    Docente docente = ConvertirDocente(usuarioLogueado);
                    Salas = docente.Salas;
                    break;
                case Roles.Padre:
                    throw new Exception("Inaccesible.");
                case Roles.Directora:
                    Salas = salas;
                    /*
                    Director director = ConvertirDirector(usuarioLogueado);
                    if (director.Institucion.Salas != null)
                    {
                        Salas = director.Institucion.Salas;
                    }
                    */

                    break;
            }
            return Salas.ToArray();
        }

        /// <summary>
        /// El usuario logueado debe ser una directora del mismo institucion
        /// </summary>
        /// <param name="docente"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        public Resultado AltaDocente(Docente docente, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();            
            if (usuarioLogueado.RolSeleccionado == Roles.Directora)
            {
                //Director directorLogged = ConvertirDirector(usuarioLogueado);
                var Existe = docentes.FirstOrDefault(x => x.ID == docente.ID);
                if (Existe==null)
                {     
                    docente.Institucion = Institución;
                    docente.ID = docentes.Count + 1;
                    if (docente.Roles == null)
                    {
                        docente.Roles = new Roles[] { Roles.Docente };
                    }
                    else
                    {
                        int i = docente.Roles.Length;
                        docente.Roles[i] = Roles.Docente;
                    }
                    //docente.Roles = new Roles[] {Roles.Docente};
                    docentes.Add(docente);
                    ActualizarArchivo("Docente");

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
        public Resultado EditarDocente(int id, Docente docente, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            Docente docenteEditar = ObtenerDocentePorId(usuarioLogueado,id);
            if (usuarioLogueado.RolSeleccionado == Roles.Directora)
            {
                //Director directorLogged = ConvertirDirector(usuarioLogueado);
                var existe = docentes.First(x => x.ID == docenteEditar.ID);
                if (existe!=null)
                {
                    // if (directorLogged.Institucion == docenteEditar.Institucion)
                    // {
                    int indice = docentes.IndexOf(docenteEditar);
                        docentes[indice] = docente;
                        ActualizarArchivo("Docente");
                     //   AbmUsuario(new AbmUsuarioArgs(docente));
                    // }
                    //  else
                    //  {
                    // res.Errores.Add("La institucion del director no coincide con la del docente a editar.");
                    // }
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
        public Resultado EliminarDocente(int id, Docente docente, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            Docente docenteEliminar = ObtenerDocentePorId(usuarioLogueado,id);
            if (usuarioLogueado.RolSeleccionado == Roles.Directora)
            {
                //Director directorLogged = ConvertirDirector(usuarioLogueado);
                var existe = docentes.First(x => x.ID == docenteEliminar.ID);
                if (existe != null)
                {
                   // if (directorLogged.Institucion == docenteEliminar.Institucion)
                   // {
                        docentes.Remove(docenteEliminar);
                        ActualizarArchivo("Docente");
                        //AbmUsuario(new AbmUsuarioArgs(docente));
                    // }
                    //  else
                    //  {
                    // res.Errores.Add("La instucion del director no coincide con la del docente.");
                    //}
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
        public Resultado AltaPadreMadre(Padre padre, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            if (usuarioLogueado.RolSeleccionado == Roles.Directora)
            {
                var Existe = padres.FirstOrDefault(x => x.ID == padre.ID);
                if (Existe == null)
                {
                    padre.ID = padres.Count + 1;
                    if (padre.Roles == null)
                    {
                        padre.Roles = new Roles[] { Roles.Padre };
                    }
                    else
                    {
                        int i = padre.Roles.Length;
                        padre.Roles[i] = Roles.Padre;
                    }
                    padres.Add(padre);
                    ActualizarArchivo("Padre");
                    //AbmUsuario(new AbmUsuarioArgs(padre));
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
        public Resultado EditarPadreMadre(int id, Padre padre, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            Padre padreEditar = ObtenerPadrePorId(usuarioLogueado,id);
            if (usuarioLogueado.RolSeleccionado == Roles.Directora)
            {
                var existe = padres.First(x => x.ID == padreEditar.ID);
                if (existe != null)
                {                   
                   int indice = padres.IndexOf(padreEditar);
                   padres[indice] = padre;
                   ActualizarArchivo("Padre");
                 // AbmUsuario(new AbmUsuarioArgs(padre));
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
        public Resultado EliminarPadreMadre(int id, Padre padre, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            Padre padreEliminar = ObtenerPadrePorId(usuarioLogueado,id);
            if (usuarioLogueado.RolSeleccionado == Roles.Directora)
            {
                var existe = padres.First(x => x.ID == padreEliminar.ID);
                if (existe != null)
                {
                   padres.Remove(padreEliminar);
                   ActualizarArchivo("Padre");
               //  AbmUsuario(new AbmUsuarioArgs(padre));

                   
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
        public Resultado AsignarDocenteSala(Docente docente, Sala sala, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado();
            if (usuarioLogueado.RolSeleccionado == Roles.Directora)
            {
                Docente Docente = ObtenerDocentePorId(usuarioLogueado, docente.ID);
                var existe = docentes.FirstOrDefault(x => x.ID == docente.ID);
                if (existe != null)
                {
                    //Director directorLogged = ConvertirDirector(usuarioLogueado);
                    //Institucion institucion = directorLogged.Institucion;
                    //  if (Institución == docente.Institucion) // && institucion.Salas.Contains(sala))
                    //  {

                    if (Docente.Salas == null)
                    {
                        List<Sala> salas = new List<Sala>();
                        salas.Add(sala);
                        Docente.Salas = salas;
                    }
                    else
                    {
                        var Duplicado = Docente.Salas.FirstOrDefault(x => x.Id == sala.Id);
                        if (Duplicado == null)
                        {
                            Docente.Salas.Add(sala);
                        }
                        else
                        {
                            res.Errores.Add("La sala ya se encuentra asignada");
                        }
                    }
                    EditarDocente(Docente.ID, Docente, usuarioLogueado);
                 //   docente.Salas.Add(sala);
                     //   ActualizarArchivo("Docente");
                    // }
                    //else
                    // {
                    // res.Errores.Add("La institucion del director no coincide con la del docente o la sala no pertenece al docente.");
                    // }
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
        public Resultado DesasignarDocenteSala(Docente docente, Sala sala, Usuario usuarioLogueado)
        {
            Docente Docente = ObtenerDocentePorId(usuarioLogueado, docente.ID);
            Resultado res = new Resultado();
            if (usuarioLogueado.RolSeleccionado == Roles.Directora)
            {
                Sala SALA = ObtenerSalaPorId(usuarioLogueado,sala.Id);

                var existe = docentes.First(x => x.ID == docente.ID);
                if (existe!=null)
                {
                    //Director directorLogged = ConvertirDirector(usuarioLogueado);
                    // Institucion institucion = directorLogged.Institucion;
                    //    if (institucion == docente.Institucion && docente.Salas.Contains(sala))
                    //   {
                    if (Docente.Salas != null)
                    {
                        var Duplicado = Docente.Salas.FirstOrDefault(x => x.Id == sala.Id);
                        if (Duplicado != null)
                        {
                            //Docente.Salas.RemoveAt(0);
                            Docente.Salas.Remove(Docente.Salas.FirstOrDefault(x => x.Id == sala.Id));
                        }
                        else
                        {
                            res.Errores.Add("La sala no se encuentra asignada");
                        }
                    }
                    else
                    {
                        res.Errores.Add("La sala no se encuentra asignada");
                    }
                    EditarDocente(Docente.ID, Docente, usuarioLogueado);
                      //  ActualizarArchivo("Docente");
                    //    }
                    //   else
                    //   {
                    //   res.Errores.Add("La institucion del director no coincide con la del docente o la sala no pertenece al docente.");
                    // }
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
        /// 
        public Resultado AsignarHijoPadre(Hijo hijo, Padre padre, Usuario usuarioLogueado)
        {
            Hijo Hijo = ObtenerAlumnoPorId(usuarioLogueado, hijo.ID);
            Resultado res = new Resultado();
            if (usuarioLogueado.RolSeleccionado == Roles.Directora)
            {
                var Padre = padres.First(x => x.ID == padre.ID);
                if (Padre != null)
                {
                    //Director directorLogged = ConvertirDirector(usuarioLogueado);
                    // Institucion institucion = directorLogged.Institucion;
                    //  if (padre.ListaHijos.Contains(hijo))
                    //  {
                    //    foreach (Sala item in institucion.Sala)
                    //    {
                    //        if (item.alumnos.Contains(hijo))
                    //var Asignado = padre.ListaHijos.FirstOrDefault(x => x.ID == hijo.ID);
                    if (Padre.ListaHijos == null)
                    {
                        List<Hijo> ListaHijo = new List<Hijo>();
                        ListaHijo.Add(hijo);
                        Padre.ListaHijos = ListaHijo;
                    }
                    else
                    {
                        var Duplicado = Padre.ListaHijos.FirstOrDefault(x => x.ID == hijo.ID);
                        if (Duplicado == null)
                        {
                            Padre.ListaHijos.Add(Hijo);
                        }
                        else
                        {
                            res.Errores.Add("Hijo ya asignado");
                        }

                    }
                    EditarPadreMadre(Padre.ID, Padre, usuarioLogueado);
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
        public Resultado DesasignarHijoPadre(Hijo hijo, Padre padre, Usuario usuarioLogueado)
        {
           // Padre Padre = ObtenerPadrePorId(usuarioLogueado, padre.ID);
            Resultado res = new Resultado();
            if (usuarioLogueado.RolSeleccionado == Roles.Directora)
            {
                var Padre = padres.First(x => x.ID == padre.ID);
                if (Padre != null)
                {
                    if (Padre.ListaHijos != null)
                    {
                        var Duplicado = Padre.ListaHijos.FirstOrDefault(x => x.ID == hijo.ID);
                        if (Duplicado != null)
                        {
                            Padre.ListaHijos.Remove(Duplicado);
                        }
                        else
                        {
                            res.Errores.Add("Hijo no asignado");
                        }
                    }                    
                    EditarPadreMadre(Padre.ID, Padre, usuarioLogueado);
                }
                else
                {
                    res.Errores.Add("El Padre no existe.");

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
        public Hijo[] ObtenerPersonas(Usuario usuarioLogueado)
        {          
            switch (usuarioLogueado.RolSeleccionado)
            {
                case Roles.Docente:
                    Docente docente = ConvertirDocente(usuarioLogueado);
                    return hijos.Where(x => docente.Salas.Contains(x.Sala)).ToArray();                  
                case Roles.Padre:
                    Padre padre = ConvertirPadre(usuarioLogueado);
                    return padre.ListaHijos.ToArray();                   
                case Roles.Directora:
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
        public Nota[] ObtenerCuadernoComunicaciones(int idPersona, Usuario usuarioLogueado)
        {
            List<Nota> nota = new List<Nota>();
            var alumno = hijos.FirstOrDefault(x => x.ID == idPersona);
            if (alumno != null)
            {
                switch (usuarioLogueado.RolSeleccionado)
                {
                    case Roles.Docente:
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
                    case Roles.Directora:
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
            AltNota(new AltaNotaArgs(hijo,nota));
            ActualizarArchivo("Hijo");
        }

        /// <summary>
        /// Alta de una nota, la nota puede estar dirigida a 1 o varias salas, o 1 o varios alumnos. Si el usuario es padre solamente podra enviar a sus hijos.
        /// </summary>
        /// <param name="nota"></param>
        /// <param name="salas"></param>
        /// <param name="hijos"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        public Resultado AltaNota(Nota nota, Sala[] salas, Hijo[] hijos, Usuario usuarioLogueado)
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
                case Roles.Docente:
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
                case Roles.Directora:
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
            ActualizarArchivo("Hijo");
            AltComentario(new AltaComentarioArgs(nuevoComentario, nota));
            nota.Comentarios = comment.ToArray();
        }

        /// <summary>
        /// Respuesta a una nota. Si es docente la nota debe ser de un alumno de la sala
        /// </summary>
        /// <param name="nota"></param>
        /// <param name="nuevoComentario"></param>
        /// <param name="usuarioLogueado"></param>
        /// <returns></returns>
        public Resultado ResponderNota(Nota nota, Comentario nuevoComentario, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado { Errores = new List<string>() };
            switch (usuarioLogueado.RolSeleccionado)
            {
                case Roles.Docente:
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
                case Roles.Directora:
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
        public Resultado MarcarNotaComoLeida(Nota nota, Usuario usuarioLogueado)
        {
            Resultado res = new Resultado { Errores = new List<string>() };
            switch (usuarioLogueado.RolSeleccionado)
            {
                case Roles.Docente:
                case Roles.Directora:
                    res.Errores.Add("No es usuario Padre");
                    break;
                case Roles.Padre:
                    Padre padre = ConvertirPadre(usuarioLogueado);
                    var esHijo = padre.ListaHijos.FirstOrDefault(x => x.Notas.Any(y => y.Id == nota.Id));
                    if (esHijo != null)
                    {
                        var NOTA = esHijo.Notas.FirstOrDefault(x => x.Id == nota.Id);
                        NOTA.Leida = true;
                        ActualizarArchivo("Hijo");

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
        public Grilla<Director> ObtenerDirectores(Usuario usuarioLogueado, int paginaActual, int totalPorPagina, string busquedaGlobal)
        {
            return new Grilla<Director>()
            {
                Lista = directores
                        .Where(x => string.IsNullOrEmpty(busquedaGlobal) || x.Nombre.Contains(busquedaGlobal) || x.Apellido.Contains(busquedaGlobal))
                        .Skip(paginaActual * totalPorPagina).Take(totalPorPagina).ToArray(),
                CantidadRegistros = directores.Count
            };
        }

        /// <summary>
        /// Grilla de docentes
        /// </summary>
        /// <param name="usuarioLogueado"></param>
        /// <param name="paginaActual"></param>
        /// <param name="totalPorPagina"></param>
        /// <param name="busquedaGlobal"></param>
        /// <returns></returns>
        public Grilla<Docente> ObtenerDocentes(Usuario usuarioLogueado, int paginaActual, int totalPorPagina, string busquedaGlobal)
        {
            return new Grilla<Docente>()
            {
                Lista = docentes
            .Where(x => string.IsNullOrEmpty(busquedaGlobal) || x.Nombre.Contains(busquedaGlobal) || x.Apellido.Contains(busquedaGlobal))
            .Skip(paginaActual * totalPorPagina).Take(totalPorPagina).ToArray(),
                CantidadRegistros = docentes.Count
            };
        }

        /// <summary>
        /// Grilla de padres
        /// </summary>
        /// <param name="usuarioLogueado"></param>
        /// <param name="paginaActual"></param>
        /// <param name="totalPorPagina"></param>
        /// <param name="busquedaGlobal"></param>
        /// <returns></returns>
        public Grilla<Padre> ObtenerPadres(Usuario usuarioLogueado, int paginaActual, int totalPorPagina, string busquedaGlobal)
        {
            return new Grilla<Padre>()
            {
                Lista = padres
            .Where(x => string.IsNullOrEmpty(busquedaGlobal) || x.Nombre.Contains(busquedaGlobal) || x.Apellido.Contains(busquedaGlobal))
            .Skip(paginaActual * totalPorPagina).Take(totalPorPagina).ToArray(),
                CantidadRegistros = padres.Count
            };
         }

        /// <summary>
        /// Grilla de alumnos
        /// </summary>
        /// <param name="usuarioLogueado"></param>
        /// <param name="paginaActual"></param>
        /// <param name="totalPorPagina"></param>
        /// <param name="busquedaGlobal"></param>
        /// <returns></returns>
        public Grilla<Hijo> ObtenerAlumnos(Usuario usuarioLogueado, int paginaActual, int totalPorPagina, string busquedaGlobal)
        {
            return new Grilla<Hijo>()
            {
                Lista = hijos
                 .Where(x => string.IsNullOrEmpty(busquedaGlobal) || x.Nombre.Contains(busquedaGlobal) || x.Apellido.Contains(busquedaGlobal))
                 .Skip(paginaActual * totalPorPagina).Take(totalPorPagina).ToArray(),
                CantidadRegistros = hijos.Count
            };
        }

        /// <summary>
        /// Obtener director por ID
        /// </summary>
        /// <param name="usuarioLogueado"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Director ObtenerDirectorPorId(Usuario usuarioLogueado, int id)
        {
            return directores.First(x => x.ID == id);
        }
        public Sala ObtenerSalaPorId(Usuario usuarioLogueado, int id)
        {
            return salas.First(x => x.Id == id);
        }

        /// <summary>
        /// Obtener docente por ID
        /// </summary>
        /// <param name="usuarioLogueado"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Docente ObtenerDocentePorId(Usuario usuarioLogueado, int id)
        {
            return docentes.FirstOrDefault(x => x.ID == id);
        }

        /// <summary>
        /// Obtener padre por ID
        /// </summary>
        /// <param name="usuarioLogueado"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Padre ObtenerPadrePorId(Usuario usuarioLogueado, int id)
        {
            return padres.First(x => x.ID == id);
        }

        /// <summary>
        /// Obtener hijo por ID
        /// </summary>
        /// <param name="usuarioLogueado"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Hijo ObtenerAlumnoPorId(Usuario usuarioLogueado, int id)
        {
            return hijos.First(x => x.ID == id);
        }

        public Institucion ObtenerInstitucionPorId(Usuario usuarioLogueado, int id)
        {
            return instituciones.First(x => x.Id == id);
        }
    }
}
