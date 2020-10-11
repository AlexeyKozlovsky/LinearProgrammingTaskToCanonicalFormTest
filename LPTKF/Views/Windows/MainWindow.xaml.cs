﻿using LPTKF.Models;
using LPTKF.Models.Extraclasses;
using LPTKF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using Accessibility;

namespace LPTKF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        LinearProgrammingTask task;
        MainWindowViewModel vm;

        DataTable initGoalFuncDataTable, initLimitSystemDataTable, compareOperatorDataTable;
        DataTable canonGoalFuncDataTable, canonLimitSystemDataTable, solutionDataTable;




        public MainWindow() {
            InitializeComponent();
            vm = (MainWindowViewModel)DataContext;
        }

        #region Инициализация DataGrid для начальной формы задачи

        private void InitGoalFunc() {
            
            initGoalFunctionDataGrid.Items.Clear();
            initGoalFunctionDataGrid.Columns.Clear();
            
            initGoalFuncDataTable = new DataTable();
            for (int i = 0; i < int.Parse(vm.Columns); i++) {
                initGoalFuncDataTable.Columns.Add($"x{i + 1}", typeof(string));
            }
            initGoalFuncDataTable.Columns.Add("aim", typeof(string));


            DataRow row = initGoalFuncDataTable.NewRow();
            for (int i = 0; i < initGoalFuncDataTable.Columns.Count; i++)
                row[i] = "0";
            row[initGoalFuncDataTable.Columns.Count - 1] = "min";

            initGoalFuncDataTable.Rows.Add(row);
            initGoalFunctionDataGrid.ItemsSource = initGoalFuncDataTable.DefaultView;
        }

        private void InitLimitSystem() {
            int rows = int.Parse(vm.Rows);
            int columns = int.Parse(vm.Columns);

            initLimitSystemDataGrid.Items.Clear();
            initLimitSystemDataGrid.Columns.Clear();

            initLimitSystemDataTable = new DataTable();

            for (int i = 0; i < columns; i++)
                initLimitSystemDataTable.Columns.Add($"x{i + 1}", typeof(string));

            initLimitSystemDataTable.Columns.Add("<=>", typeof(string));
            initLimitSystemDataTable.Columns.Add("b", typeof(string));

            DataRow currentRow;
            for (int i = 0; i < rows; i++) {
                currentRow = initLimitSystemDataTable.NewRow();
                for (int j = 0; j < columns; j++)
                    currentRow[j] = "0";

                currentRow[columns] = "=";
                currentRow[columns + 1] = "0";
                initLimitSystemDataTable.Rows.Add(currentRow);
            }

            initLimitSystemDataGrid.ItemsSource = initLimitSystemDataTable.DefaultView;
        }

        private void InitCompareOperators() {
            int columns = int.Parse(vm.Columns);

            compareOperatorDataGrid.Items.Clear();
            compareOperatorDataGrid.Columns.Clear();
            compareOperatorDataTable = new DataTable();

            for (int i = 0; i < columns; i++)
                compareOperatorDataTable.Columns.Add($"x{i + 1}", typeof(string));

            DataRow row = compareOperatorDataTable.NewRow();
            for (int i = 0; i < columns; i++)
                row[i] = ">=";

            compareOperatorDataTable.Rows.Add(row);
            compareOperatorDataGrid.ItemsSource = compareOperatorDataTable.DefaultView;
        }

        private void InitAll() {
            InitGoalFunc();
            InitLimitSystem();
            InitCompareOperators();
        }

        #endregion

        #region Обновление и инициализация задачи

        private CompareOperator GetCompareOperator(string str) {
            str = str.ToLower();
            switch (str) {
                case "<=":
                    return CompareOperator.Less;
                case ">=":
                    return CompareOperator.More;
                case "undefined":
                    return CompareOperator.Undefined;
                case "=":
                    return CompareOperator.Equal;
            }

            throw new Exception();
        }

        private GoalFunctionAim GetAim(string str) {
            str = str.ToLower();
            switch (str) {
                case "min":
                    return GoalFunctionAim.Min;
                case "max":
                    return GoalFunctionAim.Max;
            }

            throw new Exception();
        }
        
        private GoalFunction GetGoalFunction() {
            List<double> vars = new List<double>();
            for (int i = 0; i < initGoalFuncDataTable.Columns.Count - 1; i++) {
                vars.Add(double.Parse((string)initGoalFuncDataTable.DefaultView[0][i]));
            }

            GoalFunctionAim aim =
                GetAim((string)initGoalFuncDataTable.DefaultView[0][initGoalFuncDataTable.Columns.Count - 1]);

            GoalFunction result = new GoalFunction(vars, aim);
            return result;
        }

        private MathExpression GetMathExpression(int rowNum) {
            int columns = initLimitSystemDataTable.Columns.Count - 2;
            List<double> vars = new List<double>();
            for (int i = 0; i < columns; i++)
                vars.Add(double.Parse((string)initLimitSystemDataTable.DefaultView[rowNum][i]));

            CompareOperator compareOperator =
                GetCompareOperator((string)initLimitSystemDataTable.DefaultView[rowNum][columns]);
            double freeValue = double.Parse((string)initLimitSystemDataTable.DefaultView[rowNum][columns + 1]);

            MathExpression result = new MathExpression(vars, compareOperator, freeValue);

            return result;
        }

        private MathExpressionSystem GetMathExpressionSystem() {
            int rows = initLimitSystemDataTable.Rows.Count;
            List<IMathExpression> mathExpressions = new List<IMathExpression>();

            for (int i = 0; i < rows; i++)
                mathExpressions.Add(GetMathExpression(i));

            MathExpressionSystem result = new MathExpressionSystem(mathExpressions);
            return result;
        }

        private CompareOperator[] GetCompareOperators() {
            int columns = compareOperatorDataTable.Columns.Count;
            CompareOperator[] result = new CompareOperator[columns];

            for (int i = 0; i < columns; i++)
                result[i] = GetCompareOperator((string)compareOperatorDataTable.DefaultView[0][i]);

            return result;
        }
        
        private void InitLinearProgrammingTask() {
            GoalFunction goalFunction = GetGoalFunction();
            MathExpressionSystem limitSystem = GetMathExpressionSystem();
            CompareOperator[] compareOperators = GetCompareOperators();

            task = new LinearProgrammingTask(goalFunction, limitSystem, compareOperators);
        }

        private void MakeCanonical() => task?.MakeCanonical();



        #endregion

        #region Инициализация DataGrid и DataTable для канонической формы задачи

        private string ReturnCompareOperatorStirng(CompareOperator compareOperator) {
            switch (compareOperator) {
                case CompareOperator.Equal:
                    return "=";
                case CompareOperator.Less:
                    return "<=";
                case CompareOperator.More:
                    return ">=";
                case CompareOperator.Undefined:
                    return "undefined";
            }

            throw new Exception();
        }
        
        private string ReturnGoalFuncAimString(GoalFunctionAim aim) {
            switch (aim) {
                case GoalFunctionAim.Max:
                    return "max";
                case GoalFunctionAim.Min:
                    return "min";
            }


            throw new Exception();
        }


        

        private void InitCanonGoalFunctionDataGrid() {
            if (task == null) return;

            canonGoalFuncDataGrid.Items.Clear();
            canonGoalFuncDataGrid.Columns.Clear();
            canonGoalFuncDataTable = new DataTable();

            for (int i = 0; i < task.GoalFunction.Count; i++)
                canonGoalFuncDataTable.Columns.Add($"x{i + 1}", typeof(string));

            canonGoalFuncDataTable.Columns.Add("aim", typeof(string));

            DataRow row = canonGoalFuncDataTable.NewRow();
            for (int i = 0; i < task.GoalFunction.Count; i++)
                row[i] = task.GoalFunction[i].ToString();

            row[task.GoalFunction.Count] = ReturnGoalFuncAimString(task.GoalFunction.Aim);

            canonGoalFuncDataTable.Rows.Add(row);
            canonGoalFuncDataGrid.ItemsSource = canonGoalFuncDataTable.DefaultView;
        }

        private void InitCanonLimitSystemDataGrid() {
            if (task == null) return;

            int rows = task.LimitSystem.limits.Count;
            int columns = task.LimitSystem.limits[0].VariableValues.Count;

            canonLimitSystem.Items.Clear();
            canonLimitSystem.Columns.Clear();
            canonLimitSystemDataTable = new DataTable();

            for (int i = 0; i < columns; i++)
                canonLimitSystemDataTable.Columns.Add($"x{i + 1}", typeof(string));

            canonLimitSystemDataTable.Columns.Add("<=>", typeof(string));
            canonLimitSystemDataTable.Columns.Add("b", typeof(string));

            DataRow currentRow;
            for (int i = 0; i < rows; i++) {
                currentRow = canonLimitSystemDataTable.NewRow();
                for (int j = 0; j < columns; j++)
                    currentRow[j] = task.LimitSystem[i][j];
                currentRow[columns] = ReturnCompareOperatorStirng(task.LimitSystem[i].ComparerOperator);
                currentRow[columns + 1] = task.LimitSystem[i].FreeValue;

                canonLimitSystemDataTable.Rows.Add(currentRow);
            }

            canonLimitSystem.ItemsSource = canonLimitSystemDataTable.DefaultView;
        }

        private void InitCanonSolutionDataGrid() {
            if (task == null) return;


        }

        #endregion




        #region События

        private void generateButton_Click(object sender, RoutedEventArgs e) {
            InitAll();
        }

        private void makeCanonButton_Click(object sender, RoutedEventArgs e) {
            InitLinearProgrammingTask();
            MakeCanonical();
            InitCanonGoalFunctionDataGrid();
            InitCanonLimitSystemDataGrid();
        }

        #endregion

    }

}
