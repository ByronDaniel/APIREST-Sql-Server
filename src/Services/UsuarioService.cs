using Microsoft.EntityFrameworkCore;
using product.Api.Infraestructure;
using product.API.Models;

namespace product.API.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly masterContext _context;
        public UsuarioService(masterContext context)
        {
            _context = context;
        }
        List<Usuario> IUsuarioService.GetUsuarios()
        {
            List<Usuario> usuarios = _context.usuario.ToList();
            if (usuarios.Count == 0)
            {
                throw new Exception("No existen usuarios");
            }
            return usuarios;
        }

        Usuario IUsuarioService.GetUsuario(string ci)
        {
            Usuario usuario = _context.usuario.FirstOrDefault(usuario => usuario.Ci == ci);
            if (usuario == null)
            {
                throw new Exception("No existe el usuario");
            }
            return usuario;
        }

        Usuario IUsuarioService.PostUsuario(Usuario usuario)
        {
            try
            {
                _context.usuario.Add(usuario);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.ToString());
            }
            return usuario;
        }

        Usuario IUsuarioService.UpdateUsuario(Usuario usuario)
        {
            try
            {
                _context.Entry(usuario).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return usuario;
        }

        String IUsuarioService.DeleteUsuario(string ci)
        {
            var usuario = _context.usuario.FirstOrDefault(u => u.Ci == ci);
            try
            {
                if (usuario != null)
                {
                    _context.usuario.Remove(usuario);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("No existe el usuario a eliminar");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ci;
        }
    }
}
