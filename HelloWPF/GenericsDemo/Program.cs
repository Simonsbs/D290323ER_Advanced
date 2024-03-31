using System.Collections;
using System.Net.Http.Headers;
using HackerU.D290323ER.HelloWPF.MyLibrary;

namespace GenericsDemo;

internal class Program {
	static void Main(string[] args) {
		MyStack<double> stack = new MyStack<double>();
		stack.Push(1.1);
		stack.Push(2.5);
		stack.Push(4.0);
		double value = stack.Pop();
		stack.Push(6.2);
		stack.Push(9.4);
		//stack.Push(new Cat("Fido"));

		MyStack<string> stack2 = new MyStack<string>();
		stack2.Push("Simon");
		//stack2.Push(true);

		MyStack<Cat> stack3 = new MyStack<Cat>();
		stack3.Push(new Cat("Mitsy"));
		stack3.Push(new Cat("Mitsy2"));
		stack3.Push(new Cat("Mitsy3"));

		//Stack<int>
		//List<int>
		//Queue<>
		//Dictionary<string, int>

		double sum = 0;

		while (stack.Count > 0) {
			double t = stack.Pop();
			Console.WriteLine($"Item: {t}");
			sum += t;
		}

		while (stack2.Count > 0) {
			string t = stack2.Pop();
			Console.WriteLine($"Item2: {t}");
		}

		Console.WriteLine($"the sum of the stack is: {sum}");

		Console.WriteLine("------------------------------------");

		ConsoleLogger<string> logger = new ConsoleLogger<string>();
		logger.WriteToLog("Simon's message");

		ConsoleLogger<int> logger2 = new ConsoleLogger<int>();
		logger2.WriteToLog(123);

		ConsoleLogger<Cat> logger3 = new ConsoleLogger<Cat>();
		logger3.WriteToLog(new Cat("Mitsy"));

		Console.WriteLine("------------------------------------");

		MyRepository<User> userRepository = new MyRepository<User>();
		userRepository.Add(new User {
			ID = 1,
			Name = "Simon"
		});
		userRepository.Add(new User {
			ID = 2,
			Name = "Bob"
		});
		userRepository.Add(new User {
			ID = 3,
			Name = "Jane"
		});

		User user2 = userRepository.GetByID(2);

		Console.WriteLine(user2);

		MyRepository<Product> productRepository = new MyRepository<Product>();
		productRepository.Add(new Product {
			ID = 1,
			Name = "Computer"
		});
		productRepository.Add(new Product {
			ID = 2,
			Name = "Book"
		});
		productRepository.Add(new Product {
			ID = 3,
			Name = "House"
		});

		
		/*
		 *
		Implement a generic ConsoleLogger<T> class that can log messages 
		of any type to the console, using a generic method.
		   
		Requirements
			1. The ConsoleLogger<T> class should have a generic method Log(T message) 
			that logs messages to the console.
					
			2. The log output should include the type of the message (typeof()) and the message itself.
			
			3. Create a small console application to demonstrate using ConsoleLogger<T> 
			with various types.
		 *
		 */
	}
}

public class GeneralBase {
	public int ID { get; set; }
}

public interface IHasName {
	public string Name { get; set; }
}

public class User : GeneralBase {

	public string Name { get; set; }

	public override string ToString() {
		return Name;
	}
}

public class Product : GeneralBase {

	public string Name { get; set; }

	public override string ToString() {
		return Name;
	}
}

public class MyRepository<T> where T : GeneralBase {
	private List<T> _items = new List<T>();

	public void Add(T item) {
		_items.Add(item);
	}

	public T GetByID(int id) {
		foreach (T item in _items) {
			if (item.ID == id) {
				return item;
			}
		}
		
		return null;
	}
}