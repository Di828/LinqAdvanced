using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPData;

namespace LinqAdvanced
{
    public class LinqSelectWhereSyntax
    {
        List<Employee> employees = Data.GetEmployees();        

        public void SelectAndWhereSyntax()
        {

            /// Query Syntax with Select and Where
            var result = from employee in employees
                         where employee.AnnualSalary > 50000
                         select new
                         {
                             Fullname = employee.FirstName + " " + employee.LastName,
                             AnnualSalary = employee.AnnualSalary,
                         };


            /// Method Syntax with Select and Where
            var result2 = employees.Select(employee => new
            {
                FullName = employee.FirstName + " " + employee.LastName,
                AnnualSalary = employee.AnnualSalary
            }).Where(x => x.AnnualSalary > 50000);
        }
    }
}