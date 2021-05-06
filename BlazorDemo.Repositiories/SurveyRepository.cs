using BlazorDemo.Database;
using BlazorDemo.Entities;
using BlazorDemo.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BlazorDemo.Repositories
{
    public class SurveyRepository : BaseRepository<Survey>
    {
        private readonly BlazorDbContext context;

        public SurveyRepository(BlazorDbContext context)
            : base(context)
        {
            this.context = context;
        }

        public async Task<Survey> GetSurveyByIdAsync(Guid id)
        {
            return await context.Surveys
                .Include(s => s.Answers)
                .SingleOrDefaultAsync(s => s.Id == id);
        }
    }
}
