using BlazorDemo.Database;
using BlazorDemo.Entities;
using BlazorDemo.Repositories.Base;

namespace BlazorDemo.Repositories
{
    public class SurveyRepository : BaseRepository<Survey>
    {
        public SurveyRepository(BlazorDbContext context)
            : base(context)
        {
        }
    }
}
