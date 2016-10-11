using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace EventsAPI.Controllers
{
    public class Helper
    {
        //public class Wrapper
        //{
        //    [JsonProperty("JsonValues")]
        //    public ValueSet ValueSet { get; set; }
        //}

        //public class ValueSet
        //{
        //    [JsonProperty("id")]
        //    public string Id { get; set; }
        //    [JsonProperty("values")]
        //    public Dictionary<string, Value> Values { get; set; }
        //}

        //public class Value
        //{
        //    [JsonProperty("id")]
        //    public string Id { get; set; }
        //    [JsonProperty("diaplayName")]
        //    public string DisplayName { get; set; }
        //}

        public static string AsJsonList<T>(List<T> tt)
        {
            return new JavaScriptSerializer().Serialize(tt);
        }

        public static string AsJson<T>(T t)
        {
            return new JavaScriptSerializer().Serialize(t);
        }

        public static List<T> AsObjectList<T>(string tt)
        {
            return new JavaScriptSerializer().Deserialize<List<T>>(tt);
        }
        
        public static T AsObject<T>(string t)
        {
            return new JavaScriptSerializer().Deserialize<T>(t);
        }
    }
}