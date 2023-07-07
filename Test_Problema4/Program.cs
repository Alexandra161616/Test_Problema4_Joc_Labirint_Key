using System;


namespace Test_Problema4
{
    internal class Program
    {
        private static string[] str1;

        static void Main(string[] args)
        {
            Console.WriteLine("Scrie numarul de linii ale grid-ului: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("NUMARUL DE COLOANE AL GRID-ULUI ESTE LUNGIMEA CARACTERELOR DE TIP STRING INTRODUSE DE LA TASTATURA!");
            Console.WriteLine("MENTINE CONSTANTA LUNGIMEA STRING-URILOR, ALTFEL JOCUL NU VA FUNCTIONA!!!");
            str1 = new string[n];
            for (int i = 0; i < n; i++)
            {
                str1[i] = Console.ReadLine();
            }
            
            int v = Solution.ShortestPathAllKeys(str1);
            Console.WriteLine(v);
            Console.ReadLine();

        }
    }
}
