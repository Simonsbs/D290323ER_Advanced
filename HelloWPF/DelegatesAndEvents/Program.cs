namespace DelegatesAndEvents;

internal class Program {
	public delegate void MyDelegate(string message);

	static void Main(string[] args) {
		MyDelegate del = new MyDelegate(MyFunction);

		//del("Simon");

		MyDelegate fnc1 = new MyDelegate(MyFunction);
		MyDelegate fnc2 = new MyDelegate(MyFunction2);

		DoSomeWork(fnc1);
		
		DoSomeWork(fnc2);
	}

	public static void DoSomeWork(MyDelegate logger) {
		// DO STUFF
		logger("log...");
		// do stuff
		logger("More log...");
	}

	public static void MyFunction2(string text) {
		File.AppendAllText("log.txt", text + Environment.NewLine);
	}

	public static void MyFunction(string text) {
		Console.WriteLine(text);
	}
}
