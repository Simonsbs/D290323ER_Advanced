using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents;
internal class ActionsApp {
	public delegate void MenuAction();

	public void ShowGreeting() {
		Console.WriteLine("Hello, welcome to my app");
	}

	public void DisplayDate() {
		Console.WriteLine($"Today's date is: {DateTime.Now.ToShortDateString()}");
	}

	public void DisplayTime() {
		Console.WriteLine($"The time is: {DateTime.Now.ToShortTimeString()}");
	}

	public void RunApp() {
		Dictionary<int, MenuAction> functions = new Dictionary<int, MenuAction>();
		functions.Add(1, new MenuAction(ShowGreeting));
		functions.Add(2, new MenuAction(DisplayDate));
		functions.Add(3, new MenuAction(DisplayTime));


		Console.WriteLine("Please select a value (1-3): ");
		int selection = int.Parse(Console.ReadLine());

		MenuAction fnc = functions[selection];
		fnc();
	}
}
