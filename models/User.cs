namespace MVC_Web_Api.models
{
    public class User
    {
        public String Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
