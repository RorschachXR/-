using System;

namespace Project1_PrimeFactor
{
    class Program
    {
        const int N = 10005;
        bool[] vis = new bool[N];
        int tot = 0;
        int[] pri = new int[N];
        int n;
        int m = 0;
        int[] factors = new int[N];
        void getPrime()//线性筛素数
        {
            for (int i = 2; i <= 2 * n; i++)
            {
                if (!vis[i])pri[++tot] = i;
                for (int j = 1; j <= tot; j++)
                {
                    if (i * pri[j] > 2 * n) break;
                    vis[i * pri[j]] = true;
                    if (i % pri[j] == 0) break;
                }
            }
            /*
            for(int i=1;i<=tot;i++)
            {
                Console.Write(" QAQ ");
                Console.WriteLine(pri[i]);
            }
            */
        }
        void divi()//这里默认题意要求的是重复的质因数都要输出，去重的话可以用桶或者set
        {
            int x = n;
            for(int i=1;pri[i]<=x;i++)
            {
                //Console.WriteLine(" NOW "+pri[i].ToString()+" "+x );
                while (x!=1&&x%pri[i]==0)
                {
                    x /= pri[i];
                    factors[++m] = pri[i];
                }
            }
        }
        void readIn()
        {
            n = int.Parse(Console.ReadLine());
        }
        void display()
        {
            for(int i=1;i<=m;i++)
            {
                Console.WriteLine(factors[i]);
            }
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.readIn();
            p.getPrime();
            p.divi();
            p.display();

        }
    }
}
