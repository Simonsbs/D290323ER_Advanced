namespace DelegatesAndEvents;

internal class Program {
	public delegate void MyDelegate(string message);

	static void Main(string[] args) {
		MyBusinessLogic bl = new MyBusinessLogic();
		
		bl.FinishedWorking += new Notify(MyFunction);
		bl.DoingWork += new Update(HandleDoingWork);
		bl.StartWorking();


		Console.ReadLine();
		return;
		


		ActionsApp app = new ActionsApp();
		app.RunApp();

		return;

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

		/*
		 *
		 * Step 1: create a delegate called "TimerNotification"
		 * returns void and takes an integer
		 *
		 * Step 2: Create a Timer class
		 * create 2 events using the delegate above:
		 * TimerTick
		 * TimerCompleted
		 *
		 * Step 3:
		 * Add a function to the Timer class called "Start" that
		 * takes an integer (time to run in seconds)
		 * the function needs to loop the amount given in the parameter
		 * each iteration sleep for 1000 milli seconds and then raise
		 * the TimerTick event.
		 * When the loop completes, call the TimerCompleted event.
		 *
		 * Step 4:
		 * in the Main
		 * create an instance of Timer
		 * register for each of the events with a function suited
		 * call the "Start" on the timer and run the code
		 *
		 * verify that you get the tick event notifications
		 * and the completed
		 *
		 *
		 *
		 */
		
	}

	private static void HandleDoingWork(int percentcompete, string message) {
		Console.WriteLine($"Doing work: {percentcompete}% ");
		Console.WriteLine(message);
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
		Console.WriteLine("MyFunction: " + text);
	}
}
