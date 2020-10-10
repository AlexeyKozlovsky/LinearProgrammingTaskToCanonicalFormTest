using LPTKF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWinFormsCore {
    public partial class Form1 : Form {
        private LinearProgrammingTask task;
        public Form1() {
            InitializeComponent();
        }

        private void InitInitGoalFuncDataGridView() {
            initGoalFuncDataGrid.DataSource = task;
        }

    }
}
