using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MVC_Web_Api.models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }
        public String OrderedBy { get; set; } = String.Empty;
        [JsonIgnore]
        public driver Driver { get; set; } 

        public int DriverId { get; set; }

        public String Start { get; set; } = String.Empty;
        public String Destination { get; set; } = String.Empty;
        public Boolean status { get; set; } = false;


    }
}
