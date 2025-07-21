using Shared.DataTrancfareObject.IdentityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTrancfareObject.OrdersDto
{
    public class OrderDTo
    {
        public string BasketId { get; set; } =default!;
        public int DeliveryMethodId { get; set; }
        public AddressDTO Address { get; set; } = default!;
    }
}
