using AutoMapper;
using NerdStore.Catalog.Application.DTOs;
using NerdStore.Catalog.Domain;

namespace NerdStore.Catalog.Application.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.Height, o => o.MapFrom(s => s.Dimension.Height))
                .ForMember(d => d.Width, o => o.MapFrom(s => s.Dimension.Width))
                .ForMember(d => d.Depth, o => o.MapFrom(s => s.Dimension.Depth));

            CreateMap<Category, CategoryDto>();
        }
    }
}
