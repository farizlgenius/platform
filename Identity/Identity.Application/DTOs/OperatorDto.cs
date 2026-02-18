using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.DTOs
{
    public record OperatorDto(
        int Id,
        string UserId,
        string Username,
        string Email,
        string Title,
        string Firstname,
        string Middlename,
        string Lastname,
        string Phone,
        string Image,
        List<int> LocationIds,
        bool IsActive,
        RoleDto role
        );
}
