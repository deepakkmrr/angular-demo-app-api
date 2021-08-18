using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Database.Model
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime AddedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public Guid LogId { get; set; }
    }
}
