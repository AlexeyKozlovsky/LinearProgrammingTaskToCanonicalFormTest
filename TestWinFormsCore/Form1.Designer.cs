namespace TestWinFormsCore {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.initGoalFuncDataGrid = new System.Windows.Forms.DataGridView();
            this.initLimitSystemDataGrid = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.compareOperatorsDataGrid = new System.Windows.Forms.DataGridView();
            this.solutionFieldDataGrid = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.canonLimitSystemDataGrid = new System.Windows.Forms.DataGridView();
            this.canonGoalFuncDataGrid = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rowsTextBox = new System.Windows.Forms.TextBox();
            this.columnsTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.generateButton = new System.Windows.Forms.Button();
            this.newVarsLabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.forwardButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.initGoalFuncDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.initLimitSystemDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compareOperatorsDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.solutionFieldDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canonLimitSystemDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canonGoalFuncDataGrid)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.compareOperatorsDataGrid);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.initLimitSystemDataGrid);
            this.panel1.Controls.Add(this.initGoalFuncDataGrid);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(11, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(323, 524);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(68, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Целевая функция";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(47, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Система ограничений";
            // 
            // initGoalFuncDataGrid
            // 
            this.initGoalFuncDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.initGoalFuncDataGrid.Location = new System.Drawing.Point(0, 43);
            this.initGoalFuncDataGrid.Name = "initGoalFuncDataGrid";
            this.initGoalFuncDataGrid.RowHeadersWidth = 51;
            this.initGoalFuncDataGrid.Size = new System.Drawing.Size(323, 47);
            this.initGoalFuncDataGrid.TabIndex = 2;
            this.initGoalFuncDataGrid.Text = "dataGridView1";
            // 
            // initLimitSystemDataGrid
            // 
            this.initLimitSystemDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.initLimitSystemDataGrid.Location = new System.Drawing.Point(0, 124);
            this.initLimitSystemDataGrid.Name = "initLimitSystemDataGrid";
            this.initLimitSystemDataGrid.RowHeadersWidth = 51;
            this.initLimitSystemDataGrid.Size = new System.Drawing.Size(323, 133);
            this.initLimitSystemDataGrid.TabIndex = 2;
            this.initLimitSystemDataGrid.Text = "dataGridView2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(47, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 28);
            this.label3.TabIndex = 1;
            this.label3.Text = "Условия на переменные";
            // 
            // compareOperatorsDataGrid
            // 
            this.compareOperatorsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.compareOperatorsDataGrid.Location = new System.Drawing.Point(0, 291);
            this.compareOperatorsDataGrid.Name = "compareOperatorsDataGrid";
            this.compareOperatorsDataGrid.RowHeadersWidth = 51;
            this.compareOperatorsDataGrid.Size = new System.Drawing.Size(323, 44);
            this.compareOperatorsDataGrid.TabIndex = 2;
            this.compareOperatorsDataGrid.Text = "dataGridView3";
            // 
            // solutionFieldDataGrid
            // 
            this.solutionFieldDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.solutionFieldDataGrid.Location = new System.Drawing.Point(0, 291);
            this.solutionFieldDataGrid.Name = "solutionFieldDataGrid";
            this.solutionFieldDataGrid.RowHeadersWidth = 51;
            this.solutionFieldDataGrid.Size = new System.Drawing.Size(323, 141);
            this.solutionFieldDataGrid.TabIndex = 2;
            this.solutionFieldDataGrid.Text = "dataGridView4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(47, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(236, 28);
            this.label4.TabIndex = 1;
            this.label4.Text = "Условия на переменные";
            // 
            // canonLimitSystemDataGrid
            // 
            this.canonLimitSystemDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.canonLimitSystemDataGrid.Location = new System.Drawing.Point(0, 124);
            this.canonLimitSystemDataGrid.Name = "canonLimitSystemDataGrid";
            this.canonLimitSystemDataGrid.RowHeadersWidth = 51;
            this.canonLimitSystemDataGrid.Size = new System.Drawing.Size(323, 133);
            this.canonLimitSystemDataGrid.TabIndex = 2;
            this.canonLimitSystemDataGrid.Text = "dataGridView5";
            // 
            // canonGoalFuncDataGrid
            // 
            this.canonGoalFuncDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.canonGoalFuncDataGrid.Location = new System.Drawing.Point(0, 43);
            this.canonGoalFuncDataGrid.Name = "canonGoalFuncDataGrid";
            this.canonGoalFuncDataGrid.RowHeadersWidth = 51;
            this.canonGoalFuncDataGrid.Size = new System.Drawing.Size(323, 47);
            this.canonGoalFuncDataGrid.TabIndex = 2;
            this.canonGoalFuncDataGrid.Text = "dataGridView6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(47, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 28);
            this.label5.TabIndex = 1;
            this.label5.Text = "Система ограничений";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(68, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 28);
            this.label6.TabIndex = 1;
            this.label6.Text = "Целевая функция";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.forwardButton);
            this.panel2.Controls.Add(this.backButton);
            this.panel2.Controls.Add(this.newVarsLabel);
            this.panel2.Controls.Add(this.solutionFieldDataGrid);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.canonLimitSystemDataGrid);
            this.panel2.Controls.Add(this.canonGoalFuncDataGrid);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(340, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(323, 524);
            this.panel2.TabIndex = 0;
            // 
            // rowsTextBox
            // 
            this.rowsTextBox.Location = new System.Drawing.Point(11, 33);
            this.rowsTextBox.Name = "rowsTextBox";
            this.rowsTextBox.Size = new System.Drawing.Size(125, 27);
            this.rowsTextBox.TabIndex = 1;
            // 
            // columnsTextBox
            // 
            this.columnsTextBox.Location = new System.Drawing.Point(148, 33);
            this.columnsTextBox.Name = "columnsTextBox";
            this.columnsTextBox.Size = new System.Drawing.Size(125, 27);
            this.columnsTextBox.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(39, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Строки";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(174, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "Столбцы";
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(279, 32);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(143, 29);
            this.generateButton.TabIndex = 2;
            this.generateButton.Text = "Сгенерировать";
            this.generateButton.UseVisualStyleBackColor = true;
            // 
            // newVarsLabel
            // 
            this.newVarsLabel.AutoSize = true;
            this.newVarsLabel.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.newVarsLabel.Location = new System.Drawing.Point(6, 470);
            this.newVarsLabel.Name = "newVarsLabel";
            this.newVarsLabel.Size = new System.Drawing.Size(211, 25);
            this.newVarsLabel.TabIndex = 1;
            this.newVarsLabel.Text = "Условия на переменные";
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(6, 438);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(61, 29);
            this.backButton.TabIndex = 2;
            this.backButton.Text = "<-";
            this.backButton.UseVisualStyleBackColor = true;
            // 
            // forwardButton
            // 
            this.forwardButton.Location = new System.Drawing.Point(73, 438);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(61, 29);
            this.forwardButton.TabIndex = 2;
            this.forwardButton.Text = "->";
            this.forwardButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 620);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.columnsTextBox);
            this.Controls.Add(this.rowsTextBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.initGoalFuncDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.initLimitSystemDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compareOperatorsDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.solutionFieldDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canonLimitSystemDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canonGoalFuncDataGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView compareOperatorsDataGrid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView initLimitSystemDataGrid;
        private System.Windows.Forms.DataGridView initGoalFuncDataGrid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView solutionFieldDataGrid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView canonLimitSystemDataGrid;
        private System.Windows.Forms.DataGridView canonGoalFuncDataGrid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label newVarsLabel;
        private System.Windows.Forms.TextBox rowsTextBox;
        private System.Windows.Forms.TextBox columnsTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button generateButton;
    }
}

