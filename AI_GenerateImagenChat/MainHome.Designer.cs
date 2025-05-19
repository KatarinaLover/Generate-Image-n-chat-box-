namespace AI_GenerateImagenChat
{
    partial class MainHome
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
            txtPrompt = new TextBox();
            btnGenerate = new Button();
            pictureBox1 = new PictureBox();
            btnChats = new Button();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            button1 = new Button();
            btnTim = new Button();
            btnchat = new Button();
            txtTim = new TextBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            progressBar1 = new ProgressBar();
            pictureBox7 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            SuspendLayout();
            // 
            // txtPrompt
            // 
            txtPrompt.Location = new Point(236, 197);
            txtPrompt.Multiline = true;
            txtPrompt.Name = "txtPrompt";
            txtPrompt.Size = new Size(431, 38);
            txtPrompt.TabIndex = 0;
            // 
            // btnGenerate
            // 
            btnGenerate.BackColor = Color.Turquoise;
            btnGenerate.Location = new Point(619, 70);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(102, 38);
            btnGenerate.TabIndex = 2;
            btnGenerate.Text = "Tìm kiếm";
            btnGenerate.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(182, 125);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(650, 476);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // btnChats
            // 
            btnChats.BackColor = Color.Turquoise;
            btnChats.Location = new Point(727, 70);
            btnChats.Name = "btnChats";
            btnChats.Size = new Size(105, 38);
            btnChats.TabIndex = 4;
            btnChats.Text = "Chat";
            btnChats.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.doll;
            pictureBox2.Location = new Point(12, 125);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(154, 476);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.hoaie;
            pictureBox3.Location = new Point(848, 125);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(154, 476);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(839, 32);
            button1.Name = "button1";
            button1.Size = new Size(8, 8);
            button1.TabIndex = 7;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnTim
            // 
            btnTim.BackColor = Color.FromArgb(255, 167, 38);
            btnTim.ForeColor = SystemColors.ActiveCaptionText;
            btnTim.Location = new Point(551, 65);
            btnTim.Margin = new Padding(3, 2, 3, 2);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(100, 35);
            btnTim.TabIndex = 0;
            btnTim.Text = "🔍";
            btnTim.UseVisualStyleBackColor = false;
            btnTim.Click += btnTim_Click;
            // 
            // btnchat
            // 
            btnchat.BackColor = Color.FromArgb(255, 167, 38);
            btnchat.ForeColor = SystemColors.ActiveCaptionText;
            btnchat.Location = new Point(652, 65);
            btnchat.Margin = new Padding(3, 2, 3, 2);
            btnchat.Name = "btnchat";
            btnchat.Size = new Size(100, 35);
            btnchat.TabIndex = 1;
            btnchat.Text = "Chat box";
            btnchat.UseVisualStyleBackColor = false;
            btnchat.Click += btnchat_Click;
            // 
            // txtTim
            // 
            txtTim.Location = new Point(186, 65);
            txtTim.Margin = new Padding(3, 2, 3, 2);
            txtTim.Multiline = true;
            txtTim.Name = "txtTim";
            txtTim.Size = new Size(360, 35);
            txtTim.TabIndex = 2;
            txtTim.TextChanged += txtTim_TextChanged;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.FromArgb(255, 224, 192);
            pictureBox4.Location = new Point(186, 107);
            pictureBox4.Margin = new Padding(3, 2, 3, 2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(565, 354);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 4;
            pictureBox4.TabStop = false;
            pictureBox4.Click += pictureBox4_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.doll;
            pictureBox5.Location = new Point(32, 107);
            pictureBox5.Margin = new Padding(3, 2, 3, 2);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(138, 354);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 5;
            pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = Properties.Resources.hoaie;
            pictureBox6.Location = new Point(765, 107);
            pictureBox6.Margin = new Padding(3, 2, 3, 2);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(138, 354);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 6;
            pictureBox6.TabStop = false;
            // 
            // progressBar1
            // 
            progressBar1.BackColor = Color.FromArgb(248, 241, 229);
            progressBar1.Location = new Point(0, 487);
            progressBar1.Margin = new Padding(3, 2, 3, 2);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(937, 8);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 7;
            // 
            // pictureBox7
            // 
            pictureBox7.Image = Properties.Resources.anhdaidien;
            pictureBox7.Location = new Point(845, 11);
            pictureBox7.Margin = new Padding(3, 2, 3, 2);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(69, 59);
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.TabIndex = 8;
            pictureBox7.TabStop = false;
            pictureBox7.Click += pictureBox7_Click;
            // 
            // MainHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 241, 229);
            ClientSize = new Size(937, 491);
            Controls.Add(pictureBox7);
            Controls.Add(progressBar1);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox4);
            Controls.Add(txtTim);
            Controls.Add(btnchat);
            Controls.Add(btnTim);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "MainHome";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPrompt;
        private Button btnGenerate;
        private PictureBox pictureBox1;
        private Button btnChats;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Button button1;
        private Button btnTim;
        private Button btnchat;
        private TextBox txtTim;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private ProgressBar progressBar1;
        private PictureBox pictureBox7;
    }
}