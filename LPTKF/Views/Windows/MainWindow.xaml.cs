using LPTKF.Models;
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

namespace LPTKF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        LinearProgrammingTask task;

        public MainWindow() {
            InitializeComponent();
            List<double> goalFuncVars = new List<double>() {
                2, 3, 4, 4
            };
            double goalFuncFreeValue = 10;

            GoalFunction goal = new GoalFunction(goalFuncVars, CompareOperator.Equal, 10, GoalFunctionAim.Max);


            List<IMathExpression> mathExpressions = new List<IMathExpression>() {
                new MathExpression(new List<double>(){ 1, 2, 3, 4}, CompareOperator.Less, 10),
                new MathExpression(new List<double>(){ 8, 6, 1, 4}, CompareOperator.Equal, 10),
                new MathExpression(new List<double>(){ -4, 2, 0, 4}, CompareOperator.More, 10),
            };


            
            MathExpressionSystem limitSystem = new MathExpressionSystem(mathExpressions);

            CompareOperator[] compares = new CompareOperator[4] {
                CompareOperator.More, CompareOperator.More, CompareOperator.Undefined, CompareOperator.Less
            };

            task = new LinearProgrammingTask(goal, limitSystem, compares);

            task.MakeCanonical();
            Console.WriteLine("!");
        }
    }
}
