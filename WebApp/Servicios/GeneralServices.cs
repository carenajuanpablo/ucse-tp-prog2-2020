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

        public Contratos.Resultado AltaAlumno(Contratos.Hijo hijo, UsuarioLogueado usuarioLogueado)
        {
            //metodos de extension
            return ClasePrincipal.AltaAlumno(hijo,usuarioLogueado);
        }

        public Contratos.Resultado AltaDirectora(Directora directora, UsuarioLogueado usuarioLogueado)
        {
            return ClasePrincipal.AltaDirector(directora, usuarioLogueado);
        }

        public Contratos.Resultado AltaDocente(Contratos.Docente docente, UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
        }

        public Contratos.Resultado AltaNota(Contratos.Nota nota, Contratos.Sala[] salas, Contratos.Hijo[] hijos, UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
        }

        public Contratos.Resultado AltaPadreMadre(Contratos.Padre padre, UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
        }

        public Contratos.Resultado AsignarDocenteSala(Contratos.Docente docente, Contratos.Sala sala, UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
        }

        public Contratos.Resultado AsignarHijoPadre(Contratos.Hijo hijo, Contratos.Padre padre, UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
        }

        public Contratos.Resultado DesasignarDocenteSala(Contratos.Docente docente, Contratos.Sala sala, UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
        }

        public Contratos.Resultado DesasignarHijoPadre(Contratos.Hijo hijo, Contratos.Padre padre, UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
        }

        public Contratos.Resultado EditarAlumno(int id, Contratos.Hijo hijo, UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
        }

        public Contratos.Resultado EditarDirectora(int id, Directora directora, UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
        }

        public Contratos.Resultado EditarDocente(int id, Contratos.Docente docente, UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
        }

        public Contratos.Resultado EditarPadreMadre(int id, Contratos.Padre padre, UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
        }

        public Contratos.Resultado EliminarAlumno(int id, Contratos.Hijo hijo, UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
        }

        public Contratos.Resultado EliminarDirectora(int id, Directora directora, UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
        }

        public Contratos.Resultado EliminarDocente(int id, Contratos.Docente docente, UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
        }

        public Contratos.Resultado EliminarPadreMadre(int id, Contratos.Padre padre, UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
        }

        public Contratos.Resultado MarcarNotaComoLeida(Contratos.Nota nota, UsuarioLogueado usuarioLogueado)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public Contratos.Padre ObtenerPadrePorId(UsuarioLogueado usuarioLogueado, int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
