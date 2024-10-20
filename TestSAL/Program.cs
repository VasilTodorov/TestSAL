using System.Collections.Generic;

namespace TestSAL
{
    internal class Program 
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //Console.WriteLine(raft(15, 3, [666, 42, 7, 13, 400, 511, 600, 200, 202, 111, 313, 94, 280, 72, 42]));
            Console.WriteLine(raft(20, 3, [52, 17946, 27160, 387, 17346, 27505, 20816, 20577, 10961, 6021, 5262, 28278, 24163, 931, 11003, 19738, 17914, 1683, 10320, 10475]));
            Console.ReadLine();
        }
        //K-курсове, N-брой кози, T-тегло на козите
        public static int raft(int N, int K, int[] T)
        {       
            List<int> T_sorted = new List<int>(T);//сортира в намаляващ ред
            T_sorted.Sort((x, y) => y - x);
            int C = T_sorted[0];// C-капацитет
            while (true)
            {
                if (validate(C, K, T_sorted))
                {
                    break;
                }
                C += 1;
            }
            //if (validate(42, 2, T_sorted)) return -1;
            return C;
        }
        //validate - проверява дали при даден капацитета става
        //C-капацитет, К-брой курсове, T_sorted-сортирани тегла
        private static bool validate(int C, int K, List<int> T_sorted)
        {
            //L-товар
            int L;
            List<int> list = new List<int>(T_sorted);
            for (int i = 0; i < K; i++)
            {
                L = 0;
                for (int j = 0; j < list.Count; j++)
                {
                    if ((list[j] + L) <= C)
                    {
                        L += list[j];
                        list.RemoveAt(j);
                        j--;
                    }
                }
            }
            if (list.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    


}
