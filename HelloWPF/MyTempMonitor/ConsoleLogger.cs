namespace MyTempMonitor;

internal class ConsoleLogger {
	public ConsoleLogger(TemperatureMonitor monitor) {
		monitor.TemperatureChange += new Action<int>(HandleTemperatureChange);
		monitor.HighTemperatureAlert += new Action<int, string>(HandleHighTemperatureAlert);
		monitor.LowTemperatureAlert += new Action<int, string>(HandleLowTemperatureAlert);
	}

	private void HandleLowTemperatureAlert(int temperature, string message) {
		Console.ForegroundColor = ConsoleColor.Cyan;
		Console.WriteLine(message);
		Console.ResetColor();
	}

	private void HandleHighTemperatureAlert(int temperature, string message) {
		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine(message);
		Console.ResetColor();
	}

	private void HandleTemperatureChange(int temperature) {
		Console.WriteLine($"The temperature right now is: {temperature}");
	}
}