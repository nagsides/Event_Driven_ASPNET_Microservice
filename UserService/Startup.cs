//using Microsoft.AspNetCore.Builder;
//using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.OpenApi.Models;
using UserService.Data;
//using System;

namespace UserService{
  public class Startup
  {
    public Startup(IWebHostEnvironment env)
    {
    }
    public void ConfigureServices(IServiceCollection services)
    {

        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "UserService", Version = "v1" });
        });

        services.AddDbContext<UserServiceContext>(options =>
             options.UseSqlite(@"Data Source=user.db"));
    }
    public static void Configure(IApplicationBuilder app, 
		    IWebHostEnvironment env, 
		    DbContext context)
    {
        if (env.IsDevelopment())
        {
            context.Database.EnsureCreated();
            //context.Database.Migrate();
        }
    }
    /*public void Configure(IApplicationBuilder app,
       IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      app.Run(async (context) =>
      {
        await context.Response.WriteAsync("Hello, world!");
      });
    }
    */
  }
}
