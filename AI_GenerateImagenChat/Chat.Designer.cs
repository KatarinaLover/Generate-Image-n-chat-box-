namespace AI_GenerateImagenChat
{
    partial class Chat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelChat;


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
            btnNhap = new Button();
            txtChat = new TextBox();
            richTextBoxOutput = new RichTextBox();
            trang = new CheckBox();
            den = new CheckBox();
            SuspendLayout();
            // 
            // btnNhap
            // 
            btnNhap.BackColor = Color.DodgerBlue;
            btnNhap.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNhap.ForeColor = Color.White;
            btnNhap.Location = new Point(542, 367);
            btnNhap.Margin = new Padding(3, 2, 3, 2);
            btnNhap.Name = "btnNhap";
            btnNhap.Size = new Size(101, 40);
            btnNhap.TabIndex = 0;
            btnNhap.Text = "↥";
            btnNhap.UseVisualStyleBackColor = false;
            btnNhap.Click += btnNhap_Click;
            // 
            // txtChat
            // 
            txtChat.BackColor = SystemColors.HighlightText;
            txtChat.Location = new Point(10, 367);
            txtChat.Margin = new Padding(3, 2, 3, 2);
            txtChat.Multiline = true;
            txtChat.Name = "txtChat";
            txtChat.Size = new Size(526, 41);
            txtChat.TabIndex = 1;
            // 
            // richTextBoxOutput
            // 
            richTextBoxOutput.Location = new Point(10, 32);
            richTextBoxOutput.Margin = new Padding(3, 2, 3, 2);
            richTextBoxOutput.Name = "richTextBoxOutput";
            richTextBoxOutput.Size = new Size(632, 332);
            richTextBoxOutput.TabIndex = 2;
            richTextBoxOutput.Text = "";
            richTextBoxOutput.TextChanged += richTextBoxOutput_TextChanged;
            // 
            // trang
            // 
            trang.AutoSize = true;
            trang.Location = new Point(10, 9);
            trang.Margin = new Padding(3, 2, 3, 2);
            trang.Name = "trang";
            trang.Size = new Size(52, 19);
            trang.TabIndex = 3;
            trang.Text = "Sáng";
            trang.UseVisualStyleBackColor = true;
            trang.CheckedChanged += trang_CheckedChanged;
            // 
            // den
            // 
            den.AutoSize = true;
            den.Location = new Point(75, 9);
            den.Margin = new Padding(3, 2, 3, 2);
            den.Name = "den";
            den.Size = new Size(43, 19);
            den.TabIndex = 4;
            den.Text = "Tối";
            den.UseVisualStyleBackColor = true;
            den.CheckedChanged += den_CheckedChanged;
            // 
            // Chat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PeachPuff;
            ClientSize = new Size(653, 416);
            Controls.Add(den);
            Controls.Add(trang);
            Controls.Add(richTextBoxOutput);
            Controls.Add(txtChat);
            Controls.Add(btnNhap);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "Chat";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chat";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnNhap;
        private TextBox txtChat;
        private RichTextBox richTextBoxOutput;
        private CheckBox trang;
        private CheckBox den;
    }
}