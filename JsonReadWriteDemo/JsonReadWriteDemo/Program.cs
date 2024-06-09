using System.Text.Json;

namespace JsonReadWriteDemo;

internal class Program {
	static void Main(string[] args) {
		// Read from file
		string rawData = File.ReadAllText("People.json");
		var people = JsonSerializer.Deserialize<List<Person>>(rawData);

		// Write to file
		List<Person> newPeople = new() {
			new Person { Name = "Alice", Age = 25 },
			new Person { Name = "Bob", Age = 30 }
		};
		string json = JsonSerializer.Serialize(newPeople, new JsonSerializerOptions {
			WriteIndented = true 
		});
		File.WriteAllText("NewPeople.json", json);
	}
}

internal class Person {
	public string Name { get; set; }
	public int Age { get; set; }
}
