namespace AI_GenerateImagenChat
{
    partial class Dangnhap
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
            btnLoginGoogle = new Button();
            SuspendLayout();
            // 
            // btnLoginGoogle
            // 
            btnLoginGoogle.BackColor = Color.WhiteSmoke;
            btnLoginGoogle.Location = new Point(57, 95);
            btnLoginGoogle.Name = "btnLoginGoogle";
            btnLoginGoogle.Size = new Size(525, 54);
            btnLoginGoogle.TabIndex = 1;
            btnLoginGoogle.Text = "Đăng nhập bằng Google";
            btnLoginGoogle.UseVisualStyleBackColor = false;
            btnLoginGoogle.Click += btnLoginGoogle_Click;
            // 
            // Dangnhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 241, 229);
            ClientSize = new Size(649, 255);
            Controls.Add(btnLoginGoogle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Dangnhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đangnhap";
            ResumeLayout(false);
        }

        #endregion
        private Button btnLoginGoogle;
    }
}