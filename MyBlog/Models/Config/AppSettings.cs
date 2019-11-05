using Microsoft.Extensions.Configuration;

namespace MyBlog.Models.Config
{
	public class AppSettings
	{
		public AppSettings(IConfiguration configuration)
		{
			configuration.Bind(this);
		}

		public string AllowedHosts { get; set; }

		public Db DataBase { get; set; }
		public Admin Admin { get; set; }
		

	}


	public class Db
	{
		public enum DbType
		{
			PostgreSql = 0,
			Sqlite = 1
		}

		public DbType Type { get; set; }
		public string Host { get; set; }
		public int Port { get; set; }
		public string DataBase { get; set; }
		public string UserName { get; set; }
		public string PassWord { get; set; }
	}

	public class Admin
	{
		public string UserName { get; set; }
		public string PassWord { get; set; }
	}
}
