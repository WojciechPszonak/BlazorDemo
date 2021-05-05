using BlazorDemo.Database;
using BlazorDemo.Entities;
using BlazorDemo.Repositories.Base;

namespace BlazorDemo.Repositories
{
    public class AnswerRepository : BaseRepository<Answer>
    {
        public AnswerRepository(BlazorDbContext context)
            : base(context)
        {
        }
    }
}
