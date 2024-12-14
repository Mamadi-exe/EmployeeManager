using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using DAL;

namespace Factory
{
    public class DataAccess
    {
        private static readonly string path = ConfigurationManager.AppSettings["Employees.DAL"];
        public static EmployeeDAL CreateInstance(string classPath)
        {
            string className = string.Format("{0}.{1}", path, classPath);
            return Assembly.Load(path).CreateInstance(className) as EmployeeDAL;
        }
    }
}
