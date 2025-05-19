using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections;
using System.Drawing.Drawing2D;
using static AI_GenerateImagenChat.Program;
using System.Diagnostics;



namespace AI_GenerateImagenChat
{
    public partial class MainHome : Form
    {
        private Panel brightnessOverlay;
        Connecdata db = new Connecdata();
        public string UserEmail;

        private ContextMenuStrip menu;
        private ToolStripMenuItem menuItem;

        private ToolStripMenuItem menuItemHistoryImages;
        private ToolStripMenuItem menuItemHistoryChat;

        public bool isLoggedIn = false; // Kiểm tra trạng thái đăng nhập

        public MainHome()
        {
            InitializeComponent();
            SetDefaultProfilePicture();
            MakePictureBoxCircular();
            CreateContextMenu(); // Tạo menu cho ảnh đại diện
            this.Load += Form_Load;

            int borderRadius = 20; // Độ cong của góc (tùy chỉnh)
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
            path.AddArc(pictureBox4.Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
            path.AddArc(pictureBox4.Width - borderRadius, pictureBox4.Height - borderRadius, borderRadius, borderRadius, 0, 90);
            path.AddArc(0, pictureBox4.Height - borderRadius, borderRadius, borderRadius, 90, 90);
            path.CloseFigure();
            pictureBox4.Region = new Region(path);

        }


        private string apiKey = Environment.GetEnvironmentVariable("GG_IMG_KEY");
        // Or: Load from config file, not hardcoded.


        private async Task<string> DownloadAndSaveImage(string imageUrl, string imageName)
        {
            string fileDirectory = @"C:\Images\"; // Thư mục lưu ảnh
            string fileExtension = ".jpg"; // Định dạng ảnh
            string fileName = $"{imageName}_{Guid.NewGuid()}{fileExtension}"; // Đặt tên ảnh
            string filePath = Path.Combine(fileDirectory, fileName);

            // Kiểm tra thư mục có tồn tại không, nếu không thì tạo mới
            if (!Directory.Exists(fileDirectory))
            {
                Directory.CreateDirectory(fileDirectory);
            }

            using (HttpClient client = new HttpClient())
            {
                // Tải ảnh và lưu vào tệp
                byte[] imageBytes = await client.GetByteArrayAsync(imageUrl);
                await File.WriteAllBytesAsync(filePath, imageBytes); // Lưu ảnh vào tệp
            }

            return filePath; // Trả về đường dẫn tệp đã lưu
        }

        private async void btnTim_Click(object sender, EventArgs e)
        {
            string query = txtTim.Text.Trim();
            if (string.IsNullOrEmpty(query))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Danh sách từ khóa cấm
            string[] tuKhoaCam = { "sex", "xxx", "nude", "porn" };
            if (tuKhoaCam.Contains(query.ToLower()))
            {
                MessageBox.Show("Từ khóa không được phép tìm kiếm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string imageUrl = await GenerateImage(query);

            if (!string.IsNullOrEmpty(imageUrl))
            {
                decimal usersId = Properties.Settings.Default.CurrentUserId;

                string filePath = await DownloadAndSaveImage(imageUrl, query);

                if (usersId != 0)
                {
                    db.LuuLichSuAnh(usersId, filePath, query);
                }
                else
                {
                    db.LuuLichSuAnhs(filePath, query);
                }

                LoadImage(imageUrl);
            }
            else
            {
                MessageBox.Show("Không tìm thấy ảnh phù hợp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<string> GenerateImage(string query)
        {
            string url = $"https://api.unsplash.com/photos/random?query={query}&client_id={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    JToken token = JToken.Parse(json);

                    if (token.Type == JTokenType.Object)
                    {
                        var data = (JObject)token;
                        return data["urls"]?["regular"]?.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu trả về không đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"Lỗi API: {response.StatusCode}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return null;
        }
        private void LoadImage(string imageUrl)
        {
            try
            {
                var request = System.Net.WebRequest.Create(imageUrl);
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    pictureBox4.Image = Bitmap.FromStream(stream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnchat_Click(object sender, EventArgs e)
        {

            string token = Properties.Settings.Default.AccessToken;
            decimal usersId = Properties.Settings.Default.CurrentUserId;

            // Debug
            MessageBox.Show($"Token: {token}\nUserID: {usersId}", "Debug Info");

            if (string.IsNullOrEmpty(token) || usersId == 0)
            {
                MessageBox.Show("Bạn cần đăng nhập để chat!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Chat chat = new Chat();
            chat.Show();

        }

        private void LichSuChatToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string token = Properties.Settings.Default.AccessToken;
            decimal usersId = Properties.Settings.Default.CurrentUserId;

            if (string.IsNullOrEmpty(token) || usersId == 0)
            {
                MessageBox.Show("Bạn cần đăng nhập để xem lịch sử chat!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Không mở form nếu chưa đăng nhập
            }
            else
            {
                progressBar1.Value = 0; // Đặt progressBar về 0
                progressBar1.Visible = true; // Hiện progressBar (nếu cần)

                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 20; // Điều chỉnh tốc độ chạy (ms)
                timer.Tick += (s, ev) =>
                {
                    if (progressBar1.Value < 100)
                    {
                        progressBar1.Value += 2; // Tăng giá trị progressBar
                    }
                    else
                    {
                        timer.Stop(); // Dừng Timer khi đạt 100%
                        progressBar1.Visible = false; // Ẩn progressBar nếu muốn
                        ChatHistory lichsu = new ChatHistory();
                        lichsu.Show();
                    }
                };
                timer.Start(); // Bắt đầu chạy progressBar
            }

        }

        private void LichSuAnhToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string token = Properties.Settings.Default.AccessToken;
            decimal usersId = Properties.Settings.Default.CurrentUserId;

            if (string.IsNullOrEmpty(token) || usersId == 0)
            {
                MessageBox.Show("Bạn cần đăng nhập để xem lịch sử ảnh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Không mở form nếu chưa đăng nhập
            }
            else
            {
                progressBar1.Value = 0; // Đặt progressBar về 0
                progressBar1.Visible = true; // Hiện progressBar (nếu cần)

                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 25; // Điều chỉnh tốc độ chạy (ms)
                timer.Tick += (s, ev) =>
                {
                    if (progressBar1.Value < 100)
                    {
                        progressBar1.Value += 2; // Tăng giá trị progressBar
                    }
                    else
                    {
                        timer.Stop(); // Dừng Timer khi đạt 100%
                        progressBar1.Visible = false; // Ẩn progressBar nếu muốn

                        ImageHistory lichSuAnh = new ImageHistory();
                        lichSuAnh.Show(); // Mở form sau khi progressBar chạy xong
                    }
                };
                timer.Start(); // Bắt đầu chạy progressBar
            }


        }

        // Tạo menu khi nhấn vào PictureBox7
        private void CreateContextMenu()
        {

            menu = new ContextMenuStrip(); //  Phải khởi tạo menu trước khi sử dụng

            menu.AutoSize = false;
            menu.Width = 200;
            menu.Height = 500;
            menu.Font = new Font("Segoe UI", 12, FontStyle.Regular);

            menu = new ContextMenuStrip();
            menuItem = new ToolStripMenuItem();


            // Menu item Lịch sử ảnh với icon
            menuItemHistoryImages = new ToolStripMenuItem("📸  Lịch sử ảnh");
            menuItemHistoryImages.TextAlign = ContentAlignment.MiddleLeft; // Căn trái nội dung
            menuItemHistoryImages.Padding = new Padding(0, 2, 2, 2); // Đẩy nội dung lệch sang trái 1 chút
            menuItemHistoryImages.Click += LichSuAnhToolStripMenuItem_Click_1;

            // Menu item Lịch sử chat với icon
            menuItemHistoryChat = new ToolStripMenuItem("💬  Lịch sử chat");
            menuItemHistoryChat.TextAlign = ContentAlignment.MiddleLeft; // Căn trái nội dung
            menuItemHistoryChat.Padding = new Padding(0, 2, 2, 2);
            menuItemHistoryChat.Click += LichSuChatToolStripMenuItem_Click;


            menu.Items.Add(menuItemHistoryImages);
            menu.Items.Add(menuItemHistoryChat);
            menu.Items.Add(new ToolStripSeparator()); // Dấu gạch ngang ngăn cách
            menuItem.Click += MenuItem_Click; // Xử lý sự kiện khi nhấn vào menu
            menu.Items.Add(menuItem);

            pictureBox7.ContextMenuStrip = menu; // Gán menu cho pictureBox7
            pictureBox7.Click += pictureBox7_Click;
            UpdateMenuText(); // Cập nhật nội dung menu

            menu.Opening += Menu_Opening;

            menu.Paint += Menu_Paint;


        }

        private void Menu_Paint(object sender, PaintEventArgs e)
        {
            int radius = 20; // Độ bo góc
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Vẽ menu với góc bo tròn
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, radius, radius, 180, 90); // Trên trái
                path.AddArc(menu.Width - radius, 0, radius, radius, 270, 90); // Trên phải
                path.AddArc(menu.Width - radius, menu.Height - radius, radius, radius, 0, 90); // Dưới phải
                path.AddArc(0, menu.Height - radius, radius, radius, 90, 90); // Dưới trái
                path.CloseFigure();

                menu.Region = new Region(path); // Đặt vùng hiển thị cho menu
                g.FillPath(Brushes.White, path); // Đổ nền trắng
                g.DrawPath(new Pen(Color.Gray, 2), path); // Vẽ viền
            }
        }

        private void Menu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Point position = pictureBox7.PointToScreen(Point.Empty);

            // Tính toán vị trí để menu xuất hiện dưới pictureBox7
            position.Y += pictureBox7.Height;  // Đẩy menu xuống dưới pictureBox7
            position.X -= 125;  // Dịch menu sang trái (tuỳ chỉnh theo nhu cầu)

            // Hiển thị menu tại vị trí đã tính toán
            menu.Show(position);
        }

        // Cập nhật menu theo trạng thái đăng nhập
        private void UpdateMenuText()
        {
            if (menuItem != null)
            {
                if (!string.IsNullOrEmpty(Properties.Settings.Default.AccessToken))
                {
                    menuItem.Text = "🔓  Đăng xuất";
                }
                else
                {
                    menuItem.Text = "🔑  Đăng nhập";
                }
            }
        }

        // Khi nhấn vào menu "Đăng nhập" hoặc "Đăng xuất"
        private void MenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.AccessToken)) // Kiểm tra nếu đã đăng nhập
            {
                // Xử lý đăng xuất
                Properties.Settings.Default.AccessToken = string.Empty;
                Properties.Settings.Default.UsersAvartar = "";
                Properties.Settings.Default.CurrentUserId = 0;
                Properties.Settings.Default.Save(); // Lưu lại trạng thái mới

                SetDefaultProfilePicture(); // Hiển thị ảnh mặc định
                MessageBox.Show("Bạn đã đăng xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Xử lý đăng nhập
                Dangnhap dangnhap = new Dangnhap();
                dangnhap.ShowDialog(); // Mở form đăng nhập dạng popup
            }
            UpdateMenuText(); // Cập nhật lại menu
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            menu.Show(pictureBox7, new Point(0, pictureBox7.Height));
        }



        // Hàm làm tròn PictureBox
        private void MakePictureBoxCircular()
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = Math.Min(pictureBox7.Width, pictureBox7.Height); // Đảm bảo hình tròn
            path.AddEllipse(0, 0, diameter, diameter);

            pictureBox7.Region = new Region(path); // Cắt vùng hiển thị thành hình tròn
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage; // Đảm bảo ảnh vừa khung
        }

        private void Form_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.UsersAvartar))
            {
                pictureBox7.ImageLocation = Properties.Settings.Default.UsersAvartar;
            }
        }


        public void UpdateUserInfo(User userInfo)
        {
            if (userInfo != null)
            {
                this.UserEmail = userInfo.Email;

                if (!string.IsNullOrEmpty(userInfo.Picture))
                {
                    pictureBox7.ImageLocation = userInfo.Picture; // Cập nhật avatar
                    Properties.Settings.Default.UsersAvartar = userInfo.Picture; // Lưu vào Settings
                    Properties.Settings.Default.Save(); // Lưu lại cài đặt
                }
            }

        }

        // Hàm đặt ảnh mặc định
        private void SetDefaultProfilePicture()
        {
            if (pictureBox7 != null)
            {
                string appPath = Application.StartupPath; // đường dẫn thư mục chứa file .exe
                string imagePath = Path.Combine(appPath, "Resources", "anhdaidien.jpg");

                if (File.Exists(imagePath))
                {
                    pictureBox7.Image = Image.FromFile(imagePath);
                }
                else
                {
                    // Xử lý khi không tìm thấy ảnh, ví dụ: đặt ảnh mặc định khác hoặc bỏ qua
                    MessageBox.Show("Không tìm thấy ảnh đại diện mặc định tại: " + imagePath);
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
