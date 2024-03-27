using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EventExample;
/// <summary>
/// Interaction logic for DogDisplay.xaml
/// </summary>
public partial class DogDisplay : Window {
	public DogDisplay() {
		InitializeComponent();
	}

	public DogDisplay(Dog dog) : this() {
		TextBoxDogName.Text = dog.Name;
		TextBoxDogBreed.Text = dog.Breed;
		TextBoxDogIsOwned.Text = dog.IsOwned ? "Yes" : "No";
		TextBoxDogSecret.Text = dog.SECRET;
	}
}
