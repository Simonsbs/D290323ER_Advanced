namespace HackerU.D290323ER.HelloWPF.MyLibrary;

public class Animal {
	public string Name { get; set; }
	public string Description { get; set; }

	protected internal virtual void MakeSound() {
		Console.WriteLine("Generic animal sound");
	}

	internal void MakeSound2() {
		Console.WriteLine("A SOUND");
	}
}
