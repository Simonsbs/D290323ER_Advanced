using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents;

public delegate void Notify(string message);
public delegate void Update(int percentCompete, string message);


internal class MyBusinessLogic {
	
	public event Notify FinishedWorking;
	public event Update DoingWork;

	public void StartWorking() {
		Console.WriteLine("Starting to work...");

		for (int i = 0; i < 20; i++) {
			OnDoingWork(i * 5, "Working...");
			Thread.Sleep(500);
		}
		
		//FinishedWorking("Finished working boss!");

		OnFinishedWorking("Finished working boss!");
	}

	private void OnDoingWork(int percent, string text) {
		if (DoingWork == null) {
			return;
		}

		DoingWork(percent, text);
	}

	private void OnFinishedWorking(string message) {
		if (FinishedWorking == null) {
			return;
		}

		FinishedWorking(message);
	}
}
