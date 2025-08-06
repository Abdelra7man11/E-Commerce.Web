using Shared.DataTrancfareObject.IdentityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTrancfareObject.OrdersDto
{
    public class OrderToReturnDTo
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; } = default!;
        public DateTimeOffset OrderDate { get; set; } //HERE
        public AddressDTO ShipToAddress { get; set; } =default!;
        public string DeliveryMethod { get; set; } = default!;
        public string OrderStatus { get; set; } = default!; //HERE
        public ICollection<OrderItemDTo> Items { get; set; } = [];//Nav Prop
        public decimal SubTotal { get; set; } = default!;
        public decimal Total { get; set; } = default!;



    }

}
