namespace Task_2_Week_3
{
    partial class Form1
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
            btnDisplay = new Button();
            lstBooks = new ListBox();
            lblTitle = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(280, 25);
            lblTitle.Text = "Task 2: Polymorphic Behavior";
            // 
            // btnDisplay
            // 
            btnDisplay.Location = new Point(20, 55);
            btnDisplay.Name = "btnDisplay";
            btnDisplay.Size = new Size(200, 35);
            btnDisplay.Text = "Display All Books (Polymorphic)";
            btnDisplay.UseVisualStyleBackColor = true;
            btnDisplay.Click += btnDisplay_Click;
            // 
            // lstBooks
            // 
            lstBooks.FormattingEnabled = true;
            lstBooks.Location = new Point(20, 100);
            lstBooks.Name = "lstBooks";
            lstBooks.Size = new Size(740, 300);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 421);
            Controls.Add(lblTitle);
            Controls.Add(btnDisplay);
            Controls.Add(lstBooks);
            Name = "Form1";
            Text = "Task 2 - Polymorphic Behavior";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDisplay;
        private ListBox lstBooks;
        private Label lblTitle;
    }
}
