using Microsoft.EntityFrameworkCore;
using SistemaGestion.Controllers;
using SistemaGestion.DTOs;
using SistemaGestion.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestion.SistemaGestionEntities;
using SistemaGestion.database;

namespace SistemaGestion.SistemaGestionData
{
    public  class UsuarioData
    {
        private  SistemaGestionContext context;
        public UsuarioData(SistemaGestionContext coderContext)
        {
            this.context = coderContext;

        }

        public  List<Usuario> ListarUsuarios()
        {
                List<Usuario> usuarios = this.context.Usuarios.ToList();

                return usuarios;
        }

        public  Usuario ObtenerUsuario(int id)
        {
            

                Usuario? usuarioBuscado = this.context.Usuarios.Where(u => u.Id == id).FirstOrDefault();
                return usuarioBuscado;
            
        }

        public  bool CrearUsuario(UsuarioDTO usuario)
        {
                Usuario u = UsuarioMapper.MapearAProducto(usuario);
                this.context.Usuarios.Add(u);
                this.context.SaveChanges();
                return true;
 
        }

        public bool ModificarUsuario(UsuarioDTO usuario, int id)
        {


            Usuario? usuarioBuscado = this.context.Usuarios.Where(p => p.Id == id).FirstOrDefault();

            if (usuarioBuscado is not null)
            {
                usuarioBuscado.Name = usuario.Name;
                usuarioBuscado.LastName = usuario.LastName;
                usuarioBuscado.UserName = usuario.UserName;
                usuarioBuscado.Password = usuario.Password;
                usuarioBuscado.Mail = usuario.Mail;

                this.context.Usuarios.Update(usuarioBuscado);

                this.context.SaveChanges();

                return true;
            }
            return false;
        }

        public  bool EliminarUsuario(int id)
        {
            
                Usuario usuarioAEliminar = this.context.Usuarios.Where(us => us.Id == id).FirstOrDefault();

                if (usuarioAEliminar is not null)
                {
                    this.context.Usuarios.Remove(usuarioAEliminar);
                    this.context.SaveChanges();
                    return true;
                }
            

            return false;
        }

    }
}
