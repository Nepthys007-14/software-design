namespace Task_1_Week_6
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private ListBox listBoxBooks;
        private Button btnFetchBooks;
        private Button btnAddBook;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnSearch;
        private TextBox txtAuthorName;
        private TextBox txtBookTitle;
        private TextBox txtUpdateBookId;
        private TextBox txtUpdateTitle;
        private TextBox txtUpdateAuthorName;
        private TextBox txtDeleteBookId;
        private TextBox txtSearch;
        private ProgressBar progressBarOp;
        private Label lblAuthorName;
        private Label lblBookTitle;
        private Label lblUpdateBookId;
        private Label lblUpdateTitle;
        private Label lblUpdateAuthor;
        private Label lblDeleteBookId;
        private Label lblSearch;
        private Label lblFetchStatus;
        private GroupBox grpFetch;
        private GroupBox grpAdd;
        private GroupBox grpUpdate;
        private GroupBox grpDelete;
        private GroupBox grpSearch;
        private GroupBox grpProgress;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            listBoxBooks = new ListBox();
            btnFetchBooks = new Button();
            progressBarOp = new ProgressBar();
            lblFetchStatus = new Label();
            grpFetch = new GroupBox();
            grpAdd = new GroupBox();
            grpUpdate = new GroupBox();
            grpDelete = new GroupBox();
            grpSearch = new GroupBox();
            grpProgress = new GroupBox();
            btnAddBook = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnSearch = new Button();
            txtAuthorName = new TextBox();
            txtBookTitle = new TextBox();
            txtUpdateBookId = new TextBox();
            txtUpdateTitle = new TextBox();
            txtUpdateAuthorName = new TextBox();
            txtDeleteBookId = new TextBox();
            txtSearch = new TextBox();
            lblAuthorName = new Label();
            lblBookTitle = new Label();
            lblUpdateBookId = new Label();
            lblUpdateTitle = new Label();
            lblUpdateAuthor = new Label();
            lblDeleteBookId = new Label();
            lblSearch = new Label();
            grpFetch.SuspendLayout();
            grpProgress.SuspendLayout();
            grpAdd.SuspendLayout();
            grpUpdate.SuspendLayout();
            grpDelete.SuspendLayout();
            grpSearch.SuspendLayout();
            SuspendLayout();

            // grpFetch
            grpFetch.Controls.Add(listBoxBooks);
            grpFetch.Controls.Add(btnFetchBooks);
            grpFetch.Location = new Point(12, 12);
            grpFetch.Name = "grpFetch";
            grpFetch.Size = new Size(560, 230);
            grpFetch.Text = "Fetch Books (Task 1)";

            // listBoxBooks
            listBoxBooks.FormattingEnabled = true;
            listBoxBooks.ItemHeight = 20;
            listBoxBooks.Location = new Point(10, 50);
            listBoxBooks.Name = "listBoxBooks";
            listBoxBooks.Size = new Size(540, 164);
            listBoxBooks.TabIndex = 1;

            // btnFetchBooks
            btnFetchBooks.Location = new Point(10, 15);
            btnFetchBooks.Name = "btnFetchBooks";
            btnFetchBooks.Size = new Size(160, 30);
            btnFetchBooks.TabIndex = 0;
            btnFetchBooks.Text = "Fetch Books Async";
            btnFetchBooks.UseVisualStyleBackColor = true;
            btnFetchBooks.Click += btnFetchBooks_Click;

            // grpProgress
            grpProgress.Controls.Add(lblFetchStatus);
            grpProgress.Controls.Add(progressBarOp);
            grpProgress.Location = new Point(12, 248);
            grpProgress.Name = "grpProgress";
            grpProgress.Size = new Size(560, 75);
            grpProgress.Text = "Operation Progress (Task 3)";

            // progressBarOp
            progressBarOp.Location = new Point(10, 25);
            progressBarOp.Name = "progressBarOp";
            progressBarOp.Size = new Size(540, 25);
            progressBarOp.Step = 1;

            // lblFetchStatus
            lblFetchStatus.AutoSize = true;
            lblFetchStatus.Location = new Point(10, 53);
            lblFetchStatus.Name = "lblFetchStatus";
            lblFetchStatus.Size = new Size(109, 20);
            lblFetchStatus.Text = "Ready";

            // grpAdd
            grpAdd.Controls.Add(btnAddBook);
            grpAdd.Controls.Add(txtBookTitle);
            grpAdd.Controls.Add(txtAuthorName);
            grpAdd.Controls.Add(lblBookTitle);
            grpAdd.Controls.Add(lblAuthorName);
            grpAdd.Location = new Point(12, 329);
            grpAdd.Name = "grpAdd";
            grpAdd.Size = new Size(270, 140);
            grpAdd.Text = "Add Book (Task 2)";

            // lblAuthorName
            lblAuthorName.AutoSize = true;
            lblAuthorName.Location = new Point(10, 25);
            lblAuthorName.Size = new Size(54, 20);
            lblAuthorName.Text = "Author";

            // txtAuthorName
            txtAuthorName.Location = new Point(90, 22);
            txtAuthorName.Name = "txtAuthorName";
            txtAuthorName.Size = new Size(170, 27);
            txtAuthorName.TabIndex = 0;

            // lblBookTitle
            lblBookTitle.AutoSize = true;
            lblBookTitle.Location = new Point(10, 58);
            lblBookTitle.Size = new Size(38, 20);
            lblBookTitle.Text = "Title";

            // txtBookTitle
            txtBookTitle.Location = new Point(90, 55);
            txtBookTitle.Name = "txtBookTitle";
            txtBookTitle.Size = new Size(170, 27);
            txtBookTitle.TabIndex = 1;

            // btnAddBook
            btnAddBook.Location = new Point(90, 95);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(170, 30);
            btnAddBook.TabIndex = 2;
            btnAddBook.Text = "Add Book Async";
            btnAddBook.UseVisualStyleBackColor = true;
            btnAddBook.Click += btnAddBook_Click;

            // grpUpdate
            grpUpdate.Controls.Add(btnUpdate);
            grpUpdate.Controls.Add(txtUpdateAuthorName);
            grpUpdate.Controls.Add(txtUpdateTitle);
            grpUpdate.Controls.Add(txtUpdateBookId);
            grpUpdate.Controls.Add(lblUpdateAuthor);
            grpUpdate.Controls.Add(lblUpdateTitle);
            grpUpdate.Controls.Add(lblUpdateBookId);
            grpUpdate.Location = new Point(288, 329);
            grpUpdate.Name = "grpUpdate";
            grpUpdate.Size = new Size(284, 160);
            grpUpdate.Text = "Update Book (Task 3)";

            // lblUpdateBookId
            lblUpdateBookId.AutoSize = true;
            lblUpdateBookId.Location = new Point(10, 25);
            lblUpdateBookId.Size = new Size(62, 20);
            lblUpdateBookId.Text = "Book ID";

            // txtUpdateBookId
            txtUpdateBookId.Location = new Point(110, 22);
            txtUpdateBookId.Name = "txtUpdateBookId";
            txtUpdateBookId.Size = new Size(160, 27);
            txtUpdateBookId.TabIndex = 0;

            // lblUpdateTitle
            lblUpdateTitle.AutoSize = true;
            lblUpdateTitle.Location = new Point(10, 58);
            lblUpdateTitle.Size = new Size(74, 20);
            lblUpdateTitle.Text = "New Title";

            // txtUpdateTitle
            txtUpdateTitle.Location = new Point(110, 55);
            txtUpdateTitle.Name = "txtUpdateTitle";
            txtUpdateTitle.Size = new Size(160, 27);
            txtUpdateTitle.TabIndex = 1;

            // lblUpdateAuthor
            lblUpdateAuthor.AutoSize = true;
            lblUpdateAuthor.Location = new Point(10, 91);
            lblUpdateAuthor.Size = new Size(90, 20);
            lblUpdateAuthor.Text = "New Author";

            // txtUpdateAuthorName
            txtUpdateAuthorName.Location = new Point(110, 88);
            txtUpdateAuthorName.Name = "txtUpdateAuthorName";
            txtUpdateAuthorName.Size = new Size(160, 27);
            txtUpdateAuthorName.TabIndex = 2;

            // btnUpdate
            btnUpdate.Location = new Point(110, 122);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(160, 30);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Update Async";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;

            // grpDelete
            grpDelete.Controls.Add(btnDelete);
            grpDelete.Controls.Add(txtDeleteBookId);
            grpDelete.Controls.Add(lblDeleteBookId);
            grpDelete.Location = new Point(12, 475);
            grpDelete.Name = "grpDelete";
            grpDelete.Size = new Size(270, 100);
            grpDelete.Text = "Delete Book (Task 3)";

            // lblDeleteBookId
            lblDeleteBookId.AutoSize = true;
            lblDeleteBookId.Location = new Point(10, 30);
            lblDeleteBookId.Size = new Size(62, 20);
            lblDeleteBookId.Text = "Book ID";

            // txtDeleteBookId
            txtDeleteBookId.Location = new Point(90, 27);
            txtDeleteBookId.Name = "txtDeleteBookId";
            txtDeleteBookId.Size = new Size(170, 27);
            txtDeleteBookId.TabIndex = 0;

            // btnDelete
            btnDelete.Location = new Point(90, 60);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(170, 30);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete Async";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;

            // grpSearch
            grpSearch.Controls.Add(btnSearch);
            grpSearch.Controls.Add(txtSearch);
            grpSearch.Controls.Add(lblSearch);
            grpSearch.Location = new Point(288, 495);
            grpSearch.Name = "grpSearch";
            grpSearch.Size = new Size(284, 80);
            grpSearch.Text = "Search (Task 3)";

            // lblSearch
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(10, 25);
            lblSearch.Size = new Size(42, 20);
            lblSearch.Text = "Title";

            // txtSearch
            txtSearch.Location = new Point(60, 22);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(100, 27);
            txtSearch.TabIndex = 0;

            // btnSearch
            btnSearch.Location = new Point(170, 20);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 30);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search Async";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;

            // Form1
            AutoScaleDimensions = new SizeF(8, 20);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 591);
            Controls.Add(grpSearch);
            Controls.Add(grpDelete);
            Controls.Add(grpUpdate);
            Controls.Add(grpAdd);
            Controls.Add(grpProgress);
            Controls.Add(grpFetch);
            Name = "Form1";
            Text = "Week 6 - Event-Driven & Async Bookstore";
            Load += Form1_Load;
            grpFetch.ResumeLayout(false);
            grpProgress.ResumeLayout(false);
            grpProgress.PerformLayout();
            grpAdd.ResumeLayout(false);
            grpAdd.PerformLayout();
            grpUpdate.ResumeLayout(false);
            grpUpdate.PerformLayout();
            grpDelete.ResumeLayout(false);
            grpDelete.PerformLayout();
            grpSearch.ResumeLayout(false);
            grpSearch.PerformLayout();
            ResumeLayout(false);
        }
    }
}
