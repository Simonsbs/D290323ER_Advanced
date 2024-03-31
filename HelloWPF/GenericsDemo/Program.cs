using System.Collections;
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


		/*
		 *
		Implement a generic ConsoleLogger<T> class that can log messages 
		of any type to the console, using a generic method.
		   
		Requirements
			The ConsoleLogger<T> class should have a generic method Log(T message) 
			that logs messages to the console.
			The log output should include the type of the message and the message itself.
			Implement overloads or additional methods as necessary to demonstrate 
			versatility with different types, including custom types.
			Create a small console application to demonstrate using ConsoleLogger<T> 
			with various types.
		 *
		 */
	}
}

public class MyStack<T> {
	public readonly T[] _items;
	private int _currentIndex = -1;

	public MyStack() => _items = new T[10];

	public int Count => _currentIndex + 1;

	public void Push(T item) {
		_items[++_currentIndex] = item;
	}

	public T Pop() {
		return _items[_currentIndex--];
	}

	/*
	public double Pop() {
		return _items[_currentIndex--];
	}
	*/

}

/*
public class MyStackOfString {
	public readonly string[] _items;
	private int _currentIndex = -1;

	public MyStackOfString() => _items = new string[10];

	public int Count => _currentIndex + 1;

	public void Push(string item) {
		_items[++_currentIndex] = item;
	}

	public string Pop() {
		return _items[_currentIndex--];
	}

	/*
	public string Pop() {
		return _items[_currentIndex--];
	}
	*/

//}
