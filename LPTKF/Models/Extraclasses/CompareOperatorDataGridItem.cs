using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace LPTKF.Models.Extraclasses {
    class CompareOperatorDataGridItem {
        private ComboBox[] comboBoxes;
        private static string[] stringItems = new string[3] { ">=", "<=", "Undefined" };

        public CompareOperatorDataGridItem(int columns) {
            this.comboBoxes = new ComboBox[columns];
            
            for (int i = 0; i < columns; i++)
                for (int j = 0; j < stringItems.Length; j++)
                    this.comboBoxes[i].Items.Add(stringItems[j]);
        }
    }
}
