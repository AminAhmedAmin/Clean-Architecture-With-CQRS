using VuexyBase.Application.Application.DTOs.Notifications.Firebase;

namespace VuexyBase.Application.Application.Contracts.Infrastructure.Notifications.Firebase
{
    public interface IFirebaseService
    {
        Task<(int SuccessCount, int FailureCount)> SendNotificationAsync(FirebaseRequestDto dto);
    }
}
