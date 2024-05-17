using AutoMapper;
using Microsoft.EntityFrameworkCore.Infrastructure;
using REPR_API.Models;
using REPR_API.ViewModels;

namespace REPR_API.Mapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
    }
}
