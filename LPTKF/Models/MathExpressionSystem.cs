using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace LPTKF.Models {
    class MathExpressionSystem : IEnumerable, IEnumerator{

        public List<IMathExpression> limits { get; private set; }
        public IMathExpression this[int index] {
            get => this.limits[index];
            set => this.limits[index] = value;
        }

        #region Реализации IEnumerable и IEnumerator

        private int position = -1;

        public object Current {
            get {
                if (position == -1 || position >= limits.Count)
                    throw new InvalidOperationException();
                return limits[position];
            }
        }

        public IEnumerator GetEnumerator() {
            return limits.GetEnumerator();
        }

        public bool MoveNext() {
            if (position < limits.Count - 1) {
                position++;
                return true;
            }
            return false;
        }

        public void Reset() {
            position = -1;
        }

        #endregion

        public MathExpressionSystem(List<IMathExpression> limits) =>
            this.limits = limits;

        public void Add(IMathExpression mathExpression) =>
            this.limits.Add(mathExpression);

        /// <summary>
        /// Перевод системы мат.выражений в систему линейных уравнений
        /// </summary>
        /// <returns>Систему линейныйх уравнений</returns>
        public LinearEquationSystem ToLinearEquationSystem() {
            int rows = this.limits.Count;
            int columns = this.limits[0].VariableValues.Count + 1;
            LinearEquationSystem result = new LinearEquationSystem(rows, columns);

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns - 1; j++)
                    result[i, j] = this.limits[i][j];
                result[i, columns - 1] = this.limits[i].FreeValue;
            }

            return result;
        }
    }
}
