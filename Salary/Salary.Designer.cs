namespace Salary
{
    partial class Salary
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
            this.components = new System.ComponentModel.Container();
            this.dataGridViewSalary = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtBonus = new System.Windows.Forms.TextBox();
            this.txtSalaryTaken = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbReason = new System.Windows.Forms.RichTextBox();
            this.btnAddSalary = new System.Windows.Forms.Button();
            this.dtpDateSalaryAdded = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalary)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewSalary
            // 
            this.dataGridViewSalary.AllowUserToAddRows = false;
            this.dataGridViewSalary.AllowUserToDeleteRows = false;
            this.dataGridViewSalary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSalary.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridViewSalary.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewSalary.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewSalary.Name = "dataGridViewSalary";
            this.dataGridViewSalary.ReadOnly = true;
            this.dataGridViewSalary.RowHeadersWidth = 51;
            this.dataGridViewSalary.RowTemplate.Height = 24;
            this.dataGridViewSalary.Size = new System.Drawing.Size(974, 370);
            this.dataGridViewSalary.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteRowToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(156, 28);
            // 
            // deleteRowToolStripMenuItem
            // 
            this.deleteRowToolStripMenuItem.Name = "deleteRowToolStripMenuItem";
            this.deleteRowToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.deleteRowToolStripMenuItem.Text = "Delete Row";
            this.deleteRowToolStripMenuItem.Click += new System.EventHandler(this.deleteRowToolStripMenuItem_Click);
            // 
            // txtBonus
            // 
            this.txtBonus.Location = new System.Drawing.Point(12, 416);
            this.txtBonus.Name = "txtBonus";
            this.txtBonus.Size = new System.Drawing.Size(256, 22);
            this.txtBonus.TabIndex = 1;
            // 
            // txtSalaryTaken
            // 
            this.txtSalaryTaken.Location = new System.Drawing.Point(6, 45);
            this.txtSalaryTaken.Name = "txtSalaryTaken";
            this.txtSalaryTaken.Size = new System.Drawing.Size(250, 22);
            this.txtSalaryTaken.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 397);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bonus";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Salary taken";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rtbReason);
            this.groupBox1.Controls.Add(this.txtSalaryTaken);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(295, 397);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 216);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Reason salary is taken";
            // 
            // rtbReason
            // 
            this.rtbReason.Location = new System.Drawing.Point(6, 105);
            this.rtbReason.Name = "rtbReason";
            this.rtbReason.Size = new System.Drawing.Size(321, 105);
            this.rtbReason.TabIndex = 5;
            this.rtbReason.Text = "";
            // 
            // btnAddSalary
            // 
            this.btnAddSalary.BackColor = System.Drawing.Color.DarkGreen;
            this.btnAddSalary.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddSalary.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddSalary.ForeColor = System.Drawing.Color.White;
            this.btnAddSalary.Location = new System.Drawing.Point(725, 555);
            this.btnAddSalary.Name = "btnAddSalary";
            this.btnAddSalary.Size = new System.Drawing.Size(123, 51);
            this.btnAddSalary.TabIndex = 6;
            this.btnAddSalary.Text = "Add salary";
            this.btnAddSalary.UseVisualStyleBackColor = false;
            this.btnAddSalary.Click += new System.EventHandler(this.btnAddSalary_Click);
            // 
            // dtpDateSalaryAdded
            // 
            this.dtpDateSalaryAdded.Location = new System.Drawing.Point(663, 416);
            this.dtpDateSalaryAdded.Name = "dtpDateSalaryAdded";
            this.dtpDateSalaryAdded.Size = new System.Drawing.Size(279, 22);
            this.dtpDateSalaryAdded.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(660, 397);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Date salary added";
            // 
            // Salary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 684);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpDateSalaryAdded);
            this.Controls.Add(this.btnAddSalary);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBonus);
            this.Controls.Add(this.dataGridViewSalary);
            this.Name = "Salary";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalary)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSalary;
        private System.Windows.Forms.TextBox txtBonus;
        private System.Windows.Forms.TextBox txtSalaryTaken;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbReason;
        private System.Windows.Forms.Button btnAddSalary;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteRowToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dtpDateSalaryAdded;
        private System.Windows.Forms.Label label4;
    }
}

