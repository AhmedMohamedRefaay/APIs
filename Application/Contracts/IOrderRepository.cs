using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IOrderRepository:IRepository<Order,int>
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();      
    }
}
