using System;

namespace LR_Ten_OAandP
{
    class Program
    {
        static void Main(string[] args)
        {
            // Вариант 27
            //Программа рассчитывает сумму и разность двух матриц, которые
            //хранятся в разных файлах.

            Matrix m = new Matrix();

            m.GenerateMatrix(3, 3);
            m.SaveMatrix("FileForMatrix.txt", "FileForMatrix1.txt");

            if (m.LoadMatrix("FileForMatrix.txt", "FileForMatrix1.txt"))
                m.PrintMatrix();


        }
    }
}
