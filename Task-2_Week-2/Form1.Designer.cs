namespace Task_2_Week_2
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.txtArrayInput = new System.Windows.Forms.TextBox();
            this.btnCalculateSum = new System.Windows.Forms.Button();
            this.lblSumResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(350, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Sum of Array Elements (Recursion)";
            // 
            // lblPrompt
            // 
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Location = new System.Drawing.Point(20, 60);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(250, 15);
            this.lblPrompt.TabIndex = 1;
            this.lblPrompt.Text = "Enter comma-separated numbers (e.g. 1,2,3,4,5):";
            // 
            // txtArrayInput
            // 
            this.txtArrayInput.Location = new System.Drawing.Point(20, 85);
            this.txtArrayInput.Name = "txtArrayInput";
            this.txtArrayInput.Size = new System.Drawing.Size(350, 23);
            this.txtArrayInput.TabIndex = 2;
            // 
            // btnCalculateSum
            // 
            this.btnCalculateSum.Location = new System.Drawing.Point(390, 84);
            this.btnCalculateSum.Name = "btnCalculateSum";
            this.btnCalculateSum.Size = new System.Drawing.Size(120, 25);
            this.btnCalculateSum.TabIndex = 3;
            this.btnCalculateSum.Text = "Calculate Sum";
            this.btnCalculateSum.UseVisualStyleBackColor = true;
            this.btnCalculateSum.Click += new System.EventHandler(this.btnCalculateSum_Click);
            // 
            // lblSumResult
            // 
            this.lblSumResult.AutoSize = true;
            this.lblSumResult.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSumResult.Location = new System.Drawing.Point(20, 130);
            this.lblSumResult.Name = "lblSumResult";
            this.lblSumResult.Size = new System.Drawing.Size(100, 21);
            this.lblSumResult.TabIndex = 4;
            this.lblSumResult.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 180);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.txtArrayInput);
            this.Controls.Add(this.btnCalculateSum);
            this.Controls.Add(this.lblSumResult);
            this.Name = "Form1";
            this.Text = "Task 2 - Sum of Array Elements";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.TextBox txtArrayInput;
        private System.Windows.Forms.Button btnCalculateSum;
        private System.Windows.Forms.Label lblSumResult;
    }
}
