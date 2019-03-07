using System;
using System.Collections.Generic;
using System.Text;

namespace DevTo.Api.Models
{
	public class Article
	{
		public int ArticleId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public Uri CoverImage { get; set; }
		public Uri SocialImage { get; set; }
		public DateTime PublishedAt { get; set; }
		public IEnumerable<string> TagList { get; set; }

		public string Slug { get; set; }
		public string Path { get; set; }
		public Uri ArticleUrl { get; set; }
		
		public int NumberOfComments { get; set; }
		public int NumberOfReactions { get; set; }

		public string BodyHtml { get; set; }

		public ArticleAuthor User { get; set; }
	}
}
