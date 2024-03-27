namespace MyTimerApp;

public class Timer {
	public delegate void TimerNotification(int time);

	public event TimerNotification TimerTick;
	public event TimerNotification TimerCompleted;

	public void Start(int timeInSeconds) {
		for (int i = timeInSeconds; i > 0; i--) {
			Thread.Sleep(1000);
			OnTimerTick(i);
		}

		OnTimerCompleted();
	}

	private void OnTimerTick(int timeLeft) {
		if (TimerTick == null) {
			return;
		}

		TimerTick(timeLeft);
	}

	private void OnTimerCompleted() {
		if (TimerCompleted == null) {
			return;
		}

		TimerCompleted(0);
	}
}