using LPTKF.Models;
using System;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Media.Animation;

namespace TestConsoleFotLPTKF {
    class Program {
        private LinearProgrammingTask task;
        
        static void Main(string[] args) {
            InitLinearProgrammingTask();
        }

        private static void InitLinearProgrammingTask() {
            GoalFunction goalFunc = InitGoalFunction();
            MathExpressionSystem limitSystem = InitLimitSystem();
            CompareOperator[] compareOperators = InitCompareOperators(goalFunc.Count);
            LinearProgrammingTask task = new LinearProgrammingTask(goalFunc, limitSystem, compareOperators);
            task.MakeCanonical();
            
            
            PrintSolution(task.LinearEquationLimitSystem.SolutionsField[0]);
        }

        private static void PrintSolution(Solution solution) {
            for (int i = 0; i < solution.Rows; i++) {
                for (int j = 0; j < solution.Columns; j++) {
                    Console.Write(solution[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        private static CompareOperator[] InitCompareOperators(int varsCount) {
            CompareOperator[] result = new CompareOperator[varsCount];
            string[] input = Console.ReadLine().Split(' ');

            for (int i = 0; i < varsCount; i++)
                switch (int.Parse(input[i])) {
                    case -1:
                        result[i] = CompareOperator.Less;
                        break;
                    case 1:
                        result[i] = CompareOperator.More;
                        break;
                    case 0:
                        result[i] = CompareOperator.Undefined;
                        break;
                }

            return result;
        }

        private static MathExpression InitMathExpression(char sep = ' ') {
            Console.Write("Введите вектор переменных: ");
            double[] vars = StringToDoubleArray(Console.ReadLine().Split(sep));
            Console.Write("Введите -1 - меньше или равно, 1 - больше или равно, 0 - равно: ");
            CompareOperator compareOperator = CompareOperator.More;

            switch (int.Parse(Console.ReadLine())) {
                case -1:
                    compareOperator = CompareOperator.Less;
                    break;
                case 0:
                    compareOperator = CompareOperator.Equal;
                    break;
                case 1:
                    compareOperator = CompareOperator.More;
                    break;
            }

            Console.Write("Введите свободный член: ");
            double freeValue = double.Parse(Console.ReadLine());

            MathExpression result = new MathExpression(vars.ToList<double>(), compareOperator, freeValue);
            return result;
        }

        private static MathExpressionSystem InitLimitSystem() {
            Console.Write("Введите кол-во ограничений: ");
            MathExpressionSystem result = new MathExpressionSystem();
            int n = int.Parse(Console.ReadLine());
           
            for (int i = 0; i < n; i++)
                result.Add(InitMathExpression());

            return result;
        }

        private static GoalFunction InitGoalFunction() {
            double[] goalFuncVars = InputDouble("Введите вектор переменных целевой функции");
            GoalFunctionAim aim = GoalFunctionAim.Min;

            Console.Write("Введите -1, если на минимум, 1, если на максимум: ");
            int minmax = int.Parse(Console.ReadLine());
            switch (minmax) {
                case -1:
                    aim = GoalFunctionAim.Min;
                    break;
                case 1:
                    aim = GoalFunctionAim.Max;
                    break;
            }

            return new GoalFunction(goalFuncVars.ToList<double>(), CompareOperator.Equal, 0, aim);
        }

        private static double[] InputDouble(string message, char sep = ' ') {
            Console.Write(message);
            return StringToDoubleArray(Console.ReadLine().Split(sep));
        }

        private static double[] StringToDoubleArray(string[] stringArray) {
            int length = stringArray.Length;
            double[] result = new double[length];
            for (int i = 0; i < length; i++)
                result[i] = double.Parse(stringArray[i]);

            return result;
        }

        
    }
}
