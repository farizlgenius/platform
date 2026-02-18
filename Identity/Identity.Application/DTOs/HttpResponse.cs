using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.DTOs
{
    public sealed record HttpResponse<T>(HttpStatusCode code, T payload, Guid uuid, string message, DateTime timeStamp);
}
