namespace Revision;
internal class Program {
	static void Main(string[] args) {
		//int val = 1;

		//int val2 = val;

		//val = 3;

		//object o = new object();

		//object o2 = o;

		//int[] arr = new int[2] { 10, 20 };

		//int[] arr2 = arr;

		//      Console.WriteLine(arr[0]);
		//int x = arr[0];
		//arr[0] = 30;
		//      Console.WriteLine(x);
		//      Console.WriteLine(arr2[0]);


		//object b1 = 30;

		//int v2 = (int)b1;

		//Console.WriteLine(b1);



		//int? a = 10;
		//double? b;
		//string s;
		//bool? bo;
		//char? c;
		//object o;
		//List<int> list;


		//if (!a.HasValue) {
		//	Console.WriteLine("a is null");
		//} else {
		//	Console.WriteLine("a: " + a.Value);
		//}

		//doMethod(null);


		//int? i1 = null;

		//int? i5 = i1;

		//int i2 = i1 == null ? 5 : (int)i1;

		//int i3 = i1 ?? 5;

		//int i4;
		//if (i1 == null) {
		//	i4 = 5;
		//} else {
		//	i4 = (int)i1;
		//}


		//int? result = Add(null, 10);
		//      Console.WriteLine(result ?? 999);
		//      Console.WriteLine(result == null ? 999 : (int)result);

		//      result = Add(5, 10);
		//      Console.WriteLine(result ?? 456);


		Bob s1 = Bob.Instance;
		Bob s2 = Bob.Instance;

		Bob b3 = s2;

		s1.ShowMessage();
		s2.ShowMessage();
		b3.ShowMessage();

		//Add(1, 2, 3, 4, 5, 6, 7, 7);


		Cat c1 = new Cat(4, 2);
		Cat c2 = new Cat(3, 1);

		Console.WriteLine(Cat._eyes);

		Console.WriteLine(c1.legs);
		Console.WriteLine(c2.legs);

        //bool x = 8 % 2 == 0;

        Console.WriteLine(c1.Name);
		Console.WriteLine(c1.Name);

	}

	//public static void Add(params int[] a) {

	//}

	public class Cat {
		public static int _eyes;
		public readonly int ccc = 0;
		public const int ddd = 0;
		public int legs;

		private string? _name;

		public string Name {
			get {
				//return _name ??= "default";

				if (_name == null) {
					_name = "default";
				}
				return _name;
			}
			set => _name = value;
		}

		public Cat(int legs, int eyes) {
			
			_eyes = eyes;
			this.legs = legs;
		}
	}


	public sealed class Bob {
		private static Bob instance;

		private int aNumber;

		const int max = 10;
		readonly int min = 60;

		private Bob(int aNumber) {
			this.aNumber = aNumber;
			min = 0;
		}

		public static Bob Instance {
			get {
				return instance ??= new Bob(4567); 

				//if (instance == null) {
				//	instance = new Bob(4567);
				//}

				//return instance;
			}
		}

		public void ShowMessage() {
			//min = 55;
			//max = 66;
			Console.WriteLine("Hey! " + aNumber + min);
		}
	}



	//public static int? Add(int? a, int? b) {
	//	if (a.HasValue && b.HasValue) {
	//		return a.Value + b.Value;
	//	}
	//	return null;
	//}


	//public static void doMethod(int? x) {

	//}
}
