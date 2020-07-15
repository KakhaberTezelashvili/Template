using System;
using System.Threading.Tasks;

namespace Template.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<dynamic> FindAsync(Guid orderId);
        Task SaveAsync(dynamic order);
    }
}