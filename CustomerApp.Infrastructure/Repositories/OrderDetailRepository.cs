using CustomerApp.Application.Interfaces;
using CustomerApp.Domain.Entities;
using CustomerApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerApp.Infrastructure.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly CustomerDbContext _context;

        public OrderDetailRepository(CustomerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderDetail>> GetAllAsync()
        {
            return await _context.OrdersDetail.ToListAsync();
        }

        public async Task<OrderDetail?> GetByIdAsync(Guid orderId, Guid productId)
        {
            return await _context.OrdersDetail
                .FirstOrDefaultAsync(x =>
                    x.OrderId == orderId &&
                    x.ProductId == productId);
        }

        public async Task AddAsync(OrderDetail orderDetail)
        {
            await _context.OrdersDetail.AddAsync(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderDetail orderDetail)
        {
            _context.OrdersDetail.Update(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid orderId, Guid productId)
        {
            var orderDetail = await _context.OrdersDetail
                .FirstOrDefaultAsync(x =>
                    x.OrderId == orderId &&
                    x.ProductId == productId);

            if (orderDetail != null)
            {
                _context.OrdersDetail.Remove(orderDetail);
                await _context.SaveChangesAsync();
            }
        }
    }
}

