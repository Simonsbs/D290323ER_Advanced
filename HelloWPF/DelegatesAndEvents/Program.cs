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

		/*
		 * EX1
		 * Step 1: define a delegate called 'MenuAction' that has no
		 * parameters and returns void.
		 *
		 * Step 2:
		 * build 3 methods that have the same signature as 'MenuAction'
		 * and do the following:
		 * 1. ShowGreeting
		 * 2. DisplayDate
		 * 3. DisplayTime
		 *
		 * Step 3:
		 * Build a List that holds the functions above and use the
		 * index as a key
		 *
		 * Step 4:
		 * Build a simple UI that asks the user to select an action (1-3)
		 * based on the selected value the system will call the function
		 * from the dictionary and calls the function. 
		 *
		 */


		
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
