using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyApp;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
	public MainWindow() {
		InitializeComponent();
	}

	private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
		//int col = (int)GridCustomers.GetValue(Grid.ColumnProperty);
		//int newCol = col == 0 ? 2 : 0;
		//GridCustomers.SetValue(Grid.ColumnProperty, newCol);

		int col = Grid.GetColumn(GridCustomers);
		int newCol = col == 0 ? 2 : 0;
		Grid.SetColumn(GridCustomers, newCol);
	}
}