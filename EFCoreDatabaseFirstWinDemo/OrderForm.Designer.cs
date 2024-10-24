namespace EFCoreDatabaseFirstWinDemo
{
    partial class OrderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            detailsDataGridView = new DataGridView();
            ColumnProductName = new DataGridViewTextBoxColumn();
            ColumnUnitPrice = new DataGridViewTextBoxColumn();
            ColumnQuantity = new DataGridViewTextBoxColumn();
            employeeComboBox = new ComboBox();
            customerComboBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)detailsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // detailsDataGridView
            // 
            detailsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            detailsDataGridView.Columns.AddRange(new DataGridViewColumn[] { ColumnProductName, ColumnUnitPrice, ColumnQuantity });
            detailsDataGridView.Location = new Point(34, 191);
            detailsDataGridView.Name = "detailsDataGridView";
            detailsDataGridView.Size = new Size(614, 291);
            detailsDataGridView.TabIndex = 0;
            // 
            // ColumnProductName
            // 
            ColumnProductName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnProductName.DataPropertyName = "ProductName";
            ColumnProductName.HeaderText = "Product name";
            ColumnProductName.Name = "ColumnProductName";
            // 
            // ColumnUnitPrice
            // 
            ColumnUnitPrice.DataPropertyName = "UnitPrice";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnUnitPrice.DefaultCellStyle = dataGridViewCellStyle1;
            ColumnUnitPrice.HeaderText = "Unit price";
            ColumnUnitPrice.Name = "ColumnUnitPrice";
            // 
            // ColumnQuantity
            // 
            ColumnQuantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            ColumnQuantity.DefaultCellStyle = dataGridViewCellStyle2;
            ColumnQuantity.HeaderText = "Quantity";
            ColumnQuantity.Name = "ColumnQuantity";
            // 
            // employeeComboBox
            // 
            employeeComboBox.FormattingEnabled = true;
            employeeComboBox.Location = new Point(45, 89);
            employeeComboBox.Name = "employeeComboBox";
            employeeComboBox.Size = new Size(121, 23);
            employeeComboBox.TabIndex = 1;
            // 
            // customerComboBox
            // 
            customerComboBox.FormattingEnabled = true;
            customerComboBox.Location = new Point(351, 89);
            customerComboBox.Name = "customerComboBox";
            customerComboBox.Size = new Size(121, 23);
            customerComboBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 66);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 3;
            label1.Text = "Employee";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(353, 67);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 4;
            label2.Text = "Customer";
            // 
            // button1
            // 
            button1.Location = new Point(525, 528);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(31, 162);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 6;
            button2.Text = "Add Item";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(660, 567);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(customerComboBox);
            Controls.Add(employeeComboBox);
            Controls.Add(detailsDataGridView);
            Name = "OrderForm";
            Text = "OrderForm";
            ((System.ComponentModel.ISupportInitialize)detailsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView detailsDataGridView;
        private ComboBox employeeComboBox;
        private ComboBox customerComboBox;
        private Label label1;
        private Label label2;
        private DataGridViewTextBoxColumn ColumnProductName;
        private DataGridViewTextBoxColumn ColumnUnitPrice;
        private DataGridViewTextBoxColumn ColumnQuantity;
        private Button button1;
        private Button button2;
    }
}