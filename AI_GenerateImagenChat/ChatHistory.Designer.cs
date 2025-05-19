namespace AI_GenerateImagenChat
{
    partial class ChatHistory
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
            splitContainer1 = new SplitContainer();
            btnXoa = new Button();
            txtxoama = new TextBox();
            xoatatca = new CheckBox();
            treeView1 = new TreeView();
            listView1 = new ListView();
            dataGridView1 = new DataGridView();
            Ma = new DataGridViewTextBoxColumn();
            ThoiGian = new DataGridViewTextBoxColumn();
            Ban = new DataGridViewTextBoxColumn();
            AI = new DataGridViewTextBoxColumn();
            dateTimePicker1 = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dateTimePicker1);
            splitContainer1.Panel1.Controls.Add(btnXoa);
            splitContainer1.Panel1.Controls.Add(txtxoama);
            splitContainer1.Panel1.Controls.Add(xoatatca);
            splitContainer1.Panel1.Controls.Add(treeView1);
            splitContainer1.Panel1.Controls.Add(listView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGridView1);
            splitContainer1.Size = new Size(1219, 634);
            splitContainer1.SplitterDistance = 405;
            splitContainer1.TabIndex = 0;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.Red;
            btnXoa.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXoa.ForeColor = SystemColors.ButtonHighlight;
            btnXoa.Location = new Point(261, 559);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(131, 47);
            btnXoa.TabIndex = 5;
            btnXoa.Text = "🚮";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // txtxoama
            // 
            txtxoama.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            txtxoama.Location = new Point(116, 572);
            txtxoama.Name = "txtxoama";
            txtxoama.PlaceholderText = "Nhập mã để xóa";
            txtxoama.Size = new Size(139, 27);
            txtxoama.TabIndex = 4;
            txtxoama.TextChanged += textBox1_TextChanged;
            // 
            // xoatatca
            // 
            xoatatca.AutoSize = true;
            xoatatca.Location = new Point(12, 572);
            xoatatca.Name = "xoatatca";
            xoatatca.Size = new Size(98, 24);
            xoatatca.TabIndex = 3;
            xoatatca.Text = "Xóa tất cả";
            xoatatca.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            treeView1.BackColor = Color.White;
            treeView1.Location = new Point(12, 12);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(380, 476);
            treeView1.TabIndex = 1;
            treeView1.AfterSelect += TreeView1_AfterSelect;
            // 
            // listView1
            // 
            listView1.BackColor = Color.FromArgb(248, 241, 229);
            listView1.Dock = DockStyle.Fill;
            listView1.Location = new Point(0, 0);
            listView1.Name = "listView1";
            listView1.Size = new Size(405, 634);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged_1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Ma, ThoiGian, Ban, AI });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(810, 634);
            dataGridView1.TabIndex = 0;
            // 
            // Ma
            // 
            Ma.DataPropertyName = "SessionID";
            Ma.HeaderText = "Mã";
            Ma.MinimumWidth = 6;
            Ma.Name = "Ma";
            Ma.Width = 125;
            // 
            // ThoiGian
            // 
            ThoiGian.DataPropertyName = "Timestamp";
            ThoiGian.HeaderText = "Thời Gian";
            ThoiGian.MinimumWidth = 6;
            ThoiGian.Name = "ThoiGian";
            ThoiGian.Width = 160;
            // 
            // Ban
            // 
            Ban.DataPropertyName = "Question";
            Ban.HeaderText = "Tin của bạn";
            Ban.MinimumWidth = 6;
            Ban.Name = "Ban";
            Ban.Width = 200;
            // 
            // AI
            // 
            AI.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            AI.DataPropertyName = "Answer";
            AI.HeaderText = "AI";
            AI.MinimumWidth = 6;
            AI.Name = "AI";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(12, 514);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(380, 27);
            dateTimePicker1.TabIndex = 6;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // LichSu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1219, 634);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "LichSu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chat History";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Ma;
        private DataGridViewTextBoxColumn ThoiGian;
        private DataGridViewTextBoxColumn Ban;
        private DataGridViewTextBoxColumn AI;
        private ListView listView1;
        private TreeView treeView1;
        private TextBox txtxoama;
        private CheckBox xoatatca;
        private Button btnXoa;
        private DateTimePicker dateTimePicker1;
    }
}