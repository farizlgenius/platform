using Identity.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Identity.Domain.Entities
{
    public sealed partial class Login
    {
        public string Username { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;

        public Login() { }

        public Login(string username, string password) 
        {
            SetUsername(username);
            SetPassword(password);
        }

        private void SetUsername(string username)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(username);
            if (!RegexHelper.IsValidOnlyCharAndDigit(username))
                throw new ArgumentException("Username must contain only letters and digits.", nameof(username));

            Username = username;

        }

        private void SetPassword(string password)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(password);
            Password = password;
        }



        
    }
}
