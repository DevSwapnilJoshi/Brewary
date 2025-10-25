using EGlossary.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGlossary.Domain.InterfaceReposistory
{
    public interface IOrderReposistory
    {
        Task<int> CreateOrder(OrderEntity order);

        Task<IEnumerable<OrderEntity>> GetAllOrders();

        Task<OrderEntity> GetOrderById(int Id);

        Task<bool> DeleteOrder(int Id);

        Task<int> UpdateOrder(int? Id, OrderEntity order);
    }
}