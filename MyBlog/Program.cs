using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

#if LINUX
using System.IO;

#endif

namespace MyBlog
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>().ConfigureKestrel((context, options) =>
					{
#if LINUX
						if (File.Exists("/tmp/MyBlog.sock")) File.Delete("/tmp/MyBlog.sock");
						options.ListenUnixSocket("MyBlog.sock");
#endif
					});
				});
	}
}