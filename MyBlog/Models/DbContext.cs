using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using MyBlog.Models.Config;
using static MyBlog.Models.Config.Db.DbType;

namespace MyBlog.Models
{
	public class DbContextBase : DbContext
	{
		private protected readonly Db DataBase;

		public DbContextBase(AppSettings appSettings)
		{
			DataBase = appSettings.DataBase;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			switch (DataBase.Type)
			{
				case PostgreSql:
					DataBase.Port = DataBase.Port == 0 ? 5432 : DataBase.Port;
					optionsBuilder.UseNpgsql($"Host={DataBase.Host};Port={DataBase.Port};Database={DataBase.DataBase};Username={DataBase.UserName};Password={DataBase.PassWord};");
					break;
				case Sqlite:
					if (!Directory.Exists("DataBase")) Directory.CreateDirectory("DataBase");
					optionsBuilder.UseSqlite("Data Source=DataBase/MyBlog.db");
					break;
			}

#if DEBUG
			optionsBuilder.UseLoggerFactory(new LoggerFactory(new[] { new DebugLoggerProvider() }));
#endif
		}
	}

	public class MyBlogConfigContext : DbContextBase
	{
		public MyBlogConfigContext(AppSettings appSettings) : base(appSettings)
		{
		}

		public DbSet<MyBlogConfig> MyBlogConfigs { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			switch (DataBase.Type)
			{
				case PostgreSql:
					break;
				case Sqlite:
					break;

			}
		}
	}

}
