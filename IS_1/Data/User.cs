﻿namespace IS_1.Data
{
    public class User
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsBlocked { get; set; }

        public bool PasswordRestrictions { get; set; }
    }
}
