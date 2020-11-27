using System;
using System.Collections.Generic;
using System.Text;

namespace BoligKø.Web.Infrastructure.Json
{
    public class Deserializer<T>
    {
        public T Deserialize(string json)
        {
            return System.Text.Json.JsonSerializer.Deserialize<T>(json);
        }
    }
}
