using System.ComponentModel.DataAnnotations;

namespace MVC_Web_Api.models
{
    public class Auth
    {
        [Key]
        public String email { get; set; }
        public String UserType { get; set; }
        public String password { get; set; }

    }
}
