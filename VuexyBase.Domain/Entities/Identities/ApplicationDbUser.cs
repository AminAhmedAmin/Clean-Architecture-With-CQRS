using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using VuexyBase.Domain.Entities.Chats;
using VuexyBase.Domain.Entities.Favorites;
using VuexyBase.Domain.Entities.General;
using VuexyBase.Domain.Entities.Notifications;
using VuexyBase.Domain.Entities.Rates;
using VuexyBase.Domain.Entities.UserRoles;
using VuexyBase.Domain.Enums.Identities;
using VuexyBase.Domain.Enums.Languages;

namespace VuexyBase.Domain.Entities.Identities
{
    public class ApplicationDbUser : IdentityUser
    {
        public ApplicationDbUser()
        {
            DeviceTokens = new HashSet<DeviceToken>();

            UserNotifications = new HashSet<UserNotification>();

            User1Favorites = new HashSet<UserFavorite>();

            User2Favorites = new HashSet<UserFavorite>();

            User1Rates = new HashSet<UserRate>();

            User2Rates = new HashSet<UserRate>();

            SenderRooms = new HashSet<Room>();

            ReceiverRooms = new HashSet<Room>();
        }
        //================================String===================================
        public string User_Name { get; set; }

        public string ProfileImage { get; set; }

        public string VerificationCode { get; set; }
        //==================================Boolean================================
        public bool IsActive { get; set; } = true;

        public bool IsDeleted { get; set; }

        public bool IsNotificationsAllowed { get; set; } = true;

        public bool IsCodeVerified { get; set; }

        public bool IsBlocked { get; set; }
        //===============================Number====================================
        public decimal Wallet { get; set; }
        //=================================Enum&Date===============================

        public UserType UserType { get; set; }

        public Language Language { get; set; } = Language.Ar;

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(Role))]
        public string RoleId { get; set; }


        #region Navigation Properties
        public Role Role { get; set; }
        public virtual ICollection<DeviceToken> DeviceTokens { get; set; }

        public virtual ICollection<UserNotification> UserNotifications { get; set; }

        [InverseProperty(nameof(UserFavorite.User1))]
        public virtual ICollection<UserFavorite> User1Favorites { get; set; }

        [InverseProperty(nameof(UserFavorite.User2))]
        public virtual ICollection<UserFavorite> User2Favorites { get; set; }

        [InverseProperty(nameof(UserRate.User1))]
        public virtual ICollection<UserRate> User1Rates { get; set; }

        [InverseProperty(nameof(UserRate.User2))]
        public virtual ICollection<UserRate> User2Rates { get; set; }

        [InverseProperty(nameof(Room.Sender))]
        public virtual ICollection<Room> SenderRooms { get; set; }

        [InverseProperty(nameof(Room.Receiver))]
        public virtual ICollection<Room> ReceiverRooms { get; set; }

        #endregion
    }
}
