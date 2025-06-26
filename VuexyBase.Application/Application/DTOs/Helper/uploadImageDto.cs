using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuexyBase.Application.Application.ViewModels.Helper
{
    public class uploadImageDto
    {
        public IFormFile Image { get; set; }

        public int FileName { get; set; }
    }
}
