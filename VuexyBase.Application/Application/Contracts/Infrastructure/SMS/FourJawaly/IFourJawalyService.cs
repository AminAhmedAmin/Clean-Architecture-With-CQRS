namespace VuexyBase.Application.Application.Contracts.Infrastructure.SMS.FourJawaly
{
    public interface IFourJawalyService
    {
        Task<bool> SendSMSAsync(List<string> phoneNumbers, string text);
    }
}
