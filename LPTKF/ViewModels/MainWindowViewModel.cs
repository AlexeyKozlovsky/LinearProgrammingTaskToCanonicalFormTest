using LPTKF.Models;
using LPTKF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace LPTKF.ViewModels {
    class MainWindowViewModel : ViewModel {

        #region Строки и столбцы
        private string rows = "3";
        public string Rows {
            get => rows;
            set => Set(ref rows, value);
        }

        private string columns = "3";
        public string Columns {
            get => columns;
            set => Set(ref columns, value);
        }
        #endregion


        private GoalFunctionDataGridItem goalFuncDataGrid;
        public GoalFunctionDataGridItem GoalFuncDataGrid{
            get => goalFuncDataGrid;
            set => Set(ref goalFuncDataGrid, value);
        }
    }
}
