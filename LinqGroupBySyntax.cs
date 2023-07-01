using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPData;

namespace LinqAdvanced
{
    public class LinqGroupBySyntax
    {
        List<Employee> employees = Data.GetEmployees();
        List<Department> departments = Data.GetDepartments();
        public void GroupBySyntax()
        {
            /// Query Syntax GroupBy
            var groupResult = from employee in employees
                              group employee by employee.DepartmentId;


            /// Method Syntax GroupBy
            var groupResult2 = employees.GroupBy(employee => employee.DepartmentId);
            /// result of GroupBy and ToLookup  will be the same, diffrence that ToLookup execute immediatly
            var groupResult3 = employees.ToLookup(employee => employee.DepartmentId);

            foreach (var empGroup in groupResult)
            {
                Console.WriteLine($"Department Id : {empGroup.Key}");
                foreach (var employee in empGroup)
                {
                    Console.WriteLine($"FullName :{employee.FirstName} {employee.LastName}. Annual sallary : {employee.AnnualSalary}");
                }
            }
        }
    }
}
