using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoligKø.ApplicationService;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using AutoMapper;
using BoligKø.ApplicationService.Mapper;
using System.Linq.Expressions;
using BoligKø.ApplicationService.Dto;
using BoligKø.Domain.Model;

namespace BoligKø.ApplicationService.Tests
{
    [TestClass()]
    public class AnsøgerApplicationServiceTests
    {
        private IMapper _mapper;
        public AnsøgerApplicationServiceTests()
        {
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new AutomapperProfile()));
            _mapper = mapperConfig.CreateMapper();

        }

        [TestMethod()]
        public void OpretAsyncTest()
        {
            var mock = new Mock<IAnsøgerCommand>();
            var service = new AnsøgerApplicationService(_mapper, mock.Object);
            Expression<Action<IAnsøgerCommand>> call = x => x.CreateAsync(It.IsAny<Ansøger>());
            mock.Setup(call).Verifiable("Method not called");
            var ansøgninger = new List<AnsøgningDto>();
            var kriterier = new List<IKriterieDto>();
            kriterier.Add(new KvmKriterieDto(50, 60));
            kriterier.Add(new LejemålsTypeKriterieDto(LejemålsType.Hus));
            kriterier.Add(new PrisKriterieDto(1000, 5000));
            kriterier.Add(new TilladtDyrKriterieDto(true, false));
            kriterier.Add(new VærelsesKriterieDto(3, 4));
            //multi
            kriterier.Add(new LokationKriterieDto(7100));

            ansøgninger.Add(new AnsøgningDto { Aktiv = true, Id = Guid.NewGuid().ToString(), ØvrigKommentar = "Bob", Kriterier = kriterier });
            var objToCreate = new AnsøgerDto
            {
                Fornavn = "Nichlas",
                Efternavn = "Christensen",
                Email = "nichlaschristensen@live.dk",
                Id = Guid.NewGuid().ToString(),
                UserId = Guid.NewGuid().ToString(),
                Ansøgninger = ansøgninger
            };
            service.OpretAsync(objToCreate).GetAwaiter().GetResult();
            mock.Verify(call);

        }
        [TestMethod()]
        [ExpectedException(typeof(StateException))]
        public void OpretAsyncMultipleOfSameKriterieTest()
        {
            var mock = new Mock<IAnsøgerCommand>();
            var service = new AnsøgerApplicationService(_mapper, mock.Object);
            Expression<Action<IAnsøgerCommand>> call = x => x.CreateAsync(It.IsAny<Ansøger>());
            mock.Setup(call).Verifiable("Method not called");
            var ansøgninger = new List<AnsøgningDto>();
            var kriterier = new List<IKriterieDto>();
            kriterier.Add(new KvmKriterieDto(50, 60));
            kriterier.Add(new KvmKriterieDto(50, 60));

            ansøgninger.Add(new AnsøgningDto { Aktiv = true, Id = Guid.NewGuid().ToString(), ØvrigKommentar = "Bob", Kriterier = kriterier });
            var objToCreate = new AnsøgerDto
            {
                Fornavn = "Nichlas",
                Efternavn = "Christensen",
                Email = "nichlaschristensen@live.dk",
                Id = Guid.NewGuid().ToString(),
                UserId = Guid.NewGuid().ToString(),
                Ansøgninger = ansøgninger
            };
            
                service.OpretAsync(objToCreate).GetAwaiter().GetResult();
            mock.Verify(call);

        }
        [TestMethod()]
        public void OpretAsyncMultipleAllowedKriterierTest()
        {
            var mock = new Mock<IAnsøgerCommand>();
            var service = new AnsøgerApplicationService(_mapper, mock.Object);
            Expression<Action<IAnsøgerCommand>> call = x => x.CreateAsync(It.IsAny<Ansøger>());
            mock.Setup(call).Verifiable("Method not called");
            var ansøgninger = new List<AnsøgningDto>();
            var kriterier = new List<IKriterieDto>();
            kriterier.Add(new LokationKriterieDto (7100));
            kriterier.Add(new LokationKriterieDto(8000));

            ansøgninger.Add(new AnsøgningDto { Ansøger = new AnsøgerDto(), Aktiv = true, Id = Guid.NewGuid().ToString(), ØvrigKommentar = "Bob", Kriterier = kriterier });
            var objToCreate = new AnsøgerDto
            {
                Fornavn = "Nichlas",
                Efternavn = "Christensen",
                Email = "nichlaschristensen@live.dk",
                Id = Guid.NewGuid().ToString(),
                UserId = Guid.NewGuid().ToString(),
                Ansøgninger = ansøgninger
            };

            service.OpretAsync(objToCreate).GetAwaiter().GetResult();
            mock.Verify(call);

        }
        [TestMethod()]
        public void EditAsyncTest()
        {
            var mock = new Mock<IAnsøgerCommand>();
            var service = new AnsøgerApplicationService(_mapper, mock.Object);
            Expression<Action<IAnsøgerCommand>> call = x => x.UpdateAsync(It.IsAny<Ansøger>());
            mock.Setup(call).Verifiable("Method not called");
            var id = Guid.NewGuid().ToString();
            var objToEdit = new AnsøgerDto { Efternavn = "bob", Fornavn = "bob", Email = "bob@bob.dk", Id = id, UserId = id };
            var expetectedObject = new AnsøgerDto { Efternavn = "bob123", Fornavn = "bob", Email = "bob@bob.dk" };
            //Mock et return fra getbyid
            service.EditAsync(objToEdit).GetAwaiter().GetResult();
            Assert.AreEqual(objToEdit, expetectedObject);
        }

        [TestMethod()]
        public void SletAsyncTest()
        {
            Assert.Fail();
        }
    }
}