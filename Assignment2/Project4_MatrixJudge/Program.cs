using System;

namespace Project4_MatrixJudge
{

    /*
     * 
3
4
1
2 
3 
4
5 
1 
2 
3
9 
5 
1 
2



3
4
1
2 
3 
6
7
1 
2 
3
9 
5 
1 
2
     */


    class Program
    {
        const int M = 105;
        const int N = 105;
        int m, n;
        int[,] a = new int[M, N];

        void readIn()
        {
            n = int.Parse(Console.ReadLine());
            m = int.Parse(Console.ReadLine());
            for(int i=1;i<=n;i++)
                for(int j=1;j<=m;j++)
                    a[i,j]= int.Parse(Console.ReadLine());
        }
        bool judge()
        {
            int si = n, sj = 1;
            while(si>=1)
            {
                int i = si, j = sj, val=a[i,j];
                while(i<=n&&j<=m)
                {
                    if (a[i, j] != val) return false;
                    i++;j++;
                }
                si--;
            }
            si = 1;sj = 2;
            while(sj<=m)
            {
                int i = si, j = sj, val = a[i, j];
                while(i<=n&&j<=m)
                {
                    if (a[i, j] != val) return false;
                    i++;j++;
                }
                sj++;
            }
            return true;
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.readIn();
            Console.WriteLine(p.judge());
        }
    }
}
