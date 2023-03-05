using System;

namespace Assignment11
{
    class Program
    {
        static int a, b, ans;
        static string c,s;
        static bool calc()
        {
            switch(c)
            {
                case "+":ans = a + b;break;
                case "-":ans = a - b;break;
                case "*":ans = a * b;break;
                case "/":ans = a / b;break;
                default:return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            s = Console.ReadLine();
            a = Int32.Parse(s);
            c = Console.ReadLine();
            s = Console.ReadLine();
            b = Int32.Parse(s);
            if (calc()) Console.WriteLine(ans);
            else Console.WriteLine("Error!");

            
        }
    }
}
