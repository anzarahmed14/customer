using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Application.Features.PaymentMethod.Dto
{
    public class PaymentMethodDto
    {
        public Guid PaymentId { get; set; }

        public string PaymentMethodName { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
