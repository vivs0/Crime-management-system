using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using contentLibrary;
using System.Text.RegularExpressions;

namespace CrimeManagementSystem
{
    public partial class demo : Form
    {
        demo d;
        public demo()
        {
            InitializeComponent();
        }
        SqlCommand cmd;
        private void demo_Load(object sender, EventArgs e)
        {
            FirGridView.CellContentClick += FirGridView_CellContentClick;
            load();
        }

        void FirGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        void load()
        {
            using (SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=FIR_db; User Id = sa; Password = 2611798"))
            {
                FirGridView.AutoGenerateColumns = false;
//                FirGridView.ColumnCount = 1;
                string qury;
                string q1 = "select p.c_fir_id, p.complainer_name,p.complainer_father_husband_name,p.complainer_state,p.complainer_city,p.complainer_address,";
                string q2 = "p.complainer_mobile, p.complainer_area, b.fir_city,b.fir_area,b.accused_name,b.incident_date,b.fir_date,b.fir_summary,";
                string q3 = "a.recieved,a.fir_action from complainer p inner join fir_status a on(p.c_fir_id = a.fir_id) inner join fir_complain b on(a.fir_id = b.fir_id) order by b.pk desc";
                qury = q1 + q2 + q3;
                cmd = new SqlCommand(qury, conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                conn.Open();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                
                FirGridView.Columns["fir_id"].DataPropertyName = "c_fir_id";
                FirGridView.Columns["complainer_name"].DataPropertyName = "complainer_name";
                FirGridView.Columns["complainer_city"].DataPropertyName = "complainer_city";
                FirGridView.Columns["complainer_address"].DataPropertyName = "complainer_address";
                FirGridView.Columns["complainer_mobile"].DataPropertyName = "complainer_mobile";
                FirGridView.Columns["complainer_area"].DataPropertyName = "complainer_area";
                FirGridView.Columns["fir_date"].DataPropertyName = "fir_date";
                FirGridView.Columns["fir_summary"].DataPropertyName = "fir_summary";
                FirGridView.Columns["recieved"].DataPropertyName = "recieved";
                FirGridView.Columns["fir_action"].DataPropertyName = "fir_action";
                FirGridView.DataSource = dt;
            }
        }
    }
}

