using System;

namespace Jamia.Areas.Student.Models
{
    public class PersonalDetail
    {
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public bool StudentStatus { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BirthPlace { get; set; }
        public string MotherTongue { get; set; }
        public string BloodGroup { get; set; }
        public string Category { get; set; }
        public string Religion { get; set; }
    }
    public class AdmissionDetails
    {
        public string ApplicationNumber { get; set; }
        public string AdmissionDate { get; set; }
        public string Session { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }
        public string RollNumber { get; set; }
        public string LastSchoolAttended { get; set; }
    }
    public class ParentsDetail
    {
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string GuaridanName { get; set; }
        public string FatherOccupation { get; set; }
        public string MotherOccupation { get; set; }
        public string GuaridanOccupation { get; set; }

    }
}
