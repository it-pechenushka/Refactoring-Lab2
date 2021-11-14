using System.Text.Json.Serialization;

namespace Client.Helpers
{
    public class TrackInfo
    {
        [JsonPropertyName("author")]
        public string Author { set; get; }
        
        [JsonPropertyName("composition")]
        public string Composition { set; get; }

        public override string ToString()
        {
            return $"{Author} - {Composition}";
        }
    }
}