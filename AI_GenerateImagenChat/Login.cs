using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Requests;
using System.Net;
using System.Security.Policy;
using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.ApplicationServices;
using System.IO;

namespace AI_GenerateImagenChat
{
    public partial class Dangnhap : Form
    {

        Connecdata db = new Connecdata();


        private static IConfigurationRoot LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Lấy đường dẫn thư mục hiện tại
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            return builder.Build();
        }

        private static readonly IConfigurationRoot config = LoadConfiguration();
        private static readonly string ClientId = config["GoogleOAuth:ClientId"];
        private static readonly string ClientSecret = config["GoogleOAuth:ClientSecret"];

        private const string RedirectUri = "urn:ietf:wg:oauth:2.0:oob";

        private const string TokenUrl = "https://oauth2.googleapis.com/token";

        public Dangnhap()
        {
            InitializeComponent();
        }

        private async void btnLoginGoogle_Click(object sender, EventArgs e)
        {
            var authorizationUrl = GetAuthorizationUrl();
            Process.Start(new ProcessStartInfo
            {
                FileName = authorizationUrl,
                UseShellExecute = true
            });

            // Hiển thị hộp thoại để nhập mã từ trình duyệt
            string authCode = Microsoft.VisualBasic.Interaction.InputBox(
                "Nhập mã xác thực từ Google:", "Google Login", "");

            if (!string.IsNullOrEmpty(authCode))
            {
                try
                {
                    // Đổi mã xác thực thành Access Token
                    string accessToken = await ExchangeCodeForTokenAsync(authCode);

                    // Lấy thông tin user từ Google
                    var userInfo = await GetGoogleUserInfoAsync(accessToken);
                    if (userInfo == null || string.IsNullOrEmpty(userInfo.Email))
                    {
                        MessageBox.Show("Không thể lấy email từ Google.", "Lỗi");
                        return;
                    }

                    // Debug JSON trả về
                    Console.WriteLine($"User ID: {userInfo.Id}");
                    Console.WriteLine($"User Email: {userInfo.Email}");
                    Console.WriteLine($"User Name: {userInfo.Name}");
                    Console.WriteLine($"User Picture: {userInfo.Picture}");

                    // Lưu vào database
                    db.SaveUserToDatabase(userInfo);
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    Properties.Settings.Default.AccessToken = accessToken;
                    Properties.Settings.Default.CurrentUserId = db.GetUserIdByEmail(userInfo.Email);

                    Properties.Settings.Default.UsersAvartar = userInfo.Picture;
                    Properties.Settings.Default.Save();

                    foreach (Form frm in Application.OpenForms)
                    {
                        if (frm is MainHome trangchus)
                        {
                            trangchus.UpdateUserInfo(userInfo);
                            break;
                        }
                    }

                    this.Close(); // Đóng form đăng nhập
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi đăng nhập: {ex.Message}", "Lỗi");
                }
            }
        }

        
        private string GetAuthorizationUrl()
        {
            var authorizationUrl = new GoogleAuthorizationCodeRequestUrl(new Uri("https://accounts.google.com/o/oauth2/auth"))
            {
                ClientId = ClientId,
                RedirectUri = RedirectUri,
                Scope = "https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/userinfo.profile",
                ResponseType = "code"
            };

            return authorizationUrl.Build().AbsoluteUri;
        }


        public async Task<string> ExchangeCodeForTokenAsync(string code)
        {
            using (var httpClient = new HttpClient())
            {
                var requestBody = new
                {
                    client_id = ClientId,
                    client_secret = ClientSecret,
                    redirect_uri = RedirectUri,
                    code = code,
                    grant_type = "authorization_code"
                };

                var jsonContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(TokenUrl, jsonContent);
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(jsonResponse);
                var accessToken = doc.RootElement.GetProperty("access_token").GetString();

                return accessToken;
            }
        }


        public async Task<User?> GetGoogleUserInfoAsync(string accessToken)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                HttpResponseMessage response = await httpClient.GetAsync("https://www.googleapis.com/oauth2/v2/userinfo");
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Google API Response: " + jsonResponse); // Debug dữ liệu trả về

                var userInfo = JsonSerializer.Deserialize<User>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return userInfo;
            }
        }

     
    }
}
