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
using core;
using System.Text.RegularExpressions;
using contentLibrary;

namespace CrimeManagementSystem
{
    public partial class Login : Form
    {
        public static string userName;
        public static string role;
        public static string credential;
        public Login()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            close();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (checkManadatory(txtLoginID.Text))
            {
                DialogResult dr = MessageBox.Show("Login ID must not be blank", "Login ID blank", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (checkPassword(txtPassword.Text))
            {
                DialogResult dr = MessageBox.Show("Password field mus not be blank", "Password blank", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                checkLogin(txtLoginID.Text, txtPassword.Text);
            }
            
        }

        public void checkLogin(string login, string pass)
        {
            string hash;
            int count;
            SqlCommand cmd;
            try
            {
                using (SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=FIR_db; User Id = sa; Password = 2611798"))
                {
                    conn.Open();
                    cmd = new SqlCommand("select count(loginid) from logins where loginid = @a ", conn);
                    cmd.Parameters.AddWithValue("@a", txtLoginID.Text);
                    if ((int)cmd.ExecuteScalar() == 1)
                    {
                        cmd = new SqlCommand("select password_ from logins where loginid = @a ", conn);
                        cmd.Parameters.AddWithValue("@a", txtLoginID.Text);
                        hash = (string)cmd.ExecuteScalar();
                        if (Core.ValidatePassword(txtPassword.Text, hash))
                        {
                            cmd = new SqlCommand("select roles from logins where loginid = @a ", conn);
                            cmd.Parameters.AddWithValue("@a", txtLoginID.Text);
                            role = (string)cmd.ExecuteScalar();
                            DialogResult dr = MessageBox.Show("login sucessfull","Login Status",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            status.setstatus(true);
                            if (dr == DialogResult.OK)
                            {
                                close();
                            }
                        }
                        else
                        {
                            DialogResult dr = MessageBox.Show("Invalid Login ID or Password");
                        }
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Invalid Login ID or Password");
                    }
                }
            }
            catch (SqlException sce)
            {
                DialogResult dr = MessageBox.Show("Server is temporarily down. Please try again later", "Server is Down", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public bool checkManadatory(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return true;
            }
            return false;
        }
        public bool checkPassword(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return true;
            }
            return false;
        }
        void close()
        {
            if (string.IsNullOrEmpty(role))
            {
                main.log.Text = "You don't have any credential to use this software. Please login.";
                this.Close();
            }
            else
            {
                main.log.Text = role;
                main.userLevel = role;
                this.Close();
            }
        }

    }
}