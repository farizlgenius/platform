using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.DTOs
{
    public record UpdateOperator(string UserId,string Username,string Email,string Title,string Firstname,string Middlename,string Lastname,string Phone,string Image,int RoleId,List<int> LocationIds);
}
