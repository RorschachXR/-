using System;

namespace Project3_Eratosthenes
{
    class Program
    {
        //埃氏筛的时间复杂度仍能优化，这里使用更优的线性筛
        const int N = 10005;
        bool[] vis = new bool[N];
        int tot = 0;
        int[] pri = new int[N];
        int n;
        void getPrime()//线性筛素数
        {
            for (int i = 2; i <= n; i++)
            {
                if (!vis[i]) pri[++tot] = i;
                for (int j = 1; j <= tot; j++)
                {
                    if (i * pri[j] >  n) break;
                    vis[i * pri[j]] = true;
                    if (i % pri[j] == 0) break;
                }
            }

        }
        void readIn()
        {
            n = 100;
        }
        void display()
        {
            for (int i = 1; i <= tot; i++)
                Console.WriteLine(pri[i]);
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.readIn();
            p.getPrime();
            p.display();
        }
    }
}
