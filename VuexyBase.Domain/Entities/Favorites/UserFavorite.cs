using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VuexyBase.Domain.Entities.Identities;

namespace VuexyBase.Domain.Entities.Favorites
{
    public class UserFavorite
    {
        [Key]
        public int Id { get; set; }

        public string UserId1 { get; set; }

        public string UserId2 { get; set; }


        #region Navigation Properties

        [ForeignKey(nameof(UserId1))]
        public virtual ApplicationDbUser User1 { get; set; }

        [ForeignKey(nameof(UserId2))]
        public virtual ApplicationDbUser User2 { get; set; }

        #endregion
    }
}
