using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlog.Models.Config
{
	public class MyBlogConfig
	{
		[Key] public Guid Id { get; set; }

		[Required]
		[Column(TypeName = "jsonb")]
		public Config Config { get; set; }
	}

	public class Config
	{
		/// <summary>
		///     博客标题
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		///     博客作者
		/// </summary>
		public string Author { get; set; }

		/// <summary>
		/// 博客url
		/// </summary>
		public string Url { get; set; }

		/// <summary>
		/// 网页图标
		/// </summary>
		public string Favicon { get; set; }


		/// <summary>
		/// 备案信息
		/// </summary>
		public string BeiAn { get; set; }

		/// <summary>
		/// 又拍云
		/// </summary>
		public string UpYun { get; set; }

		/// <summary>
		///     侧栏菜单
		/// </summary>
		public Dictionary<string, string> Menu { get; set; }

		/// <summary>
		///     建站时间
		/// </summary>
		public Dictionary<string, string> Wbd { get; set; }
	}
}