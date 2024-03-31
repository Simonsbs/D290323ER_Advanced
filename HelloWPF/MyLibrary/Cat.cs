namespace HackerU.D290323ER.HelloWPF.MyLibrary;

public class Cat : Animal {
	public Cat(string name) {
		Name = name;
	}

	protected internal override void MakeSound() {
		Console.WriteLine("Meow");
	}

	public override string ToString() {
		return $"Cat called: {Name}";
	}
}