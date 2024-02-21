namespace SistemaGestion.DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public decimal? Cost { get; set; }
        public decimal SalePrice { get; set; }
        public int Stock { get; set; }
        public int UserId { get; set; }
    }
}
