using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CoreBlogProject.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CoreBlogProject
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();


            try
            {
                var scope = host.Services.CreateScope();

                var dbContex = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var userMngr = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var roleMngr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                dbContex.Database.EnsureCreated();

                var adminRole = new IdentityRole("Admin");
                if (!dbContex.Roles.Any())
                {
                    roleMngr.CreateAsync(adminRole).GetAwaiter().GetResult();
                    //Create a role
                }

                if (!dbContex.Users.Any(u => u.UserName == "MyBlog@burakturkozen.com"))
                {
                    //Create a Admin Role
                    var adminUser = new IdentityUser
                    {
                        UserName = "admin",
                        Email = "MyBlog@burakturkozen.com",

                    };

                    var result = userMngr.CreateAsync(adminUser, "Abc_123").GetAwaiter().GetResult();

                    //Add role to user
                    userMngr.AddToRoleAsync(adminUser, adminRole.Name).GetAwaiter().GetResult();
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }


            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
