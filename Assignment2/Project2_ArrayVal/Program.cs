using System;

namespace Project2_ArrayVal
{
    class Program
    {
        const int N = 100005;
        int n;
        int[] a = new int[N];
        int maxx = -0x3f3f3f3f,minx=0x3f3f3f3f,sum=0;
        double ave;
        void readIn()
        {
            n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
                a[i] = int.Parse(Console.ReadLine());
        }
        void getRes()
        {
            
            for (int i = 1; i <= n; i++)
            {
                maxx = Math.Max(maxx, a[i]);
                minx = Math.Min(minx, a[i]);
                sum += a[i];
            }
            ave = (double)sum / (1.00 * n);
                
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.readIn();
            p.getRes();
            Console.WriteLine("Max: " + p.maxx.ToString());
            Console.WriteLine("Min: " + p.minx.ToString());
            Console.WriteLine("Sum: " + p.sum.ToString());
            Console.WriteLine("Average: " + p.ave.ToString());
        }
    }
}
