using AutoMapper;
using REPR_API.Models;
using REPR_API.ViewModels;

namespace REPR_API.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }
}
