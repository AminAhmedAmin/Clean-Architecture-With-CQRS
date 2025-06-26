using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuexyBase.Application.Application.ViewModels.Dashboard
{

    public class DashboardStat
    {
        public string Icon { get; set; } // e.g. "ti ti-user"
        public string BadgeColor { get; set; } // e.g. "bg-label-secondary"
        public string Label { get; set; } // e.g. "Categories Number"
        public int Value { get; set; }
        }


    }
