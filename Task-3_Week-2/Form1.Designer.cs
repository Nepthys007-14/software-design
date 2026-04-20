namespace Task_3_Week_2
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
            // --- Fibonacci Section ---
            this.lblFibTitle = new System.Windows.Forms.Label();
            this.lblFibPrompt = new System.Windows.Forms.Label();
            this.txtFibInput = new System.Windows.Forms.TextBox();
            this.btnFibonacci = new System.Windows.Forms.Button();
            this.lblFibResult = new System.Windows.Forms.Label();

            // --- Power Section ---
            this.lblPowerTitle = new System.Windows.Forms.Label();
            this.lblBasePrompt = new System.Windows.Forms.Label();
            this.txtBase = new System.Windows.Forms.TextBox();
            this.lblExpPrompt = new System.Windows.Forms.Label();
            this.txtExponent = new System.Windows.Forms.TextBox();
            this.btnPower = new System.Windows.Forms.Button();
            this.lblPowerResult = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // =============================================
            // Fibonacci Section
            // =============================================
            // 
            // lblFibTitle
            // 
            this.lblFibTitle.AutoSize = true;
            this.lblFibTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblFibTitle.Location = new System.Drawing.Point(20, 15);
            this.lblFibTitle.Name = "lblFibTitle";
            this.lblFibTitle.Size = new System.Drawing.Size(350, 25);
            this.lblFibTitle.TabIndex = 0;
            this.lblFibTitle.Text = "1. Recursive Fibonacci Sequence";
            // 
            // lblFibPrompt
            // 
            this.lblFibPrompt.AutoSize = true;
            this.lblFibPrompt.Location = new System.Drawing.Point(20, 55);
            this.lblFibPrompt.Name = "lblFibPrompt";
            this.lblFibPrompt.Size = new System.Drawing.Size(150, 15);
            this.lblFibPrompt.TabIndex = 1;
            this.lblFibPrompt.Text = "Enter n:";
            // 
            // txtFibInput
            // 
            this.txtFibInput.Location = new System.Drawing.Point(100, 52);
            this.txtFibInput.Name = "txtFibInput";
            this.txtFibInput.Size = new System.Drawing.Size(120, 23);
            this.txtFibInput.TabIndex = 2;
            // 
            // btnFibonacci
            // 
            this.btnFibonacci.Location = new System.Drawing.Point(240, 51);
            this.btnFibonacci.Name = "btnFibonacci";
            this.btnFibonacci.Size = new System.Drawing.Size(150, 25);
            this.btnFibonacci.TabIndex = 3;
            this.btnFibonacci.Text = "Get Fibonacci";
            this.btnFibonacci.UseVisualStyleBackColor = true;
            this.btnFibonacci.Click += new System.EventHandler(this.btnFibonacci_Click);
            // 
            // lblFibResult
            // 
            this.lblFibResult.AutoSize = true;
            this.lblFibResult.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFibResult.Location = new System.Drawing.Point(20, 90);
            this.lblFibResult.Name = "lblFibResult";
            this.lblFibResult.Size = new System.Drawing.Size(100, 21);
            this.lblFibResult.TabIndex = 4;
            this.lblFibResult.Text = "";

            // =============================================
            // Power Calculation Section
            // =============================================
            // 
            // lblPowerTitle
            // 
            this.lblPowerTitle.AutoSize = true;
            this.lblPowerTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPowerTitle.Location = new System.Drawing.Point(20, 140);
            this.lblPowerTitle.Name = "lblPowerTitle";
            this.lblPowerTitle.Size = new System.Drawing.Size(350, 25);
            this.lblPowerTitle.TabIndex = 5;
            this.lblPowerTitle.Text = "2. Recursive Power Calculation";
            // 
            // lblBasePrompt
            // 
            this.lblBasePrompt.AutoSize = true;
            this.lblBasePrompt.Location = new System.Drawing.Point(20, 180);
            this.lblBasePrompt.Name = "lblBasePrompt";
            this.lblBasePrompt.Size = new System.Drawing.Size(60, 15);
            this.lblBasePrompt.TabIndex = 6;
            this.lblBasePrompt.Text = "Base (x):";
            // 
            // txtBase
            // 
            this.txtBase.Location = new System.Drawing.Point(100, 177);
            this.txtBase.Name = "txtBase";
            this.txtBase.Size = new System.Drawing.Size(80, 23);
            this.txtBase.TabIndex = 7;
            // 
            // lblExpPrompt
            // 
            this.lblExpPrompt.AutoSize = true;
            this.lblExpPrompt.Location = new System.Drawing.Point(200, 180);
            this.lblExpPrompt.Name = "lblExpPrompt";
            this.lblExpPrompt.Size = new System.Drawing.Size(80, 15);
            this.lblExpPrompt.TabIndex = 8;
            this.lblExpPrompt.Text = "Exponent (n):";
            // 
            // txtExponent
            // 
            this.txtExponent.Location = new System.Drawing.Point(300, 177);
            this.txtExponent.Name = "txtExponent";
            this.txtExponent.Size = new System.Drawing.Size(80, 23);
            this.txtExponent.TabIndex = 9;
            // 
            // btnPower
            // 
            this.btnPower.Location = new System.Drawing.Point(400, 176);
            this.btnPower.Name = "btnPower";
            this.btnPower.Size = new System.Drawing.Size(120, 25);
            this.btnPower.TabIndex = 10;
            this.btnPower.Text = "Calculate x^n";
            this.btnPower.UseVisualStyleBackColor = true;
            this.btnPower.Click += new System.EventHandler(this.btnPower_Click);
            // 
            // lblPowerResult
            // 
            this.lblPowerResult.AutoSize = true;
            this.lblPowerResult.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblPowerResult.Location = new System.Drawing.Point(20, 215);
            this.lblPowerResult.Name = "lblPowerResult";
            this.lblPowerResult.Size = new System.Drawing.Size(100, 21);
            this.lblPowerResult.TabIndex = 11;
            this.lblPowerResult.Text = "";

            // =============================================
            // Form1
            // =============================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 270);
            this.Controls.Add(this.lblFibTitle);
            this.Controls.Add(this.lblFibPrompt);
            this.Controls.Add(this.txtFibInput);
            this.Controls.Add(this.btnFibonacci);
            this.Controls.Add(this.lblFibResult);
            this.Controls.Add(this.lblPowerTitle);
            this.Controls.Add(this.lblBasePrompt);
            this.Controls.Add(this.txtBase);
            this.Controls.Add(this.lblExpPrompt);
            this.Controls.Add(this.txtExponent);
            this.Controls.Add(this.btnPower);
            this.Controls.Add(this.lblPowerResult);
            this.Name = "Form1";
            this.Text = "Task 3 - Student Challenge";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // Fibonacci controls
        private System.Windows.Forms.Label lblFibTitle;
        private System.Windows.Forms.Label lblFibPrompt;
        private System.Windows.Forms.TextBox txtFibInput;
        private System.Windows.Forms.Button btnFibonacci;
        private System.Windows.Forms.Label lblFibResult;

        // Power controls
        private System.Windows.Forms.Label lblPowerTitle;
        private System.Windows.Forms.Label lblBasePrompt;
        private System.Windows.Forms.TextBox txtBase;
        private System.Windows.Forms.Label lblExpPrompt;
        private System.Windows.Forms.TextBox txtExponent;
        private System.Windows.Forms.Button btnPower;
        private System.Windows.Forms.Label lblPowerResult;
    }
}
