using AutoMapper;
using Domain.Models.Orders;
using DomainLayer.Contracts;
using Microsoft.Extensions.Configuration;
using Shared.DataTrancfareObject.IdentityDto;
using Shared.DataTrancfareObject.OrdersDto;

namespace Services.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<AddressDTO, OrderAddress>().ReverseMap();

            CreateMap<Order, OrderToReturnDTo>()
                .ForMember(dest => dest.DeliveryMethod,
                opt => opt.MapFrom(src => src.DeliveryMethod.ShortName));

            CreateMap<OrderItem, OrderItemDTo>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(S => S.Product.ProductName))
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<OrderItemPictureUrlResolver>());

            CreateMap<DeliveryMethod, DeliveryMethodDTo>();
        }
    }



    public class OrderItemPictureUrlResolver(IConfiguration _configuration) : IValueResolver<OrderItem, OrderItemDTo, string>
    {
        public string Resolve(OrderItem source, OrderItemDTo destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrWhiteSpace(source.Product.PictureUrl))
            {
                return $"{_configuration["BaseUrl"]}{source.Product.PictureUrl}";
            }
            return string.Empty;
        }
    }
}
