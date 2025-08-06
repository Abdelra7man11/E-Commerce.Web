using DomainLayer.Models.ProductsModule;
using Shared;

namespace Service.Specification
{
    class ProductWithBrandSpecification : BaseSpecification<Product, int>
    {
        // GetAll Product With Brand And Type
        public ProductWithBrandSpecification(ProductQueryParams queryParams) : base(
            P =>
            (!queryParams.BrandId.HasValue || P.BrandId == queryParams.BrandId) 
            && (!queryParams.TypeId.HasValue || P.TypeId == queryParams.TypeId)
            && (string.IsNullOrEmpty(queryParams.SearchValue) || P.Name.ToLower().Contains(queryParams.SearchValue.ToLower()))
            )
        {
            AddInclude(P => P.ProductBrand);
            AddInclude(P => P.ProductType);

            switch (queryParams.sortingProducts)
            {
                case
                    SortingProducts.NameAsc:
                        AddOrderBy(P => P.Name);
                    break;
                case
                    SortingProducts.NameDesc:
                        AddOrderByDesc(P => P.Name);
                    break;
                case
                    SortingProducts.PriceAsc:
                        AddOrderBy(P => P.Price);
                    break;
                case
                    SortingProducts.PriceDesc:
                        AddOrderByDesc(P => P.Price);
                    break;
                default:
                    break;

            }

            ApplyPagination(queryParams.PageSiza, queryParams.PageIndex);
        }

        // Get Product Id

        public ProductWithBrandSpecification(int id) : base(p => p.Id == id)
        {
            AddInclude(P => P.ProductBrand);
            AddInclude(P => P.ProductType);
        }
    }
}
