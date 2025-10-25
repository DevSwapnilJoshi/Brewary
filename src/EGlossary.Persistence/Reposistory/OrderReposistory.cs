using AutoMapper;
using EGlossary.Domain.Entities;
using EGlossary.Domain.InterfaceReposistory;
using EGlossary.Persistence.DataModels;
using EGlossary.Persistence.Seeds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGlossary.Persistence.Reposistory
{
    public class OrderReposistory : IOrderReposistory
    {
        private readonly InMemoryDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderReposistory(InMemoryDbContext inMemoryDbContext, IMapper mapper)
        {
            _dbContext = inMemoryDbContext;
            _mapper = mapper;
        }

        public async Task<int> CreateOrder(OrderEntity orderEntity)
        {
            orderEntity.CreatedDate = DateTime.Now;
            var order = _mapper.Map<OrderDataModel>(orderEntity);
            await _dbContext.Order.AddAsync(order);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderEntity>> GetAllOrders()
        {
            _ = GetOrderInMemory();
            var orders = await _dbContext.Order.ToListAsync();
            return _mapper.Map<IEnumerable<OrderEntity>>(orders);
        }

        public async Task<OrderEntity> GetOrderById(int Id)
        {
            _ = GetOrderInMemory();
            var order = await _dbContext.Order.Where(p => p.Id == Id).FirstOrDefaultAsync();
            return _mapper.Map<OrderEntity>(order);
        }

        public async Task<bool> DeleteOrder(int Id)
        {
            _ = GetOrderInMemory();
            var Order = await _dbContext.Order.Where(p => p.Id == Id).FirstOrDefaultAsync();
            if (Order != null)
            {
                _dbContext.Order.Remove(Order);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else { return false; }
        }

        public async Task<int> UpdateOrder(int? Id, OrderEntity orderEntity)
        {
            _ = GetOrderInMemory();
            var Order = await _dbContext.Order.Where(p => p.Id == Id).FirstOrDefaultAsync();
            if (Order != null)
            {
                _dbContext.Order.Update(Order);
                return await _dbContext.SaveChangesAsync();
            }
            else { return 0; }
        }

        public async Task GetOrderInMemory()
        {
            await OrderSeedData.Seed(_dbContext);
        }
    }
}