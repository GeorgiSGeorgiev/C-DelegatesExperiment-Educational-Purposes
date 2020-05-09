using System;

namespace DelegatesExperiment {
	class Program {
		delegate int TheDelegate(int arg);
		delegate TheDelegate ComplicatedDel(int arg);
		class A {
			int a = 2;
			int b = 3;
			public TheDelegate f(int c) {
				int d = 5;
				TheDelegate del = (int x) => x + a + b + c + d;
				return del;
			}
		}

		static void Main(string[] args) {
			A theA = new A();
			ComplicatedDel complicatedDel = theA.f; 
			TheDelegate resultFunctrion = theA.f(100);
			TheDelegate resultFunction2 = complicatedDel(900);
			Console.WriteLine("Tests:");
			Console.WriteLine(resultFunctrion(100));
			Console.WriteLine(resultFunctrion(112));
			Console.WriteLine();
			Console.WriteLine("Assigning null to theA");
			theA = null;
			// The Scope feature
			// Scope is a special class that is created by the C# (not by the .NET platform)
			// that "exports" all of the local parameters of the A class that are used by
			// the lambda function in the f method.
			Console.WriteLine();
			try {
				Console.WriteLine(theA.f(3));
			}
			catch (NullReferenceException nullRef) {
				Console.WriteLine("Yes, an exception was thrown. Instance theA already \"doesn't exist\".");
				Console.Write("The exception message: ");
				Console.WriteLine(nullRef.Message);
			}
			Console.WriteLine();
			Console.WriteLine("But the delegate is still functioning properly. It is important to notice that the method in the delegate uses local parameters of theA which alredy doesn't exist.");
			Console.WriteLine("The result:");
			Console.WriteLine(resultFunctrion(113));
			Console.WriteLine("Testing Complicated delegate");
			Console.WriteLine(resultFunction2(100));
		}
	}
}
