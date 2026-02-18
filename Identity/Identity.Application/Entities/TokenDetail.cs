using Identity.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Entities
{
    public sealed class TokenDetail
    {
        public bool Auth { get; set; }
        public TokenInfo? Info { get; set; }
    }
    public sealed class TokenInfo
    {
        public required Users User { get; set; }
        public required List<short> Locations { get; set; }
        public required RoleDto Role { get; set; }
    }
    public sealed class Users
    {
        public string Title { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string Middlename { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
    public sealed class Location
    {
        public short LocationNo { get; set; }
        public string LocationName { get; set; } = string.Empty;
    }
    public sealed class Roles
    {
        public short RoleNo { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public List<short> Features { get; set; } = new List<short>();
    }
}
