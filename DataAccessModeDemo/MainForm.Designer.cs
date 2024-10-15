namespace DataAccessModeDemo
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ordersDataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)ordersDataGridView).BeginInit();
            SuspendLayout();
            // 
            // ordersDataGridView
            // 
            ordersDataGridView.AllowUserToAddRows = false;
            ordersDataGridView.AllowUserToDeleteRows = false;
            ordersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ordersDataGridView.Dock = DockStyle.Fill;
            ordersDataGridView.Location = new Point(0, 0);
            ordersDataGridView.Name = "ordersDataGridView";
            ordersDataGridView.ReadOnly = true;
            ordersDataGridView.Size = new Size(800, 450);
            ordersDataGridView.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ordersDataGridView);
            Name = "MainForm";
            Text = "Main Form";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)ordersDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView ordersDataGridView;
    }
}
