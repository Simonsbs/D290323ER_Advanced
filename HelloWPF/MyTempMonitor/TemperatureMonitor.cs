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

			//if (currentTemperature > 40) {
			//	OnHighTemperatureAlert(currentTemperature, $"Look out the temperature is high: {currentTemperature}");
			//}
			//else if (currentTemperature < 0) {
			//	OnLowTemperatureAlert(currentTemperature, $"Look out the temperature is low: {currentTemperature}");
			//}
		}
	}


	private void OnTemperatureChange(int temperature) {
		if (TemperatureChange != null) {
			//TemperatureChange(temperature);
			TemperatureChange.Invoke(temperature);
		}

		OnAlert(temperature);

		//if (temperature > 40) {
		//	OnHighTemperatureAlert(temperature);
		//} else if (temperature < 0) {
		//	OnLowTemperatureAlert(temperature);
		//}
	}


	private void OnAlert(int temperature) {
		if (temperature > 40 && HighTemperatureAlert != null) {
			HighTemperatureAlert(temperature, $"Look out the temperature is high: {temperature}");
		} else if (temperature < 0 && LowTemperatureAlert != null) {
			LowTemperatureAlert(temperature, $"Look out the temperature is low: {temperature}");
		}
	}

	/*
	private void OnLowTemperatureAlert(int temperature) {
		if (LowTemperatureAlert == null) {
			return;
		}

		LowTemperatureAlert(temperature, $"Look out the temperature is low: {temperature}");
	}

	private void OnHighTemperatureAlert(int temperature) {
		if (HighTemperatureAlert == null) {
			return;
		}

		HighTemperatureAlert(temperature, $"Look out the temperature is high: {temperature}");
	}
	*/
}