using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models;
using ServiceAbstraction;
using Shared.DataTrancfareObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper) : IProductService
    {
        public async Task<IEnumerable<BrandDto>> GetAllBrandAsync()
        {
            var Brand = await _unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
            var BrandDto = _mapper.Map<IEnumerable<ProductBrand>, IEnumerable<BrandDto>>(Brand);
        return BrandDto;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductAsync()
        {
            var Products =await _unitOfWork.GetRepository<Product, int>().GetAllAsync();
            var ProductDto = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(Products);
            return ProductDto;
        }

        public async Task<IEnumerable<TypeDto>> GetAllTypeAsync()
        {
            var Types =await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            var TypesDto = _mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeDto>>(Types);
            return TypesDto;
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var Products = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(id);
            var ProductsDto = _mapper.Map<Product, ProductDto>(Products);
            return ProductsDto;
        }
    }
}
