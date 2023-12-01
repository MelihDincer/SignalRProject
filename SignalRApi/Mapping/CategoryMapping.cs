using AutoMapper;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap(); //Category sınıfı ile ResultCategoryDto sınıfını eşleştir. ReverseMap metodu ile hem Category'u ResultCategoryDto ile, hem de ResultCategoryDto'yu Category ile eşleştirdik.
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>().ReverseMap();
        }       
    }
}
