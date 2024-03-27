namespace MyTimerApp;

public class Timer {
	public event SimpleDelegate TimerTick;
	public event SimpleDelegate TimerCompleted;

	public void Start(int timeInSeconds) {
		for (int i = timeInSeconds; i > 0; i--) {
			Thread.Sleep(1000);
			//OnTimerTick(i);

			TimerTick?.Invoke(i);
		}

		TimerTick?.Invoke(0);
		//OnTimerCompleted();
	}

	//private void OnTimerTick(int timeLeft) {
	//	if (TimerTick == null) {
	//		return;
	//	}

	//	TimerTick(timeLeft);
	//}

	//private void OnTimerCompleted() {
	//	if (TimerCompleted == null) {
	//		return;
	//	}

	//	TimerCompleted(0);
	//}
}