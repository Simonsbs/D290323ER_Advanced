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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tic_Tac_Toe.Enums;

namespace Tic_Tac_Toe.Controls;
/// <summary>
/// Interaction logic for Board.xaml
/// </summary>
public partial class Board : UserControl {
	public EventHandler GameEnded;
	
	private readonly Button[,] buttons = new Button[3,3];

	private bool isPlayerOneTurn = true;


	public Board() {
		InitializeComponent();
		InitializeGameGrid();
	}


	private void InitializeGameGrid() {
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				Button btn = new Button() {
					FontSize = 40,
					FontWeight = FontWeights.Bold,
					HorizontalAlignment = HorizontalAlignment.Center,
					VerticalAlignment = VerticalAlignment.Center,
					Margin = new Thickness(5),
					Content = "X"
				};

				btn.Click += Button_Click;

				Grid.SetRow(btn, i);
				Grid.SetColumn(btn, j);

				buttons[i, j] = btn;

				GameGrid.Children.Add(btn);
			}
		}
	}

	private void Button_Click(object sender, RoutedEventArgs e) {

	}

	public void StartNewGame(GameType gameType) {
	}
}
