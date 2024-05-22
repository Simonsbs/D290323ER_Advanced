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
	}

	public sealed class Bob {
		private static Bob instance;

		private int aNumber;

		private Bob(int aNumber) {
			this.aNumber = aNumber;
		}

		public static Bob Instance {
			get {
				if (instance == null) {
					instance = new Bob(4567);
				}
				return instance;
			}
		}

		public void ShowMessage() {
			Console.WriteLine("Hey! " + aNumber);
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
