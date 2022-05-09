using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;

namespace TestApp.Respository
{
    class Transact
    {
        public void Create()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-VC8JTUE\SQLEXPRESS;Initial Catalog=notown;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand($"INSERT INTO tb_address(description, phone, created_by, updated_by) VALUES ('Casa de habitacion', '45456767', 1, 1)");
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void CreateWithParams(string desc, string phone, int user)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-VC8JTUE\SQLEXPRESS;Initial Catalog=notown;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand($"INSERT INTO tb_address(description, phone, created_by, updated_by) VALUES ('{desc}', '{phone}', {user}, {user})");
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }

    }
}
