using AutoMapper;
using DomainLayer.Models;
using Shared.DataTrancfareObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.MappingProfile
{
    public class ProductProfile :Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dis => dis.BrandName, Options => Options.MapFrom(src => src.ProductBrand.Name))
                .ForMember(dis => dis.TypeName, Options => Options.MapFrom(src => src.ProductType.Name))
                .ForMember(dis => dis.PictureUrl, Option => Option.MapFrom<PictureUrlResolver>());
                //.ForMember(dis => dis.PictureUrl, Options => Options.MapFrom(src => $"https://localhost:7112/{src.PictureUrl}")) // The Manual Way


            CreateMap<ProductBrand, BrandDto>();
            CreateMap<ProductType, TypeDto>();
        }
    }
}
