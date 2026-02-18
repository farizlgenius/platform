using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.DTOs
{
    public record CreateOperator(string UserId,string Username,string Password,string Email,string Title,string Firstname,string Middlename,string Lastname,string Phone,string Image,int RoleId,List<int> LocationIds);

}
