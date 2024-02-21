using SistemaGestion.DTOs;
using SistemaGestion.SistemaGestionData;
using SistemaGestion.SistemaGestionEntities;

namespace SistemaGestion.Mapper
{
    public class UsuarioMapper
    {
        public static Usuario MapearAProducto(UsuarioDTO dto)
        {
            Usuario usuario = new Usuario();
            usuario.Id = dto.Id;
            usuario.Name = dto.Name;
            usuario.LastName = dto.LastName;
            usuario.UserName = dto.UserName;
            usuario.Password = dto.Password;
            usuario.Mail = dto.Mail;

            return usuario;
        }

        public static UsuarioDTO MapearADTO(Usuario usuario)
        {
            UsuarioDTO dto = new UsuarioDTO();

            dto.Id = usuario.Id;
            dto.Name = usuario.Name;
            dto.LastName = usuario.LastName;
            dto.UserName = usuario.UserName;
            dto.Password = usuario.Password;
            dto.Mail = usuario.Mail;

            return dto;

        }
    }
}
