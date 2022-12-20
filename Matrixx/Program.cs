using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 5, m = 6;
            int[,] E = new int[n, n];
            int[,] A = new int[n, n];
            int[,] B = new int[n, n];
            int[,] matr = new int[n, m];
            string[,] M = new string[n, m];
            Random r = new Random();



            Matrix m1 = new Matrix(5, 7);
            Matrix m2 = new Matrix(5, 7);
            m1.ReadFromFile("note.txt");
            m1.Transpon();
            Console.WriteLine(m1 * m2);
            Console.WriteLine(m2 + m2);
            Console.WriteLine(m2 - m2);
            Console.WriteLine(m1);
        }
    }
}
