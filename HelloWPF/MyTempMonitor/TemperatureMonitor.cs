namespace MyTempMonitor;

public class TemperatureMonitor {
	public event EventHandler<TemperatureEventArgs> TemperatureChange;
	public event EventHandler<TemperatureAlertEventArgs> LowTemperatureAlert;
	public event EventHandler<TemperatureAlertEventArgs> HighTemperatureAlert;

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

			var args = new TemperatureEventArgs() {
				Temperature = temperature
			};

			TemperatureChange.Invoke(this, args);
		}

		OnAlert(temperature);

		//if (temperature > 40) {
		//	OnHighTemperatureAlert(temperature);
		//} else if (temperature < 0) {
		//	OnLowTemperatureAlert(temperature);
		//}
	}


	private void OnAlert(int temperature) {
		var args = new TemperatureAlertEventArgs() {
			Temperature = temperature
		};

		if (temperature > 40 && HighTemperatureAlert != null) {
			args.Message = $"Look out the temperature is high: {temperature}";
			args.AlertType = AlertType.Hot;
			HighTemperatureAlert(this, args);
		} else if (temperature < 0 && LowTemperatureAlert != null) {
			args.Message = $"Look out the temperature is low: {temperature}";
			args.AlertType = AlertType.Cold;
			LowTemperatureAlert(this, args);
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