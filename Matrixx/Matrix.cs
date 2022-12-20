using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Matrixx
{
    internal class Matrix
    {
        public int n { get { return matrix.GetLength(0); } }
        public int m { get { return matrix.GetLength(1); } }
        public int[,] matrix { get; set; }


        public Matrix(int n, int m)
        {
            this.matrix = new int[n, m];
        }
        public Matrix(int n)
        {
            matrix = new int[n, n];
        }
        public Matrix() : this(1, 1)
        {

        }

        public async void WriteToFile(string path)
        {
            string text = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    text += matrix[i, j].ToString();
                    text += " ";
                }
                text.Trim();
                text += '\n';
            }
            using (FileStream fstream = new FileStream(path, FileMode.Create))
            {
                byte[] buffer = Encoding.Default.GetBytes(text);
                await fstream.WriteAsync(buffer, 0, buffer.Length);
                fstream.Close();
            }
        }

        public void ReadFromFile(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                int[,] matr = new int[n, m];
                for (int i = 0; i < n; i++)
                {
                    var row = reader.ReadLine().Split(' ');
                    for (int j = 0; j < m; j++)
                        matr[i, j] = int.Parse(row[j]);
                }
                matrix = matr;
                reader.Close();
            }
        }

        public void Transpon()
        {
            int[,] mas = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    mas[i, j] = matrix[n - 1 - j, i];
                }

            }

            matrix = (int[,])mas.Clone();
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            var summatr = (int[,])m1.matrix.Clone();
            var matr1 = m1.matrix;
            var matr2 = m2.matrix;
            int n = matr1.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    summatr[i, j] = matr2[i, j] + matr1[i, j];
                }
            }
            var res = new Matrix(summatr.GetLength(0), summatr.GetLength(1));
            res.matrix = summatr;
            return res;
        }
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            var summatr = (int[,])m1.matrix.Clone();
            var matr1 = m1.matrix;
            var matr2 = m2.matrix;
            int n = matr1.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    summatr[i, j] = matr2[i, j] - matr1[i, j];
                }
            }
            var res = new Matrix(summatr.GetLength(0), summatr.GetLength(1));
            res.matrix = summatr;
            return res;
        }
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            var A = m1.matrix; var B = m2.matrix;
            if (A.GetLength(1) == B.GetLength(0))
            {
                int[,] Result = new int[A.GetLength(0), B.GetLength(1)];
                int sum = 0;
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < B.GetLength(1); j++)
                    {
                        sum = 0;
                        for (int k = 0; k < A.GetLength(1); k++)
                        {
                            sum += A[i, k] * B[k, j];

                        }
                        Result[i, j] = sum;
                    }

                }
                var res = new Matrix(Result.GetLength(0), Result.GetLength(1));
                res.matrix = Result;
                return res;

            }
            else
            {
                var summatr = new int[0, 0];
                var res = new Matrix(summatr.GetLength(0), summatr.GetLength(1));
                res.matrix = summatr;
                return res;
            }

        }
        public override string ToString()
        {
            string text = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    text += matrix[i, j].ToString();
                    text += " ";
                }
                text.Trim();
                text += '\n';
            }
            return text;
        }


    }
}
