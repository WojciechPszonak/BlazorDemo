using System.ComponentModel.DataAnnotations;

namespace BlazorDemo.Models.Survey
{
    public class SurveyAddEditContactInfo
    {
        [MaxLength(13)]
        public string PhoneNumber { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }
    }
}