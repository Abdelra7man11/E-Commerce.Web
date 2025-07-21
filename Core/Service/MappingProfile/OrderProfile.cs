using AutoMapper;
using Domain.Models.Orders;
using Microsoft.Extensions.Configuration;
using Shared.DataTrancfareObject.IdentityDto;
using Shared.DataTrancfareObject.OrdersDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MappingProfiles
{
    public class OrderProfile :Profile
    {
        public OrderProfile()
        {
            CreateMap<AddressDTO, OrderAddress>().ReverseMap();

            CreateMap<OrderItem, OrderItemDTo>()
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<OrderItemPictureUrlResolver>());


            CreateMap<Order, OrderToReturnDTo>()
                .ForMember(dest => dest.DeliveryMethod,
                opt => opt.MapFrom(src => src.DeliveryMethod.ShortName))
               .ForMember(dest => dest.Total,
                opt => opt.MapFrom(src => src.DeliveryMethod.Price + src.SubTotal))
            .ForMember(dest => dest.DeliveryCost,
                opt => opt.MapFrom(src => src.DeliveryMethod.Price));


            CreateMap<DeliveryMethod, DeliveryMethodResponse>();
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
