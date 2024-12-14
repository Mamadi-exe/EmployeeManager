using BAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class EmployeeProxy:IProxy.IPerson
    {
        private EmployeeBAL employeeBAL = null;
        string userName = "Admin";
        private void Authenticate(string userName)
        {
            if (userName == this.userName)
            {
                employeeBAL = new EmployeeBAL();
            }
        }
        public List<EmployeeInfo> GetEmployees()
        {
            Authenticate(userName);
            if (employeeBAL != null)
            {
                return employeeBAL.GetEmployees();
            }
            else
            {
                return null;
            }
        }
        public EmployeeInfo GetOneEmployee(int id)
        {
            Authenticate(userName);
            if (employeeBAL != null)
            {
                return employeeBAL.GetOneEmployee(id);
            }
            else
            {
                return null;
            }
        }
        public List<EmployeeInfo> SearchEmployeesByName(string FirstName)
        {
            Authenticate(userName);
            if (employeeBAL != null)
            {
                return employeeBAL.SearchEmployeesByName(FirstName);
            }
            else
            {
                return null;
            }
        }
        public bool? Insert(EmployeeInfo employeeInfo)
        {
            Authenticate(userName);
            if (employeeBAL != null)
            {
                return employeeBAL.Insert(employeeInfo);
            }
            else
            {
                return null;
            }
        }

        public bool? Update(EmployeeInfo employeeInfo)
        {
            Authenticate(userName);
            if (employeeBAL != null)
            {
                return employeeBAL.Update(employeeInfo);
            }
            else
            {
                return null;
            }
        }
        public bool? Delete(int id)
        {
            Authenticate(userName);
            if (employeeBAL != null)
            {
                return employeeBAL.Delete(id);
            }
            else
            {
                return null;
            }
        }
        public bool? AddHoliday(EmployeeHoliday employeeHoliday)
        {
            Authenticate(userName);
            if (employeeBAL != null)
            {
                return employeeBAL.AddHoliday(employeeHoliday);
            }
            else
            {
                return null;
            }
        }
        public bool? DeleteHoliday(int id)
        {
            Authenticate(userName);
            if (employeeBAL != null)
            {
                return employeeBAL.DeleteHoliday(id);
            }
            else
            {
                return null;
            }
        }
        public List<EmployeeHoliday> GetHolidaysByEmployeeId(int employeeId)
        {
            Authenticate(userName);
            if (employeeBAL != null)
            {
                return employeeBAL.GetHolidaysByEmployeeId((int)employeeId);
            }
            else
            {
                return null;
            }
        }
        public bool? AddSalary(EmployeeSalary salaryId)
        {
            Authenticate(userName);
            if (employeeBAL != null)
            {
                return employeeBAL.AddSalary(salaryId);
            }
            else
            {
                return null;
            }
        }
        public List<EmployeeSalary> GetSalariesByEmployeeId(int salaryId)
        {
            Authenticate(userName);
            if (employeeBAL != null)
            {
                return employeeBAL.GetSalariesByEmployeeId((int)salaryId);
            }
            else
            {
                return null;
            }
        }
        public bool? DeleteSalary(int id)
        {
            Authenticate(userName);
            if (employeeBAL != null)
            {
                return employeeBAL.DeleteSalary((int)id);
            }
            else
            {
                return null;
            }
        }
        public bool? IsEmployeeOnHoliday(int employeeId)
        {
            Authenticate(userName);
            if (employeeBAL != null)
            {
                return employeeBAL.IsEmployeeOnHoliday(employeeId);
            }
            else
            {
                return null;
            }
            
        }
    }
}
