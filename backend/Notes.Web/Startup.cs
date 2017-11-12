using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Notes.Data.EfCore;
using Microsoft.EntityFrameworkCore;
using Notes.Domain.Port.In;
using Notes.Domain.Service;
using Notes.Domain.Port.Out;

namespace Notes.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NotesContext>(opt => opt.UseInMemoryDatabase("notes"));
            services.AddTransient<INoteCrudService, NoteCrudService>();
            services.AddTransient<INoteQueryService, NoteQueryService>();
            services.AddTransient<INoteCrudRepository, NoteCrudRepository>();
            services.AddTransient<INoteQueryRepository, NoteQueryRepository>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
