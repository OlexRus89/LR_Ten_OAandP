using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace LR_Ten_OAandP
{
    class Matrix
    {
        private double[,] matrix;
        private double[,] matrix1;
        private double[,] sum;
        private double[,] raz;
        int m, n;

        public void GenerateMatrix(int M, int N)
        {
            m = M;
            n = N;

            Random r = new Random(DateTime.Now.Millisecond);

            matrix = new double[M, N];
            matrix1 = new double[M, N];
            for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                {
                    matrix[i, j] = (double)r.Next(100);
                    matrix1[i, j] = (double)r.Next(100);
                }
                    
        }
        public void SaveMatrix(string pFileName, string pFileName1)
        {
            if (matrix.Length > 0)
            {
                if (File.Exists(pFileName))
                    File.Delete(pFileName);
                FileInfo f = new FileInfo(pFileName);
                TextWriter tw = f.CreateText();

                tw.WriteLine(m.ToString());
                tw.WriteLine(n.ToString());

                for (int i = 0; i < m; i++)
                    for (int j = 0; j < n; j++)
                        tw.WriteLine(i.ToString() + " " + j.ToString() + " " + matrix[i, j].ToString());

                tw.Close();
            }
            
            if (matrix1.Length > 0)
            {
                if (File.Exists(pFileName1))
                    File.Delete(pFileName1);
                FileInfo f = new FileInfo(pFileName1);
                TextWriter tw = f.CreateText();

                tw.WriteLine(m.ToString());
                tw.WriteLine(n.ToString());

                for (int i = 0; i < m; i++)
                    for (int j = 0; j < n; j++)
                        tw.WriteLine(i.ToString() + " " + j.ToString() + " " + matrix1[i, j].ToString());

                tw.Close();
            }
        }
        public Boolean LoadMatrix(string pFileName, string pFileName1)
        {
            if (File.Exists(pFileName))
            {
                try
                {
                    TextReader tr = File.OpenText(pFileName);
                    m = Convert.ToInt32(tr.ReadLine());
                    n = Convert.ToInt32(tr.ReadLine());

                    matrix = new double[m, n];
                    string line;
                    string[] substring;

                    for (int i = 0; i < m; i++)
                        for (int j = 0; j < n; j++)
                        {
                            line = tr.ReadLine();
                            substring = line.Split(new char[] {' '}, 3);
                            matrix[i, j] = Convert.ToDouble(substring[2]);
                        }
                    tr.Close();

                    return true;
                }
                catch
                {
                    return false;
                }
            }

            if (File.Exists(pFileName1))
            {
                try
                {
                    TextReader tr = File.OpenText(pFileName1);
                    m = Convert.ToInt32(tr.ReadLine());
                    n = Convert.ToInt32(tr.ReadLine());

                    matrix1 = new double[m, n];
                    string line;
                    string[] substring;

                    for (int i = 0; i < m; i++)
                        for (int j = 0; j < n; j++)
                        {
                            line = tr.ReadLine();
                            substring = line.Split(new char[] { ' ' }, 3);
                            matrix1[i, j] = Convert.ToDouble(substring[2]);
                        }
                    tr.Close();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        public void PrintMatrix()
        {
            sum = new double[m, n];
            raz = new double[m, n];
            Console.WriteLine("Сумма матриц: ");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sum[i, j] = matrix[i, j] + matrix1[i, j];
                    Console.Write("{0,7}", sum[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            Console.WriteLine("Разность матриц: ");
            for (int i = 0; i < m; i++)
            {
               for (int j = 0; j < n; j++)
                {
                    raz[i, j] = matrix[i, j] - matrix1[i, j];
                    Console.Write("{0,7}", raz[i, j] + " ");
                }                    
                Console.WriteLine();
            }
            
        }
    }
}
