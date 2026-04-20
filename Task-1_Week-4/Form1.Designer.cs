namespace Task_1_Week_4
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
            lblTitle = new Label();
            btnDisplay = new Button();
            lstBooks = new ListBox();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(12, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(493, 32);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Task 1: Bookstore System with Inheritance";
            // 
            // btnDisplay
            // 
            btnDisplay.Location = new Point(12, 78);
            btnDisplay.Margin = new Padding(3, 4, 3, 4);
            btnDisplay.Name = "btnDisplay";
            btnDisplay.Size = new Size(229, 47);
            btnDisplay.TabIndex = 4;
            btnDisplay.Text = "Display Book Info";
            btnDisplay.UseVisualStyleBackColor = true;
            // 
            // lstBooks
            // 
            lstBooks.FormattingEnabled = true;
            lstBooks.Location = new Point(12, 138);
            lstBooks.Margin = new Padding(3, 4, 3, 4);
            lstBooks.Name = "lstBooks";
            lstBooks.Size = new Size(845, 384);
            lstBooks.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(916, 562);
            Controls.Add(lblTitle);
            Controls.Add(btnDisplay);
            Controls.Add(lstBooks);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnDisplay;
        private ListBox lstBooks;
    }
}
