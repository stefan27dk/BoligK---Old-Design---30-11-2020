using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoligKø.ApplicationService;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BoligKø.ApplicationService.Mapper;
using Moq;
using System.Linq.Expressions;
using BoligKø.Domain.Model;
using BoligKø.Domain.DomainService;
using BoligKø.ApplicationService.Dto;

namespace BoligKø.ApplicationService.Tests
{
    [TestClass()]
    public class AnsøgningApplicationServiceTests
    {
        private readonly IMapper _mapper;
        public AnsøgningApplicationServiceTests()
        {
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new AutomapperProfile()));
            _mapper = mapperConfig.CreateMapper();
        }
        [TestMethod()]
        public void OpretAsyncTest()
        {
            var moq = new Mock<IAnsøgningCommand>();
            Expression<Action<IAnsøgningCommand>> call = x => x.CreateAsync(It.IsAny<Ansøgning>());
            moq.Setup(call).Verifiable("Method not called");
            var service = new AnsøgningApplicationService(_mapper, moq.Object, new AnsøgerAnsøgningDomainService());
            var kriterier = new List<IKriterieDto>();
            kriterier.Add(new KvmKriterieDto(50, 60));
            kriterier.Add(new KvmKriterieDto(50, 60));
            kriterier.Add(new LejemålsTypeKriterieDto(LejemålsType.Hus));
            kriterier.Add(new PrisKriterieDto(1000, 5000));
            kriterier.Add(new TilladtDyrKriterieDto(true, false));
            kriterier.Add(new VærelsesKriterieDto(3, 4));
            //multi
            kriterier.Add(new LokationKriterieDto(7100));
            var ansøgning = new AnsøgningDto() {Ansøger = new AnsøgerDto(), Aktiv = true, Id = Guid.NewGuid().ToString(), ØvrigKommentar = "Bob", Kriterier = kriterier };
            service.OpretAsync(ansøgning).GetAwaiter().GetResult();
            moq.Verify(call);
        }

        [TestMethod()]
        public void EditAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SletAsyncTest()
        {
            Assert.Fail();
        }
    }
}