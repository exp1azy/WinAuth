using IS_1.Data;

namespace IS_1.Models
{
    public class UserModel
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public bool IsBlocked { get; set; }

        public bool PasswordRestrictions { get; set; }

        public static UserModel? ToModel(User? user) => user == null ? null : new UserModel
        {
            Name = user.Name,
            Password = user.Password,
            IsBlocked = user.IsBlocked,
            PasswordRestrictions = user.PasswordRestrictions
        };
    }
}
