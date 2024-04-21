using System.IO;
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
using Microsoft.Win32;

namespace RecursiveFolderTree;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
	public MainWindow() {
		InitializeComponent();
	}

	private void SelectFolderClick(object sender, RoutedEventArgs e) {
		OpenFolderDialog dlg = new OpenFolderDialog();
		if (dlg.ShowDialog() == false) {
			return;
		}

		SelectedRootTextBlock.Text = dlg.FolderName;

		ResultsTreeView.Items.Clear();
		TreeViewItem root = BuildDirectory(dlg.FolderName);
		ResultsTreeView.Items.Add(root);

		//TreeViewItem root = new TreeViewItem();
		//root.Header = "Im the root";
		//root.Items.Add(new TreeViewItem { 
		//	Header = "Im a child 1"
		//});
		//root.Items.Add(new TreeViewItem {
		//	Header = "Im a child 2"
		//});
		//ResultsTreeView.Items.Add(root);
	}

	private TreeViewItem BuildDirectory(string directoryPath) {
		return BuildDirectory(new DirectoryInfo(directoryPath));
	}

	private TreeViewItem BuildDirectory(DirectoryInfo info) {
		//DirectoryInfo info = new DirectoryInfo(folderName);
		TreeViewItem directoryItem = new TreeViewItem {
			Header = info.Name
		};

		try {
			foreach (DirectoryInfo subDir in info.GetDirectories()) {
				TreeViewItem childBranch = BuildDirectory(subDir);
				directoryItem.Items.Add(childBranch);
			}

			foreach (FileInfo file in info.GetFiles()) {
				directoryItem.Items.Add(new TreeViewItem {
					Header = file.Name
				});
			}
		} catch (Exception ex) {
			directoryItem.Items.Add(new TreeViewItem {
				Header = "Error: " + ex.Message
			});
		}

		return directoryItem;
	}
}