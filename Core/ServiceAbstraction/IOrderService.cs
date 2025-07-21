using Shared.DataTrancfareObject.OrdersDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IOrderService
    {
        Task<OrderToReturnDTo> CreateOrderAsync(OrderDTo OrderDTo, string Email);

        //Task<OrderToReturnDTo> GetByIdAsync(Guid id);
        //Task<IEnumerable<OrderToReturnDTo>> GetAllAsync(string email);

        //Task<IEnumerable<DeliveryMethodResponse>> GetDeliveryMethodsAsync();


    }
}
