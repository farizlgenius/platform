using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Location.Application.Entities
{
    public sealed class Response<T>
    {
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public HttpStatusCode Code { get; set; }
        public new T? Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public IEnumerable<string>? Details { get; set; }
    }
}
