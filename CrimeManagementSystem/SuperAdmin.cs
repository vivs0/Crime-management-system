using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography;
using core;

namespace CrimeManagementSystem
{
    public partial class SuperAdmin : Form
    {
        public SuperAdmin()
        {
            InitializeComponent();
        }

        SqlCommand cmd;
        private void Form1_Load(object sender, EventArgs e)
        {
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string roles = "SA";
            using (SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=FIR_db; User Id = sa; Password = 2611798"))
            {
                conn.Open();
                cmd = new SqlCommand("insert into su_admin(pass,roles)values(@a,@b)",conn);
                cmd.Parameters.AddWithValue("@a", Core.CreateHash(textBox1.Text));
                cmd.Parameters.AddWithValue("@b", roles);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
