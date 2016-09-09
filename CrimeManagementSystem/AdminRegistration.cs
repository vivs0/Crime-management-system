using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using core;

namespace CrimeManagementSystem
{
    public partial class AdminRegistration : Form
    {
        public AdminRegistration()
        {
            InitializeComponent();
            load("select designation, id from post order by id", txtDesignation, "designation", "id");
            load("select statename, stateid from states", txtState, "statename", "stateid");
            load("select districtName, districtid from districts", txtDistrict, "districtname", "districtid");
        }
        int i;
        SqlCommand cmd;
        DataTable dt;
        private Regex validator;
        private void AdminRegistration_Load(object sender, EventArgs e)
        {
        }
        public bool checkManadatory(string str)
        {
            validator = new Regex(@"[~`!@#$%^&*()-+=|\\{}':;.,<>/?[\]""_0123456789\s]");
            if (string.IsNullOrWhiteSpace(str))
            {
                return true;
                DialogResult dr = MessageBox.Show("First Name should not be blank/ contain special character/ blank spaces", "Name Field blank", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (validator.Match(str.Trim()).Success)
            {
                return true;
                DialogResult dr = MessageBox.Show("First Name should not be blank/ contain special character/ blank spaces", "Name Field blank", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return false;
        }
        private bool checkOptional(string str)
        {
            validator = new Regex(@"[~`!@#$%^&*()-+=|\\{}':;.,<>/?[\]""_0123456789]");
            if (validator.Match(str.Trim()).Success)
            {
                return true;
            }
            return false;
        }

        public bool checkPassword(string str)
        {
            validator = new Regex(@"^(?=.*[a-z])(?=.*[0-9]).{6,10}$");
            if (string.IsNullOrWhiteSpace(str))
            {
                return true;
            }
            else if (!validator.Match(str).Success)
            {
                return true;
            }
            return false;
        }
        public bool checkPassword(string pass1, string pass2)
        {
            if (!string.Equals(pass1,pass2))
            {
                return true;
            }
            return false;
        }
        
        private void load(string query, ComboBox name, string itemField, string valueField)
        {
            using (SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=FIR_db; User Id = sa; Password = 2611798"))
            {
                try
                {
                    cmd = new SqlCommand(query, conn);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    conn.Open();
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    name.DataSource = ds.Tables[0];
                    name.DisplayMember = itemField;
                    name.ValueMember = valueField;
                }
                catch (SqlException exc)
                {
                    DialogResult dr = MessageBox.Show("Error in server. Could not load Designation.", "Error in server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void load(string query, ComboBox name, string itemField, string valueField, object para)
        {
            using (SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=FIR_db; User Id = sa; Password = 2611798"))
            {
                try
                {
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@a", para);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    conn.Open();
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    name.DataSource = ds.Tables[0];
                    name.DisplayMember = itemField;
                    name.ValueMember = valueField;
                }
                catch (SqlException exc)
                {
                    DialogResult dr = MessageBox.Show("Error in server. Could not load Designation.", "Error in server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtState_SelectionChangeCommitted(object sender, EventArgs e)
        {
                load("select districtid,districtName from districts where stateid=@a", txtDistrict, "districtname", "districtid", txtState.SelectedValue);
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (checkManadatory(txtFname.Text))
            {
                DialogResult dr = MessageBox.Show("invalid First name.", "Name Invalid", MessageBoxButtons.OK);
            }
            else if (checkOptional(textMname.Text))
            {
                DialogResult dr = MessageBox.Show("Invalid Middle name.", "Name Invalid", MessageBoxButtons.OK);
            }
            else if (checkOptional(textLname.Text))
            {
                DialogResult dr = MessageBox.Show("Invalid Last name.", "Name Invalid", MessageBoxButtons.OK);
            }
            else if (checkPassword(txtPass.Text))
            {
                DialogResult dr = MessageBox.Show("Invalid Password.", "Password Invalid", MessageBoxButtons.OK);
            }
            else if (checkPassword(txtPass.Text, txtRePass.Text))
            {
                DialogResult dr = MessageBox.Show("Password not matched.", "Password Invalid", MessageBoxButtons.OK);
            }
            else
            {
                using (SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=FIR_db; User Id = sa; Password = 2611798"))
                {
                    try
                    {
                        string role = "AD";
                        conn.Open();
                        var desigRow = (DataRowView)txtDesignation.SelectedItem;
                        var stateRow = (DataRowView)txtState.SelectedItem;
                        var districtRow = (DataRowView)txtDistrict.SelectedItem;
                        cmd = new SqlCommand("insert into _admin(firstName, middleName, lastName, Designation, doj, States,district,roles,pass)values(@a,@b,@c,@d,@e,@f,@g,@h,@i)", conn);
                        cmd.Parameters.AddWithValue("@a", txtFname.Text);
                        cmd.Parameters.AddWithValue("@b", textMname.Text);
                        cmd.Parameters.AddWithValue("@c", textLname.Text);
                        cmd.Parameters.AddWithValue("@d", desigRow["designation"].ToString());
                        cmd.Parameters.AddWithValue("@e", txtDoj.Value);
                        cmd.Parameters.AddWithValue("@f", stateRow["stateName"].ToString());
                        cmd.Parameters.AddWithValue("@g", districtRow["districtName"].ToString());
                        cmd.Parameters.AddWithValue("@h", role.ToString());
                        cmd.Parameters.AddWithValue("@i", Core.CreateHash(txtPass.Text));
                        i = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException secp)
                    {
                        DialogResult dr = MessageBox.Show(secp.Message.ToString(), "Error in server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (i > 0)
                        {
                            DialogResult dr = MessageBox.Show("Succesfully Submited.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            DialogResult dr = MessageBox.Show("There is some mistake in your Registration process / server is temporarily down ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        conn.Close();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

 }

