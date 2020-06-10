using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contratos;
using Lógica;

namespace Servicios
{
    public class GeneralServices : IServicioWeb
    {
        private static ClasePrincipal ClasePrincipal = new ClasePrincipal();

        public Contratos.Resultado AltaAlumno(Contratos.Hijo hijo, Contratos.UsuarioLogueado usuarioLogueado)
        {
            return Transformaciones.MétodosExtensión.ConvertirResultado(ClasePrincipal.AltaAlumno(Transformaciones.MétodosExtensión.ConvertirHijo(hijo), Transformaciones.MétodosExtensión.ConvertirUsuario(usuarioLogueado)));
        }
        public Contratos.Resultado AltaDirectora(Directora directora, UsuarioLogueado usuarioLogueado)
        {
            return Transformaciones.MétodosExtensión.ConvertirResultado(ClasePrincipal.AltaDirector(Transformaciones.MétodosExtensión.ConvertirDirector(directora), Transformaciones.MétodosExtensión.ConvertirUsuario(usuarioLogueado)));
        }

        public Contratos.Resultado AltaDocente(Contratos.Docente docente, UsuarioLogueado usuarioLogueado)
        {
            return Transformaciones.MétodosExtensión.ConvertirResultado(ClasePrincipal.AltaDocente(Transformaciones.MétodosExtensión.ConvertirDocente(docente), Transformaciones.MétodosExtensión.ConvertirUsuario(usuarioLogueado)));
        }

        public Contratos.Resultado AltaNota(Contratos.Nota nota, Contratos.Sala[] salas, Contratos.Hijo[] hijos, UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
        }

        public Contratos.Resultado AltaPadreMadre(Contratos.Padre padre, UsuarioLogueado usuarioLogueado)
        {
            return Transformaciones.MétodosExtensión.ConvertirResultado(ClasePrincipal.AltaPadreMadre(Transformaciones.MétodosExtensión.ConvertirPadre(padre), Transformaciones.MétodosExtensión.ConvertirUsuario(usuarioLogueado)));
        }

        public Contratos.Resultado AsignarDocenteSala(Contratos.Docente docente, Contratos.Sala sala, UsuarioLogueado usuarioLogueado)
        {
            return Transformaciones.MétodosExtensión.ConvertirResultado(ClasePrincipal.AsignarDocenteSala(Transformaciones.MétodosExtensión.ConvertirDocente(docente), Transformaciones.MétodosExtensión.ConvertirSala(sala), Transformaciones.MétodosExtensión.ConvertirUsuario(usuarioLogueado)));
        }

        public Contratos.Resultado AsignarHijoPadre(Contratos.Hijo hijo, Contratos.Padre padre, UsuarioLogueado usuarioLogueado)
        {
            return Transformaciones.MétodosExtensión.ConvertirResultado(ClasePrincipal.AsignarHijoPadre(Transformaciones.MétodosExtensión.ConvertirHijo(hijo), Transformaciones.MétodosExtensión.ConvertirPadre(padre), Transformaciones.MétodosExtensión.ConvertirUsuario(usuarioLogueado)));
        }

        public Contratos.Resultado DesasignarDocenteSala(Contratos.Docente docente, Contratos.Sala sala, UsuarioLogueado usuarioLogueado)
        {
            return Transformaciones.MétodosExtensión.ConvertirResultado(ClasePrincipal.DesasignarDocenteSala(Transformaciones.MétodosExtensión.ConvertirDocente(docente), Transformaciones.MétodosExtensión.ConvertirSala(sala), Transformaciones.MétodosExtensión.ConvertirUsuario(usuarioLogueado)));
        }

        public Contratos.Resultado DesasignarHijoPadre(Contratos.Hijo hijo, Contratos.Padre padre, UsuarioLogueado usuarioLogueado)
        {
            return Transformaciones.MétodosExtensión.ConvertirResultado(ClasePrincipal.DesasignarHijoPadre(Transformaciones.MétodosExtensión.ConvertirHijo(hijo), Transformaciones.MétodosExtensión.ConvertirPadre(padre), Transformaciones.MétodosExtensión.ConvertirUsuario(usuarioLogueado)));
        }

        public Contratos.Resultado EditarAlumno(int id, Contratos.Hijo hijo, UsuarioLogueado usuarioLogueado)
        {
            return Transformaciones.MétodosExtensión.ConvertirResultado(ClasePrincipal.EditarAlumno(id, Transformaciones.MétodosExtensión.ConvertirHijo(hijo), Transformaciones.MétodosExtensión.ConvertirUsuario(usuarioLogueado)));
        }

        public Contratos.Resultado EditarDirectora(int id, Directora directora, UsuarioLogueado usuarioLogueado)
        {
            return Transformaciones.MétodosExtensión.ConvertirResultado(ClasePrincipal.EditarDirector(id, Transformaciones.MétodosExtensión.ConvertirDirector(directora), Transformaciones.MétodosExtensión.ConvertirUsuario(usuarioLogueado)));
        }

        public Contratos.Resultado EditarDocente(int id, Contratos.Docente docente, UsuarioLogueado usuarioLogueado)
        {
            return Transformaciones.MétodosExtensión.ConvertirResultado(ClasePrincipal.EditarDocente(id, Transformaciones.MétodosExtensión.ConvertirDocente(docente), Transformaciones.MétodosExtensión.ConvertirUsuario(usuarioLogueado)));
        }

        public Contratos.Resultado EditarPadreMadre(int id, Contratos.Padre padre, UsuarioLogueado usuarioLogueado)
        {
            return Transformaciones.MétodosExtensión.ConvertirResultado(ClasePrincipal.EditarPadreMadre(id, Transformaciones.MétodosExtensión.ConvertirPadre(padre), Transformaciones.MétodosExtensión.ConvertirUsuario(usuarioLogueado)));
        }

        public Contratos.Resultado EliminarAlumno(int id, Contratos.Hijo hijo, UsuarioLogueado usuarioLogueado)
        {
            return Transformaciones.MétodosExtensión.ConvertirResultado(ClasePrincipal.EliminarAlumno(id, Transformaciones.MétodosExtensión.ConvertirHijo(hijo), Transformaciones.MétodosExtensión.ConvertirUsuario(usuarioLogueado)));
        }

        public Contratos.Resultado EliminarDirectora(int id, Directora directora, UsuarioLogueado usuarioLogueado)
        {
            return Transformaciones.MétodosExtensión.ConvertirResultado(ClasePrincipal.EliminarDirector(id, Transformaciones.MétodosExtensión.ConvertirDirector(directora), Transformaciones.MétodosExtensión.ConvertirUsuario(usuarioLogueado)));
        }

        public Contratos.Resultado EliminarDocente(int id, Contratos.Docente docente, UsuarioLogueado usuarioLogueado)
        {
            return Transformaciones.MétodosExtensión.ConvertirResultado(ClasePrincipal.EliminarDocente(id, Transformaciones.MétodosExtensión.ConvertirDocente(docente), Transformaciones.MétodosExtensión.ConvertirUsuario(usuarioLogueado)));
        }

        public Contratos.Resultado EliminarPadreMadre(int id, Contratos.Padre padre, UsuarioLogueado usuarioLogueado)
        {
            return Transformaciones.MétodosExtensión.ConvertirResultado(ClasePrincipal.EliminarPadreMadre(id, Transformaciones.MétodosExtensión.ConvertirPadre(padre), Transformaciones.MétodosExtensión.ConvertirUsuario(usuarioLogueado)));
        }

        public Contratos.Resultado MarcarNotaComoLeida(Contratos.Nota nota, UsuarioLogueado usuarioLogueado)
        {
            return Transformaciones.MétodosExtensión.ConvertirResultado(ClasePrincipal.MarcarNotaComoLeida(Transformaciones.MétodosExtensión.ConvertirNota(nota), Transformaciones.MétodosExtensión.ConvertirUsuario(usuarioLogueado)));
        }

        public Contratos.Hijo ObtenerAlumnoPorId(UsuarioLogueado usuarioLogueado, int id)
        {
            throw new NotImplementedException();
        }

        public Grilla<Contratos.Hijo> ObtenerAlumnos(UsuarioLogueado usuarioLogueado, int paginaActual, int totalPorPagina, string busquedaGlobal)
        {
            throw new NotImplementedException();
        }

        public Contratos.Nota[] ObtenerCuadernoComunicaciones(int idPersona, UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
        }

        public Directora ObtenerDirectoraPorId(UsuarioLogueado usuarioLogueado, int id)
        {
            throw new NotImplementedException();
        }

        public Grilla<Directora> ObtenerDirectoras(UsuarioLogueado usuarioLogueado, int paginaActual, int totalPorPagina, string busquedaGlobal)
        {
            throw new NotImplementedException();
        }

        public Contratos.Docente ObtenerDocentePorId(UsuarioLogueado usuarioLogueado, int id)
        {
            throw new NotImplementedException();
        }

        public Grilla<Contratos.Docente> ObtenerDocentes(UsuarioLogueado usuarioLogueado, int paginaActual, int totalPorPagina, string busquedaGlobal)
        {
            throw new NotImplementedException();
        }

        public Contratos.Institucion[] ObtenerInstituciones()
        {
            throw new NotImplementedException();
        }

        public string ObtenerNombreGrupo()
        {
            return ClasePrincipal.ObtenerNombreGrupo();
        }

        public Contratos.Padre ObtenerPadrePorId(UsuarioLogueado usuarioLogueado, int id)
        {
            return Transformaciones.MétodosExtensión.ConvertirPadre(ClasePrincipal.ObtenerPadrePorId(Transformaciones.MétodosExtensión.ConvertirUsuario(usuarioLogueado), id));
        }

        public Grilla<Contratos.Padre> ObtenerPadres(UsuarioLogueado usuarioLogueado, int paginaActual, int totalPorPagina, string busquedaGlobal)
        {
            throw new NotImplementedException();
        }

        public Contratos.Hijo[] ObtenerPersonas(UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
        }

        public Contratos.Sala[] ObtenerSalasPorInstitucion(UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
        }
        
        public UsuarioLogueado ObtenerUsuario(string email, string clave)
        {
            throw new NotImplementedException();
        }

        public Contratos.Resultado ResponderNota(Contratos.Nota nota, Contratos.Comentario nuevoComentario, UsuarioLogueado usuarioLogueado)
        {
            return Transformaciones.MétodosExtensión.ConvertirResultado(ClasePrincipal.ResponderNota(Transformaciones.MétodosExtensión.ConvertirNota(nota), Transformaciones.MétodosExtensión.ConvertirComentario(nuevoComentario), Transformaciones.MétodosExtensión.ConvertirUsuario(usuarioLogueado)));
        }

    }
}
