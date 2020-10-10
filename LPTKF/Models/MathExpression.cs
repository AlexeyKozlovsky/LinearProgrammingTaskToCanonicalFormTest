using System;
using System.Collections.Generic;
using System.Text;

namespace LPTKF.Models {
    public class MathExpression : IMathExpression{

        private List<double> variableValues;
        List<double> IMathExpression.VariableValues { get => variableValues; }

        private CompareOperator compareOperator;
        CompareOperator IMathExpression.ComparerOperator { get => compareOperator; }

        private double freeValue;
        double IMathExpression.FreeValue { get => freeValue; }

        public MathExpression(List<double> variableValues, CompareOperator compareOperator, double freeValue) {
            this.variableValues = variableValues;
            this.compareOperator = compareOperator;
            this.freeValue = freeValue;
        }

        public void UpdateCompareOperator(CompareOperator compareOperator) =>
            this.compareOperator = compareOperator;


        
    }
}
