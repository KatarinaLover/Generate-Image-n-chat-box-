using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI_GenerateImagenChat
{
    public partial class ImageHistory : Form
    {

        Connecdata db = new Connecdata();
        public ImageHistory()
        {


            string token = Properties.Settings.Default.AccessToken;
            decimal usersId = Properties.Settings.Default.CurrentUserId;

            if (string.IsNullOrEmpty(token) || usersId == 0)
            {
                MessageBox.Show("Bạn cần đăng nhập để xem lịch sử ảnh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;


            }
            else
            {
                InitializeComponent();
                LoadAnhHistory();
                LoadDanhSachAnh(""); // Mặc định hiển thị tất cả ảnh khi mở form
            }


            // Thiết lập ngôn ngữ hiển thị là tiếng Việt
            CultureInfo culture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            // Cấu hình DateTimePicker để hiển thị tiếng Việt
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dddd, dd MMMM yyyy"; // Hiển thị thứ, ngày tháng năm
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged; // Gán sự kiện thay đổi giá trị



        }


        private void LoadAnhHistory()
        {
            decimal usersId = Properties.Settings.Default.CurrentUserId;
            if (usersId == 0) return;
            DataTable dt = db.LayDanhSachLichSuAnh(usersId);

            // Thêm cột ảnh nếu chưa có
            if (!dt.Columns.Contains("Ảnh"))
                dt.Columns.Add("Ảnh", typeof(Bitmap));

            foreach (DataRow row in dt.Rows)
            {
                string imagePath = row["ImageData"].ToString(); // Lấy đường dẫn ảnh từ DB
                if (File.Exists(imagePath)) // Kiểm tra nếu ảnh tồn tại
                {
                    row["Ảnh"] = new Bitmap(imagePath);
                }
            }
            dataGridView1.DataSource = dt;

            //// Ẩn cột đường dẫn nếu không cần thiết
            //dataGridView1.Columns["ImageData"].Visible = false;


            // Đặt chiều cao và chiều rộng hàng để ảnh không bị dẹp
            dataGridView1.RowTemplate.Height = 100;
            dataGridView1.Columns["Ảnh"].Width = 250;

            // Định dạng cột ảnh để hiển thị hình ảnh đúng cách
            DataGridViewImageColumn imgColumn = (DataGridViewImageColumn)dataGridView1.Columns["Ảnh"];
            imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Ảnh co giãn theo ô mà không bị méo
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            decimal usersId = Properties.Settings.Default.CurrentUserId;

            if (usersId == 0)
            {
                MessageBox.Show("Bạn cần đăng nhập để xóa dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (checkBox1.Checked)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả dữ liệu?",
                                                      "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    db.XoaTatCaDuLieu(usersId);
                    MessageBox.Show("Đã xóa tất cả dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachAnh("");
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(textBox2.Text)) // Kiểm tra textbox có rỗng không
                {
                    MessageBox.Show("Vui lòng nhập ID để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int id;
                if (!int.TryParse(textBox2.Text, out id)) // Kiểm tra xem ID có phải số không
                {
                    MessageBox.Show("ID không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa dữ liệu có ID = {id}?",
                                                      "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    db.XoaDuLieuTheoID(id);
                    MessageBox.Show($"Đã xóa dữ liệu có ID = {id}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachAnh("");
                }
            }

        }

        private void btnTim_Click(object sender, EventArgs e)
        {

        }

        private void LoadDanhSachAnh(string keyword)
        {
            decimal usersId = Properties.Settings.Default.CurrentUserId; // Lấy UserId hiện tại
            if (usersId == 0) return; // Nếu UserId không hợp lệ thì thoát luôn
            if (string.IsNullOrEmpty(keyword))
            {
                keyword = "%";
            }
            DataTable dt = db.SoLuongAnh(keyword, usersId);
            DataTable dt1 = db.LoadHinhAnh(keyword, usersId); // Lọc theo UserId
            treeView1.Nodes.Clear();
            int TongSoAnh = 0;


            // Kiểm tra nếu dt1 chưa có cột "Ảnh", thì thêm vào
            if (!dt1.Columns.Contains("Ảnh"))
            {
                dt1.Columns.Add("Ảnh", typeof(Bitmap));
            }

            foreach (DataRow row in dt1.Rows)
            {
                string imagePath = row["ImageData"].ToString(); // Lấy đường dẫn ảnh từ DB
                if (File.Exists(imagePath)) // Kiểm tra nếu ảnh tồn tại
                {
                    row["Ảnh"] = new Bitmap(imagePath);
                }
            }

            // Gán lại dữ liệu sau khi cập nhật ảnh
            dataGridView1.DataSource = dt1;

            // Định dạng hiển thị
            dataGridView1.RowTemplate.Height = 100;
            dataGridView1.Columns["Ảnh"].Width = 250;
            //dataGridView1.Columns["ImageData"].Visible = false; // Ẩn cột đường dẫn ảnh nếu không cần


            // Cấu hình hiển thị ảnh
            DataGridViewImageColumn imgColumn = (DataGridViewImageColumn)dataGridView1.Columns["Ảnh"];
            imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

            foreach (DataRow row in dt.Rows)
            {
                string tenAnh = row["NameImage"].ToString();
                int soLuong = Convert.ToInt32(row["so_luong"]);

                treeView1.Nodes.Add($"{tenAnh} : {soLuong} ảnh");

                //dataGridView1.DataSource = db.LoadHinhAnh(keyword);

                TongSoAnh += soLuong;
            }

            lblTotalImages.Text = $"Tổng số ảnh : {TongSoAnh}";
        }



        private void listBoxStatistics_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox1.Text;
            LoadDanhSachAnh(keyword);


        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string searchValue = txtTimkiem.Text;


            DataTable resultImage = db.TimKiemAnh(searchValue);
            if (resultImage.Rows.Count > 0)
            {

                dataGridView1.DataSource = resultImage;

                // Kiểm tra nếu cột "Ảnh" chưa có trong DataTable thì thêm vào sau cột "ImageData"
                if (!resultImage.Columns.Contains("Ảnh"))
                {
                    int index = resultImage.Columns.IndexOf("ImageData"); // Lấy vị trí cột "ImageData"
                    if (index == -1) index = resultImage.Columns.Count;  // Nếu không tìm thấy, thêm vào cuối

                    resultImage.Columns.Add("Ảnh", typeof(Bitmap)); // Thêm cột ảnh mới

                    // 📌 Cập nhật ảnh trong DataGridView
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["ImageData"].Value != null)
                        {
                            string imagePath = row.Cells["ImageData"].Value.ToString();
                            if (File.Exists(imagePath))
                            {
                                row.Cells["Ảnh"].Value = new Bitmap(imagePath);
                            }
                        }
                    }

                    // Đặt chiều cao và chiều rộng hàng để ảnh không bị dẹp
                    dataGridView1.RowTemplate.Height = 100;
                    dataGridView1.Columns["Ảnh"].Width = 250;

                    // Định dạng cột ảnh để hiển thị hình ảnh đúng cách
                    DataGridViewImageColumn imgColumn = (DataGridViewImageColumn)dataGridView1.Columns["Ảnh"];
                    imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Ảnh co giãn theo ô mà không bị mé

                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu");
                    dataGridView1.DataSource = null;
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dddd, dd MMMM yyyy";
        }
    }
}
