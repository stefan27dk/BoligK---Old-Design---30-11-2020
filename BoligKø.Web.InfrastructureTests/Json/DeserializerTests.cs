using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoligKø.Web.Infrastructure.Json;
using System;
using System.Collections.Generic;
using System.Text;
using BoligKø.Web.Infrastructure.Dto;
using System.Text.Json;

namespace BoligKø.Web.Infrastructure.Json.Tests
{
    [TestClass()]
    public class DeserializerTests
    {
        [TestMethod()]
        public void DeserializeTestAnsøger()
        {
            Json.Deserializer<AnsøgerDto> deserializer = new Deserializer<AnsøgerDto>();
            bool deserializedSuccessfully = true;
            try
            {
                AnsøgerDto dto = deserializer.Deserialize("{\"email\":\"stef9633@edu.ucl.dk\",\"fornavn\":\"Stefan\",\"efternavn\":\"Popov\",\"userId\":\"ac3718e8-4dce-4b73-b723-9b9f4831b29a\",\"ans\u00F8gninger\":[],\"id\":\"6996d1bc-1538-4c89-9cef-9228dc2ac997\"}");
            }
            catch(JsonException ex)
            {
                deserializedSuccessfully = false;
            }

            Assert.IsTrue(deserializedSuccessfully);
        }

        [TestMethod()]
        public void DeserializeTestAnsøgerCollection()
        {
            Json.Deserializer<ICollection<AnsøgerDto>> deserializer = new Deserializer<ICollection<AnsøgerDto>>();
            bool deserializedSuccessfully = true;

            try
            {
                ICollection<AnsøgerDto> dtos = deserializer.Deserialize("[{\"email\":\"stef9633@edu.ucl.dk\",\"fornavn\":\"Stefan\",\"efternavn\":\"Popov\",\"userId\":\"ac3718e8-4dce-4b73-b723-9b9f4831b29a\",\"ans\u00F8gninger\":[],\"id\":\"6996d1bc-1538-4c89-9cef-9228dc2ac997\"},{\"email\":\"nich1411@edu.ucl.dk\",\"fornavn\":\"Nichlas\",\"efternavn\":\"Christensen\",\"userId\":\"49cccdb5-6fdf-4807-99ce-3fdbfcf59ee5\",\"ans\u00F8gninger\":[],\"id\":\"8498afe3-6333-4cc0-a050-32c6ae49016b\"},{\"email\":\"karl0844@edu.ucl.dk\",\"fornavn\":\"Karl\",\"efternavn\":\"Mogensen\",\"userId\":\"acded264-fc9a-499a-8972-4e67c63e06b9\",\"ans\u00F8gninger\":[],\"id\":\"b0296a54-cd04-41fc-a887-6c6d0ec4ec5b\"},{\"email\":\"mart95s9@edu.ucl.dk\",\"fornavn\":\"Martin\",\"efternavn\":\"S\u00F8rensen\",\"userId\":\"b837023f-78e9-444c-8477-e0e8baad17e3\",\"ans\u00F8gninger\":[],\"id\":\"c44fe721-3807-431b-94a5-d9f68dda46db\"}]");
            }
            catch(JsonException ex)
            {
                deserializedSuccessfully = false;
            }

            Assert.IsTrue(deserializedSuccessfully);
        }
    }
}