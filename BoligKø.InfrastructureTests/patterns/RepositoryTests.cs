using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoligKø.Infrastructure.patterns;
using System;
using System.Collections.Generic;
using System.Text;
using BoligKø.Infrastructure.context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BoligKø.Domain.Model;
using System.Threading.Tasks;

namespace BoligKø.Infrastructure.patterns.Tests
{
    [TestClass()]
    public class RepositoryTests
    {
        [TestMethod()]
        public async Task GetAllAsyncTest()
        {
            var testContext = GetTestContext();
            testContext.Add(new Ansoeger { Id = "fisk" });
            testContext.Add(new Ansoeger { Id = "danse" });


            var ansøgerRepo = new Repository<Ansoeger>(testContext);
            var all = await ansøgerRepo.GetAllAsync();

            Assert.IsTrue(all.Count == 2);
        }

        private BoligKøContext GetTestContext()
        {
            //var serviceProvider = new ServiceCollection()
            //    .AddEntityFrameworkSqlServer()
            //    .BuildServiceProvider();

            //var builder = new DbContextOptionsBuilder<BoligKøContext>();
            //builder.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database=BoligKø_{Guid.NewGuid()};Trusted_Connection=True;MultipleActiveResultSets=true")
            //    .UseInternalServiceProvider(serviceProvider);

            var options = new DbContextOptionsBuilder<BoligKøContext>()
            .UseInMemoryDatabase("BoligKø_test")
                .Options;

            var context = new BoligKøContext(options);
            //context.Database.Migrate();
            return context;
        }
    }
}