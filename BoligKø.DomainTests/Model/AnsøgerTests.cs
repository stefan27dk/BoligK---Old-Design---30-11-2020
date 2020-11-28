using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoligKø.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Domain.Model.Tests
{
    [TestClass()]
    public class AnsøgerTests
    {
        [TestMethod()]
        public void SetId()
        {
            //skal være 36 length
            var ansøger = new Ansøger();
            var id = new Guid();
            var succes = false;
            try
            {
                ansøger.SetId(id.ToString());
                succes = true;
            }
            catch (Exception)
            {
                Assert.Fail();
            }
            Assert.IsTrue(succes);
        }
        [TestMethod()]
        public void SetEmail()
        {
            //Skal indeholde @ og .

            var ansøger = new Ansøger();
            var mail = "bob@bob.dk";
            var succes = false;
            try
            {
                ansøger.SetEmail(mail);
                succes = true;
            }
            catch (Exception)
            {
                Assert.Fail();
            }
            Assert.IsTrue(succes);
        }
        [TestMethod()]

        public void SetUserId()
        {
            //skal være 36 length

            var ansøger = new Ansøger();
            var id = new Guid();
            var succes = false;
            try
            {
                ansøger.SetUserId(id.ToString());
                succes = true;
            }
            catch (Exception)
            {
                Assert.Fail();
            }
            Assert.IsTrue(succes);
        }
        [TestMethod()]

        public void AddAnsøgning()
        {
            //Test at man ikke kan have 2 aktive ansøgninger
            var ansøger = new Ansøger();
            var ansøgning = new Ansøgning();
            ansøgning.SetAktiv(true);
            var ansøgning2 = new Ansøgning();
            ansøgning2.SetAktiv(true);
            var erSket = false;
            try
            {
                ansøger.AddAnsøgning(ansøgning);
                ansøger.AddAnsøgning(ansøgning2);
                erSket = true;
            }
            catch (Exception)
            {

                erSket = false;
            }
            Assert.IsFalse(erSket);
        }

        [TestMethod()]
        public void ValidateStateTest()
        {
            //Test at alle felter er udfyldt
            var ansøger = new Ansøger();
            ansøger.SetEfternavn("bob");
            ansøger.SetFornavn("bob");
            ansøger.SetUserId(Guid.NewGuid().ToString());
            ansøger.SetEmail("bob@bob.dk");
            ansøger.SetId(Guid.NewGuid().ToString());
            var succes = false;
            try
            {
                ansøger.ValidateState();
                succes = true;
            }
            catch (Exception)
            {
                succes = false;
                
            }
            Assert.IsTrue(succes);
        }
    }
}