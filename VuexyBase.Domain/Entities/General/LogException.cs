using System.ComponentModel.DataAnnotations;
using VuexyBase.Domain.Enums.Exceptions;

namespace VuexyBase.Domain.Entities.General
{
    public class LogException
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public int? ItemId { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; } // Exception path 

        public ExceptionType ExceptionType { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

    }
}
