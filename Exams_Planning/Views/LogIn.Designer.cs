namespace Exams_Planning.Views
{
    partial class LogIn
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
            this.button1 = new System.Windows.Forms.Button();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radioAdmin = new System.Windows.Forms.RadioButton();
            this.radioEtud = new System.Windows.Forms.RadioButton();
            this.radioEnseign = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(76, 359);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 45);
            this.button1.TabIndex = 0;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(73, 232);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(229, 26);
            this.textEmail.TabIndex = 1;
            this.textEmail.TextChanged += new System.EventHandler(this.textEmail_TextChanged);
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(73, 308);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(229, 26);
            this.textPassword.TabIndex = 2;
            this.textPassword.TextChanged += new System.EventHandler(this.textPassword_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 285);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mot de pass";
            // 
            // radioAdmin
            // 
            this.radioAdmin.AutoSize = true;
            this.radioAdmin.Location = new System.Drawing.Point(321, 234);
            this.radioAdmin.Name = "radioAdmin";
            this.radioAdmin.Size = new System.Drawing.Size(152, 24);
            this.radioAdmin.TabIndex = 8;
            this.radioAdmin.TabStop = true;
            this.radioAdmin.Text = "Je suis un admin";
            this.radioAdmin.UseVisualStyleBackColor = true;
            // 
            // radioEtud
            // 
            this.radioEtud.AutoSize = true;
            this.radioEtud.Location = new System.Drawing.Point(321, 272);
            this.radioEtud.Name = "radioEtud";
            this.radioEtud.Size = new System.Drawing.Size(167, 24);
            this.radioEtud.TabIndex = 9;
            this.radioEtud.TabStop = true;
            this.radioEtud.Text = "Je suis un etudiant";
            this.radioEtud.UseVisualStyleBackColor = true;
            // 
            // radioEnseign
            // 
            this.radioEnseign.AutoSize = true;
            this.radioEnseign.Location = new System.Drawing.Point(321, 313);
            this.radioEnseign.Name = "radioEnseign";
            this.radioEnseign.Size = new System.Drawing.Size(188, 24);
            this.radioEnseign.TabIndex = 10;
            this.radioEnseign.TabStop = true;
            this.radioEnseign.Text = "Je suis un enseignant";
            this.radioEnseign.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(196, 359);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 45);
            this.button2.TabIndex = 11;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Exams_Planning.Properties.Resources.logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(196, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 142);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 449);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.radioEnseign);
            this.Controls.Add(this.radioEtud);
            this.Controls.Add(this.radioAdmin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.button1);
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioAdmin;
        private System.Windows.Forms.RadioButton radioEtud;
        private System.Windows.Forms.RadioButton radioEnseign;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}