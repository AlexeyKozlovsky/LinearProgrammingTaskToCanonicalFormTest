using System;
using System.Collections.Generic;
using System.Linq;

namespace LPTKF.Models {
    /// <summary>
    /// Класс СЛАУ
    /// </summary>
    public class LinearEquationSystem : Matrix
    {

        public SolutionsField SolutionsField { get; private set; }

        /// <summary>
        /// Список решений
        /// </summary>
        private List<Solution> solutions;
        /// <summary>
        /// Создает квадратную СЛАУ
        /// </summary>
        /// <param name="range">Порядок системы</param>
        public LinearEquationSystem(int range) : base(range, range + 1) { }

        /// <summary>
        /// Создает СЛАУ
        /// </summary>
        /// <param name="rows">Количество строк</param>
        /// <param name="columns">Количество стобцов с учетом столбца свободных членов</param>
        public LinearEquationSystem(int rows, int columns) : base(rows, columns) { }

        private int[][] GetCombinations(int n, int m)
        {
            int combs = GetCombinationQuantity(n, m);
            int[] starts = new int[n];
            int[][] result = new int[combs][];
            int currentColumn = n - 1;
            for (int i = 0; i < n; i++) starts[i] = i;

            result[0] = (int[])starts.Clone();
            for (int i = 1; i < combs; i++)
            {
                currentColumn = n - 1;
                result[i] = (int[])result[i - 1].Clone();

                while (currentColumn > 0 && result[i][currentColumn] >= m - (n - currentColumn))
                    currentColumn--;

                result[i][currentColumn]++;
                for (int j = currentColumn + 1; j < n; j++)
                    result[i][j] = result[i][j - 1] + 1;
            }

            return result;
            
            
        }

        /// <summary>
        /// Считает количество сочетаний
        /// </summary>
        /// <param name="n">По</param>
        /// <param name="m">Из</param>
        /// <returns>Возвращает количество сочетаний из m по n</returns>
        private int GetCombinationQuantity(int n, int m)
        {
            int result = 1;
            int down = 1;
            for (int i = m; i > (m-n); i--) result *= i;
            for (int i = 1; i <= n; i++) result /= i;
            return result;
        }

        /// <summary>
        /// Делает единичную диагональ по переданному базису
        /// </summary>
        /// <param name="basisColumns">массив с номерами столбцов, выбранного базиса</param>
        private double[] GetBasisSolution(int[] basisColumns)
        {
            int current = 0;
            double koefficient = 1;
            int currentRow = 0;
            int currentColumn = 0;
            LinearEquationSystem system = new LinearEquationSystem(this.Rows, this.Columns);
            system.values = (double[,])this.values.Clone();

            for (int i = 0; i < basisColumns.Length; i++)
            {
                for (int row = 0; row < this.Rows - 1 - current; row++)
                {
                    if (system[current, basisColumns[i]] == 0)
                        system.ChangeRowsForNonZeroElemnt(current, basisColumns[i], 1);

                    currentRow = system.Rows - 1 - row;
                    currentColumn = basisColumns[i];
                    koefficient = 1 / system[current, currentColumn];

                    if (system[currentRow, currentColumn] != 0)
                        system.AddRow(currentRow, current,
                            -koefficient * system[currentRow, currentColumn]); 

                    if (system[system.Rows - 1 - current, basisColumns[basisColumns.Length - i - 1]] == 0)
                        system.ChangeRowsForNonZeroElemnt(system.Rows - 1 - current,
                            basisColumns[basisColumns.Length - i - 1], -1);

                    currentRow = row;
                    currentColumn = basisColumns[basisColumns.Length - i - 1];
                    koefficient = 1 / system[system.Rows - 1 - current, currentColumn];

                    if (system[currentRow, currentColumn] != 0)
                        system.AddRow(currentRow, this.Rows - 1 - current,
                            -koefficient * system[currentRow, currentColumn]);
                }
                
                if (++current >= system.Rows - 1) break;
            }
            
            system.MakeIdentityBasisDiag(basisColumns);
            system.MakeFreeColumnsZero(basisColumns);

            double[,] values = (double[,])system.values.Clone();
            Solution solution = new Solution(values, this, basisColumns);

            this.solutions.Add(solution);
            

            double[] result = new double[this.Columns - 1];

            for (int i = 0; i < basisColumns.Length; i++)
                result[basisColumns[i]] = system[i, this.Columns - 1];

            return result;
        }


        //private double[] GetBasisSolutionTest(int[] basisColumns)
        //{
        //    int current = 0;
        //    double koefficient = 1;
        //    int currentRow = 0;
        //    int currentColumn = 0;
        //    LinearEquationSystem system = new LinearEquationSystem(this.Rows, this.Columns);
        //    system.values = this.values;

        //    for (int i = 0; i < basisColumns.Length; i++)
        //    {
        //        for (int row = 0; row < this.Rows - 1 - current; row++)
        //        {
        //            currentRow = current;
        //            currentColumn = basisColumns[i];
        //            if (system[currentRow, currentColumn] == 0)
        //        }
        //    }
        //}

        /// <summary>
        /// Делает столбцы свободных коэффициентов нулевыми
        /// </summary>
        /// <param name="basisColumns">Массив с номерами базисных столбцов</param>
        private void MakeFreeColumnsZero(int[] basisColumns)
        {
            int[] freeValues = GetFreeColumns(basisColumns);

            foreach (int free in freeValues)
            {
                for (int i = 0; i < this.Rows; i++)
                    this[i, free] = 0;
            }
        }

        /// <summary>
        /// Получает массив с номерами свободных столбцов
        /// </summary>
        /// <param name="basisColumns">Массив с номерами базисных столбцов</param>
        /// <returns>Возвращает массив с номерами свободных столбцов</returns>
        private int[] GetFreeColumns(int[] basisColumns)
        {
            Array.Sort<int>(basisColumns);
            List<int> basisList = basisColumns.ToList<int>();
            List<int> freeList = new List<int>();
            for (int i = 0; i < this.Columns - 1; i++)
                if (!basisList.Contains(i)) freeList.Add(i);

            return freeList.ToArray<int>();
        }

        /// <summary>
        /// Делает базисную диагональ единичной
        /// </summary>
        /// <param name="basisColumns">Массив номеров базисных столбцов</param>
        private void MakeIdentityBasisDiag(int[] basisColumns)
        {
            for (int i = 0; i < basisColumns.Length; i++)
                this.MultRow(i, 1 / (this[i, basisColumns[i]]));
        }

        /// <summary>
        /// Получает все базисные решения
        /// </summary>
        /// <returns>Возвращает зубчатый массив всех базисных решений</returns>
        public double[][] GetAllBasisSolutions()
        {
            this.solutions = new List<Solution>();

            int n = this.Rows;
            int m = this.Columns - 1;
            int[][] basisColumnsCombs = GetCombinations(n, m);
            double[][] result = new double[basisColumnsCombs.Length][];

            for (int i = 0; i < basisColumnsCombs.Length; i++)
                result[i] = GetBasisSolution(basisColumnsCombs[i]);

            this.SolutionsField = new SolutionsField(this.solutions);

            return result;
        }

        public double[][] GetNonNegativeSolutions(double[][] allBasisSolutions)
        {
            List<double[]> nonNegativeSolutionsList = new List<double[]>();
            foreach (double[] solution in allBasisSolutions)
                if (IsNonNegative(solution)) nonNegativeSolutionsList.Add(solution);

            double[][] result = nonNegativeSolutionsList.ToArray();
            return result;
        }

        private bool IsNonNegative(double[] solution)
        {
            for (int i = 0; i < solution.Length; i++)
                if (solution[i] < 0) return false;

            return true;
        }
    }
}
