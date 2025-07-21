using AutoMapper;
using Domain.Models.Orders;
using DomainLayer.Contracts;
using DomainLayer.Exceptions;
using DomainLayer.Models.OrderModule;
using DomainLayer.Models.ProductsModule;
using ServiceAbstraction;
using Shared.DataTrancfareObject.IdentityDto;
using Shared.DataTrancfareObject.OrdersDto;
using System;


namespace Services
{
    public class OrderService(IBasketRepository _basketRepository, IUnitOfWork _unitOfWork, IMapper _mapper) : IOrderService
    {
        public async Task<OrderToReturnDTo> CreateOrderAsync(OrderDTo orderDTo, string Email)
        {
            // Map Address
            var OderAddress = _mapper.Map<AddressDTO, OrderAddress>(orderDTo.Address);

            //Get Basket
            var Basket = await _basketRepository.GetBasketAsync(orderDTo.BasketId)
                ?? throw new BasketNotFoundException(orderDTo.BasketId);

            // Create OrderItem List
            List<OrderItem> OrderItems = [];
            var ProductRepo = _unitOfWork.GetRepository<Product, int>();

            foreach (var item in Basket.Items)
            {

                var Product = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(item.Id)
                             ?? throw new ProductNotFoundError(item.Id);
                var orderItem = new OrderItem()
                {
                    Product = new ProductItemOrder() { ProductId = Product.Id, PictureUrl = Product.PictureUrl, ProductName = Product.Name },
                    Price = Product.Price,
                    Quantity = Product.Quantity
                };
                OrderItems.Add(orderItem);

            }

            // Get Delivery Method 
            var DeliveryMethod = await _unitOfWork.GetRepository<DeliveryMethod, int>().GetByIdAsync(orderDTo.DeliveryMethodId)
                ?? throw new DeliveryMethodNotFoundException(orderDTo.DeliveryMethodId);

            // Calculate Sub Total

            var SubTotal = OrderItems.Sum(I => I.Quantity * I.Price);

            var Order = new Order(Email, OderAddress, OrderItems, DeliveryMethod, SubTotal);

            await _unitOfWork.GetRepository<Order, Guid>().AddAsync(Order);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<Order, OrderToReturnDTo>(Order);

        }


    }
}
