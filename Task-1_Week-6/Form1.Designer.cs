namespace Task_1_Week_6
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvBooks;
        private TextBox txtTitle;
        private TextBox txtISBN;
        private TextBox txtPrice;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtBio;
        private TextBox txtSearch;
        private ComboBox cmbAuthors;
        private System.Windows.Forms.Button btnAddBook;
        private Button btnAddAuthor;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private Button btnSearch;
        private System.Windows.Forms.ProgressBar progressBarOp;
        private Label lblTitle;
        private Label lblISBN;
        private Label lblPrice;
        private Label lblFirstName;
        private Label lblLastName;
        private Label lblBio;
        private Label lblAuthor;
        private Label lblSearch;
        private Label lblProgressStatus;
        private GroupBox grpBook;
        private System.Windows.Forms.GroupBox grpAuthor;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.GroupBox grpProgress;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvBooks = new System.Windows.Forms.DataGridView();
            grpBook = new System.Windows.Forms.GroupBox();
            lblTitle = new System.Windows.Forms.Label();
            txtTitle = new System.Windows.Forms.TextBox();
            lblISBN = new System.Windows.Forms.Label();
            txtISBN = new System.Windows.Forms.TextBox();
            lblPrice = new System.Windows.Forms.Label();
            txtPrice = new System.Windows.Forms.TextBox();
            lblAuthor = new System.Windows.Forms.Label();
            cmbAuthors = new System.Windows.Forms.ComboBox();
            grpAuthor = new System.Windows.Forms.GroupBox();
            lblFirstName = new System.Windows.Forms.Label();
            txtFirstName = new System.Windows.Forms.TextBox();
            lblLastName = new System.Windows.Forms.Label();
            txtLastName = new System.Windows.Forms.TextBox();
            lblBio = new System.Windows.Forms.Label();
            txtBio = new System.Windows.Forms.TextBox();
            btnAddAuthor = new System.Windows.Forms.Button();
            grpSearch = new System.Windows.Forms.GroupBox();
            lblSearch = new System.Windows.Forms.Label();
            txtSearch = new System.Windows.Forms.TextBox();
            btnSearch = new System.Windows.Forms.Button();
            grpProgress = new System.Windows.Forms.GroupBox();
            progressBarOp = new System.Windows.Forms.ProgressBar();
            lblProgressStatus = new System.Windows.Forms.Label();
            btnAddBook = new System.Windows.Forms.Button();
            btnUpdate = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnRefresh = new System.Windows.Forms.Button();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            grpBook.SuspendLayout();
            grpAuthor.SuspendLayout();
            grpSearch.SuspendLayout();
            grpProgress.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvBooks
            // 
            dgvBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
            dgvBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.ColumnHeadersHeight = 29;
            dgvBooks.Location = new System.Drawing.Point(12, 74);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.RowHeadersWidth = 62;
            dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.Size = new System.Drawing.Size(860, 188);
            dgvBooks.TabIndex = 0;
            dgvBooks.SelectionChanged += dgvBooks_SelectionChanged;
            // 
            // grpBook
            // 
            grpBook.Controls.Add(lblTitle);
            grpBook.Controls.Add(txtTitle);
            grpBook.Controls.Add(lblISBN);
            grpBook.Controls.Add(txtISBN);
            grpBook.Controls.Add(lblPrice);
            grpBook.Controls.Add(txtPrice);
            grpBook.Controls.Add(lblAuthor);
            grpBook.Controls.Add(cmbAuthors);
            grpBook.Location = new System.Drawing.Point(12, 268);
            grpBook.Name = "grpBook";
            grpBook.Size = new System.Drawing.Size(440, 130);
            grpBook.TabIndex = 1;
            grpBook.TabStop = false;
            grpBook.Text = "Book Details";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new System.Drawing.Point(6, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(38, 20);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Title";
            // 
            // txtTitle
            // 
            txtTitle.Location = new System.Drawing.Point(100, 27);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new System.Drawing.Size(320, 27);
            txtTitle.TabIndex = 0;
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Location = new System.Drawing.Point(6, 63);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new System.Drawing.Size(41, 20);
            lblISBN.TabIndex = 1;
            lblISBN.Text = "ISBN";
            // 
            // txtISBN
            // 
            txtISBN.Location = new System.Drawing.Point(100, 60);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new System.Drawing.Size(320, 27);
            txtISBN.TabIndex = 1;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new System.Drawing.Point(6, 96);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new System.Drawing.Size(41, 20);
            lblPrice.TabIndex = 2;
            lblPrice.Text = "Price";
            // 
            // txtPrice
            // 
            txtPrice.Location = new System.Drawing.Point(100, 93);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new System.Drawing.Size(100, 27);
            txtPrice.TabIndex = 2;
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new System.Drawing.Point(220, 96);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new System.Drawing.Size(54, 20);
            lblAuthor.TabIndex = 3;
            lblAuthor.Text = "Author";
            // 
            // cmbAuthors
            // 
            cmbAuthors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbAuthors.Location = new System.Drawing.Point(280, 93);
            cmbAuthors.Name = "cmbAuthors";
            cmbAuthors.Size = new System.Drawing.Size(140, 28);
            cmbAuthors.TabIndex = 3;
            cmbAuthors.SelectedIndexChanged += cmbAuthors_SelectedIndexChanged;
            // 
            // grpAuthor
            // 
            grpAuthor.Controls.Add(lblFirstName);
            grpAuthor.Controls.Add(txtFirstName);
            grpAuthor.Controls.Add(lblLastName);
            grpAuthor.Controls.Add(txtLastName);
            grpAuthor.Controls.Add(lblBio);
            grpAuthor.Controls.Add(txtBio);
            grpAuthor.Controls.Add(btnAddAuthor);
            grpAuthor.Location = new System.Drawing.Point(458, 268);
            grpAuthor.Name = "grpAuthor";
            grpAuthor.Size = new System.Drawing.Size(414, 176);
            grpAuthor.TabIndex = 2;
            grpAuthor.TabStop = false;
            grpAuthor.Text = "Author Details";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new System.Drawing.Point(6, 30);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new System.Drawing.Size(80, 20);
            lblFirstName.TabIndex = 0;
            lblFirstName.Text = "First Name";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new System.Drawing.Point(100, 27);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new System.Drawing.Size(300, 27);
            txtFirstName.TabIndex = 0;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new System.Drawing.Point(6, 63);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new System.Drawing.Size(79, 20);
            lblLastName.TabIndex = 1;
            lblLastName.Text = "Last Name";
            // 
            // txtLastName
            // 
            txtLastName.Location = new System.Drawing.Point(100, 60);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new System.Drawing.Size(300, 27);
            txtLastName.TabIndex = 1;
            // 
            // lblBio
            // 
            lblBio.AutoSize = true;
            lblBio.Location = new System.Drawing.Point(6, 96);
            lblBio.Name = "lblBio";
            lblBio.Size = new System.Drawing.Size(31, 20);
            lblBio.TabIndex = 2;
            lblBio.Text = "Bio";
            // 
            // txtBio
            // 
            txtBio.Location = new System.Drawing.Point(100, 93);
            txtBio.Name = "txtBio";
            txtBio.Size = new System.Drawing.Size(300, 27);
            txtBio.TabIndex = 2;
            // 
            // btnAddAuthor
            // 
            btnAddAuthor.Location = new System.Drawing.Point(100, 126);
            btnAddAuthor.Name = "btnAddAuthor";
            btnAddAuthor.Size = new System.Drawing.Size(150, 28);
            btnAddAuthor.TabIndex = 3;
            btnAddAuthor.Text = "Add Author";
            btnAddAuthor.UseVisualStyleBackColor = true;
            btnAddAuthor.Click += btnAddAuthor_Click;
            // 
            // grpSearch
            // 
            grpSearch.Controls.Add(lblSearch);
            grpSearch.Controls.Add(txtSearch);
            grpSearch.Controls.Add(btnSearch);
            grpSearch.Location = new System.Drawing.Point(12, 12);
            grpSearch.Name = "grpSearch";
            grpSearch.Size = new System.Drawing.Size(860, 55);
            grpSearch.TabIndex = 5;
            grpSearch.TabStop = false;
            grpSearch.Text = "Search Books";
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new System.Drawing.Point(10, 25);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new System.Drawing.Size(86, 20);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Search Title";
            // 
            // txtSearch
            // 
            txtSearch.Location = new System.Drawing.Point(100, 22);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(640, 27);
            txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new System.Drawing.Point(750, 20);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(100, 30);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // grpProgress
            // 
            grpProgress.Controls.Add(progressBarOp);
            grpProgress.Controls.Add(lblProgressStatus);
            grpProgress.Location = new System.Drawing.Point(12, 469);
            grpProgress.Name = "grpProgress";
            grpProgress.Size = new System.Drawing.Size(860, 55);
            grpProgress.TabIndex = 6;
            grpProgress.TabStop = false;
            grpProgress.Text = "Operation Progress";
            // 
            // progressBarOp
            // 
            progressBarOp.Location = new System.Drawing.Point(14, 20);
            progressBarOp.Name = "progressBarOp";
            progressBarOp.Size = new System.Drawing.Size(700, 25);
            progressBarOp.TabIndex = 0;
            // 
            // lblProgressStatus
            // 
            lblProgressStatus.AutoSize = true;
            lblProgressStatus.Location = new System.Drawing.Point(720, 25);
            lblProgressStatus.Name = "lblProgressStatus";
            lblProgressStatus.Size = new System.Drawing.Size(50, 20);
            lblProgressStatus.TabIndex = 1;
            lblProgressStatus.Text = "Ready";
            // 
            // btnAddBook
            // 
            btnAddBook.Location = new System.Drawing.Point(25, 404);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new System.Drawing.Size(100, 40);
            btnAddBook.TabIndex = 3;
            btnAddBook.Text = "Add Book";
            btnAddBook.UseVisualStyleBackColor = true;
            btnAddBook.Click += btnAddBook_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new System.Drawing.Point(131, 404);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new System.Drawing.Size(100, 40);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new System.Drawing.Point(237, 404);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(100, 40);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new System.Drawing.Point(343, 404);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new System.Drawing.Size(100, 40);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel });
            statusStrip1.Location = new System.Drawing.Point(0, 595);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(884, 26);
            statusStrip1.TabIndex = 7;
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new System.Drawing.Size(50, 20);
            toolStripStatusLabel.Text = "Ready";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(884, 621);
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAddBook);
            Controls.Add(grpProgress);
            Controls.Add(grpSearch);
            Controls.Add(grpAuthor);
            Controls.Add(grpBook);
            Controls.Add(dgvBooks);
            Controls.Add(statusStrip1);
            Text = "Week 6 - Async Bookstore";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            grpBook.ResumeLayout(false);
            grpBook.PerformLayout();
            grpAuthor.ResumeLayout(false);
            grpAuthor.PerformLayout();
            grpSearch.ResumeLayout(false);
            grpSearch.PerformLayout();
            grpProgress.ResumeLayout(false);
            grpProgress.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
