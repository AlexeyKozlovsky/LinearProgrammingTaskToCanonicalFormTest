using LPTKF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace LPTKF.ViewModels {
    class MainWindowViewModel : ViewModel {
        #region Характеристики изначальной формы задачи

        private string variablesInitCount;
        public string VariablesInitCount {
            get => variablesInitCount;
            set => Set(ref variablesInitCount, value);
        }

        private string limitSystemExpressionCount;
        public string LimitSystemExpressionsCount {
            get => limitSystemExpressionCount;
            set => Set(ref limitSystemExpressionCount, value);
        }

        private int goalFunctionAimIndex = 0;
        public int GoalFunctionAimIndex {
            get => goalFunctionAimIndex;
            set => Set(ref goalFunctionAimIndex, value);
        }

        private List<int> limitCompareOperatorsIndex = new List<int>();
        public List<int> LimitCompareOperatorsIndex {
            get => limitCompareOperatorsIndex;
            set => Set(ref limitCompareOperatorsIndex, value);
        }


        #endregion
    }
}
