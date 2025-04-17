namespace BYDMIX
{
    partial class FormCatalogTovar
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
            this.btnDeleteTovar = new System.Windows.Forms.Button();
            this.btnAddTovar = new System.Windows.Forms.Button();
            this.txtSearchTovar = new System.Windows.Forms.TextBox();
            this.dataGridViewCatalogTovar = new System.Windows.Forms.DataGridView();
            this.listBoxResults = new System.Windows.Forms.ListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCatalogTovar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeleteTovar
            // 
            this.btnDeleteTovar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(23)))), ((int)(((byte)(45)))));
            this.btnDeleteTovar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteTovar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTovar.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDeleteTovar.ForeColor = System.Drawing.Color.SlateBlue;
            this.btnDeleteTovar.Location = new System.Drawing.Point(634, 98);
            this.btnDeleteTovar.Name = "btnDeleteTovar";
            this.btnDeleteTovar.Size = new System.Drawing.Size(94, 29);
            this.btnDeleteTovar.TabIndex = 11;
            this.btnDeleteTovar.Text = "Видалити";
            this.btnDeleteTovar.UseVisualStyleBackColor = false;
            this.btnDeleteTovar.Click += new System.EventHandler(this.btnDeleteTovar_Click);
            // 
            // btnAddTovar
            // 
            this.btnAddTovar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(23)))), ((int)(((byte)(45)))));
            this.btnAddTovar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddTovar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTovar.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAddTovar.ForeColor = System.Drawing.Color.SlateBlue;
            this.btnAddTovar.Location = new System.Drawing.Point(534, 98);
            this.btnAddTovar.Name = "btnAddTovar";
            this.btnAddTovar.Size = new System.Drawing.Size(94, 29);
            this.btnAddTovar.TabIndex = 12;
            this.btnAddTovar.Text = "Додати";
            this.btnAddTovar.UseVisualStyleBackColor = false;
            this.btnAddTovar.Click += new System.EventHandler(this.btnAddTovar_Click);
            // 
            // txtSearchTovar
            // 
            this.txtSearchTovar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(32)))));
            this.txtSearchTovar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchTovar.Font = new System.Drawing.Font("Arial", 10F);
            this.txtSearchTovar.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchTovar.Location = new System.Drawing.Point(12, 78);
            this.txtSearchTovar.Multiline = true;
            this.txtSearchTovar.Name = "txtSearchTovar";
            this.txtSearchTovar.Size = new System.Drawing.Size(176, 25);
            this.txtSearchTovar.TabIndex = 9;
            this.txtSearchTovar.TextChanged += new System.EventHandler(this.txtSearchTovar_TextChanged);
            this.txtSearchTovar.Enter += new System.EventHandler(this.txtSearchTovar_Enter);
            this.txtSearchTovar.Leave += new System.EventHandler(this.txtSearchTovar_Leave);
            // 
            // dataGridViewCatalogTovar
            // 
            this.dataGridViewCatalogTovar.AllowUserToAddRows = false;
            this.dataGridViewCatalogTovar.AllowUserToDeleteRows = false;
            this.dataGridViewCatalogTovar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCatalogTovar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(30)))));
            this.dataGridViewCatalogTovar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCatalogTovar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewCatalogTovar.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(23)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(198)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(198)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCatalogTovar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCatalogTovar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(23)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(198)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(198)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCatalogTovar.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewCatalogTovar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewCatalogTovar.EnableHeadersVisualStyles = false;
            this.dataGridViewCatalogTovar.GridColor = System.Drawing.Color.Black;
            this.dataGridViewCatalogTovar.Location = new System.Drawing.Point(0, 133);
            this.dataGridViewCatalogTovar.Name = "dataGridViewCatalogTovar";
            this.dataGridViewCatalogTovar.ReadOnly = true;
            this.dataGridViewCatalogTovar.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(23)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(198)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCatalogTovar.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(23)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(198)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(198)))), ((int)(((byte)(205)))));
            this.dataGridViewCatalogTovar.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewCatalogTovar.RowTemplate.Height = 32;
            this.dataGridViewCatalogTovar.Size = new System.Drawing.Size(740, 542);
            this.dataGridViewCatalogTovar.TabIndex = 7;
            this.dataGridViewCatalogTovar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCatalogTovar_CellContentClick);
            // 
            // listBoxResults
            // 
            this.listBoxResults.FormattingEnabled = true;
            this.listBoxResults.Location = new System.Drawing.Point(12, 110);
            this.listBoxResults.Name = "listBoxResults";
            this.listBoxResults.Size = new System.Drawing.Size(176, 17);
            this.listBoxResults.TabIndex = 13;
            this.listBoxResults.Visible = false;
            this.listBoxResults.SelectedIndexChanged += new System.EventHandler(this.listBoxResults_SelectedIndexChanged);
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
            this.btnSearch.Location = new System.Drawing.Point(196, 78);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(20, 20);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            this.btnEdit.Location = new System.Drawing.Point(258, 78);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(20, 20);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(23)))), ((int)(((byte)(40)))));
            this.btnRefresh.BackgroundImage = global::BYDMIX.Properties.Resources.renewable;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(124)))), ((int)(((byte)(146)))));
            this.btnRefresh.Location = new System.Drawing.Point(227, 78);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(20, 20);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // FormCatalogTovar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(23)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(740, 675);
            this.Controls.Add(this.listBoxResults);
            this.Controls.Add(this.btnDeleteTovar);
            this.Controls.Add(this.btnAddTovar);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchTovar);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dataGridViewCatalogTovar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCatalogTovar";
            this.Text = "FormCatalogTovar";
            this.Load += new System.EventHandler(this.FormCatalogTovar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCatalogTovar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteTovar;
        private System.Windows.Forms.Button btnAddTovar;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchTovar;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dataGridViewCatalogTovar;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ListBox listBoxResults;
    }
}