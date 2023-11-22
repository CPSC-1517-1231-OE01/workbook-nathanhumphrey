using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.BLL;
using WestWindSystem.DAL;

namespace WestWindSystem
{
    public static class BackEndExtensions
    {
        public static void WWBackEndDependencies(this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<WestWindContext>(options);

            services.AddTransient<CustomerServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetService<WestWindContext>();
                return new CustomerServices(context!);
            });

			services.AddTransient<CategoryServices>((serviceProvider) =>
			{
				var context = serviceProvider.GetService<WestWindContext>();
				return new CategoryServices(context!);
			});

			services.AddTransient<ProductServices>((serviceProvider) =>
			{
				var context = serviceProvider.GetService<WestWindContext>();
				return new ProductServices(context!);
			});

			services.AddTransient<SupplierServices>((serviceProvider) =>
			{
				var context = serviceProvider.GetService<WestWindContext>();
				return new SupplierServices(context!);
			});
		}
    }
}
