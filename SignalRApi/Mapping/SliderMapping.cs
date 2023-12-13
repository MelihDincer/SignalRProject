using AutoMapper;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class SliderMapping : Profile
    {
        public SliderMapping()
        {
            CreateMap<Slider, ResultSliderDto>().ReverseMap(); //Slider sınıfı ile ResultSliderDto sınıfını eşleştir. ReverseMap metodu ile hem Slider'ı ResultSliderDto ile, hem de ResultSliderDto'yu Slider ile eşleştirdik.
            CreateMap<Slider, CreateSliderDto>().ReverseMap();
            CreateMap<Slider, UpdateSliderDto>().ReverseMap();
            CreateMap<Slider, GetSliderDto>().ReverseMap();
        }
    }
}
