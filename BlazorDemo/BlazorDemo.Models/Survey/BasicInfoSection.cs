using System;

namespace BlazorDemo.Models.Survey
{
    public class BasicInfoSection
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string Nationality { get; set; }
    }
}