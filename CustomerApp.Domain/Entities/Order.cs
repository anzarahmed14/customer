using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Domain.Entities
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }

        // Foreign Key
        public Guid CustomerId { get; set; }

        // Foreign Key
        [ForeignKey("PaymentMethod")]
        public Guid PaymentId { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderNo { get; set; } = string.Empty;

        public decimal OrderTotal { get; set; }

        // Navigation Properties
        public Customer Customer { get; set; } = null!;

        public PaymentMethod PaymentMethod { get; set; } = null!;

        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
