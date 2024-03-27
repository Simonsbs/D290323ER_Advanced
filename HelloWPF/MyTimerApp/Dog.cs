using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTimerApp;
internal class Dog {
	public Dog(Timer timer) {
		timer.TimerTick += new Timer.TimerNotification(ReactToTick);

	}

	private void ReactToTick(int time) {
		Console.WriteLine($"Dog saw the tick {time}");
	}
}
