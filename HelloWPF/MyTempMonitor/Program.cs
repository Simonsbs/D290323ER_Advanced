namespace MyTempMonitor;

internal class Program {
	static void Main(string[] args) {
		TemperatureMonitor monitor = new TemperatureMonitor();

		ConsoleLogger cLogger = new ConsoleLogger(monitor);
		FileLogger fLogger = new FileLogger(monitor);

		monitor.Start();
	}
}