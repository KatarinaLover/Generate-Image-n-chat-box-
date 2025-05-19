namespace AI_GenerateImagenChat
{
    partial class ImageHistory
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
            panel1 = new Panel();
            treeView1 = new TreeView();
            textBox1 = new TextBox();
            lblTotalImages = new Label();
            dateTimePicker1 = new DateTimePicker();
            txtTimkiem = new TextBox();
            btnXoa = new Button();
            textBox2 = new TextBox();
            checkBox1 = new CheckBox();
            dataGridView1 = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            ThoiGian = new DataGridViewTextBoxColumn();
            TenAnh = new DataGridViewTextBoxColumn();
            ImageData = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
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
            splitContainer1.Panel1.BackColor = SystemColors.ButtonHighlight;
            splitContainer1.Panel1.Controls.Add(panel1);
            splitContainer1.Panel1.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGridView1);
            splitContainer1.Size = new Size(1238, 618);
            splitContainer1.SplitterDistance = 411;
            splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(248, 241, 229);
            panel1.Controls.Add(treeView1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(lblTotalImages);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(txtTimkiem);
            panel1.Controls.Add(btnXoa);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(checkBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(411, 618);
            panel1.TabIndex = 5;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(12, 179);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(386, 354);
            treeView1.TabIndex = 9;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(215, 142);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Nhập tên để tìm kiếm";
            textBox1.Size = new Size(183, 27);
            textBox1.TabIndex = 8;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // lblTotalImages
            // 
            lblTotalImages.AutoSize = true;
            lblTotalImages.Location = new Point(12, 145);
            lblTotalImages.Name = "lblTotalImages";
            lblTotalImages.Size = new Size(96, 20);
            lblTotalImages.TabIndex = 6;
            lblTotalImages.Text = "Tổng Số Ảnh :";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(12, 25);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(386, 27);
            dateTimePicker1.TabIndex = 5;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // txtTimkiem
            // 
            txtTimkiem.BackColor = Color.White;
            txtTimkiem.Location = new Point(12, 82);
            txtTimkiem.Name = "txtTimkiem";
            txtTimkiem.PlaceholderText = "Nhập Id để tìm kiếm";
            txtTimkiem.Size = new Size(386, 27);
            txtTimkiem.TabIndex = 3;
            txtTimkiem.TextChanged += txtTimkiem_TextChanged;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.Red;
            btnXoa.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXoa.ForeColor = SystemColors.ButtonHighlight;
            btnXoa.Location = new Point(267, 539);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(131, 47);
            btnXoa.TabIndex = 1;
            btnXoa.Text = "🚮";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(128, 552);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Nhập Id để xóa";
            textBox2.Size = new Size(122, 27);
            textBox2.TabIndex = 4;
            textBox2.Tag = "";
            // 
            // checkBox1
            // 
            checkBox1.AccessibleName = "";
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(12, 555);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(97, 24);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Xóa tất cả";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, ThoiGian, TenAnh, ImageData });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(823, 618);
            dataGridView1.TabIndex = 0;
            // 
            // ID
            // 
            ID.DataPropertyName = "Id";
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.Width = 50;
            // 
            // ThoiGian
            // 
            ThoiGian.DataPropertyName = "SearchTime";
            ThoiGian.HeaderText = "Thời Gian";
            ThoiGian.MinimumWidth = 6;
            ThoiGian.Name = "ThoiGian";
            ThoiGian.Width = 143;
            // 
            // TenAnh
            // 
            TenAnh.DataPropertyName = "NameImage";
            TenAnh.HeaderText = "Tên Ảnh";
            TenAnh.MinimumWidth = 6;
            TenAnh.Name = "TenAnh";
            TenAnh.Width = 105;
            // 
            // ImageData
            // 
            ImageData.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ImageData.DataPropertyName = "ImageData";
            ImageData.HeaderText = "Đường dẫn ảnh";
            ImageData.MinimumWidth = 6;
            ImageData.Name = "ImageData";
            ImageData.Resizable = DataGridViewTriState.True;
            // 
            // Lichsuanh
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(1238, 618);
            Controls.Add(splitContainer1);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Lichsuanh";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Image History";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn ThoiGian;
        private DataGridViewTextBoxColumn TenAnh;
        private DataGridViewTextBoxColumn ImageData;
        private Button btnXoa;
        private CheckBox checkBox1;
        private TextBox txtTimkiem;
        private TextBox textBox2;
        private Panel panel1;
        private DateTimePicker dateTimePicker1;
        private Label lblTotalImages;
        private TextBox textBox1;
        private TreeView treeView1;
    }
}