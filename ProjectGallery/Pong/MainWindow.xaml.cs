using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Pong;

public partial class MainWindow : Window {
	private double paddleSpeed = 15;
	private Rectangle paddle1;
	private Rectangle paddle2;
	private Rectangle ball;
	private DispatcherTimer gameTimer;

	private double ballSpeedY = 5;
	private double ballSpeedX = 5;

	public MainWindow() {
		InitializeComponent();

		paddle1 = CreatePlayerRectangle();
		paddle2 = CreatePlayerRectangle();
		ball = new Rectangle {
			Width = 15,
			Height = 15,
			Fill = Brushes.White
		};

		GameCanvas.Children.Add(paddle1);
		GameCanvas.Children.Add(paddle2);
		GameCanvas.Children.Add(ball);

		Loaded += new RoutedEventHandler(WindowLoaded);
		SizeChanged += new SizeChangedEventHandler(HandleWindowSizeChanged);
		KeyDown += new KeyEventHandler(HandleKeyDown);

		gameTimer = new DispatcherTimer();
		gameTimer.Interval = TimeSpan.FromMilliseconds(16);
		gameTimer.Tick += new EventHandler(GameLoop);
		gameTimer.Start();
	}

	private void GameLoop(object? sender, EventArgs e) {
		Canvas.SetLeft(ball, Canvas.GetLeft(ball) + ballSpeedX);
		Canvas.SetTop(ball, Canvas.GetTop(ball) + ballSpeedY);

		// Ball collision with top and bottom walls
		if (Canvas.GetTop(ball) <= 0 || Canvas.GetTop(ball) >= GameCanvas.ActualHeight - ball.Height) {
			ballSpeedY = -ballSpeedY;
		}

		// Ball collision with paddles
		if (Canvas.GetLeft(ball) <= Canvas.GetLeft(paddle1) + paddle1.Width &&
			Canvas.GetTop(ball) + ball.Height >= Canvas.GetTop(paddle1) &&
			Canvas.GetTop(ball) <= Canvas.GetTop(paddle1) + paddle1.Height) {
			ballSpeedX = -ballSpeedX;
		}

		if (Canvas.GetLeft(ball) >= Canvas.GetLeft(paddle2) - ball.Width &&
			Canvas.GetTop(ball) + ball.Height >= Canvas.GetTop(paddle2) &&
			Canvas.GetTop(ball) <= Canvas.GetTop(paddle2) + paddle2.Height) {
			ballSpeedX = -ballSpeedX;
		}

		// Ball out of bounds (left or right side)
		if (Canvas.GetLeft(ball) <= 0 || Canvas.GetLeft(ball) >= GameCanvas.ActualWidth - ball.Width) {
			ResetBall();
		}
	}

	private void ResetBall() {
		Canvas.SetLeft(ball, (GameCanvas.ActualWidth - ball.Width) / 2);
		Canvas.SetTop(ball, (GameCanvas.ActualHeight - ball.Height) / 2);
		ballSpeedX = 5;
		ballSpeedY = 5;
	}

	private void SetInitialPositions() {
		Canvas.SetLeft(paddle1, 50);
		Canvas.SetTop(paddle1, (GameCanvas.ActualHeight / 2) - (paddle1.ActualHeight));

		Canvas.SetLeft(paddle2, GameCanvas.ActualWidth - 50);
		Canvas.SetTop(paddle2, (GameCanvas.ActualHeight / 2) - (paddle2.ActualHeight));

		Canvas.SetLeft(ball, (GameCanvas.ActualWidth - ball.ActualWidth) / 2);
		Canvas.SetTop(ball, (GameCanvas.ActualHeight - ball.ActualHeight) / 2);
	}

	private void HandleWindowSizeChanged(object sender, SizeChangedEventArgs e) {
		SetInitialPositions();
	}

	private void WindowLoaded(object sender, RoutedEventArgs e) {
		SetInitialPositions();
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