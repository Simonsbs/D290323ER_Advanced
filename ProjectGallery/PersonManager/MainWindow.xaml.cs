using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using PersonManager.Models;

namespace PersonManager;

public partial class MainWindow : Window {
	private const string filePath = "people.json";

	public MainWindow() {
		InitializeComponent();

		PeopleDataGrid.ItemsSource = People;

		LoadData();
	}

	private List<Person> People {
		get;
		set;
	} = new List<Person>();

	public void HandleSelectionChanged(object sender, SelectionChangedEventArgs e) {
		if (PeopleDataGrid.SelectedItem is Person selectedPerson) {
			TB_ID.Text = selectedPerson.ID.ToString();
			TB_Name.Text = selectedPerson.Name;
			TB_Age.Text = selectedPerson.Age.ToString();
		}
	}

	public void HandleUpdateClick(object sender, RoutedEventArgs e) {
		if (PeopleDataGrid.SelectedItem is Person selectedPerson && 
		    int.TryParse(TB_ID.Text, out int id) && 
		    int.TryParse(TB_Age.Text, out int age) &&
		    TB_Name.Text.Length > 0) {

			selectedPerson.ID = id;
			selectedPerson.Name = TB_Name.Text;
			selectedPerson.Age = age;

			PeopleDataGrid.Items.Refresh();

			SaveData();
		}
	}

	private void SaveData() {
		try {
			string rawData = JsonSerializer.Serialize(People);
			File.WriteAllText(filePath, rawData);
		} catch (Exception ex) {
			MessageBox.Show($"Failed to save data: {ex.Message}");
		}
	}

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
