using System.ComponentModel;
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
using Tic_Tac_Toe.Controls;
using Tic_Tac_Toe.Enums;

namespace Tic_Tac_Toe;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, INotifyPropertyChanged {
	private int playerOneScore = 0;
	private int playerTwoScore = 0;

	public event PropertyChangedEventHandler? PropertyChanged;
	public MainWindow() {
		InitializeComponent();

		MyBoard.GameEnded += HandleGameEnded;
	}

	private void OnPropertyChanged(string name) {
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	}

	private void HandleGameEnded(object? sender, GameEndEventArgs e) {
		switch (e.GameResult) {
			case GameResult.PlayerOneWins:
				PlayerOneScore++;
				break;
			case GameResult.PlayerTwoWins:
				PlayerTwoScore++;
				break;
		}
	}

	public int PlayerOneScore {
		get => playerOneScore;
		set {
			playerOneScore = value;
			OnPropertyChanged(nameof(PlayerOneScore));
		}
	}

	public int PlayerTwoScore {
		get => playerTwoScore;
		set {
			playerTwoScore = value;
			OnPropertyChanged(nameof(PlayerTwoScore));
		}
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