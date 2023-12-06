namespace MobileHub.Src.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Fullname { get; set; } = string.Empty;
        public string Rut { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime Birthday { get; set; } = DateTime.Now;
    }
}