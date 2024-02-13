using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WepApiProyectoFinal.database;
using WepApiProyectoFinal.models;

namespace Entregable2.service
{
    public static class UsuarioData
    {
        public static List<Usuario> ListarUsuarios()
        {
            using (SistemaGestionContext context = new SistemaGestionContext())
            {

                List<Usuario> usuarios = context.Usuarios.ToList();

                return usuarios;

            }
        }

        public static Usuario ObtenerUsuario(int id)
        {
            using (SistemaGestionContext context = new SistemaGestionContext())
            {

                Usuario? usuarioBuscado = context.Usuarios.Where(u => u.Id == id).FirstOrDefault();
                return usuarioBuscado;
            }
        }

        public static bool CrearUsuario(Usuario usuario)
        {
            using (SistemaGestionContext context = new SistemaGestionContext())
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
                return true;
            }


        }

        public static bool ModificarUsuario(Usuario usuario, int id)
        {
            using (SistemaGestionContext context = new SistemaGestionContext())
            {
                Usuario? usuarioBuscado = ObtenerUsuario(id);


                usuarioBuscado.Name = usuario.Name;
                usuarioBuscado.LastName = usuario.LastName;
                usuarioBuscado.UserName = usuario.UserName;
                usuarioBuscado.Password = usuario.Password;
                usuarioBuscado.Mail = usuario.Mail;

                context.Usuarios.Update(usuarioBuscado);

                context.SaveChanges();

                return true;
            }
        }

        public static bool EliminarUsuario(int id)
        {
            using (SistemaGestionContext context = new SistemaGestionContext())
            {
                Usuario usuarioAEliminar = context.Usuarios.Where(us => us.Id == id).FirstOrDefault();

                if (usuarioAEliminar is not null)
                {
                    context.Usuarios.Remove(usuarioAEliminar);
                    context.SaveChanges();
                    return true;
                }
            }

            return false;
        }

    }
}
