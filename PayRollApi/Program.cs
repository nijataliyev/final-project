using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PayRollApi.DAL;
using PayRollApi.Models;

namespace PayRollApi
{
    public class Program
    {

        public static void Main(string[] args)
        {
            IWebHost webHost = CreateWebHostBuilder(args).Build();


            using (IServiceScope serviceScope = webHost.Services.CreateScope())
            {
                using (PayRollDbContext dbContext = serviceScope.ServiceProvider.GetRequiredService<PayRollDbContext>())
                {
                    using (UserManager<Worker> userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<Worker>>())
                    {
                        using (RoleManager<IdentityRole> roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>())
                        {
                            DefaultDbData.Seed(dbContext, userManager, roleManager);
                        }
                    }
                }
            }
            webHost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
