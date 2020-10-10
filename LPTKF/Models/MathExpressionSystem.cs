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
    }
}
