using BlazorDemo.Database;
using BlazorDemo.Entities;
using BlazorDemo.Repositories.Base;

namespace BlazorDemo.Repositories
{
    public class QuestionRepository : BaseRepository<Question>
    {
        public QuestionRepository(BlazorDbContext context)
            : base(context)
        {
        }
    }
}
