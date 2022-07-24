using System.ComponentModel.DataAnnotations;

namespace MVC_Web_Api.models
{
    public class driver
    {
        [Key]
        public int  Id { get; set; }
        public String Name { get; set; } = String.Empty;
        public String Email { get; set; }= String.Empty;
        public String Phone { get; set; }= String.Empty;
        public int Age { get; set; }
    }
}
