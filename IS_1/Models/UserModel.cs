using IS_1.Data;

namespace IS_1.Models
{
    public class UserModel
    {
        public User User { get; set; }

        public bool IsFirstAuth { get; set; }

        public static UserModel? ToModel(User? user) => user == null ? null : new UserModel
        {
            User = user,
            IsFirstAuth = true
        };
    }
}
