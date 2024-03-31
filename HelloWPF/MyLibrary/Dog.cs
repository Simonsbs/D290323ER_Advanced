namespace HackerU.D290323ER.HelloWPF.MyLibrary;

internal class Dog : Animal {
	public Dog(string name) {
		Name = name;
	}

	protected internal override void MakeSound() {
		Console.WriteLine("Woof!");
	}
}