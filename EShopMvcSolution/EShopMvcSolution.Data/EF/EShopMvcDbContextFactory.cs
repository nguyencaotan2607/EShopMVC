using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EShopMvcSolution.Data.EF
{
    public class EShopMvcDbContextFactory : IDesignTimeDbContextFactory<EShopMvcDbContext>
    {
        EShopMvcDbContext IDesignTimeDbContextFactory<EShopMvcDbContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsetting.json")
                .Build();


            var connectionString = configuration.GetConnectionString("EShopMvcSolutionDb");

            var optionBuilder = new DbContextOptionsBuilder<EShopMvcDbContext>();
            optionBuilder.UseSqlServer(connectionString);

            return new EShopMvcDbContext(optionBuilder.Options);
        }
    }
}
