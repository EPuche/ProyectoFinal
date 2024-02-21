namespace SistemaGestion.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Mail { get; set; } = null!;
    }
}
