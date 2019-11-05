using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBlog.Models;
using MyBlog.Models.Config;
using MyBlog.Utils.Dao;

namespace MyBlog.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IConfigDao _configDao;

		public HomeController(ILogger<HomeController> logger, AppSettings appSettings, IConfigDao configDao)
		{
			_logger = logger;
			_configDao = configDao;
			logger.LogInformation(appSettings.DataBase.Type.ToString());
		}

		public async Task<IActionResult> Index()
		{
			return View(await _configDao.GetConfig());
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
