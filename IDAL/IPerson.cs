using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface IPerson
    {
        List<EmployeeInfo> GetEmployees();
        EmployeeInfo GetOneEmployee(int id);
        List<EmployeeInfo> SearchEmployeesByName(string FirstName);
        bool? Insert(EmployeeInfo employeeInfo);
        bool? Update(EmployeeInfo employeeInfo);
        bool? Delete(int id);

        bool? AddHoliday(EmployeeHoliday employeeHoliday);
        bool? DeleteHoliday(int id);
        List<EmployeeHoliday> GetHolidaysByEmployeeId(int employeeID);
        bool? IsEmployeeOnHoliday(int employeeId);

        bool? AddSalary(EmployeeSalary employeeSalary);
        List<EmployeeSalary> GetSalariesByEmployeeId(int employeeID);
        bool? DeleteSalary(int id);
    }
}
