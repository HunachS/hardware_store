namespace BYDMIX
{
    partial class FormDelivery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewSuppliers = new System.Windows.Forms.DataGridView();
            this.listBoxResults = new System.Windows.Forms.ListBox();
            this.txtSearchDelivery = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.btnDeleteDeliv = new System.Windows.Forms.Button();
            this.btnAddDelivery = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRefreshLoadSuppliers = new System.Windows.Forms.Button();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSuppliers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewSuppliers
            // 
            this.dataGridViewSuppliers.AllowUserToAddRows = false;
            this.dataGridViewSuppliers.AllowUserToDeleteRows = false;
            this.dataGridViewSuppliers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSuppliers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(30)))));
            this.dataGridViewSuppliers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewSuppliers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewSuppliers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(23)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(198)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(198)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSuppliers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(23)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(198)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(198)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSuppliers.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewSuppliers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewSuppliers.EnableHeadersVisualStyles = false;
            this.dataGridViewSuppliers.GridColor = System.Drawing.Color.Black;
            this.dataGridViewSuppliers.Location = new System.Drawing.Point(0, 165);
            this.dataGridViewSuppliers.Name = "dataGridViewSuppliers";
            this.dataGridViewSuppliers.ReadOnly = true;
            this.dataGridViewSuppliers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(23)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(198)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSuppliers.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(23)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(198)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(198)))), ((int)(((byte)(205)))));
            this.dataGridViewSuppliers.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewSuppliers.RowTemplate.Height = 32;
            this.dataGridViewSuppliers.Size = new System.Drawing.Size(740, 510);
            this.dataGridViewSuppliers.TabIndex = 8;
            this.dataGridViewSuppliers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSuppliers_CellClick);
            this.dataGridViewSuppliers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSuppliers_CellContentClick);
            // 
            // listBoxResults
            // 
            this.listBoxResults.FormattingEnabled = true;
            this.listBoxResults.Location = new System.Drawing.Point(8, 81);
            this.listBoxResults.Name = "listBoxResults";
            this.listBoxResults.Size = new System.Drawing.Size(176, 17);
            this.listBoxResults.TabIndex = 18;
            this.listBoxResults.Visible = false;
            this.listBoxResults.SelectedIndexChanged += new System.EventHandler(this.listBoxResults_SelectedIndexChanged);
            // 
            // txtSearchDelivery
            // 
            this.txtSearchDelivery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.txtSearchDelivery.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchDelivery.Font = new System.Drawing.Font("Arial", 10F);
            this.txtSearchDelivery.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchDelivery.Location = new System.Drawing.Point(8, 49);
            this.txtSearchDelivery.Multiline = true;
            this.txtSearchDelivery.Name = "txtSearchDelivery";
            this.txtSearchDelivery.Size = new System.Drawing.Size(176, 25);
            this.txtSearchDelivery.TabIndex = 16;
            this.txtSearchDelivery.TextChanged += new System.EventHandler(this.txtSearchDelivery_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(23)))), ((int)(((byte)(40)))));
            this.btnSearch.BackgroundImage = global::BYDMIX.Properties.Resources._001_research;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(124)))), ((int)(((byte)(146)))));
            this.btnSearch.Location = new System.Drawing.Point(192, 49);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(20, 20);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(23)))), ((int)(((byte)(40)))));
            this.buttonPrint.BackgroundImage = global::BYDMIX.Properties.Resources.printer;
            this.buttonPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPrint.FlatAppearance.BorderSize = 0;
            this.buttonPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(124)))), ((int)(((byte)(146)))));
            this.buttonPrint.Location = new System.Drawing.Point(116, 20);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(20, 20);
            this.buttonPrint.TabIndex = 14;
            this.buttonPrint.UseVisualStyleBackColor = false;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // btnDeleteDeliv
            // 
            this.btnDeleteDeliv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(23)))), ((int)(((byte)(40)))));
            this.btnDeleteDeliv.BackgroundImage = global::BYDMIX.Properties.Resources.delete_button;
            this.btnDeleteDeliv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDeleteDeliv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteDeliv.FlatAppearance.BorderSize = 0;
            this.btnDeleteDeliv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteDeliv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(124)))), ((int)(((byte)(146)))));
            this.btnDeleteDeliv.Location = new System.Drawing.Point(90, 20);
            this.btnDeleteDeliv.Name = "btnDeleteDeliv";
            this.btnDeleteDeliv.Size = new System.Drawing.Size(20, 20);
            this.btnDeleteDeliv.TabIndex = 14;
            this.btnDeleteDeliv.UseVisualStyleBackColor = false;
            this.btnDeleteDeliv.Click += new System.EventHandler(this.btnDeleteDeliv_Click);
            // 
            // btnAddDelivery
            // 
            this.btnAddDelivery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(23)))), ((int)(((byte)(40)))));
            this.btnAddDelivery.BackgroundImage = global::BYDMIX.Properties.Resources.add_button;
            this.btnAddDelivery.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddDelivery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddDelivery.FlatAppearance.BorderSize = 0;
            this.btnAddDelivery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDelivery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(124)))), ((int)(((byte)(146)))));
            this.btnAddDelivery.Location = new System.Drawing.Point(64, 20);
            this.btnAddDelivery.Name = "btnAddDelivery";
            this.btnAddDelivery.Size = new System.Drawing.Size(20, 20);
            this.btnAddDelivery.TabIndex = 14;
            this.btnAddDelivery.UseVisualStyleBackColor = false;
            this.btnAddDelivery.Click += new System.EventHandler(this.btnAddDelivery_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(23)))), ((int)(((byte)(40)))));
            this.btnEdit.BackgroundImage = global::BYDMIX.Properties.Resources.edit;
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(124)))), ((int)(((byte)(146)))));
            this.btnEdit.Location = new System.Drawing.Point(38, 20);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(20, 20);
            this.btnEdit.TabIndex = 14;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRefreshLoadSuppliers
            // 
            this.btnRefreshLoadSuppliers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(23)))), ((int)(((byte)(40)))));
            this.btnRefreshLoadSuppliers.BackgroundImage = global::BYDMIX.Properties.Resources.renewable;
            this.btnRefreshLoadSuppliers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRefreshLoadSuppliers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshLoadSuppliers.FlatAppearance.BorderSize = 0;
            this.btnRefreshLoadSuppliers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshLoadSuppliers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(124)))), ((int)(((byte)(146)))));
            this.btnRefreshLoadSuppliers.Location = new System.Drawing.Point(7, 20);
            this.btnRefreshLoadSuppliers.Name = "btnRefreshLoadSuppliers";
            this.btnRefreshLoadSuppliers.Size = new System.Drawing.Size(20, 20);
            this.btnRefreshLoadSuppliers.TabIndex = 15;
            this.btnRefreshLoadSuppliers.UseVisualStyleBackColor = false;
            this.btnRefreshLoadSuppliers.Click += new System.EventHandler(this.btnRefreshLoadSuppliers_Click);
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(29, 18);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(73, 20);
            this.dateTimePickerFrom.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(198)))), ((int)(((byte)(205)))));
            this.label1.Location = new System.Drawing.Point(5, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "З:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(198)))), ((int)(((byte)(205)))));
            this.label2.Location = new System.Drawing.Point(108, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "По:";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(140, 18);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(76, 20);
            this.dateTimePickerTo.TabIndex = 19;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(12, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtSearchDelivery);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.btnSearch);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.listBoxResults);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePickerTo);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePickerFrom);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnDeleteDeliv);
            this.splitContainer1.Panel2.Controls.Add(this.buttonPrint);
            this.splitContainer1.Panel2.Controls.Add(this.btnRefreshLoadSuppliers);
            this.splitContainer1.Panel2.Controls.Add(this.btnEdit);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddDelivery);
            this.splitContainer1.Size = new System.Drawing.Size(371, 100);
            this.splitContainer1.SplitterDistance = 220;
            this.splitContainer1.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(198)))), ((int)(((byte)(205)))));
            this.label3.Location = new System.Drawing.Point(20, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "Пошук:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(198)))), ((int)(((byte)(205)))));
            this.label4.Location = new System.Drawing.Point(240, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 22;
            this.label4.Text = "Опції:";
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(23)))), ((int)(((byte)(45)))));
            this.splitContainer2.Location = new System.Drawing.Point(389, 49);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Size = new System.Drawing.Size(339, 100);
            this.splitContainer2.SplitterDistance = 201;
            this.splitContainer2.TabIndex = 21;
            // 
            // FormDelivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(23)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(740, 675);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.dataGridViewSuppliers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDelivery";
            this.Text = "FormDelivery";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSuppliers)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSuppliers;
        private System.Windows.Forms.ListBox listBoxResults;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchDelivery;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRefreshLoadSuppliers;
        private System.Windows.Forms.Button btnAddDelivery;
        private System.Windows.Forms.Button btnDeleteDeliv;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}