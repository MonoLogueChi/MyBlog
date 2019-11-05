using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyBlog.Models;
using MyBlog.Models.Config;
using MyBlog.Utils.Dao;
using Westwind.AspNetCore.Markdown;

namespace MyBlog
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
			services.AddMarkdown();
			services.AddMvc().AddApplicationPart(typeof(MarkdownPageProcessorMiddleware).Assembly);
			services.AddControllersWithViews();

			services.AddSingleton(new AppSettings(Configuration));
			services.AddSingleton<IConfigDao, ConfigDao>();

			services.AddDbContext<MyBlogConfigContext>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();
			else
				app.UseExceptionHandler("/Home/Error");


			app.UseDefaultFiles(new DefaultFilesOptions
			{
				DefaultFileNames = new List<string> {"index.md", "index.html"}
			});
			app.UseMarkdown();

			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();


			using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetRequiredService<MyBlogConfigContext>();
				context.Database.EnsureCreated();
			}

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					"default",
					"{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}