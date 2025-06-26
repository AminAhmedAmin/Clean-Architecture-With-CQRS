using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuexyBase.Application.Application.Contracts.Application.Dashboard.Slider;
using VuexyBase.Application.Persistence;

namespace VuexyBase.Application.Application.Services.Dashboard.Slider
{
    public class SliderService : ISliderService
    {
        private readonly ApplicationDbContext _db;

        public SliderService(ApplicationDbContext db)
        {
            _db = db;
        }

    }
}
