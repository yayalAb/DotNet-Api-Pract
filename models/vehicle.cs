using System.ComponentModel.DataAnnotations;

namespace MVC_Web_Api.models
{
    public class vehicle
    {
        [Key]
        public int Id { get; set; }
        public String Owner { get; set; } = String.Empty;
        public String Driver { get; set; } = String.Empty;
        public String Type { get; set; } = String.Empty;
        public String Model { get; set; }
    }
}
