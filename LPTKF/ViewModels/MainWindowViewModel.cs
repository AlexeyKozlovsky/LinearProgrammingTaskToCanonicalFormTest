using LPTKF.Infrastructure.Commands;
using LPTKF.Models;
using LPTKF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

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


        #region Команды

        public ICommand InitDataGridsCommand { get; }
        private bool OnInitDataGridCommandExecute(object p) {
            try {
                if (int.Parse(Rows) <= 0) return false;
                if (int.Parse(Columns) <= 0) return false;
            } catch {
                return false;
            }
            return true;
        }
        private void OnInitDataGridCommandExecuted(object p) {

        }

        #endregion

        private GoalFunction goalFuncDataGrid;
        public GoalFunction InitGoalFuncDataGrid{
            get => goalFuncDataGrid;
            set => Set(ref goalFuncDataGrid, value);
        }

        private List<string[]> goalFuncVarsStrings = new List<string[]>() {
            new string[4]{"1", "5", "3", "6"}
        };
        public List<string[]> GoalFuncVarsString {
            get => goalFuncVarsStrings;
            set => Set(ref goalFuncVarsStrings, value);
        }

        

        public MainWindowViewModel() {
            InitDataGridsCommand = new LambdaCommand(OnInitDataGridCommandExecuted, OnInitDataGridCommandExecute);
        }
    }
}
