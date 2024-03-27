using System.Reflection.Metadata;

namespace MyTempMonitor;

internal class FileLogger {
	public FileLogger(TemperatureMonitor monitor) {
		monitor.TemperatureChange += new Action<int>(HandleTemperatureChange);
		monitor.LowTemperatureAlert += new Action<int, string>(HandleLowTemperatureAlert);
	}

	private void HandleLowTemperatureAlert(int temperature, string message) {
		File.AppendAllText("low_temp.txt", message + Environment.NewLine);
	}

	private void HandleTemperatureChange(int temperature) {
		File.AppendAllText("temp.txt", $"The temperature right now is: {temperature}" + Environment.NewLine);
	}
}