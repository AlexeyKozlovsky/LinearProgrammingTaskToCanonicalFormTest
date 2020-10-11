using LPTKF.Models;
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

namespace LPTKF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        LinearProgrammingTask task;
        MainWindowViewModel vm;

        DataTable initGoalFuncDataTable;

        #region Команды

        
        #endregion

        public MainWindow() {
            InitializeComponent();
            vm = (MainWindowViewModel)DataContext;
        }

        private void InitDataGrid(DataGrid dataGrid) {
            DataGridColumn column;
            int columnsNum = int.Parse(vm.Columns);
            for (int i = 0; i < columnsNum; i++) {
                column = new DataGridTextColumn();
                column.Header = $"x{i + 1}";
                dataGrid.Columns.Add(column);
            }
        }

        private void TestDataGrid() {
            
        }

        private void InitGoalFunc() {
            initGoalFunctionDataGrid.Items.Clear();
            initGoalFuncDataTable = new DataTable();
            for (int i = 0; i < int.Parse(vm.Columns); i++) {
                initGoalFuncDataTable.Columns.Add($"x{i + 1}", typeof(string));
            }

            foreach (DataColumn col in initGoalFuncDataTable.Columns) {
                initGoalFunctionDataGrid.Columns.Add(new DataGridTextColumn() {
                    Header = col.ColumnName,
                    Binding = new Binding(String.Format("[{0}]", col.ColumnName))
                });
            }
            DataRow row = initGoalFuncDataTable.NewRow();
            row[0] = "1";
            row[1] = "1";
            row[2] = "2";
            initGoalFuncDataTable.Rows.Add(row);
            initGoalFunctionDataGrid.ItemsSource = initGoalFuncDataTable.DefaultView;


        }

        private void InitAllInitDataGrids() {
            


            initGoalFunctionDataGrid.Columns.Clear();
            initLimitSystemDataGrid.Columns.Clear();
            compareOperatorDataGrid.Columns.Clear();

            InitDataGrid(initGoalFunctionDataGrid);
            DataGridColumn column = new DataGridComboBoxColumn();
            column.Header = "->";
            initGoalFunctionDataGrid.Columns.Add(column);


            InitDataGrid(initLimitSystemDataGrid);
            column = new DataGridComboBoxColumn();
            column.Header = "<=>";
            initLimitSystemDataGrid.Columns.Add(column);
            column = new DataGridTextColumn();
            column.Header = "b";
            initLimitSystemDataGrid.Columns.Add(column);


            for (int i = 0; i < int.Parse(vm.Columns); i++) {
                column = new DataGridComboBoxColumn();
                column.Header = $"x{i + 1}";
                compareOperatorDataGrid.Columns.Add(column);
            }
        }

        private void generateButton_Click(object sender, RoutedEventArgs e) {
            InitGoalFunc();
        }
    }
}
