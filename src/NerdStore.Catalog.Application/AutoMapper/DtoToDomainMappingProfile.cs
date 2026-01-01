using AutoMapper;
using NerdStore.Catalog.Application.DTOs;
using NerdStore.Catalog.Domain;

namespace NerdStore.Catalog.Application.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<ProductDto, Product>()
                .ConstructUsing(p => new Product(
                    p.Name,
                    p.Description,
                    p.IsActive,
                    p.Price,
                    p.CategoryId,
                    p.CreatedAt,
                    p.Image,
                    new Dimension(p.Height, p.Width, p.Depth)));

            CreateMap<CategoryDto, Category>()
                .ConstructUsing(c => new Category(c.Name, c.Code));
        }
    }
}
