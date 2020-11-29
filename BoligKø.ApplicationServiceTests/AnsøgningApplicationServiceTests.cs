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
using BoligKø.ApplicationService.Dto;
using System.Threading.Tasks;

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
            var service = new AnsøgningApplicationService(_mapper, moq.Object);
            var kriterier = new List<IKriterieDto>();
            kriterier.Add(new KvmKriterieDto(50, 60));
            kriterier.Add(new PrisKriterieDto(1000, 5000));
            kriterier.Add(new TilladtDyrKriterieDto(true, false));
            kriterier.Add(new VærelsesKriterieDto(3, 4));
            //multi
            kriterier.Add(new LokationKriterieDto(7100));
            kriterier.Add(new LejemålsTypeKriterieDto(LejemålsType.Hus));

            var ansøgning = new AnsøgningDto() {Ansøger = new AnsøgerDto(), Aktiv = true, Id = Guid.NewGuid().ToString(), ØvrigKommentar = "Bob", Kriterier = kriterier };
            
            service.OpretAsync(ansøgning).GetAwaiter().GetResult();
            moq.Verify(call);
        }

        [TestMethod()]
        public void EditAsyncTest()
        {
            var moq = new Mock<IAnsøgningCommand>();
            Expression<Action<IAnsøgningCommand>> call = x => x.UpdateAsync(It.IsAny<Ansøgning>());
            
            moq.Setup(call).Verifiable("Method not called");
            var ansøgningToReturn = GenerateMockAnsøgning();
            ansøgningToReturn.SetAnsøger(GenerateMockAnsøger());
            moq.Setup(o => o.GetByIdIncludingAsync(It.IsAny<string>(), o => o.Ansøger)).Returns(Task.FromResult(ansøgningToReturn));
            var service = new AnsøgningApplicationService(_mapper, moq.Object);
            var kriterier = new List<IKriterieDto>();
            kriterier.Add(new KvmKriterieDto(50, 60));
            kriterier.Add(new LejemålsTypeKriterieDto(LejemålsType.Hus));
            kriterier.Add(new PrisKriterieDto(1000, 5000));
            kriterier.Add(new TilladtDyrKriterieDto(true, false));
            kriterier.Add(new VærelsesKriterieDto(3, 4));
            //multi
            kriterier.Add(new LokationKriterieDto(7100));
            var ansøgning = new AnsøgningDto() { Ansøger = _mapper.Map<AnsøgerDto>(ansøgningToReturn.Ansøger), Aktiv = true, Id = Guid.NewGuid().ToString(), ØvrigKommentar = "Bob", Kriterier = kriterier };
            service.EditAsync(ansøgning).GetAwaiter().GetResult();
            moq.Verify(call, Times.AtLeastOnce);
        }
        private Ansøgning GenerateMockAnsøgning()
        {
            var kriterier = new List<Kriterie>();
            kriterier.Add(new KvmKriterie(50, 60));
            kriterier.Add(new PrisKriterie(1000, 5000));
            kriterier.Add(new TilladtDyrKriterie(true, false));
            kriterier.Add(new VærelsesKriterie(3, 4));
            //multi
            kriterier.Add(new LokationKriterie(7100));
            kriterier.Add(new LejemålsTypeKriterie(LejemålsType.Hus));

            var ansøgning = new Ansøgning();
            ansøgning.SetAktiv(true);
            ansøgning.SetId(Guid.NewGuid().ToString());
            ansøgning.SetØvrigKommentar("bob");
            ansøgning.SetKriterier(kriterier);

            return ansøgning;

        }
        private Ansøger GenerateMockAnsøger()
        {
            var ansøger = new Ansøger();

            ansøger.SetFornavn("Nichlas");
            ansøger.SetEfternavn("Christensen");
            ansøger.SetEmail("nichlaschristensen@live.dk");
            ansøger.SetId(Guid.NewGuid().ToString());
            ansøger.SetUserId(Guid.NewGuid().ToString()); 
            return ansøger;
        }
        [TestMethod()]
        public void SletAsyncTest()
        {
            Assert.Fail();
        }
    }
}