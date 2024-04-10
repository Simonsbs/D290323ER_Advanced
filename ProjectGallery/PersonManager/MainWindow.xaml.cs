using System.IO;
using System.Text.Json;
using System.Windows;
using PersonManager.Models;

namespace PersonManager;

public partial class MainWindow : Window {
	private const string filePath = "people.json";

	public MainWindow() {
		InitializeComponent();

		LoadData();
	}

	private List<Person> People {
		get;
		set;
	} = new List<Person>();

	private void LoadData() {
		if (!File.Exists(filePath)) {
			return;
		}
		try {
			string rawData = File.ReadAllText(filePath);
			List<Person>? result = JsonSerializer.Deserialize<List<Person>>(rawData);
			if (result == null) {
				return;
			}

			foreach (Person person in result) {
				People.Add(person);
			}
		} catch (Exception ex) {
			MessageBox.Show($"Failed to load data: {ex.Message}");
		}

	}
}
