using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите размер матрицы (N): ");
        int n = int.Parse(Console.ReadLine());

        double[,] matrix = new double[n, n];

        Console.WriteLine("Введите элементы матрицы:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"Элемент [{i}, {j}]: ");
                matrix[i, j] = double.Parse(Console.ReadLine());
            }
        }

        double determinant = CalculateDeterminant(matrix, n);
        Console.WriteLine($"Определитель матрицы: {determinant}");
    }

    static double CalculateDeterminant(double[,] matrix, int n)
    {
        if (n == 1)
            return matrix[0, 0];

        if (n == 2)
            return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

        double determinant = 0;

        for (int j = 0; j < n; j++)
        {
            double minor = CalculateMinor(matrix, 0, j, n);
            determinant += Math.Pow(-1, j) * matrix[0, j] * minor;
        }

        return determinant;
    }

    static double CalculateMinor(double[,] matrix, int row, int col, int n)
    {
        double[,] minorMatrix = new double[n - 1, n - 1];
        int minorRow = 0, minorCol;

        for (int i = 0; i < n; i++)
        {
            if (i == row) continue;
            minorCol = 0;

            for (int j = 0; j < n; j++)
            {
                if (j == col) continue;
                minorMatrix[minorRow, minorCol] = matrix[i, j];
                minorCol++;
            }
            minorRow++;
        }

        return CalculateDeterminant(minorMatrix, n - 1);
    }
}