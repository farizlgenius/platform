using Location.Application.Entities;
using Location.Domain.Constants;
using Location.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Location.Application.Helpers
{
    public sealed class ResponseHelper
    {
        public static Response<T> SuccessBuilder<T>(T Data)
        {
            return new Response<T>()
            {
                Code = HttpStatusCode.OK,
                Timestamp = DateTime.UtcNow,
                Message = ResponseMessage.SUCCESS,
                Details = Enumerable.Empty<string>(),
                Data = Data
            };
        }

        public static Response<T> UnsuccessBuilderWithString<T>(string Message, string detail)
        {
            return new Response<T>()
            {
                Code = HttpStatusCode.InternalServerError,
                Timestamp = DateTime.UtcNow,
                Message = Message,
                Details = new List<string> { detail },
                Data = default
            };
        }

        public static Response<T> UnsuccessBuilder<T>(string Message, IEnumerable<string> Details)
        {
            return new Response<T>()
            {
                Code = HttpStatusCode.InternalServerError,
                Timestamp = DateTime.UtcNow,
                Message = Message,
                Details = Details.ToList(),
                Data = default
            };
        }

        public static Response<T> UnsuccessBuilder<T>(T Data)
        {
            return new Response<T>()
            {
                Code = HttpStatusCode.InternalServerError,
                Timestamp = DateTime.UtcNow,
                Message = ResponseMessage.UNSUCCESS,
                Details = Enumerable.Empty<string>(),
                Data = Data
            };
        }

        public static Response<T> NotFoundBuilder<T>()
        {
            return new Response<T>()
            {
                Code = HttpStatusCode.NotFound,
                Timestamp = DateTime.UtcNow,
                Message = ResponseMessage.NOT_FOUND,
                Details = Enumerable.Empty<string>(),
                Data = default
            };
        }

        public static Response<T> NotFoundBuilder<T>(IEnumerable<string> Message)
        {
            return new Response<T>()
            {
                Code = HttpStatusCode.NotFound,
                Timestamp = DateTime.UtcNow,
                Message = ResponseMessage.NOT_FOUND,
                Details = Message,
                Data = default
            };
        }

        public static Response<T> NotFoundBuilder<T>(string Message)
        {
            return new Response<T>()
            {
                Code = HttpStatusCode.NotFound,
                Timestamp = DateTime.UtcNow,
                Message = Message,
                Details = [],
                Data = default
            };
        }

        public static Response<T> FoundReferenceBuilder<T>()
        {
            return new Response<T>()
            {
                Code = HttpStatusCode.InternalServerError,
                Timestamp = DateTime.UtcNow,
                Message = ResponseMessage.FOUND_REFERENCE,
                Details = Enumerable.Empty<string>(),
                Data = default
            };
        }

        public static Response<T> FoundReferenceBuilder<T>(IEnumerable<string> Message)
        {
            return new Response<T>()
            {
                Code = HttpStatusCode.InternalServerError,
                Timestamp = DateTime.UtcNow,
                Message = ResponseMessage.FOUND_REFERENCE,
                Details = Message,
                Data = default
            };
        }


        public static Response<T> ExceedLimit<T>()
        {
            return new Response<T>()
            {
                Code = HttpStatusCode.InternalServerError,
                Timestamp = DateTime.UtcNow,
                Message = ResponseMessage.COMPONENT_EXCEED_LIMIT,
                Details = Enumerable.Empty<string>(),
                Data = default
            };
        }

        public static Response<T> Duplicate<T>()
        {
            return new Response<T>()
            {
                Code = HttpStatusCode.BadRequest,
                Timestamp = DateTime.UtcNow,
                Message = ResponseMessage.DUPLICATE_USER,
                Details = Enumerable.Empty<string>(),
                Data = default
            };
        }

        public static Response<T> BadRequest<T>()
        {
            return new Response<T>()
            {
                Code = HttpStatusCode.BadRequest,
                Timestamp = DateTime.UtcNow,
                Message = ResponseMessage.DUPLICATE_USER,
                Details = Enumerable.Empty<string>(),
                Data = default
            };
        }

        public static Response<T> Unauthorize<T>()
        {
            return new Response<T>()
            {
                Code = HttpStatusCode.Unauthorized,
                Timestamp = DateTime.UtcNow,
                Message = ResponseMessage.UNAUTHORIZED,
                Details = Enumerable.Empty<string>(),
                Data = default
            };
        }

        public static Response<T> Unauthorize<T>(IEnumerable<string> Message)
        {
            return new Response<T>()
            {
                Code = HttpStatusCode.Unauthorized,
                Timestamp = DateTime.UtcNow,
                Message = ResponseMessage.UNAUTHORIZED,
                Details = Message,
                Data = default
            };
        }

        public static Response<T> DefaultRecord<T>()
        {
            return new Response<T>()
            {
                Code = HttpStatusCode.NotAcceptable,
                Timestamp = DateTime.UtcNow,
                Message = ResponseMessage.DELETE_DEFAULT,
                Details = Enumerable.Empty<string>(),
                Data = default
            };
        }
    }
}
