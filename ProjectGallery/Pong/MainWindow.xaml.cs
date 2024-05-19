using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Pong;

public partial class MainWindow : Window {
	private double paddleSpeed = 15;
	private Rectangle paddle1;
	private Rectangle paddle2;

	public MainWindow() {
		InitializeComponent();

		Loaded += new RoutedEventHandler(WindowLoaded);
	}

	private void WindowLoaded(object sender, RoutedEventArgs e) {
		paddle1 = CreatePlayerRectangle();
		paddle2 = CreatePlayerRectangle();

		GameCanvas.Children.Add(paddle1);
		GameCanvas.Children.Add(paddle2);

		Canvas.SetLeft(paddle1, 50);
		Canvas.SetTop(paddle1, (GameCanvas.ActualHeight / 2) - (paddle1.ActualHeight));

		Canvas.SetLeft(paddle2, GameCanvas.ActualWidth - 50);
		Canvas.SetTop(paddle2, (GameCanvas.ActualHeight / 2) - (paddle2.ActualHeight));

		KeyDown += new KeyEventHandler(HandleKeyDown);
	}

	private void HandleKeyDown(object sender, KeyEventArgs e) {
		double p1Top = Canvas.GetTop(paddle1);
		double p2Top = Canvas.GetTop(paddle2);

		if (e.Key == Key.W && p1Top > 0) {
			Canvas.SetTop(paddle1, p1Top - paddleSpeed);
		}
		if (e.Key == Key.S && p1Top < (GameCanvas.ActualHeight - paddle1.ActualHeight)) {
			Canvas.SetTop(paddle1, p1Top + paddleSpeed);
		}
		if (e.Key == Key.Up && p2Top > 0) {
			Canvas.SetTop(paddle2, p2Top - paddleSpeed);
		}
		if (e.Key == Key.Down && p2Top < (GameCanvas.ActualHeight - paddle2.ActualHeight)) {
			Canvas.SetTop(paddle2, p2Top + paddleSpeed);
		}
	}

	private Rectangle CreatePlayerRectangle() {
		return new Rectangle() {
			Width = 10,
			Height = 100,
			Fill = Brushes.White
		};
	}
}