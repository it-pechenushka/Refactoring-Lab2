using System.Text.Json.Serialization;

namespace Server.Dto
{
    public class TrackDto
    {
        [JsonPropertyName("author")]
        public string Author { set; get; }
        
        [JsonPropertyName("composition")]
        public string Composition { set; get; }

        public TrackDto(string author, string composition)
        {
            Author = author;
            Composition = composition;
        }

        public override string ToString()
        {
            return $"{Author} - {Composition}";
        }
    }
}