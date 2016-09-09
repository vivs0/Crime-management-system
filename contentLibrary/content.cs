using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace contentLibrary
{
    public class content
    {
        public static Label lblLogin()
        {
            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular);
            label1.Location = new Point(524, 9);
            label1.Text = "Login";
            return label1;
        }
    }

    public class recordSet
    {
        DataGridView dataGridView1;
        DataGridViewTextBoxColumn colPk;
        DataGridViewLinkColumn col_profile;
        DataGridViewTextBoxColumn colFirstName;
        DataGridViewTextBoxColumn colMiddlename;
        DataGridViewTextBoxColumn colLastName;
        DataGridViewTextBoxColumn colNickName;
        DataGridViewTextBoxColumn colDOB;
        DataGridViewTextBoxColumn colAddress;
        DataGridViewTextBoxColumn colState;
        DataGridViewTextBoxColumn colDistrict;
        DataGridViewTextBoxColumn colRegion;
        public DataGridView dgv()
        {
            dataGridView1 = new DataGridView();
            colPk = new DataGridViewTextBoxColumn();
            col_profile = new DataGridViewLinkColumn();
            colFirstName = new DataGridViewTextBoxColumn();
            colMiddlename = new DataGridViewTextBoxColumn();
            colLastName = new DataGridViewTextBoxColumn();
            colNickName = new DataGridViewTextBoxColumn();
            colDOB = new DataGridViewTextBoxColumn();
            colAddress = new DataGridViewTextBoxColumn();
            colState = new DataGridViewTextBoxColumn();
            colDistrict = new DataGridViewTextBoxColumn();
            colRegion = new DataGridViewTextBoxColumn();

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            colPk,
            col_profile,
            colFirstName,
            colMiddlename,
            colLastName,
            colNickName,
            colDOB,
            colAddress,
            colState,
            colDistrict,
            colRegion});
            dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridView1.Location = new System.Drawing.Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new System.Drawing.Size(930, 533);
            dataGridView1.TabIndex = 0;
            // 
            // colPk
            // 
            colPk.HeaderText = "Column1";
            colPk.Name = "colPk";
            colPk.ReadOnly = true;
            colPk.Visible = false;
            // 
            // col_profile
            // 
            col_profile.HeaderText = "Profile_id";
            col_profile.Name = "col_profile";
            col_profile.ReadOnly = true;
            col_profile.Visible = true;
            // 
            // colFirstName
            // 
            colFirstName.HeaderText = "First Name";
            colFirstName.Name = "colFirstName";
            colFirstName.ReadOnly = true;
            // 
            // colMiddlename
            // 
            colMiddlename.HeaderText = "Middle Name";
            colMiddlename.Name = "colMiddlename";
            colMiddlename.ReadOnly = true;
            // 
            // colLastName
            // 
            colLastName.HeaderText = "Last Name";
            colLastName.Name = "colLastName";
            colLastName.ReadOnly = true;
            // 
            // colNickName
            // 
            colNickName.HeaderText = "Nick Name";
            colNickName.Name = "colNickName";
            colNickName.ReadOnly = true;
            // 
            // colDOB
            // 
            colDOB.HeaderText = "D.O.B";
            colDOB.Name = "colDOB";
            colDOB.ReadOnly = true;
            // 
            // colAddress
            // 
            colAddress.HeaderText = "Address";
            colAddress.Name = "colAddress";
            colAddress.ReadOnly = true;
            // 
            // colState
            // 
            colState.HeaderText = "State";
            colState.Name = "colState";
            colState.ReadOnly = true;
            // 
            // colDistrict
            // 
            colDistrict.HeaderText = "District";
            colDistrict.Name = "colDistrict";
            colDistrict.ReadOnly = true;
            // 
            // colRegion
            // 
            colRegion.HeaderText = "Region";
            colRegion.Name = "colRegion";
            colRegion.ReadOnly = true;

            return dataGridView1;
        }

    }
}
