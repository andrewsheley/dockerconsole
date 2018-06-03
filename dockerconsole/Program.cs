using dockerconsole.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;

namespace dockerconsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Settings 
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();

            // Set up DI
            var serviceProvider = new ServiceCollection()
               .AddDbContext<testdbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
               .BuildServiceProvider();


            Processing processing = new Processing(serviceProvider.GetService<testdbContext>());
            await processing.DoSomethingAsync();








            //var cob = new DbContextOptionsBuilder<testdbContext>();
            //cob.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            //using (var db = new testdbContext(cob.Options))
            //{
            //    for (int i = 0; i < 100; i++)
            //    {
            //        //Console.WriteLine($"Iteration: {i}  at time: {DateTime.Now}");
            //        db.Add(new Log() {
            //            LogData = $"Iteration: {i}  at time: {DateTime.Now}"
            //        });
            //    }

            //     db.SaveChanges();
            //}



            Console.WriteLine("Finished Job at: " + DateTime.Now);

            //for (int i = 0; i < 100; i++)
            //{
            //    Console.WriteLine($"Iteration: {i}  at time: {DateTime.Now}");
            //}
        }
    }
}



// 1. Install NuGet packages in PM console X 3
// Install-Package Microsoft.EntityFrameworkCore.SqlServer
// Install-Package Microsoft.EntityFrameworkCore.Tools
// Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design

// 2. Scaffold in PM console
//Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Tables Blog,Post

// 3. Delete Onconfiguring in Context
//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//{
//	#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//	optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;");
//}

// 4. Add Constructor
//public BloggingContext(DbContextOptions<BloggingContext> options) : base(options) { }

// 5. Add context to startup.cs
//services.AddDbContext<InterviewDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

// URL:  https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/existing-db

