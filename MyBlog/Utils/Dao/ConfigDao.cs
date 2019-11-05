using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBlog.Models;
using MyBlog.Models.Config;

namespace MyBlog.Utils.Dao
{
	public class ConfigDao : IConfigDao
	{
		private readonly AppSettings _appSettings;

		public ConfigDao(AppSettings appSettings)
		{
			_appSettings = appSettings;
		}

		public async Task<Config> GetConfig()
		{
			await using var con = new MyBlogConfigContext(_appSettings);
			return await con.MyBlogConfigs.Select(s => s.Config).FirstOrDefaultAsync();
		}






	}
}
