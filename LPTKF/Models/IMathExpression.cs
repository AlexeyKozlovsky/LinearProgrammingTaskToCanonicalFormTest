using System;
using System.Collections.Generic;
using System.Text;

namespace LPTKF.Models {
    public interface IMathExpression {
        List<double> VariableValues { get; }
        CompareOperator ComparerOperator { get; }
        double FreeValue { get; }

        double this[int index] {
            get => VariableValues[index];
            set => VariableValues[index] = value;
        }

        void Add(double value) => this.VariableValues.Add(value);
    }
}
