using static MyTimerApp.Timer;

namespace MyTimerApp;

internal class Program {
	static void Main(string[] args) {
		Console.WriteLine("Program starting");
		
		Timer timer = new Timer();

		timer.TimerCompleted += new TimerNotification(HandleTimerCompleted);
		timer.TimerTick += new TimerNotification(HandleTimerTick);
		timer.TimerTick += new TimerNotification(LogTimerTick);

		Dog dog = new Dog(timer);

		timer.Start(10);

		
		
		Console.WriteLine("Program completed");
	}

	private static void LogTimerTick(int time) {
		File.AppendAllText("timer.txt", $"Time tick, time left: {time}");
	}

	private static void HandleTimerTick(int time) {
		Console.WriteLine($"Time tick, time left: {time}");
	}

	private static void HandleTimerCompleted(int time) {
		Console.WriteLine($"Timer has finished {time}");
	}
}



