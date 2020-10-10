namespace WinFormsTestProject {
    partial class Form1 {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.initGoalFunctionDataGrid = new System.Windows.Forms.DataGridView();
            this.canonGoalFunctionDataGrid = new System.Windows.Forms.DataGridView();
            this.initLimitSystemDataGrid = new System.Windows.Forms.DataGridView();
            this.canonLimitSystemDataGrid = new System.Windows.Forms.DataGridView();
            this.solutionFieldDataGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.varsLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.initCompareOperatorsDataGrid = new System.Windows.Forms.DataGridView();
            this.rowsTextBox = new System.Windows.Forms.TextBox();
            this.columnsTextBox = new System.Windows.Forms.TextBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.forwardSolutionButton = new System.Windows.Forms.Button();
            this.backSolutionButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.initGoalFunctionDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canonGoalFunctionDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.initLimitSystemDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canonLimitSystemDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.solutionFieldDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.initCompareOperatorsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.initCompareOperatorsDataGrid);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.initLimitSystemDataGrid);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.initGoalFunctionDataGrid);
            this.panel1.Location = new System.Drawing.Point(12, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(381, 573);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.backSolutionButton);
            this.panel2.Controls.Add(this.forwardSolutionButton);
            this.panel2.Controls.Add(this.varsLabel);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.solutionFieldDataGrid);
            this.panel2.Controls.Add(this.canonLimitSystemDataGrid);
            this.panel2.Controls.Add(this.canonGoalFunctionDataGrid);
            this.panel2.Location = new System.Drawing.Point(399, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(389, 573);
            this.panel2.TabIndex = 1;
            // 
            // initGoalFunctionDataGrid
            // 
            this.initGoalFunctionDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.initGoalFunctionDataGrid.Location = new System.Drawing.Point(3, 37);
            this.initGoalFunctionDataGrid.Name = "initGoalFunctionDataGrid";
            this.initGoalFunctionDataGrid.RowHeadersWidth = 51;
            this.initGoalFunctionDataGrid.RowTemplate.Height = 24;
            this.initGoalFunctionDataGrid.Size = new System.Drawing.Size(375, 49);
            this.initGoalFunctionDataGrid.TabIndex = 0;
            // 
            // canonGoalFunctionDataGrid
            // 
            this.canonGoalFunctionDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.canonGoalFunctionDataGrid.Location = new System.Drawing.Point(3, 37);
            this.canonGoalFunctionDataGrid.Name = "canonGoalFunctionDataGrid";
            this.canonGoalFunctionDataGrid.RowHeadersWidth = 51;
            this.canonGoalFunctionDataGrid.RowTemplate.Height = 24;
            this.canonGoalFunctionDataGrid.Size = new System.Drawing.Size(383, 49);
            this.canonGoalFunctionDataGrid.TabIndex = 1;
            // 
            // initLimitSystemDataGrid
            // 
            this.initLimitSystemDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.initLimitSystemDataGrid.Location = new System.Drawing.Point(3, 133);
            this.initLimitSystemDataGrid.Name = "initLimitSystemDataGrid";
            this.initLimitSystemDataGrid.RowHeadersWidth = 51;
            this.initLimitSystemDataGrid.RowTemplate.Height = 24;
            this.initLimitSystemDataGrid.Size = new System.Drawing.Size(375, 150);
            this.initLimitSystemDataGrid.TabIndex = 1;
            // 
            // canonLimitSystemDataGrid
            // 
            this.canonLimitSystemDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.canonLimitSystemDataGrid.Location = new System.Drawing.Point(3, 133);
            this.canonLimitSystemDataGrid.Name = "canonLimitSystemDataGrid";
            this.canonLimitSystemDataGrid.RowHeadersWidth = 51;
            this.canonLimitSystemDataGrid.RowTemplate.Height = 24;
            this.canonLimitSystemDataGrid.Size = new System.Drawing.Size(383, 150);
            this.canonLimitSystemDataGrid.TabIndex = 2;
            // 
            // solutionFieldDataGrid
            // 
            this.solutionFieldDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.solutionFieldDataGrid.Location = new System.Drawing.Point(3, 328);
            this.solutionFieldDataGrid.Name = "solutionFieldDataGrid";
            this.solutionFieldDataGrid.RowHeadersWidth = 51;
            this.solutionFieldDataGrid.RowTemplate.Height = 24;
            this.solutionFieldDataGrid.Size = new System.Drawing.Size(383, 150);
            this.solutionFieldDataGrid.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(99, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Целевая функция";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(84, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Целевая функция";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(99, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Система ограничений";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(84, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(218, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Система ограничений";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(96, 300);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Опорные решения";
            // 
            // varsLabel
            // 
            this.varsLabel.AutoSize = true;
            this.varsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.varsLabel.Location = new System.Drawing.Point(3, 520);
            this.varsLabel.Name = "varsLabel";
            this.varsLabel.Size = new System.Drawing.Size(183, 25);
            this.varsLabel.TabIndex = 7;
            this.varsLabel.Text = "Опорные решения";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(78, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(239, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Условия на переменные";
            // 
            // initCompareOperatorsDataGrid
            // 
            this.initCompareOperatorsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.initCompareOperatorsDataGrid.Location = new System.Drawing.Point(3, 328);
            this.initCompareOperatorsDataGrid.Name = "initCompareOperatorsDataGrid";
            this.initCompareOperatorsDataGrid.RowHeadersWidth = 51;
            this.initCompareOperatorsDataGrid.RowTemplate.Height = 24;
            this.initCompareOperatorsDataGrid.Size = new System.Drawing.Size(375, 49);
            this.initCompareOperatorsDataGrid.TabIndex = 6;
            // 
            // rowsTextBox
            // 
            this.rowsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rowsTextBox.Location = new System.Drawing.Point(12, 22);
            this.rowsTextBox.Name = "rowsTextBox";
            this.rowsTextBox.Size = new System.Drawing.Size(100, 27);
            this.rowsTextBox.TabIndex = 2;
            // 
            // columnsTextBox
            // 
            this.columnsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.columnsTextBox.Location = new System.Drawing.Point(118, 22);
            this.columnsTextBox.Name = "columnsTextBox";
            this.columnsTextBox.Size = new System.Drawing.Size(100, 27);
            this.columnsTextBox.TabIndex = 3;
            // 
            // generateButton
            // 
            this.generateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.generateButton.Location = new System.Drawing.Point(225, 22);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(168, 27);
            this.generateButton.TabIndex = 4;
            this.generateButton.Text = "Сгенерировать";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(27, -1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Строки";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(125, -1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "Столбцы";
            // 
            // forwardSolutionButton
            // 
            this.forwardSolutionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.forwardSolutionButton.Location = new System.Drawing.Point(61, 490);
            this.forwardSolutionButton.Name = "forwardSolutionButton";
            this.forwardSolutionButton.Size = new System.Drawing.Size(52, 27);
            this.forwardSolutionButton.TabIndex = 9;
            this.forwardSolutionButton.Text = "->";
            this.forwardSolutionButton.UseVisualStyleBackColor = true;
            // 
            // backSolutionButton
            // 
            this.backSolutionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backSolutionButton.Location = new System.Drawing.Point(3, 490);
            this.backSolutionButton.Name = "backSolutionButton";
            this.backSolutionButton.Size = new System.Drawing.Size(52, 27);
            this.backSolutionButton.TabIndex = 10;
            this.backSolutionButton.Text = "<-";
            this.backSolutionButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 641);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.columnsTextBox);
            this.Controls.Add(this.rowsTextBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.initGoalFunctionDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canonGoalFunctionDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.initLimitSystemDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canonLimitSystemDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.solutionFieldDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.initCompareOperatorsDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView initLimitSystemDataGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView initGoalFunctionDataGrid;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView solutionFieldDataGrid;
        private System.Windows.Forms.DataGridView canonLimitSystemDataGrid;
        private System.Windows.Forms.DataGridView canonGoalFunctionDataGrid;
        private System.Windows.Forms.DataGridView initCompareOperatorsDataGrid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label varsLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button backSolutionButton;
        private System.Windows.Forms.Button forwardSolutionButton;
        private System.Windows.Forms.TextBox rowsTextBox;
        private System.Windows.Forms.TextBox columnsTextBox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

