using CustomerApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Application.Interfaces
{
    public interface IPaymentMethodRepository
    {
        Task<IEnumerable<PaymentMethod>> GetAllAsync();

        Task<PaymentMethod> GetByIdAsync(Guid id);

        Task AddAsync(PaymentMethod paymentMethod);

        Task UpdateAsync(PaymentMethod paymentMethod);

        Task DeleteAsync(Guid id);
    }
}
