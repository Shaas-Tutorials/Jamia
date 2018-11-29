namespace Jamia.Infrastructure
{
    public class AreaNames
    {
        public const string SuperAdmin = "SuperAdmin";
        public const string Admin = "Admin";
        public const string Student = "Student";
        public const string Teacher = "Teacher";
    }
    public class RoleNames
    {
        public const string SuperAdmin = "SuperAdmin";
        public const string Admin = "Admin";
        public const string Student = "Student";
        public const string Teacher = "Teacher";
    }
    public class ControlerNames
    {
        public const string Home = "Home";

        #region Admin
        public const string Sessions = "Sessions";
        public const string Courses = "Courses";
        #endregion

        #region Super Admin
        public const string Institutes = "Institutes";
        public const string Campus = "Campus";
        #endregion
    }
    public class ActionNames
    {
        public const string Index = "Index";
    }
    public class SchemaNames
    {
        public const string Security = "Security";
        public const string SuperAdmin = "SuperAdmin";
        public const string Admin = "Admin";
        public const string Student = "Student";
    }
    public class PolicyNames
    {
        public const string Status = "Status";
    }
}
