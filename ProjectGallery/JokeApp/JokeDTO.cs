using System.Text.Json.Serialization;

namespace JokeApp;

public class JokeDTO {
	[JsonPropertyName("setup")]
	public string JokeSetup { get; set; }

	[JsonPropertyName("delivery")]
	public string JokeDelivery { get; set; }

	[JsonPropertyName("joke")]
	public string Joke { get; set; }

    [JsonPropertyName("error")]
	public bool APIError { get; set; }

	[JsonPropertyName("type")]
	public string Type { get; set; }
}