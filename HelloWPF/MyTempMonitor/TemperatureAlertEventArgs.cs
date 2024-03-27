namespace MyTempMonitor;

public class TemperatureAlertEventArgs : TemperatureEventArgs {
	public string Message { get; set; }

	public AlertType AlertType { get; set; }
}