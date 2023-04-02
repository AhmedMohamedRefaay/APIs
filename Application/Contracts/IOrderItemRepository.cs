using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
namespace Application.Contracts
{
    public  interface IOrderItemRepository:IRepository<OrderItem,int>
    {
        Task<IEnumerable<OrderItem>> GetAllOrdersItemAsync();

    }
}
