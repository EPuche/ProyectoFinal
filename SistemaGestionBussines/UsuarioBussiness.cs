﻿using SistemaGestion.DTOs;
using SistemaGestion.SistemaGestionEntities;
using SistemaGestion.SistemaGestionData;

namespace SistemaGestion.SistemaGestionBussines
{
    public class UsuarioBussiness
    {
        private UsuarioData usuarioData;

        public UsuarioBussiness(UsuarioData usuarioData)
        {
            this.usuarioData = usuarioData;
        }
        public  List<Usuario> ListarUsuarioBussines()
        {
            return usuarioData.ListarUsuarios();
        }

        public  UsuarioDTO ObtenerUsuarioBussines(string user)
        {
            return usuarioData.ObtenerUsuario(user);
        }

        public  bool CrearUsuarioBussines(UsuarioDTO usuario)
        {
            return usuarioData.CrearUsuario(usuario);

        }

        public  bool ModificarUsuarioBussines(UsuarioDTO usuario, int id)
        {
            return usuarioData.ModificarUsuario(usuario, id);
        }

        public  bool EliminarUsuarioBussines(int id)
        {
            return usuarioData.EliminarUsuario(id);
        }
    }
}
