using System.Text;
using VuexyBase.Application.Application.Contracts.Infrastructure.SMS.FourJawaly;
using VuexyBase.Application.Application.DTOs.SMS.FourJawaly;

namespace VuexyBase.Infrastructure.Infrastructure.Services.SMS.FourJawaly
{
    public class FourJawalyService : IFourJawalyService
    {
        #region Properties
        public static string AppKey { get; set; }
        public static string AppSecret { get; set; }
        public static string SenderName { get; set; }
        public static string Url { get; set; }
        public string CountryIso { get; set; } = "SA";
        #endregion

        public async Task<bool> SendSMSAsync(List<string> phoneNumbers, string text)
        {
            var _httpClient = new HttpClient();
            try
            {
                var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{AppKey}:{AppSecret}"));
                var dto = CreateRequestDto(phoneNumbers, text);

                var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");

                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);
                _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(SenderName);

                var response = await _httpClient.PostAsync(Url, content);

                //var resultJson = await response.Content.ReadAsStringAsync();
                //var result = System.Text.Json.JsonSerializer.Deserialize<FourJawalyResponseDto>(resultJson);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while sending the SMS.", ex);
            }
        }

        private FourJawalyRequestDto CreateRequestDto(List<string> phoneNumbers, string text)
        {
            return new FourJawalyRequestDto
            {
                messages = new List<MessagesDto>
                {
                    new MessagesDto
                    {
                        text = text,
                        numbers = phoneNumbers
                    }
                },
                globals = new GlobalsDto
                {
                    number_iso = CountryIso,
                    sender = SenderName
                }
            };
        }
    }
}
