using BlazorDemo.Api.Configuration;
using BlazorDemo.Database;
using BlazorDemo.Mapper;
using BlazorDemo.Repositories;
using BlazorDemo.Services.Domain.Question;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BlazorDemo.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RabbitMqOptions>(Configuration.GetSection("RabbitMqOptions"));

            services.AddCors(options => options
                .AddPolicy("AllowAnyOrigin", policy => policy
                    .AllowAnyOrigin()
                    .AllowAnyMethod()));

            services.AddDbContext<BlazorDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BlazorDb")));
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BlazorDemo.Api", Version = "v1" });
            });

            services.AddAutoMapper(typeof(QuestionProfile));
            services.AddMediatR(
                typeof(AddQuestionHandler),
                typeof(DeleteQuestionHandler),
                typeof(EditQuestionHandler),
                typeof(GetQuestionsHandler));

            services.AddScoped<AnswerRepository>();
            services.AddScoped<QuestionRepository>();
            services.AddScoped<SurveyRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BlazorDemo.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowAnyOrigin");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
