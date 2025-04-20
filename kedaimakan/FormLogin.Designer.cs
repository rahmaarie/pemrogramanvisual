namespace kedaimakan
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            panel1 = new Panel();
            btnLogin = new Button();
            label2 = new Label();
            input_password = new TextBox();
            input_username = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(273, 93);
            label1.Name = "label1";
            label1.Size = new Size(227, 38);
            label1.TabIndex = 0;
            label1.Text = "Login Karyawan";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(input_password);
            panel1.Controls.Add(input_username);
            panel1.Location = new Point(181, 134);
            panel1.Name = "panel1";
            panel1.Size = new Size(420, 195);
            panel1.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.ActiveBorder;
            btnLogin.Location = new Point(121, 137);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(165, 36);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(147, 114);
            label2.Name = "label2";
            label2.Size = new Size(113, 20);
            label2.TabIndex = 2;
            label2.Text = "Lupa Password?";
            // 
            // input_password
            // 
            input_password.BackColor = SystemColors.InactiveCaption;
            input_password.BorderStyle = BorderStyle.FixedSingle;
            input_password.Location = new Point(82, 84);
            input_password.Name = "input_password";
            input_password.Size = new Size(256, 27);
            input_password.TabIndex = 1;
            input_password.Text = "Password";
            // 
            // input_username
            // 
            input_username.BackColor = SystemColors.InactiveCaption;
            input_username.BorderStyle = BorderStyle.FixedSingle;
            input_username.Location = new Point(81, 33);
            input_username.Name = "input_username";
            input_username.Size = new Size(256, 27);
            input_username.TabIndex = 0;
            input_username.Text = "Username";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Coral;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form Login";
            Load += FormLogin_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private TextBox input_username;
        private Label label2;
        private TextBox input_password;
        private Button btnLogin;
    }
}
