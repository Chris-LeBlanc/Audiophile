namespace Audiophile.Models
{
    public class Login
    {
        public Guid LoginId { get; set; }

        public string? Email { get; set; } 

        public string? Password { get; set; }

        public User? User { get; set; }
    }
}