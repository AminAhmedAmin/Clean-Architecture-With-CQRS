using FirebaseAdmin.Messaging;
using VuexyBase.Application.Application.Contracts.Infrastructure.Notifications.Firebase;
using VuexyBase.Application.Application.DTOs.Notifications.Firebase;

namespace VuexyBase.Infrastructure.Services.Notifications.Firebase
{
    public class FirebaseService : IFirebaseService
    {

        public async Task<(int SuccessCount, int FailureCount)> SendNotificationAsync(FirebaseRequestDto dto)
        {
            var messages = dto.Tokens.Select(token => new Message
            {
                Android = new AndroidConfig
                {
                    Notification = new AndroidNotification
                    {
                        ChannelId = "high_importance_channel"
                    }
                },
                Notification = new Notification
                {
                    Title = dto.Title,
                    Body = dto.Body,
                },
                Token = token,
                Data = dto.Data
            }).ToList();

            try
            {
                var response = await FirebaseMessaging.DefaultInstance.SendEachAsync(messages);
                return (response.SuccessCount, response.FailureCount);
            }
            catch
            {
                return (0, 0);
            }
        }
    }
}
