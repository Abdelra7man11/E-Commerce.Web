using Domain.Models.Orders;
using Service.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
     class OrderSpesifications : BaseSpecification<Order , Guid>
    {
        //For GetAll
        public OrderSpesifications(string email) : base(o => o.UserEmail == email)
        {
            AddInclude(o => o.DeliveryMethod);
            AddInclude(o => o.Items);
            AddOrderByDesc(o=>o.OrderDate);
        }
        //For Get By Id
        public OrderSpesifications(Guid id):base(o=>o.Id == id)
        {
            AddInclude(o => o.Items);
            AddInclude(o => o.DeliveryMethod);
        }


    }
}
