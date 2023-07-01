using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPData;

namespace LinqAdvanced
{
    public class LinqContains
    {
        List<Employee> employees = Data.GetEmployees();
        public void LinqContainsMethod()
        {
            var employee = new Employee()
            {
                Id = employees[0].Id,
                FirstName = employees[0].FirstName,
                LastName = employees[0].LastName,
                AnnualSalary = employees[0].AnnualSalary,
                IsManager = employees[0].IsManager,
                DepartmentId = employees[0].DepartmentId
            };

            bool containsEmployee = employees.Contains(employee);  // result will be false because the links are diffrence, to change compare :
            bool containsEmployeeByValues = employees.Contains(employee, new EmployeeComparer()); // result will be true, EmployeeComparer - release our compare method;

        }
    }

    public class EmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee? x, Employee? y) => x.Id == y.Id && x.FirstName == y.FirstName && x.LastName == y.LastName && x.AnnualSalary == y.AnnualSalary;

        public int GetHashCode([DisallowNull] Employee obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
