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
using Tic_Tac_Toe.Enums;

namespace Tic_Tac_Toe;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
	public MainWindow() {
		InitializeComponent();
	}

	private void NewGame_Click(object sender, RoutedEventArgs e) {
		GameType gameType;

		if (sender == Btn_PvP) {
			gameType = GameType.PvP;
		} else if (sender == Btn_PvC) {
			gameType = GameType.PvC;
		} else if (sender == Btn_CvC) {
			gameType = GameType.CvC;
		} else {
			return;
		}

		MyBoard.StartNewGame(gameType);
	}
}