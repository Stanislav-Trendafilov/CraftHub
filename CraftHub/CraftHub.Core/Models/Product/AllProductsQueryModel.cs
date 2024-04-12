﻿using CraftHub.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CraftHub.Core.Models.Product
{
	public class AllProductsQueryModel
	{
		public int ProductsPerPage { get; } = 6;

		public string Category { get; init; } = null!;

		[Display(Name = "Search by text")]
		public string SearchTerm { get; init; } = null!;

		public ProductSorting Sorting { get; init; }

		public int CurrentPage { get; set; } = 1;

		public int TotalProductsCount { get; set; }
		public IEnumerable<string> Categories { get; set; } = null!;

		public IEnumerable<ProductServiceModel> Products { get; set; } = new List<ProductServiceModel>();
	}
}
