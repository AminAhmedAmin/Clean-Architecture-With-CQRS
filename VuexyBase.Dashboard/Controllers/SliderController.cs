using Microsoft.AspNetCore.Mvc;
using VuexyBase.Application.Application.Contracts.Application.Dashboard.Slider;

namespace VuexyBase.Dashboard.Controllers
{
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
