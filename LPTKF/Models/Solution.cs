using LPTKF.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LPTKF.Models
{
    class Solution : LinearEquationSystem
    {
        private LinearEquationSystem initialSystem;
        private int[] basisColumns;
        private double[] freeValues;
        private double precise;

        public double Precise {
            get {
                return this.precise;
            }
        }
        public bool IsNonNegative { 
            get {
                for (int i = 0; i < this.Rows; i++)
                    if (this[i, this.Columns - 1] < 0) return false;
                return true;
            }
        }

        public Solution(int range, LinearEquationSystem initialSystem, int[] basisColumns) : base(range) {
            this.initialSystem = initialSystem;
            this.basisColumns = basisColumns;
            this.InitFreeValues();
            this.CountPrecise();
        }

        public Solution(int rows, int columns, LinearEquationSystem initialSystem,
            int[] basisColumns) : base(rows, columns) {
            this.initialSystem = initialSystem;
            this.basisColumns = basisColumns;
            this.InitFreeValues();
            this.CountPrecise();
        }

        public Solution(double[,] values, LinearEquationSystem initialSystem,
            int[] basisColumns) : base(values.GetLength(0), values.GetLength(1)) {
            this.initialSystem = initialSystem;
            this.basisColumns = basisColumns;
            this.values = values;
            this.InitFreeValues();
            this.CountPrecise();
        }

        private void InitFreeValues() {
            this.freeValues = new double[this.Rows];
            for (int i = 0; i < this.Rows; i++) {
                freeValues[i] = this[i, this.Columns - 1];
            }
        }

        private void CountPrecise() {
            double current = 0;
            double result = 0;
            for (int i = 0; i < this.Rows; i++) {
                current = 0;
                for (int j = 0; j < this.basisColumns.Length; j++) {
                    current += this.initialSystem[i, basisColumns[j]] * freeValues[j];
                }
                result += Math.Pow(current - this.initialSystem[i, this.Columns - 1], 2);
            }
            result /= this.Rows;

            //if (result >= 1E-3)
            //    throw new SolutionPreciseException();

            this.precise = result;
        }


        public override string ToString() {
            string result = "(";

            foreach (double current in this.freeValues) result += Math.Round(current, 2).ToString() + "; ";
            result = result.Substring(0, result.Length - 2) + ")";
            return result;
        }



    }
}
