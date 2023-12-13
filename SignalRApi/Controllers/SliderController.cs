using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SliderList() 
        {
            var values = _mapper.Map<List<ResultSliderDto>>(_sliderService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto createSliderDto)
        {
            _sliderService.TAdd(new Slider()
            {
                Title1 = createSliderDto.Title1,
                Description1 = createSliderDto.Description1,
                Title2 = createSliderDto.Title2,
                Description2 = createSliderDto.Description2,   
                Title3  = createSliderDto.Title3,
                Description3 = createSliderDto.Description3,   
            });
            return Ok("Öne Çıkan Bilgisi Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteSlider(int id)
        {
            var value = _sliderService.TGetByID(id);
            _sliderService.TDelete(value);
            return Ok("Öne Çıkan Bilgisi Silindi");
        }

        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            _sliderService.TUpdate(new Slider()
            {
                SliderID = updateSliderDto.SliderID,
                Title1 = updateSliderDto.Title1,   
                Description1 = updateSliderDto.Description1,
                Title2 = updateSliderDto.Title2,
                Description2 = updateSliderDto.Description2,
                Title3 = updateSliderDto.Title3,   
                Description3 = updateSliderDto.Description3,
            });
            return Ok("Öne Çıkan Bilgisi Güncellendi");
        }

        [HttpGet("GetSlider")]
        public IActionResult GetSlider(int id)
        {
            var value = _sliderService.TGetByID(id);
            return Ok(value);
        }
    }
}
