using BlazorDemo.Entities.Base;
using BlazorDemo.Entities.Enums;
using System;
using System.Collections.Generic;

namespace BlazorDemo.Entities
{
    public class Survey : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string Nationality { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public IEnumerable<Answer> Answers { get; set; } = new List<Answer>();
    }
}
