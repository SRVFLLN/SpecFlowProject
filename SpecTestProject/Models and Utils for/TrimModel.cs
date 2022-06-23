using Newtonsoft.Json;

namespace SpecTestProject.Models_and_Utils_for
{ 
    [JsonObject("array")]
    public class TrimModel
    {
        [JsonProperty("make")]
        public string MakeName { get; set; }
        [JsonProperty("model")]
        public string ModelName { get; set; }
        [JsonProperty("year")]
        public string Year { get; set; }
        [JsonProperty("trim")]
        public string TrimName { get; set; }
        [JsonProperty("doors")]
        public string Doors { get; set; }
        [JsonProperty("seats")]
        public string Seats { get; set; }
        [JsonProperty("price")]
        public string Price { get; set; }
    }
}
