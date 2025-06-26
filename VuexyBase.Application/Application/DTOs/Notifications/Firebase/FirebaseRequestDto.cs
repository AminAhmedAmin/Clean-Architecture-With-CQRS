namespace VuexyBase.Application.Application.DTOs.Notifications.Firebase
{
    public class FirebaseRequestDto
    {
        public string Title { get; set; } = "VuexyBase";

        public string Body { get; set; }

        public List<string> Tokens { get; set; } = [];

        public Dictionary<string, string> Data { get; set; }
    }
}
