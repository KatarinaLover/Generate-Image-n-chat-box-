using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_GenerateImagenChat
{
    public partial class ChatHistory : Form
    {
        Connecdata db = new Connecdata();
        private DataTable danhSachDuLieu;
        private ImageList imageList1;

        public ChatHistory()
        {
            string token = Properties.Settings.Default.AccessToken;
            decimal usersId = Properties.Settings.Default.CurrentUserId;

            if (string.IsNullOrEmpty(token) || usersId == 0)
            {
                MessageBox.Show("Bạn cần đăng nhập để xem lịch sử chat!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Dangnhap formDangNhap = new Dangnhap(); // Mở form đăng nhập


                if (formDangNhap.ShowDialog() == DialogResult.OK) // Nếu đăng nhập thành công
                {
                    // Cập nhật lại token và userId sau khi đăng nhập
                    token = Properties.Settings.Default.AccessToken;
                    usersId = Properties.Settings.Default.CurrentUserId;

                    // Kiểm tra lại lần nữa sau khi đăng nhập
                    if (string.IsNullOrEmpty(token) || usersId == 0)
                    {
                        MessageBox.Show("Đăng nhập thất bại. Không thể tiếp tục!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        return;
                    }
                }
                else
                {
                    // Nếu không đăng nhập thì đóng form luôn
                    this.Close();
                    return;
                }
            }

            InitializeComponent();
            LoadChatHistory();
            LoadTreeview();
        }

        private void LoadChatHistory()
        {
            decimal usersId = Properties.Settings.Default.CurrentUserId;
            if (usersId == 0) return;

            DataTable dt = db.LayDanhSachLichSu(usersId);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Không có lịch sử chat nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {


        }

        public void LoadTreeview()
        {
            decimal usersId = Properties.Settings.Default.CurrentUserId;
            if (usersId == 0) return;
            danhSachDuLieu = db.LayDanhSachLichSu(usersId);

            treeView1.Nodes.Clear();


            var distinctSessions = danhSachDuLieu.AsEnumerable().Select(x => x["SessionID"].ToString()).Distinct().ToList();

            foreach (var session in distinctSessions)
            {
                treeView1.Nodes.Add(session);
            }

            treeView1.AfterSelect += TreeView1_AfterSelect;
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectSessionID = e.Node.Text;
            LoadDataGridView(selectSessionID);
        }


        private void LoadDataGridView(string sessionID)
        {
            var filteredData = danhSachDuLieu.AsEnumerable().Where(x => x["SessionID"].ToString() == sessionID).CopyToDataTable();


            dataGridView1.DataSource = filteredData;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            decimal usersId = Properties.Settings.Default.CurrentUserId;

            if (usersId == 0)
            {
                MessageBox.Show("Bạn cần đăng nhập để xóa dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (xoatatca.Checked)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả dữ liệu không", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    db.XoaTatcadulieuChatHistory(usersId);
                    MessageBox.Show("Đã xóa tất cả dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadChatHistory();
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtxoama.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã SessionID để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sessionID = txtxoama.Text.Trim();

                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa lịch sử với SessionID = {sessionID} không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    db.XoaLichSuTheoSessionID(usersId, sessionID);
                    MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadChatHistory(); // Load lại dữ liệu sau khi xóa
                }
            }
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            decimal usersId = Properties.Settings.Default.CurrentUserId;
            if (usersId == 0) return;

            // Lấy ngày được chọn trên DateTimePicker
            DateTime selectedDate = dateTimePicker1.Value.Date;

            // Lấy ngày hiện tại
            DateTime today = DateTime.Today;

            // Đảm bảo selectedDate không lớn hơn hôm nay
            if (selectedDate > today)
            {
                MessageBox.Show("Vui lòng chọn một ngày trong quá khứ hoặc hôm nay!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy toàn bộ lịch sử chat của người dùng
            DataTable fullData = db.LayDanhSachLichSu(usersId);

            if (fullData.Rows.Count > 0)
            {
                // Lọc dữ liệu từ ngày chọn đến hôm nay
                var filteredData = fullData.AsEnumerable()
                    .Where(row => row.Field<DateTime>("Timestamp").Date >= selectedDate && row.Field<DateTime>("Timestamp").Date <= today)
                    .CopyToDataTable();

                dataGridView1.DataSource = filteredData;
            }
            else
            {
                MessageBox.Show("Không có lịch sử chat trong khoảng thời gian này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null; // Xóa dữ liệu hiển thị nếu không có kết quả
            }
        }
    }
}
