using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeDataAccess;

namespace EmployeeService
{
    public class EmployeeSecurity
    {
        public static bool Login(string Username,string Password)
        {
            using(GHEntities entities=new GHEntities())
            {
                return (entities.Users.Any(Emp => Emp.Username.Equals(Username, StringComparison.OrdinalIgnoreCase) && Emp.Password  == Password));
            }
        }
    }
}