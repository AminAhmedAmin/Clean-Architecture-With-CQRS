namespace VuexyBase.Application.Application.DTOs.SMS.FourJawaly
{
    public class FourJawalyRequestDto
    {
        public List<MessagesDto> messages { get; set; } = [];
        public GlobalsDto globals { get; set; }
    }

    public class MessagesDto
    {
        public string text { get; set; }
        public List<string> numbers { get; set; }

    }

    public class GlobalsDto
    {
        public string number_iso { get; set; }
        public string sender { get; set; }

    }

}
