using System;
using SharpToJs;

namespace Math
{
	public class Sample
	{
		static void Main(string args[])
		{
			int a = 1;
			int b = 2;
			
			int sum = a + b;
			console.log(sum);
			if(sum > 4)
				console.log("more than 4");
			else console.log("less than 4");
			
			var obj = new Math.Sample();
			obj.Foo();
		}
		
		public void Foo()
		{
			for(int i = 0; i < 10; i++)
			{
				console.log(i);
			}
		}
	}
}