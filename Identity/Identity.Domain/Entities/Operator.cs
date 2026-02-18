using Identity.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Identity.Domain.Entities
{
    public sealed partial class Operator
    {
        public int Id { get; set; }
        public string UserId { get; private set; } = string.Empty;
        public string Username { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Title { get; private set; } = string.Empty;
        public string FirstName { get; private set; } = string.Empty;
        public string MiddleName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string Phone { get; private set; } = string.Empty;
        public string Image { get; private set; } = string.Empty;

        private readonly List<int> _locationIds = [];
        public IReadOnlyCollection<int> LocationIds => _locationIds.AsReadOnly();
        public bool IsActive { get; set; } = true;
        public int RoleId { get; set; }

        public Operator() { }

        public Operator(string userid,string username,string password,string email,string title,string firstname,string middlename,string lastname,string phone,string image,int roleid, IEnumerable<int>? locationids = null)
        {
            SetUserId(userid);
            SetUsername(username);
            SetPassword(password);
            SetEmail(email);
            SetFirstname(firstname);
            SetRole(roleid);

            if (locationids is not null)
                _locationIds = locationids.Distinct().ToList();

            title = title ?? string.Empty;
            middlename = middlename ?? string.Empty;
            lastname = lastname ?? string.Empty;
            phone = phone ?? string.Empty;
            image = image ?? string.Empty;

        }

        public void AddLocation(int locationId)
        {
            if (locationId <= 0)
                throw new ArgumentException("LocationId must be greater than zero.", nameof(locationId));

            if (!_locationIds.Contains(locationId))
                _locationIds.Add(locationId);
        }

        public void RemoveLocation(int locationId)
        {
            _locationIds.Remove(locationId);
        }

        private void SetUserId(string userId) 
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(userId);

            if (!RegexHelper.IsValidOnlyCharAndDigit(userId))
                throw new ArgumentException("User Id must contain only letters and digits.", nameof(userId));

            UserId = userId;
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
            Password = EncryptHelper.HashPassword(password);
        }

        private void SetEmail(string email) 
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(email);
            if (!RegexHelper.IsValidEmail(email))
                throw new ArgumentException("Email format is incorrect.", nameof(email));

            Email = email;
        }

        private void SetFirstname(string firstname) 
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(firstname);
            if (!RegexHelper.IsValidName(firstname))
                throw new ArgumentException("Firstname must contain only letters.", nameof(firstname));

            FirstName = firstname;
        }

        private void SetRole(int rolid)
        {
            if(rolid <= 0) throw new ArgumentException("Role not assigned.",nameof(rolid));

            RoleId = rolid;
        }




    }
}
