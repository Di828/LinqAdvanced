using TCPData;
using TCPExtensions;

namespace LinqAdvanced
{
    internal class Program
    {
        // Query Syntax предпочтительнее чем Method Syntax
        static void Main(string[] args)
        {
            List<Employee> employees = TCPData.Data.GetEmployees();
            List<Department> departments = TCPData.Data.GetDepartments();
            var managers = employees.Filter(e => e.IsManager);


            ///Order By Method Syntax
            var result5 = employees.Join(departments, emp => emp.DepartmentId, dep => dep.Id,
                    (emp, dep) => new
                    {
                        FullName = emp.FirstName + " " + emp.LastName,
                        AnnualSalary = emp.AnnualSalary,
                        DepartmentId = dep.Id,
                        Department = dep.LongName
                    }).OrderBy(o => o.DepartmentId)
                      .ThenByDescending(o => o.AnnualSalary);
            ///Order By Query Syntax
            var result6 = from emp in employees
                          join dep in departments
                          on emp.DepartmentId equals dep.Id
                          orderby dep.Id, emp.AnnualSalary descending
                          select new
                          {
                              FullName = emp.FirstName + " " + emp.LastName,
                              AnnualSalary = emp.AnnualSalary,
                              DepartmentId = dep.Id,
                              Department = dep.LongName
                          };

            foreach (var manager in result5)
            {
                Console.WriteLine($"Full Name : {manager.FullName}, Salary : {manager.AnnualSalary}");
                Console.WriteLine($"Department : {manager.Department}");
                Console.WriteLine();
            }

            //foreach (var manager in result2)
            //{
            //    Console.WriteLine($"First Name : {manager.FirstName}, Last Name : {manager.LastName}. Salary : {manager.AnnualSalary}");
            //    Console.WriteLine($"Department : {manager.Department}");
            //    Console.WriteLine();
            //}            
        }
    }
}