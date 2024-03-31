using System;
using System.Drawing;
using HackerU.D290323ER.HelloWPF.MyLibrary;

namespace HackerU.D290323ER.HelloWPF.AccessModifiers2;

internal class Program {
	static void Main(string[] args) {
		Cat c = new Cat("Mitsy");
		// unable to access due to protection level
		//c.MakeSound();
		//c.MakeAnotherSound();
		//c.isAlive = true;
		//c.Color = "Green";


		Animal a = new Animal();
		//a.MakeSound();
		//a.MakeSound2();
		// unable to access due to protection level
		//a.MakeSound();
		//a.MakeAnotherSound();
		//a.isAlive = true;
		//a.Color = "Green";

		//Dog d = new Dog("Fido");

		
	}

}

/*
public class Animal {
	protected bool isAlive;

	protected string Color { get; set; }

	protected virtual void MakeSound() {
		Console.WriteLine("Generic animal sound");
		MakeAnotherSound();
	}

	protected void MakeAnotherSound() {
		Console.WriteLine("More sounds");
	}
}

public class Cat : Animal {

	protected override void MakeSound() {
		Console.WriteLine("Meow");

		MakeAnotherSound();

		isAlive = true;
		Color = "Green";
	}
}

*/