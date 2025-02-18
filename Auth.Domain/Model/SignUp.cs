using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AuthService.Model
{
    public class SignUp
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
    }
}
