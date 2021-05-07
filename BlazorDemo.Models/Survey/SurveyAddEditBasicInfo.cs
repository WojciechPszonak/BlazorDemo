using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorDemo.Models.Survey
{
    public class SurveyAddEditBasicInfo
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public DateTime? BirthDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nationality { get; set; }
    }
}