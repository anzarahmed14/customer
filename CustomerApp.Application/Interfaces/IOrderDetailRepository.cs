using CustomerApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Application.Interfaces
{
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetail>> GetAllAsync();

        Task<OrderDetail> GetByIdAsync(Guid orderId, Guid productId);

        Task AddAsync(OrderDetail orderDetail);

        Task UpdateAsync(OrderDetail orderDetail);

        Task DeleteAsync(Guid orderId, Guid productId);
    }
}
