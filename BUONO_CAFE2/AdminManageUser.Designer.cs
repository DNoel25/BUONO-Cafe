namespace BUONO_CAFE2
{
    partial class AdminManageUser
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
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnUpdateUser = new System.Windows.Forms.Button();
            this.btnSeachUser = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblpower = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAddUser
            // 
            this.btnAddUser.BackColor = System.Drawing.Color.Black;
            this.btnAddUser.ForeColor = System.Drawing.Color.Brown;
            this.btnAddUser.Location = new System.Drawing.Point(249, 80);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(290, 55);
            this.btnAddUser.TabIndex = 0;
            this.btnAddUser.Text = "ADD USER";
            this.btnAddUser.UseVisualStyleBackColor = false;
            this.btnAddUser.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUpdateUser
            // 
            this.btnUpdateUser.BackColor = System.Drawing.Color.Black;
            this.btnUpdateUser.ForeColor = System.Drawing.Color.Brown;
            this.btnUpdateUser.Location = new System.Drawing.Point(255, 198);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Size = new System.Drawing.Size(290, 55);
            this.btnUpdateUser.TabIndex = 1;
            this.btnUpdateUser.Text = "UPDATE USER";
            this.btnUpdateUser.UseVisualStyleBackColor = false;
            this.btnUpdateUser.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSeachUser
            // 
            this.btnSeachUser.BackColor = System.Drawing.Color.Black;
            this.btnSeachUser.ForeColor = System.Drawing.Color.Brown;
            this.btnSeachUser.Location = new System.Drawing.Point(255, 307);
            this.btnSeachUser.Name = "btnSeachUser";
            this.btnSeachUser.Size = new System.Drawing.Size(290, 55);
            this.btnSeachUser.TabIndex = 2;
            this.btnSeachUser.Text = "SEARCH USER";
            this.btnSeachUser.UseVisualStyleBackColor = false;
            this.btnSeachUser.Click += new System.EventHandler(this.btnSeachUser_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(713, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "LogOut";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblpower
            // 
            this.lblpower.AutoSize = true;
            this.lblpower.Location = new System.Drawing.Point(128, 12);
            this.lblpower.Name = "lblpower";
            this.lblpower.Size = new System.Drawing.Size(46, 17);
            this.lblpower.TabIndex = 4;
            this.lblpower.Text = "label1";
            this.lblpower.Visible = false;
            // 
            // AdminManageUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BUONO_CAFE2.Properties.Resources.Login;
            this.ClientSize = new System.Drawing.Size(800, 438);
            this.Controls.Add(this.lblpower);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSeachUser);
            this.Controls.Add(this.btnUpdateUser);
            this.Controls.Add(this.btnAddUser);
            this.Name = "AdminManageUser";
            this.Text = "User Management";
            this.Load += new System.EventHandler(this.AdminManageUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnUpdateUser;
        private System.Windows.Forms.Button btnSeachUser;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblpower;
    }
}