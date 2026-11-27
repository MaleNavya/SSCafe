namespace SSCafe.UserManagement.Domain.Entities
{
    public class Menu
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        
    }
}