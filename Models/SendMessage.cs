using System.ComponentModel.DataAnnotations;

namespace CoffeShop.Models
{
    public class SendMessage
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
    }
}
