using System.ComponentModel.DataAnnotations;

namespace VuexyBase.Domain.Entities.More
{
    public class FAQ
    {
        [Key]
        public int Id { get; set; }

        public string QuestionAr { get; set; }

        public string AnswerAr { get; set; }

        public string QuestionEn { get; set; }

        public string AnswerEn { get; set; }

        public bool IsActive { get; set; }
    }
}
