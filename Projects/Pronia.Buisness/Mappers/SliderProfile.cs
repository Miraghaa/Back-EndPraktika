using AutoMapper;
using Pronia.Buisness.ViewModels.SliderViewModels;
using Pronia.Core.Entities;

namespace Pronia.Buisness.Mappers;

public class SliderProfile:Profile
{
    public SliderProfile()
    {
        CreateMap<Slider, SliderPostVM>().ReverseMap();
        CreateMap<SliderUploadVM, Slider>().ReverseMap();
    }
}
