using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlog.Models.Config;

namespace MyBlog.Utils.Dao
{
	public interface IConfigDao
	{
		Task<Config> GetConfig();

	}
}
