using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using contentLibrary;
using System.Drawing.Drawing2D;
using System.Data.Sql;
using System.Data.SqlClient;

namespace CrimeManagementSystem
{
    public partial class FIRDetail : Form
    {
        public SqlCommand cmd;
        public FIRDetail()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private void FIRDetail_Load(object sender, EventArgs e)
        {
            lblFirID.Text = main.FIR_ID;
            lblName.Text = main.complainerName;
            lblComplainerFullAddress.Text = main.complainerAddress;
            lblComplain.Text = main.complain;
            lblMobile.Text = main.complainerMobile;
            lblIncidentDate.Text = main.incidentDate;
            lblFIRDate.Text = main.firDate;
            lblAccusedName.Text = main.Accusedname;
            status1.SelectedText = main.stat1;
            status2.SelectedText = main.stat2;

            if (main.stat1 != "Pending")
            {
                status1.Enabled = false;
                button1.Visible = false;
            }
            if (main.stat2 != "Pending")
            {
                status2.Enabled = false;
                button2.Visible = false;
            }
        }

        void updateThis(string columnName, string textBoxValue)
        {
            using (SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=FIR_db; User Id = sa; Password = 2611798"))
            {
                try
                {
                    string query = string.Format("update fir_status set {0} = @b where fir_id= @c", columnName);
                    cmd = new SqlCommand(query, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@b", textBoxValue);
                    cmd.Parameters.AddWithValue("@c", lblFirID.Text);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException exc)
                {
                    DialogResult dr = MessageBox.Show("Error in server. Could not load Designation.", "Error in server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            updateThis("recieved", status1.SelectedItem.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateThis("fir_action", status2.SelectedItem.ToString());
        }

    }
}
