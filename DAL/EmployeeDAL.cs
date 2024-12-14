using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using SQLHelper;

namespace DAL
{
    public class EmployeeDAL: IDAL.IPerson
    {
        private const string GET_PERSONS = "Sp_ShowAll";
        private const string GET_ONE_PERSON = "Sp_ShowOne";
        private const string GET_ONE_EMPLOYEE_NAME = "Sp_SearchEmployeeByName";
        private const string INSERT_PERSON = "Sp_Insert";
        private const string UPDATE_PERSON = "Sp_Update";
        private const string DELETE_PERSON = "Sp_Delete";
        private const string ADD_HOLIDAY = "Sp_AddHoliday";
        private const string DELETE_HOLIDAY = "Sp_DeleteHoliday";
        private const string GET_HOLIDAY_WITH_MONTHS_RETURNED = "Sp_GetEmployeeHolidaysWithMonthsSinceReturn";
        private const string ADD_SALARY = "Sp_AddSalary";
        private const string GET_SALARIES_BY_EMPLOYEE_ID = "Sp_GetSalariesByEmployeeId";
        private const string DELETE_SALARY = "Sp_DeleteSalary";
        const string CHECK_HOLIDAY_STATUS = "Sp_IsEmployeeOnHoliday";

        private string ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public List<EmployeeInfo> GetEmployees()
        {
            List<EmployeeInfo> list = new List<EmployeeInfo>();
            using (SqlDataReader dr = SqlHelper.ExecuteReader(ConnectionString, GET_PERSONS))
            {
                while (dr.Read())
                {
                    EmployeeInfo employeeInfo = new EmployeeInfo();
                    employeeInfo.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                    employeeInfo.FirstName = dr["FirstName"].ToString();
                    employeeInfo.LastName = dr["LastName"].ToString();
                    employeeInfo.Nationality = dr["Nationality"].ToString();
                    employeeInfo.Gender = dr["Gender"].ToString();
                    employeeInfo.DateOfBirth = dr.GetDateTime(dr.GetOrdinal("DateOfBirth"));
                    employeeInfo.ContactNumber = dr["ContactNumber"].ToString();
                    employeeInfo.HomeCountryContactNumber = dr["HomeCountryContactNumber"].ToString();
                    employeeInfo.HomeCountryAddress = dr["HomeCountryAddress"].ToString();
                    employeeInfo.DateJoinedLamazani = dr.GetDateTime(dr.GetOrdinal("DateJoinedLamazani"));
                    employeeInfo.Position = dr["Position"].ToString();
                    employeeInfo.Branch = dr["Branch"].ToString();
                    employeeInfo.EmployeeDescription = dr["EmployeeDescription"].ToString();
                    employeeInfo.BasicSalary = dr.GetDecimal(dr.GetOrdinal("BasicSalary"));
                    employeeInfo.PersonalImage = dr["PersonalImage"] as byte[];
                    employeeInfo.QIDImage = dr["QIDImage"] as byte[];
                    employeeInfo.PassportImage = dr["PassportImage"] as byte[];
                    employeeInfo.QIDNumber = dr["QIDNumber"].ToString();
                    employeeInfo.PassportNumber = dr["PassportNumber"].ToString();
                    employeeInfo.QIDExpiry = dr.GetDateTime(dr.GetOrdinal("QIDExpiry"));
                    employeeInfo.MedicalCertificateExpiry = dr.GetDateTime(dr.GetOrdinal("MedicalCertificateExpiry"));

                    list.Add(employeeInfo);
                }
                dr.Close();
            }

            return list;
        }

        public EmployeeInfo GetOneEmployee(int id)
        {
            EmployeeInfo employeeInfo = new EmployeeInfo();
            using (SqlDataReader dr = SqlHelper.ExecuteReader(ConnectionString, GET_ONE_PERSON, id))
            {
                if (dr.Read())
                {
                    employeeInfo.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                    employeeInfo.FirstName = dr["FirstName"].ToString();
                    employeeInfo.LastName = dr["LastName"].ToString();
                    employeeInfo.Nationality = dr["Nationality"].ToString();
                    employeeInfo.Gender = dr["Gender"].ToString();
                    employeeInfo.DateOfBirth = dr.GetDateTime(dr.GetOrdinal("DateOfBirth"));
                    employeeInfo.ContactNumber = dr["ContactNumber"].ToString();
                    employeeInfo.HomeCountryContactNumber = dr["HomeCountryContactNumber"].ToString();
                    employeeInfo.HomeCountryAddress = dr["HomeCountryAddress"].ToString();
                    employeeInfo.DateJoinedLamazani = dr.GetDateTime(dr.GetOrdinal("DateJoinedLamazani"));
                    employeeInfo.Position = dr["Position"].ToString();
                    employeeInfo.Branch = dr["Branch"].ToString();
                    employeeInfo.EmployeeDescription = dr["EmployeeDescription"].ToString();
                    employeeInfo.BasicSalary = dr.GetDecimal(dr.GetOrdinal("BasicSalary"));
                    employeeInfo.PersonalImage = dr["PersonalImage"] as byte[];
                    employeeInfo.QIDImage = dr["QIDImage"] as byte[];
                    employeeInfo.PassportImage = dr["PassportImage"] as byte[];
                    employeeInfo.QIDNumber = dr["QIDNumber"].ToString();
                    employeeInfo.PassportNumber = dr["PassportNumber"].ToString();
                    employeeInfo.QIDExpiry = dr.GetDateTime(dr.GetOrdinal("QIDExpiry"));
                    employeeInfo.MedicalCertificateExpiry = dr.GetDateTime(dr.GetOrdinal("MedicalCertificateExpiry"));
                }

                dr.Close();
            }

            return employeeInfo;
        }

        public List<EmployeeInfo> SearchEmployeesByName(string FirstName)
        {
            List<EmployeeInfo> list = new List<EmployeeInfo>();
            using (SqlDataReader dr = SqlHelper.ExecuteReader(ConnectionString, GET_ONE_EMPLOYEE_NAME, FirstName))
            {
                while (dr.Read())
                {
                    EmployeeInfo employeeInfo = new EmployeeInfo();
                    employeeInfo.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                    employeeInfo.FirstName = dr["FirstName"].ToString();
                    employeeInfo.LastName = dr["LastName"].ToString();
                    employeeInfo.Nationality = dr["Nationality"].ToString();
                    employeeInfo.Gender = dr["Gender"].ToString();
                    employeeInfo.DateOfBirth = dr.GetDateTime(dr.GetOrdinal("DateOfBirth"));
                    employeeInfo.ContactNumber = dr["ContactNumber"].ToString();
                    employeeInfo.HomeCountryContactNumber = dr["HomeCountryContactNumber"].ToString();
                    employeeInfo.HomeCountryAddress = dr["HomeCountryAddress"].ToString();
                    employeeInfo.DateJoinedLamazani = dr.GetDateTime(dr.GetOrdinal("DateJoinedLamazani"));
                    employeeInfo.Position = dr["Position"].ToString();
                    employeeInfo.Branch = dr["Branch"].ToString();
                    employeeInfo.EmployeeDescription = dr["EmployeeDescription"].ToString();
                    employeeInfo.BasicSalary = dr.GetDecimal(dr.GetOrdinal("BasicSalary"));
                    employeeInfo.PersonalImage = dr["PersonalImage"] as byte[];
                    employeeInfo.QIDImage = dr["QIDImage"] as byte[];
                    employeeInfo.PassportImage = dr["PassportImage"] as byte[];
                    employeeInfo.QIDNumber = dr["QIDNumber"].ToString();
                    employeeInfo.PassportNumber = dr["PassportNumber"].ToString();
                    employeeInfo.QIDExpiry = dr.GetDateTime(dr.GetOrdinal("QIDExpiry"));
                    employeeInfo.MedicalCertificateExpiry = dr.GetDateTime(dr.GetOrdinal("MedicalCertificateExpiry"));
                    list.Add(employeeInfo);
                }
                dr.Close();
            }
            return list;
        }

        public bool? Insert(EmployeeInfo employeeInfo)
        {
            int result = SqlHelper.ExecuteNonQuery(ConnectionString, INSERT_PERSON, employeeInfo.FirstName, employeeInfo.LastName, employeeInfo.Nationality, employeeInfo.Gender, employeeInfo.DateOfBirth, employeeInfo.ContactNumber, employeeInfo.HomeCountryContactNumber, employeeInfo.HomeCountryAddress, employeeInfo.DateJoinedLamazani, employeeInfo.Position, employeeInfo.Branch, employeeInfo.EmployeeDescription, employeeInfo.BasicSalary, employeeInfo.PersonalImage, employeeInfo.QIDImage, employeeInfo.PassportImage, employeeInfo.QIDNumber, employeeInfo.PassportNumber, employeeInfo.QIDExpiry, employeeInfo.MedicalCertificateExpiry);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool? Update(EmployeeInfo employeeInfo)
        {
            int result = SqlHelper.ExecuteNonQuery(ConnectionString, UPDATE_PERSON, employeeInfo.EmployeeID, employeeInfo.FirstName, employeeInfo.LastName, employeeInfo.Nationality, employeeInfo.Gender, employeeInfo.DateOfBirth, employeeInfo.ContactNumber, employeeInfo.HomeCountryContactNumber, employeeInfo.HomeCountryAddress, employeeInfo.DateJoinedLamazani, employeeInfo.Position, employeeInfo.Branch, employeeInfo.EmployeeDescription, employeeInfo.BasicSalary, employeeInfo.PersonalImage, employeeInfo.QIDImage, employeeInfo.PassportImage, employeeInfo.QIDNumber, employeeInfo.PassportNumber, employeeInfo.QIDExpiry, employeeInfo.MedicalCertificateExpiry);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool? Delete(int id)
        {
            int result = SqlHelper.ExecuteNonQuery(ConnectionString, DELETE_PERSON, id);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool? AddHoliday(EmployeeHoliday employeeHoliday)
        {
            int result = SqlHelper.ExecuteNonQuery(ConnectionString, ADD_HOLIDAY, employeeHoliday.EmployeeID, employeeHoliday.StartDate, employeeHoliday.EndDate, employeeHoliday.Reason);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public  bool? DeleteHoliday(int id)
        {
            int result = SqlHelper.ExecuteNonQuery(ConnectionString, DELETE_HOLIDAY, id);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<EmployeeHoliday> GetHolidaysByEmployeeId(int employeeId)
        {
            List<EmployeeHoliday> employeeHolidays = new List<EmployeeHoliday>();

            using (SqlDataReader dr = SqlHelper.ExecuteReader(ConnectionString, GET_HOLIDAY_WITH_MONTHS_RETURNED, employeeId))
            {
                while (dr.Read()) // Use while loop to handle multiple holidays for the employee
                {
                    EmployeeHoliday employeeHoliday = new EmployeeHoliday();

                    employeeHoliday.HolidayID = Convert.ToInt32(dr["HolidayID"]);
                    employeeHoliday.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                    employeeHoliday.StartDate = dr.GetDateTime(dr.GetOrdinal("StartDate"));
                    employeeHoliday.EndDate = dr.GetDateTime(dr.GetOrdinal("EndDate"));
                    employeeHoliday.Reason = dr["Reason"].ToString();

                    // Retrieve MonthsSinceReturn and convert to int
                    employeeHoliday.MonthsSinceReturn = Convert.ToInt32(dr["MonthsSinceReturn"]);

                    employeeHolidays.Add(employeeHoliday);
                }

                dr.Close();
            }

            return employeeHolidays;
        }

        public bool? AddSalary(EmployeeSalary employeeSalary)
        {
            int result = SqlHelper.ExecuteNonQuery(ConnectionString, ADD_SALARY,
                employeeSalary.EmployeeID, employeeSalary.Bonus, employeeSalary.SalaryTaken, employeeSalary.ReasonSalaryTaken, employeeSalary.DateSalaryAdded);

            return result > 0;
        }

        public List<EmployeeSalary> GetSalariesByEmployeeId(int employeeId)
        {
            List<EmployeeSalary> employeeSalaries = new List<EmployeeSalary>();

            using (SqlDataReader dr = SqlHelper.ExecuteReader(ConnectionString, GET_SALARIES_BY_EMPLOYEE_ID, employeeId))
            {
                while (dr.Read())
                {
                    EmployeeSalary salary = new EmployeeSalary
                    {
                        SalaryID = Convert.ToInt32(dr["SalaryID"]),
                        EmployeeID = Convert.ToInt32(dr["EmployeeID"]),
                        Bonus = Convert.ToDecimal(dr["Bonus"]),
                        SalaryTaken = Convert.ToDecimal(dr["SalaryTaken"]),
                        ReasonSalaryTaken = dr["ReasonSalaryTaken"].ToString(),
                        BasicSalary = Convert.ToDecimal(dr["BasicSalary"]),
                        Total = Convert.ToDecimal(dr["Total"]),
                        DateSalaryAdded = dr.GetDateTime(dr.GetOrdinal("DateSalaryAdded"))
                    };

                    employeeSalaries.Add(salary);
                }
                dr.Close();
            }
            return employeeSalaries;
        }
        public bool? DeleteSalary(int id)
        {
            int result = SqlHelper.ExecuteNonQuery(ConnectionString, DELETE_SALARY, id);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool? IsEmployeeOnHoliday(int employeeId)
        {
            // Execute the stored procedure
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(CHECK_HOLIDAY_STATUS, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                conn.Open();
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();

                return result == 1; // Return true if result is 1 (on holiday)
            }
        }
    }

}
