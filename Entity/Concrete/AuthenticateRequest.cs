using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete
{
    public class AuthenticateRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
