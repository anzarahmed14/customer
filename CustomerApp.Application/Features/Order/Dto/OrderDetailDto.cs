using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Application.Features.Order.Dto
{
    public class OrderDetailDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; } = 0;
        public decimal Price { get; set; } = 0;
       // public decimal Total => Quantity * Price;

    }
}
