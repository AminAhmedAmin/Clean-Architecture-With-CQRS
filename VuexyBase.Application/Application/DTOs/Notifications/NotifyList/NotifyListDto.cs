using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuexyBase.Application.Application.DTOs.Notifications.NotifyList
{
    public class NotifyListDto
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Message { get; set; }
        public string date { get; set; }
        public int? Type { get; set; }
        public int? ItemId { get; set; }
    }
}
