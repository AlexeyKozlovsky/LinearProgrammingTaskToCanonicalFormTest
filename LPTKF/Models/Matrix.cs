using LPTKF.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace LPTKF.Models
{
    /// <summary>
    /// Матрица
    /// </summary>
    class Matrix
    {
        /// <summary>
        /// Двумерный массив значений элементов матрицы
        /// </summary>
        protected double[,] values;

        /// <summary>
        /// Индексатор для обращения к элементу матрицы
        /// </summary>
        /// <param name="x">Номер строки</param>
        /// <param name="y">Номер столбца</param>
        /// <returns>Возвращает элемент матрицы</returns>
        public double this[int x, int y]
        {
            get { return this.values[x, y]; }
            set { this.values[x, y] = value; }
        }

        /// <summary>
        /// Возвращает количество строк матрицы
        /// </summary>
        public int Rows { get { return this.values.GetLength(0); } }

        /// <summary>
        /// Возвращает количество столбцов матрицы
        /// </summary>
        public int Columns { get { return this.values.GetLength(1); } }

        /// <summary>
        /// Зубчатый массив пар линейно-зависимых строк
        /// </summary>
        protected int[][] dependencyRows;

        /// <summary>
        /// Зубчатый массив пар линейно-зависимых столбцов
        /// </summary>
        protected int[][] dependencyColumns;


        /// <summary>
        /// Создает квадратную матрицу
        /// </summary>
        /// <param name="range">Порядок матрицы</param>
        public Matrix(int range) => this.values = new double[range, range];

        /// <summary>
        /// Создает матрицу
        /// </summary>
        /// <param name="rows">Количество строк</param>
        /// <param name="columns">Количество столбцов</param>
        public Matrix(int rows, int columns) =>
            this.values = new double[rows, columns];


        /// <summary>
        /// Проверяет одинаковы ли матрицы по размеру. Если нет, то кидает исключение
        /// </summary>
        /// <param name="matrix1">1 матрица</param>
        /// <param name="matrix2">2 матрица</param>
        /// <param name="message">Сообщение исключения</param>
        private static void CheckSize(Matrix matrix1, Matrix matrix2, string message = "")
        {
            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
                throw new MatrixException(message);
        }

        /// <summary>
        /// Складывает матрицы
        /// </summary>
        /// <param name="matrix1">Матрица 1</param>
        /// <param name="matrix2">Матрица 2</param>
        /// <returns>Возвращает матрицу, являющуюся результатом сложения</returns>
        public static Matrix operator+(Matrix matrix1, Matrix matrix2)
        {
            CheckSize(matrix1, matrix2, "Нельзя складывать разные по размеру матрицы");

            Matrix result = new Matrix(matrix1.Rows, matrix1.Columns);
            for (int i = 0; i < matrix1.Rows; i++)
                for (int j = 0; j < matrix1.Columns; j++)
                    result[i, j] = matrix1[i, j] + matrix2[i, j];

            return result;
        }

        /// <summary>
        /// Вычитает матрицы
        /// </summary>
        /// <param name="matrix1">Матрица 1</param>
        /// <param name="matrix2">Матрица 2</param>
        /// <returns>Возвращает матрицу, являющуюся результатом вычитания</returns>
        public static Matrix operator-(Matrix matrix1, Matrix matrix2)
        {
            CheckSize(matrix1, matrix2, "Нельзя вычитать разные по размеру матрицы");

            Matrix result = new Matrix(matrix1.Rows, matrix1.Columns);
            for (int i = 0; i < matrix1.Rows; i++)
                for (int j = 0; j < matrix1.Columns; j++)
                    result[i, j] = matrix1[i, j] - matrix2[i, j];

            return result;
        }

        /// <summary>
        /// Умножает матрицу на число
        /// </summary>
        /// <param name="matrix">Матрица</param>
        /// <param name="value">Число</param>
        /// <returns>Возвращает матрицу, являющуюся результатом умножения</returns>
        public static Matrix operator*(Matrix matrix, double value)
        {
            Matrix result = new Matrix(matrix.Rows, matrix.Columns);

            for (int i = 0; i < matrix.Rows; i++)
                for (int j = 0; j < matrix.Columns; j++)
                    result[i, j] *= value;

            return result;
        }

        /// <summary>
        /// Умножает матрицу на число
        /// </summary>
        /// <param name="value">Число</param>
        /// <param name="matrix">Матрица</param>
        /// <returns>Возвращает матрицу, являющуюся результатом умножения</returns>
        public static Matrix operator*(double value, Matrix matrix)
        {
            return matrix * value;
        }

        /// <summary>
        /// Умножает матрицы
        /// </summary>
        /// <param name="matrix1">Матрица 1</param>
        /// <param name="matrix2">Матрица 2</param>
        /// <returns>Возвращает матрицу, являющуюся результатом умножения</returns>
        public static Matrix operator*(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Columns != matrix2.Rows)
                throw new MatrixException("Нельзя умножать несогласованные матрицы");

            Matrix result = new Matrix(matrix1.Rows, matrix2.Columns); 
            for (int i = 0; i < result.Rows; i++)
                for (int j = 0; j < result.Columns; j++)
                {
                    double current = 0;
                    for (int k = 0; k < matrix1.Columns; k++)
                        current += matrix1[i, k] * matrix2[k, j];

                    result[i, j] = current;
                }

            return result;
        }

        /// <summary>
        /// Проверяет корректен ли номер строки или столбца.
        /// Если нет, то кидает исключение
        /// </summary>
        /// <param name="current">Номер строки или столбца</param>
        /// <param name="length">Количество строк или столбцов</param>
        protected void RowColumnNumCheck(int current, int length)
        {
            if (current < 0 || current >= length)
                throw new MatrixException();
        }

        // Линейные преобразования

        /// <summary>
        /// Меняет строки матрицы местами
        /// </summary>
        /// <param name="row1">Строка 1</param>
        /// <param name="row2">Строка 2</param>
        protected void ChangeRows(int row1, int row2)
        {
            RowColumnNumCheck(row1, this.Rows);

            for (int i = 0; i < this.Columns; i++)
                (this[row1, i], this[row2, i]) = (this[row2, i], this[row1, i]);
        }

        /// <summary>
        /// Меняет столбцы матрицы местами
        /// </summary>
        /// <param name="column1">Столбец 1</param>
        /// <param name="column2">Столбец 2</param>
        protected void ChangeColumns(int column1, int column2)
        {
            RowColumnNumCheck(column1, this.Columns);
            RowColumnNumCheck(column2, this.Columns);

            for (int i = 0; i < this.Rows; i++)
                (this[i, column1], this[i, column2]) = (this[i, column2], this[i, column1]);
        }

        /// <summary>
        /// Добавляет к строке матрицы другую строку, домноженную на ненулевой коэффициент
        /// </summary>
        /// <param name="row">Строка</param>
        /// <param name="rowAdded">Прибавляемая строка</param>
        /// <param name="koefficient">Коэффициент</param>
        protected void AddRow(int row, int rowAdded, double koefficient = 1)
        {
            RowColumnNumCheck(row, this.Rows);
            RowColumnNumCheck(rowAdded, this.Rows);

            if (koefficient == 0)
                throw new MatrixException("Нельзя домножать на ноль");

            for (int i = 0; i < this.Columns; i++)
                this[row, i] += this[rowAdded, i] * koefficient;
        }

        /// <summary>
        /// Добавляет к столбцу матрицы столбец, домноженный не ненулевой коэффициент
        /// </summary>
        /// <param name="column">Столбец</param>
        /// <param name="columnAdded">Прибавляемый столбец</param>
        /// <param name="koefficient">Коэффициент</param>
        protected void AddColumn(int column, int columnAdded, double koefficient = 1)
        {
            RowColumnNumCheck(column, this.Columns);
            RowColumnNumCheck(columnAdded, this.Columns);

            if (koefficient == 0)
                throw new MatrixException("Нельзя домножать на ноль");

            for (int i = 0; i < this.Rows; i++)
                this[i, column] += this[i, columnAdded] * koefficient;
        }

        /// <summary>
        /// Меняет строки местами так, чтобы на нужной позиции оказался ненулевой элемент
        /// </summary>
        /// <param name="aim">Строка, на которой должен быть ненулевой элемент</param>
        /// <param name="column">Столбец, в котором должен быть ненулевой элемент</param>
        /// <param name="step">Шаг</param>
        protected void ChangeRowsForNonZeroElemnt(int aim, int column, int step = 1)
        {
            RowColumnNumCheck(aim, this.Rows);
            RowColumnNumCheck(column, this.Columns);

            if (step == 0)
                throw new MatrixException();

            int current = step == 1 ? 0 : this.Rows - 1;
            while (current >= 0 && current < this.Rows && 
                this[current, column] == 0) current += step;

            this.ChangeRows(aim, current);
        }
        
        /// <summary>
        /// Умножает строку матрицы на ненулевой коэффициент
        /// </summary>
        /// <param name="row">Номер строки</param>
        /// <param name="koefficient">Коэффициент</param>
        protected void MultRow(int row, double koefficient)
        {
            RowColumnNumCheck(row, this.Rows);
            if (koefficient == 0)
                throw new MatrixException("Коэффициент должен быть ненулевым");

            for (int i = 0; i < this.Columns; i++)
                this[row, i] *= koefficient;
        }

        /// <summary>
        /// Проверяет на линейную зависимость ряды элементов (строки или столбцы)
        /// </summary>
        /// <param name="groupNum1">Номер ряда 1</param>
        /// <param name="groupNum2">Номер ряда 2</param>
        /// <param name="status">Статус, если 0, то строки, если 1, то стролбцы</param>
        /// <returns>Возвращает true, если линейно-НЕзависимы, иначе false</returns>
        //private bool SameElementsCheck(int groupNum1, int groupNum2, int status = 0) {
        //    this.RowColumnNumCheck(groupNum1, this.values.GetLength(status));
        //    this.RowColumnNumCheck(groupNum2, this.values.GetLength(status));

        //    if (status == 0) {
        //        int current = 0;
        //        while (this[groupNum1, current] == 0 && this[groupNum2, current] == 0 && ++current >= this.values.GetLength((status + 1) % 2)) ;
                
        //        for (int i = 0; i < this.values.GetLength((status + 1) % 2); i++) {
                    
        //        }
        //    } else {
        //        for (int i = 0; i < this.values.GetLength((status + 1)%2); i++) {

        //        }
        //    }
            

        //}

        private void LinearDependencyRowCheck() {

        }

        private void LinearDependencyColumnCheck() {

        }
        
    }
}
