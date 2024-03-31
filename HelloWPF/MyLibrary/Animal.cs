using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary {
	public class Animal {
		public string Name { get; set; }
		public string Description { get; set; }

		public virtual void MakeSound() {
			Console.WriteLine("Generic animal sound");
		}
	}

	public class Cat : Animal {
		public Cat(string name) {
			Name = name;
		}

		public override void MakeSound() {
			Console.WriteLine("Meow");
		}
	}

	public class Dog : Animal {
		public Dog(string name) {
			Name = name;
		}

		public override void MakeSound() {
			Console.WriteLine("Woof!");
		}
	}
}
