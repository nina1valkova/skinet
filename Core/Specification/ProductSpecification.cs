using System;
using Core.Entities;

namespace Core.Specification;

public class ProductSpecification : BaseSpecification<Product>
{
    public ProductSpecification(/*string? brand, string? type, string? sort*/
    ProductSpecParams specParams):base(x =>
    /*(string .IsNullOrWhiteSpace(brand) || x.Brand == brand) &&
    (string.IsNullOrWhiteSpace(type) || x.Type == type)*/
    (string.IsNullOrEmpty(specParams.Search) || x.Name.ToLower().Contains(specParams.Search)) &&
    (/*!specParams.Brands.Any()*/ specParams.Brands.Count == 0 || specParams.Brands.Contains(x.Brand)) &&
    (/*!specParams.Types.Any()*/ specParams.Types.Count == 0 || specParams.Types.Contains(x.Type))
    )
    {
        ApplyPaging(specParams.PageSize*(specParams.PageIndex -1), specParams.PageSize);

        switch(/*sort*/ specParams.Sort)
        {
            case "priceAsc":
               AddOrderBy(x => x.Price);
               break;
            case "priceDesc":
               AddOrderByDescending(x => x.Price);
               break;  
            default:
               AddOrderBy(x => x.Name);
               break;    
        }
    }

}
