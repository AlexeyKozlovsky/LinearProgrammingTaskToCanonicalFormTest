using LPTKF.Models;
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

namespace LPTKF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        LinearProgrammingTask task;
        MainWindowViewModel vm;


        public MainWindow() {
            InitializeComponent();
            vm = (MainWindowViewModel)DataContext;
            
            InitDataGrid(initGoalFuncDataGrid);
            
        }

        private void InitDataGrid(DataGrid dataGrid) {
            DataGridColumn column;
            int columnsNum = int.Parse(vm.Columns);
            for (int i = 0; i < columnsNum; i++) {
                column = new DataGridTextColumn();
                column.Header = $"x{i + 1}";
                dataGrid.Columns.Add(column);
            }

            column = new DataGridComboBoxColumn();
            column.Header = "Знак";
            dataGrid.Columns.Add(column);

            column = new DataGridTextColumn();
            column.Header = "b";
            dataGrid.Columns.Add(column);
        }
    }
}
