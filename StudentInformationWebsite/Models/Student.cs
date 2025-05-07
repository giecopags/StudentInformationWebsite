namespace StudentInformationWebsite.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }

        public string StudentName
        {
            get
            {
                string middleInitial = string.IsNullOrEmpty(MiddleName) ? "" : MiddleName[0] + ".";
                return $"{FirstName} {middleInitial} {LastName}";
            }
        }
    }
}
