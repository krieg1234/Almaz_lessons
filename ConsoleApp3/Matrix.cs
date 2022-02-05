using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almaz_lessons_app
{
    internal class Matrix
    {
        public int[,] data { get; }

        public Matrix (int[,] _data){
            this.data= _data;
        }

        public Matrix(int height, int widht)
        {
            Random rnd=new Random();
            this.data= new int[height, widht];
            for (int i = 0; i < height; i++)
            {                
                for (int j = 0; j < widht; j++)
                {
                    data[i,j] = rnd.Next(10);
                }
            }

        }

        public int RowsCount()
        {
            return this.data.GetUpperBound(0) + 1;
        }
        
        public int ColumnsCount()
        {
            return this.data.GetUpperBound(1) + 1;
        }


        public void PrintInfo()
        {
            for (var i = 0; i < this.RowsCount(); i++)
            {
                for (var j = 0; j < this.ColumnsCount(); j++)
                {
                    Console.Write(this.data[i, j].ToString().PadLeft(4));
                }

                Console.WriteLine();
            }
            Console.WriteLine("\n");
        }

        public static Matrix operator +(Matrix matrixA, Matrix matrixB)
        {
            if (matrixA.RowsCount() != matrixB.RowsCount())
            {
                throw new Exception("Матрицы должны быть однинакового размера");
            }
            if (matrixA.ColumnsCount() != matrixB.ColumnsCount())
            {
                throw new Exception("Матрицы должны быть однинакового размера");
            }

            var matrixC = new int[matrixA.RowsCount(), matrixA.ColumnsCount()];

            for (var i = 0; i < matrixA.RowsCount(); i++)
            {
                for (var j = 0; j < matrixB.ColumnsCount(); j++)
                {
                    matrixC[i, j] = matrixA.data[i,j]+ matrixB.data[i, j];                    
                }
            }
            return new Matrix(matrixC);
        }

        public static Matrix operator *(Matrix matrixA, Matrix matrixB)
        {
            if (matrixA.ColumnsCount() != matrixB.RowsCount())
            {
                throw new Exception("Количество столбцов первой матрицы не равно количеству строк второй матрицы.");
            }

            var matrixC = new int[matrixA.RowsCount(), matrixB.ColumnsCount()];

            for (var i = 0; i < matrixA.RowsCount(); i++)
            {
                for (var j = 0; j < matrixB.ColumnsCount(); j++)
                {
                    matrixC[i, j] = 0;

                    for (var k = 0; k < matrixA.ColumnsCount(); k++)
                    {
                        matrixC[i, j] += matrixA.data[i, k] * matrixB.data[k, j];
                    }
                }
            }

            return new Matrix(matrixC);
        }

        public static bool operator == (Matrix matrixA, Matrix matrixB)
        {
            if (matrixA.RowsCount != matrixB.RowsCount)
            {
                return false;
            }
            if (matrixA.ColumnsCount != matrixB.ColumnsCount)
            {
                return false;
            }

            for (var i = 0; i < matrixA.RowsCount(); i++)
            {
                for (var j = 0; j < matrixB.ColumnsCount(); j++)
                {
                    if (matrixA.data[i, j] != matrixB.data[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator !=(Matrix matrixA, Matrix matrixB)
        {
            if (matrixA == matrixB)
            {
                return false;
            }

            return true;
        }

        public Matrix Trasponire ()
        {
            var result = new int[this.RowsCount(), this.ColumnsCount()];

            for (var i = 0; i < this.RowsCount(); i++)
            {
                for (var j = 0; j < this.ColumnsCount(); j++)
                {
                    result[i, j] = this.data[j,i] ;
                }
            }

            return new Matrix(result);
        }
    }
}
