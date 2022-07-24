
using System.ComponentModel.DataAnnotations;

namespace MVC_Web_Api.models
{
    public class OrderList
    {
        [Key]
        public int Id { get; set; }
        public  List<Orders> OrderId { get; set; }
        public Product Product_Id { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
    }
}
