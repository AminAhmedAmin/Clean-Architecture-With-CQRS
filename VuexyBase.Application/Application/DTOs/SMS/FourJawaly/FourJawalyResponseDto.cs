using FirebaseAdmin.Messaging;

namespace VuexyBase.Application.Application.DTOs.SMS.FourJawaly
{
    public class FourJawalyResponseDto
    {
        public string job_id { get; set; }
        public List<Message> messages { get; set; } = [];
        public int code { get; set; }
        public string message { get; set; }
    }
}
