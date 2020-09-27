namespace BUONO_CAFE2
{
    partial class ManagerFront
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
            this.btnViewAccounts = new System.Windows.Forms.Button();
            this.btnViewStocks = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnViewAccounts
            // 
            this.btnViewAccounts.Location = new System.Drawing.Point(178, 45);
            this.btnViewAccounts.Name = "btnViewAccounts";
            this.btnViewAccounts.Size = new System.Drawing.Size(429, 23);
            this.btnViewAccounts.TabIndex = 0;
            this.btnViewAccounts.Text = "View Accounts";
            this.btnViewAccounts.UseVisualStyleBackColor = true;
            this.btnViewAccounts.Click += new System.EventHandler(this.btnViewAccounts_Click);
            // 
            // btnViewStocks
            // 
            this.btnViewStocks.Location = new System.Drawing.Point(178, 103);
            this.btnViewStocks.Name = "btnViewStocks";
            this.btnViewStocks.Size = new System.Drawing.Size(429, 23);
            this.btnViewStocks.TabIndex = 1;
            this.btnViewStocks.Text = "View Stocks";
            this.btnViewStocks.UseVisualStyleBackColor = true;
            this.btnViewStocks.Click += new System.EventHandler(this.btnViewStocks_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(713, 40);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 33);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "LogOut";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ManagerFront
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnViewStocks);
            this.Controls.Add(this.btnViewAccounts);
            this.Name = "ManagerFront";
            this.Text = "ManagerFront";
            this.Load += new System.EventHandler(this.ManagerFront_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnViewAccounts;
        private System.Windows.Forms.Button btnViewStocks;
        private System.Windows.Forms.Button btnBack;
    }
}