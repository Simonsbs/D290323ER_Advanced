using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerU.D290323ER.HelloWPF.MyLibrary.Animals;
public class AnimalManger {
	public void MakeAnimalsMakeSounds() {
		Cat c = new Cat("Cat");
		Dog d = new Dog("Dog");

		c.MakeSound();
		c.MakeSound2();

		//d.MakeSound();
		d.MakeSound2();
	}
}

internal interface ISpeak {

}

internal delegate void MyDelegate();
