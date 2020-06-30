using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ToDoAPI.Models
{
    public class ResponseObjects
    {
        [JsonProperty("userId")]
        public string userId { get; set; }
        [JsonProperty("ID")]
        public string id { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("completed")]
        public string completed { get; set; }


    }
}
