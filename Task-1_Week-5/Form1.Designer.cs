namespace Task_1_Week_5
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
        private ComboBox cmbAuthors;
        private Button btnAddBook;
        private Button btnAddAuthor;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnRefresh;
        private Label lblTitle;
        private Label lblISBN;
        private Label lblPrice;
        private Label lblFirstName;
        private Label lblLastName;
        private Label lblBio;
        private Label lblAuthor;
        private GroupBox grpBook;
        private GroupBox grpAuthor;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
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
            btnAddBook = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();

            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            grpBook.SuspendLayout();
            grpAuthor.SuspendLayout();
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
            grpBook.Text = "Book Details";

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(6, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(38, 20);
            lblTitle.Text = "Title";

            // txtTitle
            txtTitle.Location = new Point(100, 27);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(320, 27);
            txtTitle.TabIndex = 0;

            // lblISBN
            lblISBN.AutoSize = true;
            lblISBN.Location = new Point(6, 63);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(41, 20);
            lblISBN.Text = "ISBN";

            // txtISBN
            txtISBN.Location = new Point(100, 60);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(320, 27);
            txtISBN.TabIndex = 1;

            // lblPrice
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(6, 96);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(41, 20);
            lblPrice.Text = "Price";

            // txtPrice
            txtPrice.Location = new Point(100, 93);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(100, 27);
            txtPrice.TabIndex = 2;

            // lblAuthor
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(220, 96);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(54, 20);
            lblAuthor.Text = "Author";

            // cmbAuthors
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
            grpAuthor.Text = "Author Details";

            // lblFirstName
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(6, 30);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(80, 20);
            lblFirstName.Text = "First Name";

            // txtFirstName
            txtFirstName.Location = new Point(100, 27);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(300, 27);
            txtFirstName.TabIndex = 0;

            // lblLastName
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(6, 63);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(79, 20);
            lblLastName.Text = "Last Name";

            // txtLastName
            txtLastName.Location = new Point(100, 60);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(300, 27);
            txtLastName.TabIndex = 1;

            // lblBio
            lblBio.AutoSize = true;
            lblBio.Location = new Point(6, 96);
            lblBio.Name = "lblBio";
            lblBio.Size = new Size(31, 20);
            lblBio.Text = "Bio";

            // txtBio
            txtBio.Location = new Point(100, 93);
            txtBio.Name = "txtBio";
            txtBio.Size = new Size(300, 27);
            txtBio.TabIndex = 2;

            // btnAddAuthor
            btnAddAuthor.Location = new Point(100, 126);
            btnAddAuthor.Name = "btnAddAuthor";
            btnAddAuthor.Size = new Size(150, 28);
            btnAddAuthor.TabIndex = 3;
            btnAddAuthor.Text = "Add Author";
            btnAddAuthor.UseVisualStyleBackColor = true;
            btnAddAuthor.Click += btnAddAuthor_Click;

            // btnAddBook
            btnAddBook.Location = new Point(12, 434);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(100, 40);
            btnAddBook.TabIndex = 3;
            btnAddBook.Text = "Add Book";
            btnAddBook.UseVisualStyleBackColor = true;
            btnAddBook.Click += btnAddBook_Click;

            // btnUpdate
            btnUpdate.Location = new Point(118, 434);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 40);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;

            // btnDelete
            btnDelete.Location = new Point(224, 434);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 40);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;

            // btnRefresh
            btnRefresh.Location = new Point(330, 434);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 40);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;

            // Form1
            AutoScaleDimensions = new SizeF(8, 20);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 486);
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAddBook);
            Controls.Add(grpAuthor);
            Controls.Add(grpBook);
            Controls.Add(dgvBooks);
            Name = "Form1";
            Text = "Bookstore CRUD - Laboratory Exercise 5";
            Load += Form1_Load;

            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            grpBook.ResumeLayout(false);
            grpBook.PerformLayout();
            grpAuthor.ResumeLayout(false);
            grpAuthor.PerformLayout();
            ResumeLayout(false);
        }
    }
}
