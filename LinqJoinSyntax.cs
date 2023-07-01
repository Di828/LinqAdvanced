using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPData;

namespace LinqAdvanced
{
    public class LinqJoinSyntax
    {
        List<Employee> employees;
        List<Department> departments;
        public LinqJoinSyntax()
        {
            employees = Data.GetEmployees();
            departments = Data.GetDepartments();
        }
        public void InnerJoinSyntax()
        {            

            /// Query Syntax with Inner Join
            var result = from employee in employees
                         join department in departments
                         on employee.DepartmentId equals department.Id
                         select new
                         {
                             employee.FirstName,
                             employee.LastName,
                             employee.AnnualSalary,
                             Department = department.LongName
                         };


            /// Method Syntax with Inner Join (Таблица для объединения, ключ текущей таблицы, ключ таблицы для объединения, лямбда выражение с новым типом созданным из 2 таблиц)
            var result2 = employees.Join(
                departments,
                employee => employee.DepartmentId,
                department => department.Id,
                (employee, department) => new
                {
                    employee.FirstName,
                    employee.LastName,
                    employee.AnnualSalary,
                    Department = department.LongName
                });

        }

        public void LeftJoinSyntax() 
        { 
            ///GroupJoin - Query Syntax = Left Join
            var result12 = from employee in employees
                           join department in departments
                           on employee.DepartmentId equals department.Id
                           into departmentGroup
                           select new
                           {
                               employee.FirstName,
                               employee.LastName,
                               employee.AnnualSalary,
                               Department = departmentGroup
                           };


            ///GroupJoin - Method Syntax = LeftJoin
            var result22 = employees.GroupJoin(departments,
                employee => employee.DepartmentId,
                department => department.Id,
                (employee, departmentGroup) => new
                {
                    employee.FirstName,
                    employee.LastName,
                    employee.AnnualSalary,
                    Department = departmentGroup
                });            
        }
    }
}
