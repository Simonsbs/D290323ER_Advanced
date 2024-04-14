using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using PersonManager.Models;

namespace PersonManager;

public partial class MainWindow : Window {
	private const string filePath = "people.json";
	private readonly ICollectionView peopleView;

	public MainWindow() {
		InitializeComponent();

		peopleView = CollectionViewSource.GetDefaultView(People);

		PeopleDataGrid.ItemsSource = peopleView;
		
		LoadData();
	}

	private ObservableCollection<Person> People {
		get;
		set;
	} = new ObservableCollection<Person>();

	public void HandleSelectionChanged(object sender, SelectionChangedEventArgs e) {
		if (PeopleDataGrid.SelectedItem is Person selectedPerson) {
			TB_ID.Text = selectedPerson.ID.ToString();
			TB_Name.Text = selectedPerson.Name;
			TB_Age.Text = selectedPerson.Age.ToString();
		}
	}

	private void HandleAddClick(object sender, RoutedEventArgs e) {
		if (int.TryParse(TB_ID.Text, out int id) &&
		    int.TryParse(TB_Age.Text, out int age) &&
		    TB_Name.Text.Length > 0) {

			Person newPerson = new Person() {
				ID = GenerateID(),
				Name = TB_Name.Text,
				Age = age
			};

			People.Add(newPerson);

			SaveData();
			ClearForm();
		}
	}

	private int GenerateID() {
		return People.Count == 0 ? 1 : People.Max(p => p.ID) + 1;
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
			ClearForm();
		}
	}
	
	private void HandleDeleteClick(object sender, RoutedEventArgs e) {
		MessageBoxResult result = MessageBox.Show("Are you sure?", "delete", MessageBoxButton.YesNo);
		if (result == MessageBoxResult.No) {
			return;
		}

		Button btn = sender as Button;
		if (btn == null) {
			return;
		}

		if (btn.DataContext is Person personToDelete) {
			People.Remove(personToDelete);
			SaveData();
			ClearForm();
		}
	}
	
	private void HandleFilterKeyUp(object sender, KeyEventArgs e) {
		string filterString = TB_Filter.Text.ToLower();

		peopleView.Filter = o => {
			if (o is Person personToFilter) {
				return personToFilter.Name.ToLower().Contains(filterString);
			}
			return false;
		};
	}

	private void ClearForm() {
		TB_ID.Clear();
		TB_Name.Clear();
		TB_Age.Clear();
		PeopleDataGrid.SelectedItem = null;
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
