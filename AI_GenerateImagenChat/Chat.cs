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
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;

namespace AI_GenerateImagenChat
{
    public partial class Chat : Form
    {
        private string sessionId = Guid.NewGuid().ToString();

        private void ApplyTheme(Color formColor, Color panelColor, Color textColor, Color checkboxColor, Color controlColor, Color buttonColor)
        {
            this.BackColor = formColor; // Đổi màu nền của Form chính

            // Cập nhật màu nền & chữ cho các thành phần
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label || ctrl is CheckBox)
                {
                    ctrl.ForeColor = textColor; // Màu chữ của Label, Button, CheckBox
                }
                else if (ctrl is Panel || ctrl is GroupBox)
                {
                    ctrl.BackColor = panelColor; // Màu nền của Panel, GroupBox
                }
                else if (ctrl is RichTextBox || ctrl is TextBox)
                {
                    ctrl.BackColor = controlColor;  // Nền xám đen khi chế độ tối
                    ctrl.ForeColor = textColor;     // Chữ trắng khi chế độ tối
                }
                else if (ctrl is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat; // Đảm bảo nút không có hiệu ứng mặc định
                    btn.UseVisualStyleBackColor = false; // Bắt buộc sử dụng màu nền tùy chỉnh
                    btn.BackColor = controlColor;  // Đổi màu nền (xám đậm khi nền đen)
                    btn.ForeColor = textColor;     // Đổi màu chữ (trắng khi nền đen)
                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = textColor; // Viền theo màu chữ

                }
                // Đổi màu chữ của checkbox
                trang.ForeColor = checkboxColor;
                den.ForeColor = checkboxColor;
            }
        }
        public Chat()
        {
            InitializeComponent();
            CheckAndRequireLogin(); // Gọi hàm kiểm tra đăng nhập khi mở form
            // Mặc định chọn ô trắng
            trang.Checked = true;
            ApplyTheme(Color.PeachPuff, Color.White, Color.Black, Color.Black, Color.White, Color.White);
        }

        // Hàm kiểm tra đăng nhập
        private void CheckAndRequireLogin()
        {
            if (Properties.Settings.Default.CurrentUserId == 0) // Nếu chưa đăng nhập
            {
                Dangnhap loginForm = new Dangnhap();
                loginForm.ShowDialog();

                // Nếu vẫn chưa đăng nhập, đóng form Chat
                if (Properties.Settings.Default.CurrentUserId == 0)
                {
                    this.Close();
                }
            }
        }
        
        private async Task<string> GetGeminiResponse(string prompt)
        {
            try
            {
                // Thay 'YOU_API_KEY' bằng khóa API 
                string api_key = Environment.GetEnvironmentVariable("GEMINI_API_KEY");
                using (HttpClient client = new HttpClient())
                {
                    // Cấu hình yêu cầu cho google  Genmi API
                    var requestBody = new { contents = new[] { new { parts = new { text = prompt } } } };
                    var jsonRequestBody = JsonConvert.SerializeObject(requestBody);

                    var content = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");
                    // URL endpoint của Genmi API
                    var response = await client.PostAsync($"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash-latest:generateContent?key={api_key}", content);
                    var responseString = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<dynamic>(responseString);
                    string answer = responseObject?.candidates[0].content?.parts[0]?.text ?? "Error: ";
                    return answer;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in GetGeminiResponse: {ex.Message}");
                throw;
            }
        }

        private async void btnNhap_Click(object sender, EventArgs e)
        {
            // Kiểm tra UserId
            if (Properties.Settings.Default.CurrentUserId == 0)
            {
                CheckAndRequireLogin();
                if (Properties.Settings.Default.CurrentUserId == 0) return; // Nếu vẫn chưa đăng nhập thì thoát luôn
            }

            decimal usersId = Properties.Settings.Default.CurrentUserId;

            string useInput = txtChat.Text;
            if (!string.IsNullOrEmpty(useInput))
            {
                richTextBoxOutput.AppendText("Bạn: " + useInput + "\n" + "\n");
                richTextBoxOutput.AppendText("Harry potter: Loading...." + "\n" + "\n");
                //Lưu chỉ mục của dòng Loading
                int loadingLineIndex = richTextBoxOutput.Lines.Length - 1;
                string response = await GetGeminiResponse(useInput);
                // Tim  vị trí của dòng "Loading" để thay thế
                string[] liner = richTextBoxOutput.Lines;
                for (int i = 0; i < liner.Length; i++)
                {
                    if (liner[i].StartsWith("Harry potter: Loading...."))
                    {
                        //Cập nhật nội dụng dòng "Loading...." với phản hồi thực tế
                        liner[i] = "Harry potter: " + response;
                        break;
                    }
                }
                //Xóa nội dung hiện tại và thay thế bằng các dòng mới 
                richTextBoxOutput.Lines = liner;

                Connecdata db = new Connecdata();
                db.LuuLichSuChat(usersId, sessionId, useInput, response);
                // Xóa TextBox sau khi gửi
                txtChat.Clear();
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập đoạn chat!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void trang_CheckedChanged(object sender, EventArgs e)
        {
            if (trang.Checked)
            {
                den.Checked = false;
                ApplyTheme(Color.PeachPuff, Color.White, Color.Black, Color.Black, Color.White, Color.White);
            }
        }

        private void den_CheckedChanged(object sender, EventArgs e)
        {
            if (den.Checked)
            {
                trang.Checked = false;
                ApplyTheme(Color.Black, Color.DarkSlateGray, Color.White, Color.White, Color.DimGray, Color.DimGray);
            }


        }

        private void richTextBoxOutput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
