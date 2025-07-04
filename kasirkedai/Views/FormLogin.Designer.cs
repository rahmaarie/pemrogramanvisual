namespace kasirkedai
{
    partial class FormLogin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.input_password = new System.Windows.Forms.TextBox();
            this.input_username = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.buttonLogin);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.input_password);
            this.panel1.Controls.Add(this.input_username);
            this.panel1.Location = new System.Drawing.Point(184, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 221);
            this.panel1.TabIndex = 0;
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.IndianRed;
            this.buttonLogin.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.Location = new System.Drawing.Point(112, 135);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(209, 50);
            this.buttonLogin.TabIndex = 3;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(154, 116);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(110, 16);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Lupa Password ?";
            // 
            // input_password
            // 
            this.input_password.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.input_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_password.ForeColor = System.Drawing.SystemColors.ControlText;
            this.input_password.Location = new System.Drawing.Point(102, 83);
            this.input_password.Name = "input_password";
            this.input_password.Size = new System.Drawing.Size(236, 30);
            this.input_password.TabIndex = 1;
            this.input_password.Text = "Password";
            this.input_password.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // input_username
            // 
            this.input_username.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.input_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_username.ForeColor = System.Drawing.SystemColors.ControlText;
            this.input_username.Location = new System.Drawing.Point(102, 31);
            this.input_username.Name = "input_username";
            this.input_username.Size = new System.Drawing.Size(236, 30);
            this.input_username.TabIndex = 0;
            this.input_username.Text = "Username";
            this.input_username.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(289, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Login Karyawan";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Coral;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLogin";
            this.Load += new System.EventHandler(this.FormLogin_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox input_username;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox input_password;
        private System.Windows.Forms.Button buttonLogin;
    }
}