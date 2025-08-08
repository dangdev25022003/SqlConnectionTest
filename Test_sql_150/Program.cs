//using System;
//using System.Data.SqlClient;

//class Program
//{
//    static void Main()
//    {
//        Console.OutputEncoding = System.Text.Encoding.UTF8;
//        string connectionString = "Server=VNHNLEXVM\\MSSQLSERVER1;Database=Company;Trusted_Connection=True;";

//        using (SqlConnection conn = new SqlConnection(connectionString))
//        {
//            try
//            {
//                conn.Open();
//                Console.WriteLine("✅ Đã kết nối tới SQL Server!");

//                string sql = "SELECT * FROM NhanVien";
//                using (SqlCommand cmd = new SqlCommand(sql, conn))
//                using (SqlDataReader reader = cmd.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {
//                        Console.WriteLine($"ID: {reader["MaNV"]}, Họ tên: {reader["HoTen"]}, Ngày sinh: {reader["NgaySinh"]}, Chức vụ: {reader["ChucVu"]}");
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("❌ Lỗi kết nối: " + ex.Message);
//            }
//        }
//    }
//}
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Write("Enter product name to search: ");
        string productName = Console.ReadLine();

        bool isInStore1 = IsProductInStore("Store1Connection", productName);
        bool isInStore2 = IsProductInStore("Store2Connection", productName);

        if (isInStore1 && isInStore2)
        {
            Console.WriteLine($"✅ The product '{productName}' is available in BOTH stores.");
        }
        else if (isInStore1 || isInStore2)
        {
            Console.WriteLine($"⚠️ The product '{productName}' is available in only ONE store.");
        }
        else
        {
            Console.WriteLine($"❌ The product '{productName}' is NOT available in any store.");
        }
    }

    static bool IsProductInStore(string connectionKey, string productName)
    {
        string connectionString = ConfigurationManager.ConnectionStrings[connectionKey]?.ConnectionString;
        if (connectionString == null)
        {
            Console.WriteLine($"❌ Connection string '{connectionKey}' not found.");
            return false;
        }

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT COUNT(*) FROM Products WHERE Name = @Name";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", productName);

                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
    }
}

