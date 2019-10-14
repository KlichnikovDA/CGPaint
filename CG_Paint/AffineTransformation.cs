using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_Paint
{
    public static class AffineTransformation
    {
        // Смещение фигуры целиком
        public static int[,] Transfer(int[,] InitialMatrix, int M, int N)
        {
            int[,] T = new int[,] { { 1, 0, 0 }, { 0, 1, 0 }, { M, N, 1 } };
            return MatrixMultiply(InitialMatrix, T);
        }

        // Смещение одной точки фигуры
        public static int[,] Transfer(int[,] InitialMatrix, int M, int N, int P)
        {
            // Задание матрицы операций
            int[,] T = new int[,] { { 1, 0, 0 }, { 0, 1, 0 }, { M, N, 1 } };
            // Вектор, описывающий точку
            int[] Pt = new int[InitialMatrix.GetLength(1)];
            for (int i = 0; i < InitialMatrix.GetLength(1); i++)
                Pt[i] = InitialMatrix[P, i];
            // Результирующий вектор
            int[] MatrixRes = MatrixMultiply(Pt, T);
            // Обновление матрицы фигуры
            for (int i = 0; i < InitialMatrix.GetLength(1); i++)
                InitialMatrix[P, i] = MatrixRes[i];
            return InitialMatrix;
        }

        // Операция умножения двух матриц
        static int[,] MatrixMultiply(int[,] A, int[,] B)
        {
            int[,] C = new int[A.GetLength(0), B.GetLength(1)];
            // Проход по строкам первой матрицы
            for (int i = 0; i < A.GetLength(0); i++)
            {
                // Проход по столбцам второй матрицы
                for (int j = 0; j < B.GetLength(1); j++)
                    // Проход по столбцам первой и строкам второй матриц
                    for (int k = 0; k < A.GetLength(1); k++)
                    {
                        C[i, j] += A[i, k] * B[k, j];
                    }
            }
            return C;
        }

        // Операция умножения вектора на матрицу
        static int[] MatrixMultiply(int[] A, int[,] B)
        {
            int[] C = new int[B.GetLength(1)];
            // Проход по столбцам второй матрицы
            for (int j = 0; j < B.GetLength(1); j++)
                // Проход по столбцам первой и строкам второй матриц
                for (int k = 0; k < B.GetLength(0); k++)
                {
                    C[j] += A[k] * B[k, j];
                }
            return C;
        }
    }
}
