using System.Diagnostics;
using System.Windows;

namespace Main;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
	public MainWindow() {
		InitializeComponent();
	}

	private void OpenApp1_Click(object sender, RoutedEventArgs e) {
		StartApp("App1.exe");
	}

	private void OpenApp2_Click(object sender, RoutedEventArgs e) {
		StartApp("App2.exe");
	}

	private void StartApp(string appPath) {
		Process appProcess = new Process {
			StartInfo = new ProcessStartInfo {
				FileName = appPath,
				UseShellExecute = true
			}
		};
		appProcess.Start();
		appProcess.WaitForExit();
	}
}