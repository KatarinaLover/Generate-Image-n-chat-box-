using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing;
using System.Data;
using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data.Common;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;


namespace AI_GenerateImagenChat
{
    public class Connecdata
    {
        private string connectionString = "Data Source=LAPTOP-DQ58LHVB\\KATEPHAN;Initial Catalog=APP_AI_Chat;Integrated Security=True;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }


        public decimal GetUserIdByEmail(string email)
        {
            decimal userId = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id FROM Users WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    userId = (decimal)result;
                }
            }
            return userId;
        }




        // Hàm lưu lịch sử chat vào SQL Server
        public void LuuLichSuChat(decimal usersId,string sessionId, string question, string answer)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "INSERT INTO ChatHistory (UsersId, SessionID, Question, Answer) VALUES (@UsersId, @SessionID, @Question, @Answer)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UsersId", usersId);
                    cmd.Parameters.AddWithValue("@SessionID", sessionId);
                    cmd.Parameters.AddWithValue("@Question", question);
                    cmd.Parameters.AddWithValue("@Answer", answer);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Hàm lưu lịch sử hình ảnh và SQL Server
        public void LuuLichSuAnh(decimal usersId, string imageData, string nameImage)
        {

            using (SqlConnection comm = GetConnection())
            {
                string query = "INSERT INTO ImageSearchHistory (UsersId, ImageData, NameImage) VALUES (@UsersId, @ImageData, @NameImage)";
                using (SqlCommand cmds = new SqlCommand(query, comm))
                {
                    cmds.Parameters.AddWithValue("@UsersId", usersId);
                    cmds.Parameters.AddWithValue("@ImageData", imageData);
                    cmds.Parameters.AddWithValue("@NameImage", nameImage);
                    comm.Open();
                    cmds.ExecuteNonQuery();
                }
            }
        }

        // Hàm lưu lịch sử hình ảnh và SQL Server
        public void LuuLichSuAnhs(string imageData, string nameImage)
        {

            using (SqlConnection comm = GetConnection())
            {
                string query = "INSERT INTO ImageSearchHistory (ImageData, NameImage) VALUES (@ImageData, @NameImage)";
                using (SqlCommand cmds = new SqlCommand(query, comm))
                {
                    cmds.Parameters.AddWithValue("@ImageData", imageData);
                    cmds.Parameters.AddWithValue("@NameImage", nameImage);
                    comm.Open();
                }
            }
        }

        //  Hàm lấy lịch sử chat từ SQL Server
        public DataTable LayDanhSachLichSu(decimal usersId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT SessionID, Timestamp, Question, Answer FROM ChatHistory WHERE UsersId = @UsersId ORDER BY SessionID DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UsersId", usersId);
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
        //  Hàm lấy lịch sử ảnh từ SQL Server
        public DataTable LayDanhSachLichSuAnh(decimal usersId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT Id, ImageData, SearchTime, NameImage FROM ImageSearchHistory WHERE UsersId = @UsersId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@UsersId", usersId);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // Hàm Xóa Tất Cả dữ liệu ImageSearchHistory
        public void XoaTatCaDuLieu(decimal usersId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM ImageSearchHistory WHERE UsersId = @UsersId"; // Thay TenBang bằng tên bảng của bạn
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UsersId", usersId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Hàm xóa tất cả dữ liệu của ChatHistory
        public void XoaTatcadulieuChatHistory(decimal usersId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM ChatHistory WHERE UsersId = @UsersId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UsersId", usersId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Hàm Xóa dữ liệu dựa trên id
        public void XoaDuLieuTheoID(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM ImageSearchHistory WHERE Id = @Id"; // Dùng tham số tránh SQL Injection
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("Không tìm thấy ID để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm xóa dữ liệu bảng ChatHistory dự trên mã 
        public void XoaLichSuTheoSessionID(decimal usersId, string sessionID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ChatHistory WHERE UsersId = @UsersId AND SessionID = @SessionID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UsersId", usersId);

                    // Chuyển đổi sessionID từ string sang Guid
                    if (Guid.TryParse(sessionID, out Guid sessionGuid))
                    {
                        cmd.Parameters.Add("@SessionID", SqlDbType.UniqueIdentifier).Value = sessionGuid;
                    }
                    else
                    {
                        MessageBox.Show("SessionID không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        // Hàm tìm kiếm dựa trên Id
        public DataTable TimKiemAnh(string searchValue)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM ImageSearchHistory WHERE Id = @search OR NameImage LIKE '%' + @search + '%'";


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@search", searchValue);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                   
                }
            }

            return dt;
        }


        // lấy danh sách ảnh và số lượng của mỗi ảnh
        public DataTable SoLuongAnh(string keyword, decimal usersId)
        {
            DataTable dt = new DataTable();
            string query = "SELECT NameImage, COUNT(*) as so_luong FROM ImageSearchHistory WHERE NameImage LIKE @keyword AND UsersId = @UsersId GROUP BY NameImage";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (string.IsNullOrEmpty(keyword))
                    {
                        cmd.Parameters.AddWithValue("@keyword", "%"); // Nếu rỗng, lấy tất cả
                        cmd.Parameters.Add("@UsersId", SqlDbType.Decimal).Value = usersId;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%"); // Tìm kiếm theo từ khóa
                        cmd.Parameters.Add("@UsersId", SqlDbType.Decimal).Value = usersId;
                    }


                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }


        public DataTable LoadHinhAnh(string keyword, decimal usersId) 
        {
            DataTable dt = new DataTable();

            string query = "SELECT Id, ImageData, SearchTime, NameImage FROM ImageSearchHistory WHERE UsersId = @UsersId AND NameImage LIKE @keyword";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@UsersId", SqlDbType.Decimal).Value = usersId;
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

                
            }
            return dt;
        }


        public void SaveUserToDatabase(User userInfo)
        {


            Console.WriteLine("Email nhận được: " + userInfo.Email);
            if (string.IsNullOrEmpty(userInfo.Email))
            {
                throw new ArgumentException("Email không được để trống.");
            }
            // Chuyển đổi Google ID sang decimal
            decimal userId = ConvertGoogleId(userInfo.Id, true);
            string query = @"IF NOT EXISTS (SELECT 1 FROM Users WHERE Email = @Email)
                        BEGIN
                            INSERT INTO Users (Id, Email, Name, Picture)
                            VALUES (@Id, @Email, @Name, @Picture)
                        END";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        Console.WriteLine("Email: " + (userInfo.Email ?? "NULL"));

                        command.Parameters.Add(new SqlParameter("@Id", userId));
                        command.Parameters.Add(new SqlParameter("@Email", userInfo.Email ?? (object)DBNull.Value));
                        command.Parameters.Add(new SqlParameter("@Name", userInfo.Name ?? (object)DBNull.Value));
                        command.Parameters.Add(new SqlParameter("@Picture", userInfo.Picture ?? (object)DBNull.Value));

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Thông tin người dùng đã được lưu vào database.");
                        }
                        else
                        {
                            Console.WriteLine("Người dùng đã tồn tại trong database.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi lưu thông tin người dùng: " + ex.Message);
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

        // Phương thức cắt chuỗi
        public decimal ParseGoogleId(string googleId)
        {
            if (string.IsNullOrEmpty(googleId))
                throw new ArgumentException("Google ID không được null hoặc rỗng");

            // Lấy tối đa 18 chữ số cuối
            string idPart = googleId.Length > 18 ? googleId.Substring(googleId.Length - 18) : googleId;

            if (!decimal.TryParse(idPart, out decimal result))
                throw new FormatException("Không thể chuyển đổi Google ID thành số");

            return result;
        }

        // Phương thức hash MD5
        public decimal GoogleIdToDecimal(string googleId)
        {
            if (string.IsNullOrEmpty(googleId))
                throw new ArgumentException("Google ID không được null hoặc rỗng");

            using (var md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(googleId));
                // Lấy 8 byte đầu và chuyển thành số dương
                long longHash = BitConverter.ToInt64(hash, 0);
                decimal result = Math.Abs(longHash) % 1000000000000000000m;

                // Đảm bảo không trả về 0
                return result == 0 ? 1 : result;
            }
        }

        // Phương thức tổng hợp
        public decimal ConvertGoogleId(string googleId, bool useHashing = true)
        {
            try
            {
                return useHashing ? GoogleIdToDecimal(googleId) : ParseGoogleId(googleId);
            }
            catch
            {
                // Fallback: luôn dùng hash nếu parse thất bại
                return GoogleIdToDecimal(googleId);
            }
        }



    }
}
