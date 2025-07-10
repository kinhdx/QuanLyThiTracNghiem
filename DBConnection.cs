using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem
{

    class DBConnection
    {
        private static string connectionString = @"Data Source=WINDOWS-10\SQLEXPRESS;Initial Catalog=QuanLyThiTracNghiem;Integrated Security=True";
        public static string ConnectionString() => connectionString;
    }
}
