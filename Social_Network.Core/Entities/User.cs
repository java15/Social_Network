using System;
using Social_Network.Core.Entities.Base;

namespace Social_Network.Core.Entities
{
    public class User:EntityBase
    {
        public User() { }

        public User(string login, string password)
        {
            if (String.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentNullException("login");
            }
            if (String.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException("password");
            }


            this.Login = login;
            this.Password = password;
        }

        public string Login { get; protected set; }

        public string Password { get; set; }
    }
}
