using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTrancfareObject.OrdersDto
{
    public class OrderItemDTo
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public string ProductName { get; set; } = default!;
        public string PictureUrl { get; set; } = default!;
    }
}
