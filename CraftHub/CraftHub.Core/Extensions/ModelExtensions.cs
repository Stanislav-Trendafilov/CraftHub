using CraftHub.Core.Contracts;
using System.Text.RegularExpressions;

namespace CraftHub.Core.Extensions
{
	public static class ModelExtensions
	{
		public static string GetInformation(this IProductModel product)
		{
			string info = product.Title.Replace(" ", "-") +"-"+ GetDescription(product.Description);
			info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

			return info;
		}

		private static string GetDescription(string description)
		{
			description = string.Join("-", description.Split(" ").Take(10));

			return description;
		}
	}
}
