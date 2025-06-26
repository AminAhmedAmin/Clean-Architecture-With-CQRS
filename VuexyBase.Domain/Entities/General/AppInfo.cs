using System.ComponentModel.DataAnnotations;

namespace VuexyBase.Domain.Entities.General
{
    public class AppInfo
    {
        [Key]
        public int Id { get; set; }

        public string TermsAndConditionsAr { get; set; }
        public string TermsAndConditionsEn { get; set; }


        public string AboutUsAr { get; set; }
        public string AboutUsEn { get; set; }


        public string PrivacyPolicyAr { get; set; }
        public string PrivacyPolicyEn { get; set; }


        public string CancellationPolicyAr { get; set; }
        public string CancellationPolicyEn { get; set; }
    }
}
