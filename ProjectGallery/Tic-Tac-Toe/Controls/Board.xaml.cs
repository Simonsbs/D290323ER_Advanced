using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Tic_Tac_Toe.Enums;

namespace Tic_Tac_Toe.Controls;
/// <summary>
/// Interaction logic for Board.xaml
/// </summary>
public partial class Board : UserControl, INotifyPropertyChanged {
	public event PropertyChangedEventHandler? PropertyChanged;

	public EventHandler GameEnded;

	private const string PlayerOneContent = "X";
	private const string PlayerTwoContent = "O";

	private readonly Button[,] _buttons = new Button[3, 3];

	private readonly Random _rnd = new Random();

	private bool _isPlayerOneTurn = true;
	private bool _gameIsActive = true;
	private GameType _gameType = GameType.PvP;

	public Board() {
		InitializeComponent();
		InitializeGameGrid();

		DataContext = this;
	}

	private void OnPropertyChanged(string name) {
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	}

	public GameType CurrentGameType {
		get {
			return _gameType;
		}
		set {
			_gameType = value;
			OnPropertyChanged(nameof(CurrentGameType));
		}
	}

	private void InitializeGameGrid() {
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				Button btn = new Button() {
					FontSize = 40,
					FontWeight = FontWeights.Bold,
					Margin = new Thickness(5)
				};

				btn.Click += Button_Click;

				Grid.SetRow(btn, i);
				Grid.SetColumn(btn, j);

				_buttons[i, j] = btn;

				GameGrid.Children.Add(btn);
			}
		}
	}

	private void Button_Click(object sender, RoutedEventArgs e) {
		if (!_gameIsActive || (CurrentGameType == GameType.PvC && !_isPlayerOneTurn) || CurrentGameType == GameType.CvC) {
			return;
		}

		Button btn = sender as Button;
		if (btn == null) {
			return;
		}

		if (btn.Content == null) {
			btn.Content = _isPlayerOneTurn ? PlayerOneContent : PlayerTwoContent;

			if (ProcessEndGame()) {
				return;
			}

			_isPlayerOneTurn = !_isPlayerOneTurn;


			// After human - let the computer take a turn
			if (CurrentGameType == GameType.PvC && !_isPlayerOneTurn) {
				ComputerMove();
			}
		}
	}

	private void ComputerMove() {
		DispatcherTimer timer = new DispatcherTimer() {
			Interval = TimeSpan.FromSeconds(_rnd.Next(10) / 10.0)
		};
		timer.Tick += (sender, e) => {
			timer.Stop();

			// randomly find an empty button
			Button btn;
			do {
				int row = _rnd.Next(3);
				int col = _rnd.Next(3);
				btn = _buttons[row, col];
			} while (btn.Content != null);


			btn.Content = _isPlayerOneTurn ? PlayerOneContent : PlayerTwoContent;
			if (ProcessEndGame()) {
				return;
			}

			_isPlayerOneTurn = !_isPlayerOneTurn;

			if (CurrentGameType == GameType.CvC && !IsBoardFull()) {
				ComputerMove();
			}
		};
		timer.Start();
	}

	private bool ProcessEndGame() {
		if (CheckForWinner()) {
			GameResult result = _isPlayerOneTurn ? GameResult.PlayerOneWins : GameResult.PlayerTwoWins;

			MessageBox.Show(result.ToString());

			_gameIsActive = false;
			return true;
		}

		if (IsBoardFull()) {
			GameResult result = GameResult.Draw;

			MessageBox.Show(result.ToString());

			_gameIsActive = false;
			return true;
		}

		return false;
	}

	public void StartNewGame(GameType gameType) {
		CurrentGameType = gameType;

		_isPlayerOneTurn = true;
		_gameIsActive = true;

		foreach (Button btn in _buttons) {
			btn.Content = null;
		}

		if (CurrentGameType == GameType.CvC) {
			ComputerMove();
		}
	}

	private bool IsBoardFull() {
		foreach (Button button in _buttons) {
			if (button.Content == null) {
				return false;
			}
		}

		return true;
	}

	private bool CheckForWinner() {
		for (int i = 0; i < 3; i++) {
			// Check Row
			if (AreButtonsEqual(_buttons[i, 0], _buttons[i, 1], _buttons[i, 2])) {
				return true;
			}

			// Check Column
			if (AreButtonsEqual(_buttons[0, i], _buttons[1, i], _buttons[2, i])) {
				return true;
			}
		}

		//Check Diagonals
		if (AreButtonsEqual(_buttons[0, 0], _buttons[1, 1], _buttons[2, 2])) {
			return true;
		}
		if (AreButtonsEqual(_buttons[0, 2], _buttons[1, 1], _buttons[2, 0])) {
			return true;
		}

		return false;
	}

	private bool AreButtonsEqual(Button b1, Button b2, Button b3) =>
		 b1.Content != null && b1.Content == b2.Content && b2.Content == b3.Content;

}
