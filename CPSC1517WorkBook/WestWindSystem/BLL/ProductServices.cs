using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WestWindSystem.DAL;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{
	public class ProductServices
	{
		private WestWindContext _context;

		internal ProductServices(WestWindContext context)
		{
			_context = context;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public List<Product> GetProductsByCategoryId(int id)
		{
			return _context.Products
				.Where(p => p.CategoryId == id)
				.Include(p => p.Supplier)
				.ToList<Product>();
		}
	}
}
