using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Factory;
using IDAL;
using DAL;

namespace BAL
{
    public class EmployeeBAL: IProxy.IPerson
    {
        private static readonly EmployeeDAL dal = DataAccess.CreateInstance("EmployeeDAL");
        public List<EmployeeInfo> GetEmployees()
        {
            return dal.GetEmployees();
        }
        public EmployeeInfo GetOneEmployee(int id)
        {
            return dal.GetOneEmployee(id);
        }
        public List<EmployeeInfo> SearchEmployeesByName(string FirstName)
        {
            return dal.SearchEmployeesByName(FirstName);
        }
        public bool? Insert(EmployeeInfo employeeInfo)
        {
            return dal.Insert(employeeInfo);
        }

        public bool? Update(EmployeeInfo employeeInfo)
        {
            return dal.Update(employeeInfo);
        }
        public bool? Delete(int id)
        {
            return dal.Delete(id);
        }

        public bool? AddHoliday(EmployeeHoliday employeeHoliday) 
        {
            return dal.AddHoliday(employeeHoliday);
        }
        public bool? DeleteHoliday(int id)
        {
            return dal.DeleteHoliday(id);
        }
        public List<EmployeeHoliday> GetHolidaysByEmployeeId(int employeeId)
        {
            // Calling the DAL layer method to get the list of holidays by employee ID
            return dal.GetHolidaysByEmployeeId((int)employeeId);
        }

        public bool? AddSalary(EmployeeSalary employeeSalary)
        {
            return dal.AddSalary(employeeSalary);
        }

        public List<EmployeeSalary> GetSalariesByEmployeeId(int employeeId)
        {
            return dal.GetSalariesByEmployeeId((int)employeeId);
        }
        public bool? DeleteSalary(int id)
        {
            return dal.DeleteSalary(id);
        }
        public bool? IsEmployeeOnHoliday(int employeeId)
        {
            return dal.IsEmployeeOnHoliday(employeeId); 
        }
    }
}
