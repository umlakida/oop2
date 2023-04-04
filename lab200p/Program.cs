using System;

class Matrix
{
    int[,] matrix;

    public Matrix(int rows, int cols)
    {
        matrix = new int[rows, cols];
    }

    //public void IntRandomInitialize(int rows, int cols)
    //{
    //    Random random = new Random();
    //    for (int i = 0; i < rows; i++)
    //    {
    //        for (int j = 0; j < cols; j++)
    //        {
    //            matrix[i, j] = random.Next(-2, 10);

    //        }
    //    }
    //}

    public void DoubleRandomInitialize(int rows, int cols)
    {
        Random random = new Random();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = random.Next(0, 100) / 10;
            }
        }
    }

    public void Print() 
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }
    }


    public void CountNegativeElements()
    {
        int n = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 0)
                {
                    for (int k = 0; k < matrix.GetLength(1); k++)
                    {
                        if (matrix[i, k] < 0)
                        {
                            n++;
                        }
                    }
                    break;
                }
            }
        }
        Console.WriteLine("Amount of negative elements: " + n);
    }


    public void FindSaddlePoints()
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            int minInRow = matrix[i, 0];
            int colMinInRowIndex = 0;

            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] < minInRow)
                {
                    minInRow = matrix[i, j];
                    colMinInRowIndex = j;
                }
            }

            int maxInCol = matrix[0, colMinInRowIndex];
            int rowMaxInColIndex = 0;

            for (int j = 0; j < rows; j++)
            {
                if (matrix[j, colMinInRowIndex] > maxInCol)
                {
                    maxInCol = matrix[j, colMinInRowIndex];
                    rowMaxInColIndex = j;
                }
            }

            if (minInRow == maxInCol)
            {
                Console.WriteLine($"Saddle point found at {rowMaxInColIndex}, {colMinInRowIndex}");
            }
        }
    }
}



    class Program
    {
        static void Main(string[] args)
        {
            int rows = 4;
            int cols = 3;

            Matrix matrix = new Matrix(rows, cols);
           
            matrix.DoubleRandomInitialize(rows, cols); 
            matrix.Print();
            matrix.CountNegativeElements();
            matrix.FindSaddlePoints();
        }
    }

