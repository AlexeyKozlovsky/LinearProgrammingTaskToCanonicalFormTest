//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;
//using System.Windows.Controls;
//using System.Windows.Media.Converters;

//namespace LPTKF.Models {
//    class LinearProgrammingTask {
//        #region Целевая функция
//        private double[] goalFunction;
//        public double[] GoalFunction {
//            get => goalFunction;
//            set => goalFunction = value;
//        }

//        private GoalFunctionAim aim;
//        public GoalFunctionAim Aim {
//            get => aim;
//        }

//        #endregion

//        #region Система ограничений
//        private List<double>[] limitsArray;

//        private CompareOperator[] systemComaparers;
//        public CompareOperator[] SystemComparers {
//            get => systemComaparers;
//        }


//        private LinearEquationSystem limitsLinearEquationSystem;
//        public LinearEquationSystem LimitsLinearEquationSystem {
//            get => limitsLinearEquationSystem;
//            set => limitsLinearEquationSystem = value;
//        }

//        #endregion

//        private List<double[]> variableLinks;
//        public List<double[]> VariableLinks {
//            get => variableLinks;
//            set => variableLinks = value;
//        }

//        #region Условия на переменные
//        private CompareOperator[] variablesConditions;
//        public CompareOperator[] VariableConditions {
//            get => variablesConditions;
//        }
//        #endregion


//        public LinearProgrammingTask(double[] goalFunction, GoalFunctionAim aim, List<double>[] limitsArray,
//            CompareOperator[] systemComparers, CompareOperator[] variablesConditions) {
//            this.goalFunction = goalFunction;
//            this.aim = aim;
//            this.limitsArray = limitsArray;
//            this.systemComaparers = systemComparers;
//            this.variablesConditions = variablesConditions;

//            ChangeSystemDueToSystemComparers();


//        }

//        /// <summary>
//        /// Инициализирует массив, показывающий как преобразованы переменные
//        /// </summary>
//        private void InitVariableLinks() {
//            int length = limitsArray.Length - 1;
//            this.variableLinks = new List<double[]>();
//            int variableCount = this.limitsArray[0].Count - 1;

//            for (int i = 0; i < length; i++)
//                this.variableLinks[i] = new double[variableCount];
//        }

//        private void ChangeSystemDueToSystemComparers() {
//            for (int i = 0; i < this.limitsArray.Length; i++) {
//                switch (this.systemComaparers[i]) {
//                    case CompareOperator.Less:
//                        AddNewVariable(-1, i);
//                        break;
//                    case CompareOperator.More:
//                        AddNewVariable(1, i);
//                        break;
//                }
//            }
//        }

//        private void InitNotLimitedVariables() {
//            for (int i = 0; i < this.variablesConditions.Length; i++) {
//                switch (this.variablesConditions[i]) {
//                    case CompareOperator.Less:
//                        MultColumn(i, -1);
//                        this.variableLinks[i] = new double[1] { -i };
//                        break;

//                    case CompareOperator.Undefined:
//                        this.variableLinks[i] = new double[2] { i, -this.limitsArray[0].Count - 1 };
//                        CopyNewVariable(i, -1);
//                        break;

//                    case CompareOperator.Equal:
//                        this.variableLinks[i] = new double[1] { i };
//                        break;
//                }
//            }
//        }

//        private void MultColumn(int column, double value) {
//            for (int i = 0; i < this.limitsArray.Length; i++) {
//                this.limitsArray[i][column] *= value;
//            }
//        }

//        private void AddNewVariable(int value, int row) {
//            for (int i = 0; i < this.limitsArray.Length; i++) {
//                this.limitsArray[i].Add(0);
//            }
//            this.limitsArray[row].Add(value);
//        }
        
//        private void AddNewVariable(int value) {
//            for (int i = 0; i < this.limitsArray.Length; i++) {
//                this.limitsArray[i].Add(value);
//            }
//        }

//        private void CopyNewVariable(int row, double koefficient) {
//            for (int i = 0; i < this.limitsArray.Length; i++) {
//                this.limitsArray[i].Add(this.limitsArray[i][row] * koefficient);
//            }
//        }

//        /// <summary>
//        /// Инициализирует систему ограничений
//        /// </summary>
//        private void InitCanonicLinearSystem() {
//            int columns = this.limitsArray[0].Count;
//            int rows = this.limitsArray.Length;

//            this.limitsLinearEquationSystem = new LinearEquationSystem(rows, columns);
//            for (int i = 0; i < rows; i++) {
//                for (int j = 0; j < columns; j++) {
//                    this.limitsLinearEquationSystem[i, j] = this.limitsArray[i][j];
//                }
//            }
//        }
//    }
//}
