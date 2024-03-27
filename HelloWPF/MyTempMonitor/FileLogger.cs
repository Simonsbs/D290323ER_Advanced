using System.Reflection.Metadata;

namespace MyTempMonitor;

internal class FileLogger {
	public FileLogger(TemperatureMonitor monitor) {
		monitor.TemperatureChange += HandleTemperatureChange;
		monitor.LowTemperatureAlert += HandleLowTemperatureAlert;
	}

	private void HandleLowTemperatureAlert(object sender, TemperatureAlertEventArgs e) {
		File.AppendAllText("low_temp.txt", e.Message + Environment.NewLine);
	}

	private void HandleTemperatureChange(object sender, TemperatureEventArgs e) {
		File.AppendAllText("temp.txt", $"The temperature right now is: {e.Temperature}" + Environment.NewLine);
	}
}