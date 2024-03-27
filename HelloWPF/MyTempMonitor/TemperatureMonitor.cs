namespace MyTempMonitor;

public class TemperatureMonitor {
	public event Action<int> TemperatureChange;
	public event Action<int, string> LowTemperatureAlert;
	public event Action<int, string> HighTemperatureAlert;

	public void Start() {
		Random rnd = new Random();
		
		while (true) {
			Thread.Sleep(200);

			int currentTemperature = rnd.Next(-20, 50);
			
			OnTemperatureChange(currentTemperature);

			if (currentTemperature > 40) {
				OnHighTemperatureAlert(currentTemperature, $"Look out the temperature is high: {currentTemperature}");
			}
			else if (currentTemperature < 0) {
				OnLowTemperatureAlert(currentTemperature, $"Look out the temperature is low: {currentTemperature}");
			}
		}
	}


	private void OnTemperatureChange(int temperature) {
		if (TemperatureChange == null) {
			return;
		}

		TemperatureChange(temperature);
	}

	private void OnLowTemperatureAlert(int temperature, string message) {
		if (LowTemperatureAlert == null) {
			return;
		}

		LowTemperatureAlert(temperature, message);
	}

	private void OnHighTemperatureAlert(int temperature, string message) {
		if (HighTemperatureAlert == null) {
			return;
		}

		HighTemperatureAlert(temperature, message);
	}

}