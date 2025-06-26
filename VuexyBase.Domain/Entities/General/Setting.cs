using System.ComponentModel.DataAnnotations;

namespace VuexyBase.Domain.Entities.General
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

        public string Address { get; set; }

        public string SenderName { get; set; }
    }
}
