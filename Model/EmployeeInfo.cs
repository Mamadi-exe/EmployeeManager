using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class EmployeeInfo
    {
        [DataMember]
        public int EmployeeID { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Nationality { get; set; }
        [DataMember]
        public DateTime DateOfBirth { get; set; }
        [DataMember]
        public string Gender {  get; set; }
        [DataMember]
        public string ContactNumber { get; set; }
        [DataMember]
        public string HomeCountryContactNumber { get; set; }
        [DataMember]
        public string HomeCountryAddress { get; set; }
        [DataMember]
        public DateTime DateJoinedLamazani { get; set; }
        [DataMember]
        public string Position { get; set; }
        [DataMember]
        public string Branch { get; set; }
        [DataMember]
        public string EmployeeDescription { get; set; }
        [DataMember]
        public decimal BasicSalary { get; set; }
        [DataMember]
        public byte[] PersonalImage { get; set; }
        [DataMember]
        public byte[] QIDImage { get; set; }
        [DataMember]
        public byte[] PassportImage { get; set;}
        [DataMember]
        public string QIDNumber { get; set; }
        [DataMember]
        public string PassportNumber { get; set; }
        [DataMember]
        public DateTime QIDExpiry { get; set; }
        [DataMember]
        public DateTime MedicalCertificateExpiry { get; set; }



    }

    [DataContract]
    public class EmployeeHoliday
    {
        [DataMember]
        public int HolidayID { get; set; }
        [DataMember]
        public int EmployeeID { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public string Reason { get; set; }
        [DataMember]
        public int MonthsSinceReturn { get; set; }
    }

    [DataContract]
    public class EmployeeSalary
    {
        [DataMember]
        public int SalaryID { get; set; }
        [DataMember]
        public int EmployeeID { get; set; }
        [DataMember]
        public decimal Bonus { get; set; }
        [DataMember]
        public decimal SalaryTaken { get; set; }
        [DataMember]
        public decimal BasicSalary { get; set; } 
        [DataMember]
        public decimal Total {  get; set; }
        [DataMember]
        public string ReasonSalaryTaken { get; set; }
        [DataMember]
        public DateTime DateSalaryAdded { get; set; }
    }
}
