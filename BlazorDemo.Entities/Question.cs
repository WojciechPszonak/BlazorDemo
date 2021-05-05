using BlazorDemo.Entities.Base;
using System.Collections.Generic;

namespace BlazorDemo.Entities
{
    public class Question : BaseEntity
    {
        public string Text { get; set; }

        public IEnumerable<Answer> Answers { get; set; } = new List<Answer>();
    }
}
