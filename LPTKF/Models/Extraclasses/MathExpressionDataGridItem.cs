using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace LPTKF.Models.Extraclasses {
    class MathExpressionDataGridItem {
        static readonly string defaultTextBoxValue = "0";
        static readonly string[] compareOperatorsStrings = new string[3] { "<=", "=", "=>" };

        TextBox[] varsTextBoxes;
        ComboBox compareOperatorComboBox;
        TextBox freeValueTextBox;

        public MathExpressionDataGridItem(int columns) {
            varsTextBoxes = new TextBox[columns];
            for (int i = 0; i < varsTextBoxes.Length; i++)
                varsTextBoxes[i].Text = defaultTextBoxValue;

            compareOperatorComboBox = new ComboBox();
            for (int i = 0; i < compareOperatorsStrings.Length; i++)
                compareOperatorComboBox.Items.Add(compareOperatorsStrings[i]);

            freeValueTextBox = new TextBox();
            freeValueTextBox.Text = defaultTextBoxValue;
        }
    }
}
