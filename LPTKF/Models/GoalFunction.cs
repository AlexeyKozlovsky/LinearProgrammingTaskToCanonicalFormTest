using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace LPTKF.Models {
    public class GoalFunction : IMathExpression {

        private List<double> variableValues;
        public double this[int index] {
            get => variableValues[index];
            set => variableValues[index] = value;
        }

        public int Count {
            get => variableValues.Count;
        }

        public List<double> Vars {
            get => variableValues;
            set => variableValues = value;
        }


        List<double> IMathExpression.VariableValues { get => variableValues; }

        private CompareOperator compareOperator;
        CompareOperator IMathExpression.ComparerOperator { get => compareOperator; }

        private double freeValue;
        double IMathExpression.FreeValue { get => freeValue; }

        public GoalFunctionAim Aim { get; private set; }

        public GoalFunction(List<double> variableValues, CompareOperator compareOperator, double freeValue, 
            GoalFunctionAim aim) {
            this.variableValues = variableValues;
            this.compareOperator = compareOperator;
            this.freeValue = freeValue;
            this.Aim = aim;
        }

        public void ChangeAim() {
            if (this.Aim == GoalFunctionAim.Max) this.Aim = GoalFunctionAim.Min;
            else this.Aim = GoalFunctionAim.Max;

            for (int i = 0; i < this.variableValues.Count; i++) this.variableValues[i] *= -1;
        }

        public void UpdateFunc(double[] variableVector) => this.variableValues = variableVector.ToList<double>();

        public void UpdateFunc(List<double> variableVector) => this.variableValues = variableVector;

        public void Add(double value) => this.variableValues.Add(value);

        public void AddRange(double[] values) => this.variableValues.AddRange(values.ToList<double>());
        public void AddRange(List<double> values) => this.variableValues.AddRange(values);

    }
}
