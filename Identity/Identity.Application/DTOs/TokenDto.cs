using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.DTOs
{
    public sealed class TokenDto
    {
        public DateTime TimeStamp { get; set; }
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken {  get; set; } = string.Empty;
        public int ExpireInMinute { get; set; }
    }
}
