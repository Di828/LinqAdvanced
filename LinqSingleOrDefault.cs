using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPData;

namespace LinqAdvanced
{
    internal class LinqSingleOrDefault
    {
        public void SingleOrDefaultEspecial()
        {
            List<Employee> employees = Data.GetEmployees();
            var result = employees.SingleOrDefault(x => x.Id > 1); // Will Throw an exception if more than one elements OK
            var result2 = employees.SingleOrDefault(x => x.Id == -1); // Will return null if element not exist
        }
    }
}
