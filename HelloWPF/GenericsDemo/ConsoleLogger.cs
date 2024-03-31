namespace GenericsDemo;

public class ConsoleLogger<T> {
	public void WriteToLog(T message) {
		Console.WriteLine($"Message: {message} ; Type: {typeof(T)}");
	}
}