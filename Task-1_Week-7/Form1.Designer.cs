namespace Task_1_Week_7
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private ListBox listBoxBooks;
        private Button btnFetchBooks;
        private Button btnPreviousPage;
        private Button btnNextPage;
        private Label lblPageNumber;
        private GroupBox grpPagination;
        private GroupBox grpSearch;
        private GroupBox grpFileOps;
        private GroupBox grpProgress;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnExportBooks;
        private Button btnImportBooks;
        private ProgressBar progressBarOp;
        private Label lblStatus;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpPagination = new GroupBox();
            listBoxBooks = new ListBox();
            btnFetchBooks = new Button();
            btnPreviousPage = new Button();
            btnNextPage = new Button();
            lblPageNumber = new Label();
            grpSearch = new GroupBox();
            txtSearch = new TextBox();
            btnSearch = new Button();
            grpFileOps = new GroupBox();
            btnExportBooks = new Button();
            btnImportBooks = new Button();
            grpProgress = new GroupBox();
            progressBarOp = new ProgressBar();
            lblStatus = new Label();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();

            grpPagination.SuspendLayout();
            grpSearch.SuspendLayout();
            grpFileOps.SuspendLayout();
            grpProgress.SuspendLayout();
            SuspendLayout();

            // grpPagination
            grpPagination.Controls.Add(btnFetchBooks);
            grpPagination.Controls.Add(btnPreviousPage);
            grpPagination.Controls.Add(lblPageNumber);
            grpPagination.Controls.Add(btnNextPage);
            grpPagination.Controls.Add(listBoxBooks);
            grpPagination.Location = new Point(12, 12);
            grpPagination.Name = "grpPagination";
            grpPagination.Size = new Size(560, 275);
            grpPagination.TabIndex = 0;
            grpPagination.TabStop = false;
            grpPagination.Text = "Pagination (Task 1)";

            // btnFetchBooks
            btnFetchBooks.Location = new Point(10, 25);
            btnFetchBooks.Name = "btnFetchBooks";
            btnFetchBooks.Size = new Size(120, 30);
            btnFetchBooks.TabIndex = 0;
            btnFetchBooks.Text = "Fetch Books";
            btnFetchBooks.UseVisualStyleBackColor = true;
            btnFetchBooks.Click += btnFetchBooks_Click;

            // btnPreviousPage
            btnPreviousPage.Location = new Point(140, 25);
            btnPreviousPage.Name = "btnPreviousPage";
            btnPreviousPage.Size = new Size(100, 30);
            btnPreviousPage.TabIndex = 1;
            btnPreviousPage.Text = "< Previous";
            btnPreviousPage.UseVisualStyleBackColor = true;
            btnPreviousPage.Enabled = false;
            btnPreviousPage.Click += btnPreviousPage_Click;

            // lblPageNumber
            lblPageNumber.AutoSize = true;
            lblPageNumber.Location = new Point(250, 30);
            lblPageNumber.Name = "lblPageNumber";
            lblPageNumber.Size = new Size(60, 20);
            lblPageNumber.TabIndex = 2;
            lblPageNumber.Text = "Page 0 of 0";

            // btnNextPage
            btnNextPage.Location = new Point(350, 25);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(100, 30);
            btnNextPage.TabIndex = 3;
            btnNextPage.Text = "Next >";
            btnNextPage.UseVisualStyleBackColor = true;
            btnNextPage.Enabled = false;
            btnNextPage.Click += btnNextPage_Click;

            // listBoxBooks
            listBoxBooks.FormattingEnabled = true;
            listBoxBooks.ItemHeight = 20;
            listBoxBooks.Location = new Point(10, 65);
            listBoxBooks.Name = "listBoxBooks";
            listBoxBooks.Size = new Size(540, 184);
            listBoxBooks.TabIndex = 4;

            // grpSearch
            grpSearch.Controls.Add(txtSearch);
            grpSearch.Controls.Add(btnSearch);
            grpSearch.Location = new Point(12, 293);
            grpSearch.Name = "grpSearch";
            grpSearch.Size = new Size(270, 55);
            grpSearch.TabIndex = 1;
            grpSearch.TabStop = false;
            grpSearch.Text = "Search (Task 4)";

            // txtSearch
            txtSearch.Location = new Point(10, 22);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(140, 27);
            txtSearch.TabIndex = 0;

            // btnSearch
            btnSearch.Location = new Point(155, 20);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 30);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;

            // grpFileOps
            grpFileOps.Controls.Add(btnExportBooks);
            grpFileOps.Controls.Add(btnImportBooks);
            grpFileOps.Location = new Point(288, 293);
            grpFileOps.Name = "grpFileOps";
            grpFileOps.Size = new Size(284, 55);
            grpFileOps.TabIndex = 2;
            grpFileOps.TabStop = false;
            grpFileOps.Text = "File I/O (Task 3 & 4)";

            // btnExportBooks
            btnExportBooks.Location = new Point(10, 20);
            btnExportBooks.Name = "btnExportBooks";
            btnExportBooks.Size = new Size(120, 30);
            btnExportBooks.TabIndex = 0;
            btnExportBooks.Text = "Export";
            btnExportBooks.UseVisualStyleBackColor = true;
            btnExportBooks.Click += btnExportBooks_Click;

            // btnImportBooks
            btnImportBooks.Location = new Point(145, 20);
            btnImportBooks.Name = "btnImportBooks";
            btnImportBooks.Size = new Size(120, 30);
            btnImportBooks.TabIndex = 1;
            btnImportBooks.Text = "Import";
            btnImportBooks.UseVisualStyleBackColor = true;
            btnImportBooks.Click += btnImportBooks_Click;

            // grpProgress
            grpProgress.Controls.Add(progressBarOp);
            grpProgress.Controls.Add(lblStatus);
            grpProgress.Location = new Point(12, 354);
            grpProgress.Name = "grpProgress";
            grpProgress.Size = new Size(560, 55);
            grpProgress.TabIndex = 3;
            grpProgress.TabStop = false;
            grpProgress.Text = "Operation Progress";

            // progressBarOp
            progressBarOp.Location = new Point(10, 22);
            progressBarOp.Name = "progressBarOp";
            progressBarOp.Size = new Size(440, 25);
            progressBarOp.TabIndex = 0;

            // lblStatus
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(460, 25);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(48, 20);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Ready";

            // statusStrip1
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip1.Location = new Point(0, 410);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(584, 26);
            statusStrip1.TabIndex = 4;
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(50, 20);
            toolStripStatusLabel.Text = "Ready";

            // Form1
            AutoScaleDimensions = new SizeF(8, 20);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 436);
            Controls.Add(grpProgress);
            Controls.Add(grpFileOps);
            Controls.Add(grpSearch);
            Controls.Add(grpPagination);
            Controls.Add(statusStrip1);
            Name = "Form1";
            Text = "Week 7 - Advanced Async & Pagination";
            Load += Form1_Load;

            grpPagination.ResumeLayout(false);
            grpPagination.PerformLayout();
            grpSearch.ResumeLayout(false);
            grpSearch.PerformLayout();
            grpFileOps.ResumeLayout(false);
            grpFileOps.PerformLayout();
            grpProgress.ResumeLayout(false);
            grpProgress.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
