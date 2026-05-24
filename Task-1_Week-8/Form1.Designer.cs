namespace Task_1_Week_8
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvBooks;
        private TextBox txtTitle;
        private TextBox txtISBN;
        private TextBox txtPrice;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtBio;
        private TextBox txtSearch;
        private TextBox txtApiIsbn;
        private TextBox txtBookDetails;
        private TextBox txtAuthorSearch;
        private ComboBox cmbAuthors;
        private Button btnAddBook;
        private Button btnAddAuthor;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnRefresh;
        private Button btnSearch;
        private Button btnFetchBook;
        private Button btnAuthorSearch;
        private Button btnApiPrevPage;
        private Button btnApiNextPage;
        private Button btnClearCache;
        private ProgressBar progressBarOp;
        private Label lblTitle;
        private Label lblISBN;
        private Label lblPrice;
        private Label lblFirstName;
        private Label lblLastName;
        private Label lblBio;
        private Label lblAuthor;
        private Label lblSearch;
        private Label lblProgressStatus;
        private Label lblApiIsbn;
        private Label lblAuthorSearch;
        private Label lblApiPageNumber;
        private GroupBox grpBook;
        private GroupBox grpAuthor;
        private GroupBox grpSearch;
        private GroupBox grpProgress;
        private GroupBox grpGoogleApi;
        private ListBox listBoxApiResults;
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
            dgvBooks = new DataGridView();
            grpBook = new GroupBox();
            txtTitle = new TextBox();
            txtISBN = new TextBox();
            txtPrice = new TextBox();
            lblTitle = new Label();
            lblISBN = new Label();
            lblPrice = new Label();
            cmbAuthors = new ComboBox();
            lblAuthor = new Label();
            grpAuthor = new GroupBox();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtBio = new TextBox();
            btnAddAuthor = new Button();
            lblFirstName = new Label();
            lblLastName = new Label();
            lblBio = new Label();
            grpSearch = new GroupBox();
            txtSearch = new TextBox();
            btnSearch = new Button();
            lblSearch = new Label();
            grpProgress = new GroupBox();
            progressBarOp = new ProgressBar();
            lblProgressStatus = new Label();
            grpGoogleApi = new GroupBox();
            txtApiIsbn = new TextBox();
            btnFetchBook = new Button();
            lblApiIsbn = new Label();
            txtBookDetails = new TextBox();
            txtAuthorSearch = new TextBox();
            btnAuthorSearch = new Button();
            lblAuthorSearch = new Label();
            listBoxApiResults = new ListBox();
            btnApiPrevPage = new Button();
            lblApiPageNumber = new Label();
            btnApiNextPage = new Button();
            btnAddBook = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();

            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            grpBook.SuspendLayout();
            grpAuthor.SuspendLayout();
            grpSearch.SuspendLayout();
            grpProgress.SuspendLayout();
            grpGoogleApi.SuspendLayout();
            SuspendLayout();

            // dgvBooks
            dgvBooks.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.Location = new Point(12, 12);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.RowHeadersWidth = 62;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.Size = new Size(860, 250);
            dgvBooks.TabIndex = 0;
            dgvBooks.SelectionChanged += dgvBooks_SelectionChanged;

            // grpBook
            grpBook.Controls.Add(lblTitle);
            grpBook.Controls.Add(txtTitle);
            grpBook.Controls.Add(lblISBN);
            grpBook.Controls.Add(txtISBN);
            grpBook.Controls.Add(lblPrice);
            grpBook.Controls.Add(txtPrice);
            grpBook.Controls.Add(lblAuthor);
            grpBook.Controls.Add(cmbAuthors);
            grpBook.Location = new Point(12, 268);
            grpBook.Name = "grpBook";
            grpBook.Size = new Size(440, 130);
            grpBook.TabIndex = 1;
            grpBook.TabStop = false;
            grpBook.Text = "Book Details";

            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(6, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(38, 20);
            lblTitle.Text = "Title";

            txtTitle.Location = new Point(100, 27);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(320, 27);
            txtTitle.TabIndex = 0;

            lblISBN.AutoSize = true;
            lblISBN.Location = new Point(6, 63);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(41, 20);
            lblISBN.Text = "ISBN";

            txtISBN.Location = new Point(100, 60);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(320, 27);
            txtISBN.TabIndex = 1;

            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(6, 96);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(41, 20);
            lblPrice.Text = "Price";

            txtPrice.Location = new Point(100, 93);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(100, 27);
            txtPrice.TabIndex = 2;

            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(220, 96);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(54, 20);
            lblAuthor.Text = "Author";

            cmbAuthors.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAuthors.Location = new Point(280, 93);
            cmbAuthors.Name = "cmbAuthors";
            cmbAuthors.Size = new Size(140, 27);
            cmbAuthors.TabIndex = 3;
            cmbAuthors.SelectedIndexChanged += cmbAuthors_SelectedIndexChanged;

            // grpAuthor
            grpAuthor.Controls.Add(lblFirstName);
            grpAuthor.Controls.Add(txtFirstName);
            grpAuthor.Controls.Add(lblLastName);
            grpAuthor.Controls.Add(txtLastName);
            grpAuthor.Controls.Add(lblBio);
            grpAuthor.Controls.Add(txtBio);
            grpAuthor.Controls.Add(btnAddAuthor);
            grpAuthor.Location = new Point(458, 268);
            grpAuthor.Name = "grpAuthor";
            grpAuthor.Size = new Size(414, 160);
            grpAuthor.TabIndex = 2;
            grpAuthor.TabStop = false;
            grpAuthor.Text = "Author Details";

            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(6, 30);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(80, 20);
            lblFirstName.Text = "First Name";

            txtFirstName.Location = new Point(100, 27);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(300, 27);
            txtFirstName.TabIndex = 0;

            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(6, 63);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(79, 20);
            lblLastName.Text = "Last Name";

            txtLastName.Location = new Point(100, 60);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(300, 27);
            txtLastName.TabIndex = 1;

            lblBio.AutoSize = true;
            lblBio.Location = new Point(6, 96);
            lblBio.Name = "lblBio";
            lblBio.Size = new Size(31, 20);
            lblBio.Text = "Bio";

            txtBio.Location = new Point(100, 93);
            txtBio.Name = "txtBio";
            txtBio.Size = new Size(300, 27);
            txtBio.TabIndex = 2;

            btnAddAuthor.Location = new Point(100, 126);
            btnAddAuthor.Name = "btnAddAuthor";
            btnAddAuthor.Size = new Size(150, 28);
            btnAddAuthor.TabIndex = 3;
            btnAddAuthor.Text = "Add Author";
            btnAddAuthor.UseVisualStyleBackColor = true;
            btnAddAuthor.Click += btnAddAuthor_Click;

            // grpSearch
            grpSearch.Controls.Add(lblSearch);
            grpSearch.Controls.Add(txtSearch);
            grpSearch.Controls.Add(btnSearch);
            grpSearch.Location = new Point(12, 480);
            grpSearch.Name = "grpSearch";
            grpSearch.Size = new Size(860, 55);
            grpSearch.TabIndex = 5;
            grpSearch.TabStop = false;
            grpSearch.Text = "Search Books";

            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(10, 25);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(78, 20);
            lblSearch.Text = "Search Title";

            txtSearch.Location = new Point(100, 22);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(640, 27);
            txtSearch.TabIndex = 0;

            btnSearch.Location = new Point(750, 20);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 30);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;

            // grpProgress
            grpProgress.Controls.Add(progressBarOp);
            grpProgress.Controls.Add(lblProgressStatus);
            grpProgress.Location = new Point(12, 541);
            grpProgress.Name = "grpProgress";
            grpProgress.Size = new Size(860, 55);
            grpProgress.TabIndex = 6;
            grpProgress.TabStop = false;
            grpProgress.Text = "Operation Progress";

            progressBarOp.Location = new Point(10, 22);
            progressBarOp.Name = "progressBarOp";
            progressBarOp.Size = new Size(700, 25);
            progressBarOp.TabIndex = 0;

            lblProgressStatus.AutoSize = true;
            lblProgressStatus.Location = new Point(720, 25);
            lblProgressStatus.Name = "lblProgressStatus";
            lblProgressStatus.Size = new Size(120, 20);
            lblProgressStatus.TabIndex = 1;
            lblProgressStatus.Text = "Ready";

            // grpGoogleApi
            grpGoogleApi.Controls.Add(lblApiIsbn);
            grpGoogleApi.Controls.Add(txtApiIsbn);
            grpGoogleApi.Controls.Add(btnFetchBook);
            grpGoogleApi.Controls.Add(txtBookDetails);
            grpGoogleApi.Controls.Add(lblAuthorSearch);
            grpGoogleApi.Controls.Add(txtAuthorSearch);
            grpGoogleApi.Controls.Add(btnAuthorSearch);
            grpGoogleApi.Controls.Add(listBoxApiResults);
            grpGoogleApi.Controls.Add(btnApiPrevPage);
            grpGoogleApi.Controls.Add(lblApiPageNumber);
            grpGoogleApi.Controls.Add(btnApiNextPage);
            grpGoogleApi.Controls.Add(btnClearCache);
            grpGoogleApi.Location = new Point(12, 602);
            grpGoogleApi.Name = "grpGoogleApi";
            grpGoogleApi.Size = new Size(860, 280);
            grpGoogleApi.TabIndex = 7;
            grpGoogleApi.TabStop = false;
            grpGoogleApi.Text = "Google Books API (Tasks 1-3)";

            lblApiIsbn.AutoSize = true;
            lblApiIsbn.Location = new Point(10, 28);
            lblApiIsbn.Name = "lblApiIsbn";
            lblApiIsbn.Size = new Size(38, 20);
            lblApiIsbn.Text = "ISBN";

            txtApiIsbn.Location = new Point(55, 25);
            txtApiIsbn.Name = "txtApiIsbn";
            txtApiIsbn.Size = new Size(160, 27);
            txtApiIsbn.TabIndex = 0;

            btnFetchBook.Location = new Point(225, 23);
            btnFetchBook.Name = "btnFetchBook";
            btnFetchBook.Size = new Size(120, 30);
            btnFetchBook.TabIndex = 1;
            btnFetchBook.Text = "Fetch Book";
            btnFetchBook.UseVisualStyleBackColor = true;
            btnFetchBook.Click += btnFetchBook_Click;

            txtBookDetails.Location = new Point(10, 60);
            txtBookDetails.Multiline = true;
            txtBookDetails.Name = "txtBookDetails";
            txtBookDetails.ReadOnly = true;
            txtBookDetails.ScrollBars = ScrollBars.Vertical;
            txtBookDetails.Size = new Size(840, 85);
            txtBookDetails.TabIndex = 2;

            lblAuthorSearch.AutoSize = true;
            lblAuthorSearch.Location = new Point(10, 155);
            lblAuthorSearch.Name = "lblAuthorSearch";
            lblAuthorSearch.Size = new Size(54, 20);
            lblAuthorSearch.Text = "Author";

            txtAuthorSearch.Location = new Point(70, 152);
            txtAuthorSearch.Name = "txtAuthorSearch";
            txtAuthorSearch.Size = new Size(160, 27);
            txtAuthorSearch.TabIndex = 3;

            btnAuthorSearch.Location = new Point(240, 150);
            btnAuthorSearch.Name = "btnAuthorSearch";
            btnAuthorSearch.Size = new Size(120, 30);
            btnAuthorSearch.TabIndex = 4;
            btnAuthorSearch.Text = "Search Author";
            btnAuthorSearch.UseVisualStyleBackColor = true;
            btnAuthorSearch.Click += btnAuthorSearch_Click;

            listBoxApiResults.FormattingEnabled = true;
            listBoxApiResults.ItemHeight = 20;
            listBoxApiResults.Location = new Point(10, 188);
            listBoxApiResults.Name = "listBoxApiResults";
            listBoxApiResults.Size = new Size(700, 84);
            listBoxApiResults.TabIndex = 5;

            btnApiPrevPage.Location = new Point(720, 188);
            btnApiPrevPage.Name = "btnApiPrevPage";
            btnApiPrevPage.Size = new Size(60, 30);
            btnApiPrevPage.TabIndex = 6;
            btnApiPrevPage.Text = "<";
            btnApiPrevPage.UseVisualStyleBackColor = true;
            btnApiPrevPage.Enabled = false;
            btnApiPrevPage.Click += btnApiPrevPage_Click;

            lblApiPageNumber.AutoSize = true;
            lblApiPageNumber.Location = new Point(720, 228);
            lblApiPageNumber.Name = "lblApiPageNumber";
            lblApiPageNumber.Size = new Size(60, 20);
            lblApiPageNumber.TabIndex = 7;
            lblApiPageNumber.Text = "Page 0/0";

            btnApiNextPage.Location = new Point(785, 188);
            btnApiNextPage.Name = "btnApiNextPage";
            btnApiNextPage.Size = new Size(60, 30);
            btnApiNextPage.TabIndex = 8;
            btnApiNextPage.Text = ">";
            btnApiNextPage.UseVisualStyleBackColor = true;
            btnApiNextPage.Enabled = false;
            btnApiNextPage.Click += btnApiNextPage_Click;

            btnClearCache = new Button();
            btnClearCache.Location = new Point(720, 230);
            btnClearCache.Name = "btnClearCache";
            btnClearCache.Size = new Size(125, 30);
            btnClearCache.TabIndex = 9;
            btnClearCache.Text = "Clear Cache";
            btnClearCache.UseVisualStyleBackColor = true;
            btnClearCache.Click += btnClearCache_Click;

            // buttons
            btnAddBook.Location = new Point(12, 434);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(100, 40);
            btnAddBook.TabIndex = 3;
            btnAddBook.Text = "Add Book";
            btnAddBook.UseVisualStyleBackColor = true;
            btnAddBook.Click += btnAddBook_Click;

            btnUpdate.Location = new Point(118, 434);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 40);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;

            btnDelete.Location = new Point(224, 434);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 40);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;

            btnRefresh.Location = new Point(330, 434);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 40);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;

            // statusStrip1
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip1.Location = new Point(0, 883);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(884, 26);
            statusStrip1.TabIndex = 8;
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(50, 20);
            toolStripStatusLabel.Text = "Ready";

            // Form1
            AutoScaleDimensions = new SizeF(8, 20);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 909);
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAddBook);
            Controls.Add(grpGoogleApi);
            Controls.Add(grpProgress);
            Controls.Add(grpSearch);
            Controls.Add(grpAuthor);
            Controls.Add(grpBook);
            Controls.Add(dgvBooks);
            Controls.Add(statusStrip1);
            Name = "Form1";
            Text = "Week 8 - Google Books API & CRUD";
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
            grpGoogleApi.ResumeLayout(false);
            grpGoogleApi.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
