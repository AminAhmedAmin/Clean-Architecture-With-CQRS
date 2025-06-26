namespace VuexyBase.Dashboard.ViewModels.User
{
    public class UserIndexViewModel
    {
        public UserStaticsViewModel statics { get; set; }
        public List<UserDataViewModel> users { get; set; }
    }

    public class UserStaticsViewModel
    {
        public int totalUserCount { get; set; }
        public int totalActiveUsers { get; set; }
        public int totalUnActiveUsers { get; set; }
        public int totalBlockedUsers { get; set; }
    }

    public class UserDataViewModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string image { get; set; }
        public string city { get; set; }
        public bool isActive { get; set; }
    }
}
