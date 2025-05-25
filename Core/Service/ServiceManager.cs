using AutoMapper;
using DomainLayer.Contracts;
using ServiceAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ProductService> _LazyproductService;
        public ServiceManager(IUnitOfWork _unitOfWork , IMapper _mapper)
        {
            _LazyproductService = new Lazy<ProductService>(()=> new ProductService(_unitOfWork , _mapper));
        }
        public IProductService ProductService => _LazyproductService.Value;
    }
}
