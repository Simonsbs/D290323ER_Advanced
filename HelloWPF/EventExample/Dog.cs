using System.IO;
using System.Text.Json;

namespace EventExample;

public class Dog {
	public string Name { get; set; }
	public string Breed { get; set; }
	public bool IsOwned { get; set; }

	public string SECRET { get; set; } = "IM A SECRET!";

	public static List<Dog> GetListFromFile() {
		string rawdata = File.ReadAllText("dogs.json");

		List<Dog> resultingList = JsonSerializer.Deserialize<List<Dog>>(rawdata);

		return resultingList;
	}
}