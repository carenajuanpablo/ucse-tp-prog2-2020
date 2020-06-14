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
        readonly string pathListaDeSalas = Path.GetFullPath("c:\\Users\\jcarena\\Documents\\TP2020\\ListaDeSalas.txt");
        readonly string pathListaDeNotas = Path.GetFullPath("c:\\Users\\jcarena\\Documents\\TP2020\\ListaDeNotas.txt");


        List<Institucion> instituciones { get; set; }
        List<Hijo> hijos { get; set; }
        List<Padre> padres { get; set; }
        List<Docente> docentes { get; set; }
        List<Director> directores { get; set; }
        List<Sala> salas { get; set; }
        List<Nota> notas { get; set; }



        public Usuario UsuarioLogueado;
        public Institucion Institución = new Institucion();

        public ClasePrincipal()
        {
            instituciones = LeerListaDeInstituciones();
            hijos = LeerListaDeHijos();
            padres = LeerListaDePadres();
            docentes = LeerListaDeDocentes();
            directores = LeerListaDeDirectores();
            salas = LeerListaDeSalas();
            notas = LeerListaDeNotas();


            //Instituciones Ejemplo
            Institucion Institucion1 = new Institucion() { Ciudad = "Rafaela", Direccion = "España 84", Id = 1, Nombre = "UCSE", Provincia = "SF", Telefono = "4545654" };
            Institucion Institucion2 = new Institucion() { Ciudad = "Rosario", Direccion = "Zeballos 1500", Id = 2, Nombre = "UTN", Provincia = "SF", Telefono = "4555556" };
            instituciones.Add(Institucion1);
            instituciones.Add(Institucion2);
            ActualizarArchivo("Institucion");

            //Salas Ejemplo
            Sala Sala1 = new Sala() { Id = 1, Nombre = "1A", institucion = Institucion1 };
            Sala Sala2 = new Sala() { Id = 2, Nombre = "2A", institucion = Institucion1 };
            Sala Sala3 = new Sala() { Id = 3, Nombre = "2B", institucion = Institucion2 };
            salas.Add(Sala1);
            salas.Add(Sala2);
            salas.Add(Sala3);
            ActualizarArchivo("Sala");

            //Directores Ejemplo
            Director Director1 = new Director() { ID = 1, Nombre = "Roger", Apellido = "Taylor", Email = "A1", Cargo = "A", Contraseña = "123", Roles = new Roles[] { Roles.Directora }, RolSeleccionado = Roles.Directora, Institucion = Institucion1, FechaIngreso = new DateTime(2020, 01, 02) };
            Director Director2 = new Director() { ID = 2, Nombre = "John", Apellido = "Deacon", Email = "A2", Cargo = "B", Contraseña = "123", Roles = new Roles[] { Roles.Directora }, RolSeleccionado = Roles.Directora, Institucion = Institucion2, FechaIngreso = new DateTime(2020, 01, 02) };
            directores.Add(Director1);
            directores.Add(Director2);
            ActualizarArchivo("Director");

            //Notas Ejemplos
            Nota Nota1 = new Nota() { Id = 1, Titulo = "Nota1", FechaEventoAsociado = new DateTime(2020, 03, 02), Descripcion = "esto es una nota1", Comentarios = new Comentario[] { } };//, Comentarios = new Comentario[] { new Comentario() { Fecha = new DateTime(2020,01,02), Mensaje = "Comentario1", Usuario = Director1 } } };
            Nota Nota2 = new Nota() { Id = 2, Titulo = "Nota2", FechaEventoAsociado = new DateTime(2020, 03, 02), Descripcion = "esto es una nota2", Comentarios = new Comentario[] { } };// Comentarios = new Comentario[] { new Comentario() { Fecha = new DateTime(2020, 01, 02), Mensaje = "Comentario1", Usuario = Director1 } } };
            notas.Add(Nota1);
            notas.Add(Nota2);
            ActualizarArchivo("Nota");


            //Alumnos Ejemplos
            Hijo Hijo1 = new Hijo() { Nombre = "Damian", Apellido = "Manzo", Email = "D1", FechaNacimiento = new DateTime(1990, 05, 03), ResultadoUltimaEvaluacionAnual = 4, ID = 1, Institucion = Institucion1, Sala = Sala1, Notas = new List<Nota> {Nota1 } };
            Hijo Hijo2 = new Hijo() { Nombre = "Roberto", Apellido = "Sensini", Email = "D2", FechaNacimiento = new DateTime(1940, 05, 03), ResultadoUltimaEvaluacionAnual = 8, ID = 2, Institucion = Institucion1, Sala = Sala2, Notas = new List<Nota> { Nota2 } };

            hijos.Add(Hijo1);
            hijos.Add(Hijo2);

            ActualizarArchivo("Hijo");

            //Padres Ejemplo
            Padre Padre1 = new Padre() { Nombre = "Roberto", ID = 1, Apellido = "Pereyra", Email = "C1", Contraseña = "123", Roles = new Roles[] { Roles.Padre }, RolSeleccionado = Roles.Padre };
            Padre Padre2 = new Padre() { Nombre = "Juan Pablo", ID = 2, Apellido = "Disummo", Email = "C2", Contraseña = "123", Roles = new Roles[] { Roles.Padre }, RolSeleccionado = Roles.Padre, ListaHijos = new List<Hijo> { Hijo1 }, Institucion = Institucion1 };

            padres.Add(Padre1);
            padres.Add(Padre2);
            ActualizarArchivo("Padre");


            //Docentes Ejemplo
            Docente Docente1 = new Docente() { Institucion = Institucion1, ID = 1, Nombre = "Maximiliano", Apellido = "Lovera", Email = "B1", Roles = new Roles[] { Roles.Docente }, RolSeleccionado = Roles.Docente, Contraseña = "123"};
            docentes.Add(Docente1);
            ActualizarArchivo("Docente");
            

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
        public List<Sala> LeerListaDeSalas()
        {
            if (!File.Exists(pathListaDeSalas))
            {
                TextWriter archivo = new StreamWriter(pathListaDeSalas);
                List<Sala> Lista = new List<Sala>();
                archivo.Close();
                return Lista;
            }
            else
            {
                using (StreamReader archivo = new StreamReader(pathListaDeSalas))
                {
                    string JsonContenido = archivo.ReadToEnd();
                    List<Sala> Lista = JsonConvert.DeserializeObject<List<Sala>>(JsonContenido);

                    archivo.Close();

                    if (Lista == null)
                        Lista = new List<Sala>();
                    return Lista;
                }
            }
        }
        public List<Nota> LeerListaDeNotas()
        {
            if (!File.Exists(pathListaDeNotas))
            {
                TextWriter archivo = new StreamWriter(pathListaDeNotas);
                List<Nota> Lista = new List<Nota>();
                archivo.Close();
                return Lista;
            }
            else
            {
                using (StreamReader archivo = new StreamReader(pathListaDeNotas))
                {
                    string JsonContenido = archivo.ReadToEnd();
                    List<Nota> Lista = JsonConvert.DeserializeObject<List<Nota>>(JsonContenido);

                    archivo.Close();

                    if (Lista == null)
                        Lista = new List<Nota>();
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
            if (!File.Exists(pathListaDePadres))
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
            if (!File.Exists(pathListaDeDocentes))
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
            if (!File.Exists(pathListaDeDirectores))
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
                case "Sala":
                    using (StreamWriter archivo = new StreamWriter(pathListaDeSalas))
                    {
                        string JsonContenido = JsonConvert.SerializeObject(salas);
                        archivo.Write(JsonContenido);
                        archivo.Close();
                    }
                    break;
                case "Nota":
                    using (StreamWriter archivo = new StreamWriter(pathListaDeNotas))
                    {
                        string JsonContenido = JsonConvert.SerializeObject(notas);
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
                    Docente Doc = ConvertirDocente(User);
                    Inst = Doc.Institucion;
                    break;
                case Roles.Padre:
                    Padre Pad = ConvertirPadre(User);
                    Inst = Pad.Institucion;
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
            
            if (UsuarioEncontrado != null)
            {
                Institución = ObtenerInstituciónUsuarioLogueado(UsuarioLogueado);
            }
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
        /// <param name="hijo"></param>AltaAlum
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
                    if (hijo.Roles == null)
                    {
                        hijo.Roles = new Roles[] { Roles.Directora };
                    }
                    else
                    {
                        int i = hijo.Roles.Length;
                        hijo.Roles[i] = Roles.Directora;
                    }

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

            var existe = hijos.First(x => x.ID == alumnoEditar.ID);
            if (existe != null)
                {
                    alumnoEditar.Notas = hijo.Notas;
                    alumnoEditar.Sala = hijo.Sala;
                    alumnoEditar.Nombre = hijo.Nombre;
                    alumnoEditar.Apellido = hijo.Apellido;
                    alumnoEditar.Email = hijo.Email;
                    alumnoEditar.FechaNacimiento = hijo.FechaNacimiento;
                    alumnoEditar.ResultadoUltimaEvaluacionAnual = hijo.ResultadoUltimaEvaluacionAnual;
                    int indice = hijos.IndexOf(alumnoEditar);
                    hijos[indice] = alumnoEditar;
                    ActualizarArchivo("Hijo");
                   // AbmUsuario(new AbmUsuarioArgs(hijo));
                }
                else
                {
                    res.Errores.Add("El alumno que se quiere editar no existe.");
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
                    directorEditar.Nombre = director.Nombre;
                    directorEditar.Apellido = director.Apellido;
                    directorEditar.Email = director.Email;
                    directorEditar.FechaIngreso = director.FechaIngreso;
                    directorEditar.Cargo = director.Cargo;
                   
                    int indice = directores.IndexOf(directorEditar);
                    directores[indice] = directorEditar;
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
                    Docente docente = ObtenerDocentePorId(UsuarioLogueado,UsuarioLogueado.ID);
                    if (docente.Salas != null)
                    {
                        Salas = docente.Salas;
                    }

                    break;
                case Roles.Padre:
                    throw new Exception("Inaccesible.");
                case Roles.Directora:
                    Salas = salas;

                    Director director = ObtenerDirectorPorId(usuarioLogueado, UsuarioLogueado.ID);

                    Salas = salas.Where(x => x.institucion != null && x.institucion.Id == director.Institucion.Id).ToList();


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
                    docenteEditar.Nombre = docente.Nombre;
                    docenteEditar.Apellido = docente.Apellido;
                    docenteEditar.Email = docente.Email;

                    int indice = docentes.IndexOf(docenteEditar);
                        docentes[indice] = docenteEditar;
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
                    padre.Institucion = Institución;
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
                    padreEditar.Nombre = padre.Nombre;
                    padreEditar.Apellido = padre.Apellido;
                    padreEditar.Email = padre.Email;
                   int indice = padres.IndexOf(padreEditar);
                   padres[indice] = padreEditar;
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
                    Sala Sala = ObtenerSalaPorId(usuarioLogueado,sala.Id);
                    if (Docente.Salas == null)
                    {
                        List<Sala> salas = new List<Sala>();
                        salas.Add(Sala);
                        Docente.Salas = salas;
                    }
                    else
                    {
                        var Duplicado = Docente.Salas.FirstOrDefault(x => x.Id == sala.Id);
                        if (Duplicado == null)
                        {
                            Docente.Salas.Add(Sala);
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
                        ListaHijo.Add(Hijo);
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
            List<Hijo> Hijos = new List<Hijo>();
            switch (usuarioLogueado.RolSeleccionado)
            {
                case Roles.Docente:
                    Docente docente = ObtenerDocentePorId(UsuarioLogueado,UsuarioLogueado.ID);
                    // return hijos.Where(x => x.Sala.Id == docente.Salas.Any(y => y.Id == x.Sala.Id));
                    if (docente.Salas != null)
                    {
                        return hijos.Where(x => docente.Salas.Contains(x.Sala)).ToArray();
                    }
                    return Hijos.ToArray();
                case Roles.Padre:
                    Padre padre = ObtenerPadrePorId(UsuarioLogueado, UsuarioLogueado.ID);

                    if (padre.ListaHijos != null)
                    {
                        return padre.ListaHijos.ToArray();
                    }
                    else
                    {
                        return Hijos.ToArray();
                    }
                    /*
                    if (padre.ListaHijos?.Any()?.GetValueOrDefault())
                    {

                        return Hijos.ToArray();
                    }
                    else
                    {

                       return padre.ListaHijos.ToArray();
                    }
                    */
                   
                case Roles.Directora:
                    //var director = ObtenerDirectorPorId(usuarioLogueado, UsuarioLogueado.ID);
                    Hijos = hijos.Where(x => x.Institucion.Id == Institución.Id).ToList();
                    return Hijos.ToArray();
                    //return hijos.Where(x => x.Institucion == Institución).ToArray();
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
                            Docente docente = ObtenerDocentePorId(UsuarioLogueado, UsuarioLogueado.ID);
                            //   var Coincide = docente.Salas.FirstOrDefault(x => x.alumnos.Any(y => y.ID == idPersona));
                            //  if (Coincide != null)
                            {
                                foreach (var item in alumno.Notas)
                                {
                                    nota.Add(item);
                                }
                            }
                            //    else
                            //   {
                            //  throw new Exception("Alumno no pertenece a un aula del profesor");
                            //  }
                            break;
                        }
                    case Roles.Padre:
                        {
                            Padre padre = ObtenerPadrePorId(UsuarioLogueado, UsuarioLogueado.ID);
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
                            //Director director = ConvertirDirector(usuarioLogueado);
                            if (Institución == alumno.Institucion)
                            {
                                if (alumno.Notas != null)
                                {
                                    foreach (var item in alumno.Notas)
                                    {
                                        nota.Add(item);
                                    }
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
            nota.Id = notas.Count + 1;
            nota.FechaEventoAsociado = DateTime.Today;
            nota.Comentarios = new Comentario[] { };
            notasHijo.Add(nota);
            hijo.Notas = notasHijo;

            notas.Add(nota);
            ActualizarArchivo("Nota");
            //AltNota(new AltaNotaArgs(hijo,nota));
            EditarAlumno(hijo.ID, hijo, UsuarioLogueado);
            //ActualizarArchivo("Hijo");
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
                        Padre padre = ObtenerPadrePorId(UsuarioLogueado,UsuarioLogueado.ID);
                        if (hijos != null && hijos.Length > 0)
                        {
                            foreach (var item in hijos)
                            {
                                Hijo Hijo = ObtenerAlumnoPorId(usuarioLogueado, item.ID);
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
                        Docente docente = ObtenerDocentePorId(UsuarioLogueado,UsuarioLogueado.ID);
                        if (hijos != null && hijos.Length > 0)
                        {
                            foreach (var item in hijos)
                            {
                                Hijo Hijo = ObtenerAlumnoPorId(usuarioLogueado, item.ID);
                                if (docente.Institucion == Hijo.Institucion)
                                {
                                    GuardarNota(Hijo, nota);
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
                        //Director director = ConvertirDirector(usuarioLogueado);
                        if (hijos != null && hijos.Length > 0)
                        {
                            foreach (var item in hijos)
                            {
                                Hijo Hijo = ObtenerAlumnoPorId(usuarioLogueado,item.ID);
                                if (Institución == Hijo.Institucion)
                                {
                                    GuardarNota(Hijo, nota);
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
                                if (Institución == item.Institucion)
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


        public void AgregarComentario(Nota nota, Comentario nuevoComentario, Hijo hijo)
        {
            //var comment = nota.Comentarios == null ? new List<Comentario>() : nota.Comentarios.ToList();
            // comment.Add(nuevoComentario);
            var NOTA = hijo.Notas.FirstOrDefault(x => x.Id == nota.Id);
            hijo.Notas.Remove(NOTA);
            notas.Remove(NOTA);
            if (NOTA.Comentarios == null)
            {
                List<Comentario> Comentario = new List<Comentario>();
                Comentario.Add(nuevoComentario);
                NOTA.Comentarios = Comentario.ToArray();
               hijo.Notas.Add(NOTA);
            }
            else
            {
                List<Comentario> Com = NOTA.Comentarios.ToList();
                Com.Add(nuevoComentario);
                NOTA.Comentarios = Com.ToArray();
                hijo.Notas.Add(NOTA);
            }
            notas.Add(NOTA);
            ActualizarArchivo("Nota");
            /*
            int cant = NOTA.Comentarios.Count();
            NOTA.Comentarios[cant-1] = nuevoComentario;

            nota.Comentarios = comment.ToArray();
            hijo.Notas.Add(nota);
            */
            EditarAlumno(hijo.ID, hijo, UsuarioLogueado);
           // ActualizarArchivo("Hijo");
           // AltComentario(new AltaComentarioArgs(nuevoComentario, nota));
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
                    var alumno = hijos.FirstOrDefault(x => x.Notas != null && x.Notas.Any(y => y.Id == nota.Id));

                    Docente docente = ObtenerDocentePorId(UsuarioLogueado, UsuarioLogueado.ID);
                    //var esAlumno = docente.Salas.FirstOrDefault(x => x.alumnos.Any(y => y.Notas.Any(z => z.Id == nota.Id)));
                    // if (esAlumno != null)
                    //  {
                    AgregarComentario(nota, nuevoComentario, alumno);
                    //    }
                    //   else
                    //   {
                    //   res.Errores.Add($"La nota no corresponde a un alumno del profesor");
                    //}
                    break;
                case Roles.Padre:
                    Padre padre = ObtenerPadrePorId(UsuarioLogueado, UsuarioLogueado.ID);
                    var esHijo = padre.ListaHijos.FirstOrDefault(x => x.Notas != null && x.Notas.Any(y => y.Id == nota.Id));
                    if (esHijo != null)
                    {
                        AgregarComentario(nota, nuevoComentario, esHijo);
                    }
                    else
                    {
                        res.Errores.Add($"La nota no corresponde a un hijo del usuario logueado");
                    }
                    break;
                case Roles.Directora:
                    //Director director = ObtenerDirectorPorId(usuarioLogueado, usuarioLogueado.ID);
                    // var result = hijos.Where(c => c.Notas.Where(p => p.Id == nota.Id).Any());
                    //var alumno = hijos.Where(d => d.Notas != null && d.Notas.Any(s => s.Id == nota.Id));

                    var alumno2 = hijos.FirstOrDefault(x => x.Notas != null && x.Notas.Any(y => y.Id == nota.Id));
                    if (Institución == alumno2.Institucion)
                    {
                        AgregarComentario(nota, nuevoComentario, alumno2);
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
                    Padre padre = ObtenerPadrePorId(UsuarioLogueado, UsuarioLogueado.ID);
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
            return directores.FirstOrDefault(x => x.ID == id);
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
            return padres.FirstOrDefault(x => x.ID == id);
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
