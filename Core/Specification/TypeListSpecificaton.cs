using Core.Entities;

namespace Core.Specification;

public class TypeListSpecificaton : BaseSpecification<Product, string>
{
    public TypeListSpecificaton()
    {
        AddSelect(x=>x.Type);
        ApplyDistinct();
    }
}
