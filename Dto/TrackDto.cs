using System.Text.Json.Serialization;

namespace Dto
{
	public class TrackDto
	{
		[JsonPropertyName("author")] public string Author { set; get; }

		[JsonPropertyName("composition")] public string Composition { set; get; }
		[JsonPropertyName("createdBy")] public string CreatedBy { set; get; }

		public override string ToString()
		{
			return $"{Author} - {Composition}";
		}
	}
}
