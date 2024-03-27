namespace MyTempMonitor;

internal class ConsoleLogger {
	public ConsoleLogger(TemperatureMonitor monitor) {
		monitor.TemperatureChange += HandleTemperatureChange;
		monitor.HighTemperatureAlert += HandleTemperatureAlert;
		monitor.LowTemperatureAlert += HandleTemperatureAlert;
	}

	private void HandleTemperatureAlert(object sender, TemperatureAlertEventArgs e) {
		Console.ForegroundColor = e.AlertType == AlertType.Hot ? ConsoleColor.Red : ConsoleColor.Cyan;
		Console.WriteLine(e.Message);
		Console.ResetColor();
	}

	private void HandleTemperatureChange(object sender, TemperatureEventArgs e) {
		Console.WriteLine($"The temperature right now is: {e.Temperature}");
	}
}