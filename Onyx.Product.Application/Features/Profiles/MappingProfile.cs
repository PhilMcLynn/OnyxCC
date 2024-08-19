using AutoMapper;
using Onyx.Product.Application.Features.Colours;
using Onyx.Product.Application.Features.Products.Commands;
using Onyx.Product.Application.Features.Products.Queries.GetProductDetail;
using Onyx.Product.Application.Features.Products.Queries.GetProductList;
using Onyx.Product.Domain.Entities;
using DOMAIN = Onyx.Product.Domain.Entities;

namespace Onyx.Product.Application.Features.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<DOMAIN.Product, ProductListVm>()
                .ForMember(dest => dest.ProductName, act => act.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, act => act.MapFrom(src => src.Amount))
                .ReverseMap();
            CreateMap<DOMAIN.Product, ProductDetailVm>()
                .ForMember(dest => dest.ProductName, act => act.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, act => act.MapFrom(src => src.Amount))
                .ReverseMap();
            CreateMap<Colour, ColourDto>().ReverseMap();
            CreateMap<Colour, ColourListVm>().ReverseMap();

            CreateMap<DOMAIN.Product, CreateProductCommand>().ReverseMap();
        }
    }
}
