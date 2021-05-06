using System.ComponentModel.DataAnnotations;

namespace BlazorDemo.Models.Question
{
    public class QuestionAddEdit
    {
        [Required]
        [MaxLength(255)]
        public string Text { get; set; }
    }
}
