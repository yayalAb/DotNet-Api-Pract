using System.ComponentModel.DataAnnotations;

namespace MVC_Web_Api.models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String ProductName { get; set; } = string.Empty;
        [Required]
        public String ProductCategory { get; set; } = string.Empty;
        [Required]
        public String ProductQuality { get; set; }=string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; } 

        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpireDate { get; set; }

        [Range(0,int.MaxValue)]
        public int Content { get; set; }

        [Range(0.0, Double.MaxValue)]
        public Double UnitPrice { get; set; }

    }
}
