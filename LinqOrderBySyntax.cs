using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPData;

namespace LinqAdvanced
{
    public class LinqOrderBySyntax
    {
        List<Employee> employees = Data.GetEmployees();
        List<Department> departments = Data.GetDepartments();

        public void OrderBySyntax()
        {
            /// Query Syntax OrderBy
            var result = from employee in employees
                         join department in departments
                         on employee.DepartmentId equals department.Id
                         orderby employee.AnnualSalary descending, employee.FirstName
                         select new
                         {
                             employee.FirstName,
                             employee.LastName,
                             employee.AnnualSalary,
                             Department = department.LongName
                         };


            /// Method Syntax OrderBy
            var result2 = employees.Join(departments,
                employee => employee.DepartmentId,
                department => department.Id,
                (employee, department) => new
                {
                    employee.FirstName,
                    employee.LastName,
                    employee.AnnualSalary,
                    Department = department.LongName
                }).OrderByDescending(x => x.AnnualSalary)
                .ThenBy(x => x.FirstName);
        }
    }
}
