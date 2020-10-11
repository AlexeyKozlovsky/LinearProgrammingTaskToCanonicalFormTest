using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks.Sources;
using System.Windows.Markup;

namespace LPTKF.Models {
    public class LinearProgrammingTask {
        public GoalFunction GoalFunction { get; private set; }
        public MathExpressionSystem LimitSystem { get; private set; }
        public LinearProgrammingTaskForm TaskForm { get; private set; }
        private CompareOperator[] variableStatus;

        /// <summary>
        /// Словарь перевода переменных
        /// </summary>
        private Dictionary<int, List<int>> variablesDict;

        public LinearEquationSystem LinearEquationLimitSystem { get; private set; }

        /// <summary>
        /// Колчиество переменных
        /// </summary>
        private int variablesCount;

        public LinearProgrammingTask(GoalFunction goalFunction, MathExpressionSystem limitSystem,
            CompareOperator[] variableStatus) {
            this.GoalFunction = goalFunction;
            this.LimitSystem = limitSystem;
            this.variableStatus = variableStatus;

            this.variablesCount = this.variableStatus.Length;
            this.variablesDict = new Dictionary<int, List<int>>();
            InitTaskForm();
        }

        /// <summary>
        /// Проверяет, приведена ли ЗЛП к КФ
        /// </summary>
        /// <returns>Возвращает true, если приведена, false - если нет</returns>
        private bool IsCanonical() {
            if (this.GoalFunction.Aim == GoalFunctionAim.Max) return false;
            
            foreach (IMathExpression ex in this.LimitSystem)
                if (ex.ComparerOperator != CompareOperator.Equal) return false;

            return true;
        }

        private void InitTaskForm() {
            if (IsCanonical()) this.TaskForm = LinearProgrammingTaskForm.Canonical;
            else this.TaskForm = LinearProgrammingTaskForm.NonCanonical;
        }

        /// <summary>
        /// Делает x = x' - x'' , если не было указано, что x > 0 или x < 0 или x = 0
        /// </summary>
        /// <param name="column">Номер переменной, которую надо разбить на две</param>
        private void MakeTwoVarsFromOneVar(int column) {
            if (column >= this.variableStatus.Length)
                throw new Exception();

            this.variablesDict.Add(column, new List<int>() { column, -this.variablesCount });
            
            foreach (IMathExpression expression in this.LimitSystem) {
                expression.Add(-expression.VariableValues[column]);
            }

            this.variablesCount++;
        }

        /// <summary>
        /// Делает x = -x', если x < 0
        /// </summary>
        /// <param name="column">Номер переменной</param>
        private void ReverseVariable(int column) {
            if (column >= this.variableStatus.Length)
                throw new Exception();

            this.variablesDict.Add(column, new List<int>() { -column });
            
            foreach (IMathExpression ex in this.LimitSystem)
                ex[column] *= -1;

            this.variablesCount++;
        }

        private void AddValueToRow(int row, double value) {
            for (int i = 0; i < this.LimitSystem.limits.Count; i++) {
                if (i == row) this.LimitSystem.limits[i].Add(value);
                else this.LimitSystem.limits[i].Add(0);
            }
        }

        private void MakeEquations() {
            for (int i = 0; i < this.LimitSystem.limits.Count; i++) {
                this.variablesCount++;
                if (this.LimitSystem.limits[i].ComparerOperator == CompareOperator.Less) 
                    AddValueToRow(i, 1);
                else if (this.LimitSystem.limits[i].ComparerOperator == CompareOperator.More)
                    AddValueToRow(i, -1);
                else this.variablesCount--;

                if (this.LimitSystem.limits[i] is MathExpression)
                    ((MathExpression)this.LimitSystem.limits[i]).UpdateCompareOperator(CompareOperator.Equal);
            }
        }


        private void UpdateVariableInGoalFunction(double[] values, int variabeNum) {
            if (!this.variablesDict.ContainsKey(variabeNum))
                throw new Exception();

            for (int i = 0; i < this.variablesDict[variabeNum].Count; i++) {
                int sign = 1;
                if (this.variablesDict[variabeNum][i] < 0) sign = -1;

                values[Math.Abs(this.variablesDict[variabeNum][i])] = sign * this.GoalFunction[variabeNum];
            }
        }
        
        /// <summary>
        /// Обнавляет целевую функцию в соответствие с измененными переменными
        /// </summary>
        private void UpdateGoalFunction() {
            // TODO: дописать обновление функции

            double[] values = new double[this.variablesCount];
            for (int i = 0; i < this.GoalFunction.Count; i++) {
                if (this.variablesDict.ContainsKey(i))
                    UpdateVariableInGoalFunction(values, i);
                else values[i] = this.GoalFunction[i];
            }

            this.GoalFunction.UpdateFunc(values);
        }

        public void MakeCanonical() {
            if (this.GoalFunction.Aim == GoalFunctionAim.Max) this.GoalFunction.ChangeAim();

            
            for (int i = 0; i < this.variableStatus.Length; i++) {
                if (this.variableStatus[i] == CompareOperator.Less) ReverseVariable(i);
                else if (this.variableStatus[i] == CompareOperator.Undefined) MakeTwoVarsFromOneVar(i);
            }

            MakeEquations();
            UpdateGoalFunction();
            this.LinearEquationLimitSystem = this.LimitSystem.ToLinearEquationSystem();
            this.LinearEquationLimitSystem.GetAllBasisSolutions();
            this.TaskForm = LinearProgrammingTaskForm.Canonical;
        }

        public string ReturnVars() {
            string result = "";

            foreach (var k in this.variablesDict) {
                if (k.Value.Count == 2) result += $"x{k.Key + 1} = x{Math.Abs(k.Value[0]) + 1} - x{Math.Abs(k.Value[1]) + 1}; ";
                else result += $"x{k.Key + 1} = -x{Math.Abs(k.Value[0]) + 1}; ";
            }

            return result;
        }


        private string ReturnGoalFunction() {
            string result = "";
            for (int i = 0; i < this.GoalFunction.Count; i++) {
                result += $"{this.GoalFunction[i]}x{i} "; 
            }

            result += "-> ";
            result += this.GoalFunction.Aim == GoalFunctionAim.Min ? "min" : "max";
            result += "\n";
            return result;
        }

        private string ReturnMathExpression(IMathExpression expression) {
            string result = "";
            for (int i = 0; i < expression.VariableValues.Count; i++) {
                result += $"{expression[i]}x{i+1} ";
            }

            string operatorString = "";
            switch (expression.ComparerOperator) {
                case CompareOperator.Equal:
                    operatorString = "=";
                    break;
                case CompareOperator.Less:
                    operatorString = "<=";
                    break;
                case CompareOperator.More:
                    operatorString = ">=";
                    break;
            }

            result += $" {operatorString} {expression.FreeValue}\n";
            return result;
        }

        private string ReturnLimitSystem() {
            string result = "";
            foreach (IMathExpression expression in this.LimitSystem) {
                result += ReturnMathExpression(expression);
            }

            return result;
        }

        public string ReturnCharacteristics() {
            string result = "";

            result += this.TaskForm == LinearProgrammingTaskForm.Canonical ? "Каноническая форма" :
                "Не каноническая форма";
            result += "\n";

            result += this.ReturnVars();
            result += $"\nЦелевая функция: {this.ReturnGoalFunction()}\n";
            result += "Система ограничений:\n";
            result += ReturnLimitSystem();

            return result;
        }

    }
}
