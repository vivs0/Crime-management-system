using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using core;
using System.Threading;

namespace CrimeManagementSystem
{
    public partial class AddRecord : Form
    {
        public AddRecord()
        {
            InitializeComponent();
        }
        SqlCommand cmd;
        string imagePath;
        private Regex validator;
        ListBox listCrimeBox;
        ComboBox txtFirstCrime;
        ComboBox txtBehaviour;
        ComboBox txtStatus;
        TextBox txtProfileID;
        DateTimePicker txtYearActive;
        TableLayoutPanel tableLayoutPanel2;
        Int16 stateid;
        Int16 districtid;
        private void AddRecord_Load(object sender, EventArgs e)
        {
            load("select statename, stateid from states", txtState, "statename", "stateid");
            load("select districtName, districtid from districts", txtDistrict, "districtname", "districtid");
            load("select SubRegionName, SubRegionId from SubRegions", txtSubRegion, "SubRegionName", "SubRegionId");
        }
        public bool checkManadatory(string str)
        {
            validator = new Regex(@"[~`!@#$%^&*()-+=|\\{}':;.,<>/?[\]""_0123456789\s]");
            if (string.IsNullOrWhiteSpace(str))
            {
                return true;
            }
            else if (validator.Match(str.Trim()).Success)
            {
                return true;
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

        private void txtState_SelectionChangeCommitted(object sender, EventArgs e)
        {
            load("select districtid,districtName from districts where stateid=@a", txtDistrict, "districtname", "districtid", txtState.SelectedValue);
        }
        private void txtDistrict_SelectionChangeCommitted(object sender, EventArgs e)
        {
            load("select SubRegionName, SubRegionId from SubRegions where districtid=@a", txtSubRegion, "SubRegionName", "SubRegionId", txtDistrict.SelectedValue);
        }
        private void load(string query, ComboBox name, string itemField, string valueField, object para)
        {
            using (SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=FIR_db; User Id = sa; Password = 9889922527"))
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
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            if (open.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = Path.GetFileName(open.FileName);
                imagePath = open.FileName;
            }
        }
        private byte[] imageUpload()
        {
            string image = imagePath;
            byte[] bimage;
            if (string.IsNullOrEmpty(imagePath))
            {
                bimage = new byte[1];
                bimage[0] = 0x00;
            }
            else
            {
            Bitmap bmp = new Bitmap(image);
            FileStream fs = new FileStream(image, FileMode.Open, FileAccess.Read);
            bimage = new byte[fs.Length];
            fs.Read(bimage, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            }
            return bimage;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            string param = "";
            if (checkManadatory(txtFname.Text))
            {
                DialogResult dr = MessageBox.Show("Name should not contain any special character or blank spaces", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (checkOptional(txtMname.Text))
            {
                DialogResult dr = MessageBox.Show("Name should not contain any special character or blank spaces. Leave blank if there is no Middle name.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (checkOptional(txtLname.Text))
            {
                DialogResult dr = MessageBox.Show("Name should not contain any special character or blank spaces. Leave blank if there is no Last name.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (checkOptional(txtNicname.Text))
            {
                DialogResult dr = MessageBox.Show("Name should not contain any special character or blank spaces. Leave blank if there is no Nick Name.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int rowC = 0;
                try
                {
                    using (SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=FIR_db; User Id = sa; Password = 2611798"))
                    {
                        var rowstate = (DataRowView)txtState.SelectedItem;
                        var rowCity = (DataRowView)txtDistrict.SelectedItem;
                        var rowRegion = (DataRowView)txtSubRegion.SelectedItem;
                        conn.Open();
                        param = "@firstname, @middlename, @lastname, @nickname, @dob, @addresss, @subregion, @city, @states, @profilepic,@stateid,@districtid";
                        cmd = new SqlCommand("insert into profiles (firstname,middlename, lastname, nickname, dob, addresss, subregion, city, states, profilepic,stateid,districtid)values(" + param + ")", conn);
                        cmd.Parameters.AddWithValue("@firstname", txtFname.Text);
                        cmd.Parameters.AddWithValue("@middlename", txtMname.Text);
                        cmd.Parameters.AddWithValue("@lastname", txtLname.Text);
                        cmd.Parameters.AddWithValue("@nickname", txtNicname.Text);
                        cmd.Parameters.AddWithValue("@dob", txtDob.Text);
                        cmd.Parameters.AddWithValue("@addresss", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@states", rowstate["stateName"].ToString());
                        cmd.Parameters.AddWithValue("@city", rowCity["districtName"].ToString());
                        cmd.Parameters.AddWithValue("@subregion", rowRegion["subRegionName"].ToString());
                        //                        cmd.Parameters.AddWithValue("@profilepic", SqlDbType.Image).Value = imageUpload();
                        cmd.Parameters.AddWithValue("@profilepic", imageUpload());
                        cmd.Parameters.AddWithValue("@stateid", Convert.ToInt16(txtState.SelectedValue.ToString()));
                        cmd.Parameters.AddWithValue("@districtid", Convert.ToInt16(txtDistrict.SelectedValue.ToString()));
                        rowC = (int)cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException sce)
                {
                    DialogResult dr = MessageBox.Show("unable to upload. Please check your entries / internet connection", "Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FileLoadException fe)
                {
                    DialogResult dr = MessageBox.Show("Image file has been deleted or its location has changed. Please select again.", "Image not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (InvalidOperationException ie)
                {
                    DialogResult dr = MessageBox.Show("Connection Error. Check your Internet connection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Form f = new Progress();
                    f.ShowDialog();
                    if (rowC == 2)
                    {
                        nextStep();
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Not working");
                    }
                }
            }
        }
        void nextStep()
        {
            panel1.Controls.Remove(tableLayoutPanel1);
  
            Label lblProfileID = new Label();
            lblProfileID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblProfileID.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblProfileID.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            lblProfileID.Location = new System.Drawing.Point(5, 13);
            lblProfileID.Name = "lblProfileID";
            lblProfileID.Size = new System.Drawing.Size(100, 21);
            lblProfileID.TabIndex = 2;
            lblProfileID.Text = "ID :";
            lblProfileID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            Label lblInvolve = new Label();
            lblInvolve.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblInvolve.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblInvolve.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            lblInvolve.Location = new System.Drawing.Point(5, 13);
            lblInvolve.Name = "lblInvolve";
            lblInvolve.Size = new System.Drawing.Size(100, 21);
            lblInvolve.TabIndex = 2;
            lblInvolve.Text = "Involvement :";
            lblInvolve.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            Label lblFirstCrimeDate = new Label();
            lblFirstCrimeDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblFirstCrimeDate.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblFirstCrimeDate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            lblFirstCrimeDate.Location = new System.Drawing.Point(5, 13);
            lblFirstCrimeDate.Name = "lblFirstCrimeDate";
            lblFirstCrimeDate.Size = new System.Drawing.Size(100, 21);
            lblFirstCrimeDate.TabIndex = 2;
            lblFirstCrimeDate.Text = "Year Active From :";
            lblFirstCrimeDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            Label lblFirstCrime = new Label();
            lblFirstCrime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblFirstCrime.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblFirstCrime.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            lblFirstCrime.Location = new System.Drawing.Point(5, 13);
            lblFirstCrime.Name = "lblFirstCrime";
            lblFirstCrime.Size = new System.Drawing.Size(100, 21);
            lblFirstCrime.TabIndex = 2;
            lblFirstCrime.Text = "First Crime :";
            lblFirstCrime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            Label lblBehaviour = new Label();
            lblBehaviour.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblBehaviour.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblBehaviour.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            lblBehaviour.Location = new System.Drawing.Point(5, 13);
            lblBehaviour.Name = "lblBehaviour";
            lblBehaviour.Size = new System.Drawing.Size(100, 21);
            lblBehaviour.TabIndex = 2;
            lblBehaviour.Text = "Behaviour :";
            lblBehaviour.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            Label lblStatus = new Label();
            lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lblStatus.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblStatus.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            lblStatus.Location = new System.Drawing.Point(5, 13);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(100, 21);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Status :";
            lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            Button btnUpload = new Button();
            btnUpload.Anchor = System.Windows.Forms.AnchorStyles.Left;
            btnUpload.Location = new System.Drawing.Point(191, 466);
            btnUpload.Name = "buttonSubmit";
            btnUpload.Size = new System.Drawing.Size(75, 34);
            btnUpload.TabIndex = 10;
            btnUpload.Text = "Submit";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;

            txtProfileID = new TextBox();
            txtProfileID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            txtProfileID.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtProfileID.Location = new System.Drawing.Point(191, 104);
            txtProfileID.Name = "txtProfileID";
            txtProfileID.Size = new System.Drawing.Size(180, 24);
            txtProfileID.TabIndex = 100;
            txtProfileID.ReadOnly = true;
            txtProfileID.Text = loadID();

            listCrimeBox = new ListBox();
            listCrimeBox.Anchor = AnchorStyles.Left;
            listCrimeBox.FormattingEnabled = true;
            listCrimeBox.Location = new System.Drawing.Point(12, 70);
            listCrimeBox.Name = "listCrimeBox";
            listCrimeBox.Size = new System.Drawing.Size(178, 134);
            listCrimeBox.TabIndex = 11;
            listCrimeBox.SelectionMode = SelectionMode.MultiSimple;

            txtYearActive = new DateTimePicker();
            txtYearActive.Anchor = System.Windows.Forms.AnchorStyles.Left;
            txtYearActive.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtYearActive.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            txtYearActive.Location = new System.Drawing.Point(191, 189);
            txtYearActive.Name = "txtYearActive";
            txtYearActive.Size = new System.Drawing.Size(180, 25);
            txtYearActive.TabIndex = 4;
            txtYearActive.Value = new System.DateTime(2015, 4, 15, 0, 0, 0, 0);

            txtFirstCrime = new ComboBox();
            txtFirstCrime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            txtFirstCrime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            txtFirstCrime.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtFirstCrime.FormattingEnabled = true;
            txtFirstCrime.Location = new System.Drawing.Point(191, 297);
            txtFirstCrime.Name = "txtFirstCrime";
            txtFirstCrime.Size = new System.Drawing.Size(180, 25);
            txtFirstCrime.TabIndex = 6;

            txtBehaviour = new ComboBox();
            txtBehaviour.Anchor = System.Windows.Forms.AnchorStyles.Left;
            txtBehaviour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            txtBehaviour.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtBehaviour.FormattingEnabled = true;
            txtBehaviour.Location = new System.Drawing.Point(191, 297);
            txtBehaviour.Name = "txtBehaviour";
            txtBehaviour.Size = new System.Drawing.Size(180, 25);
            txtBehaviour.TabIndex = 6;

            txtStatus = new ComboBox();
            txtStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            txtStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            txtStatus.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtStatus.FormattingEnabled = true;
            txtStatus.Location = new System.Drawing.Point(191, 297);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new System.Drawing.Size(180, 25);
            txtStatus.TabIndex = 6;

            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            tableLayoutPanel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.95327F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.04673F));
            tableLayoutPanel2.Controls.Add(lblProfileID, 0, 0);
            tableLayoutPanel2.Controls.Add(lblInvolve, 0, 1);
            tableLayoutPanel2.Controls.Add(lblFirstCrimeDate, 0, 2);
            tableLayoutPanel2.Controls.Add(lblFirstCrime, 0, 3);
            tableLayoutPanel2.Controls.Add(lblBehaviour, 0, 4);
            tableLayoutPanel2.Controls.Add(lblStatus, 0, 5);
            tableLayoutPanel2.Controls.Add(btnUpload, 1, 6);
            tableLayoutPanel2.Controls.Add(txtProfileID, 1, 0);
            tableLayoutPanel2.Controls.Add(listCrimeBox, 1, 1);
            tableLayoutPanel2.Controls.Add(txtYearActive, 1, 2);
            tableLayoutPanel2.Controls.Add(txtFirstCrime, 1, 3);
            tableLayoutPanel2.Controls.Add(txtBehaviour, 1, 4);
            tableLayoutPanel2.Controls.Add(txtStatus, 1, 5);
            tableLayoutPanel2.Location = new System.Drawing.Point(82, 41);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 7;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute,35));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35));
            tableLayoutPanel2.Size = new System.Drawing.Size(535, 350);
            tableLayoutPanel2.TabIndex = 10;
            panel1.Controls.Add(tableLayoutPanel2);
            load("select id,crimelist from crime", txtFirstCrime, "crimeList", "id");
            load("select id,crimelist from crime", listCrimeBox, "crimeList", "id");
            load("select id, behaviour from behaviourlist", txtBehaviour, "behaviour", "id");
            load("select id, status_ from stat", txtStatus, "status_", "id");
        }
        private string loadID()
        {
            string id = "";
            try
            {
                using (SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=FIR_db; User Id = sa; Password = 2611798"))
                {
                    conn.Open();
                    cmd = new SqlCommand("select top 1 profile_id from profiles order by pk desc", conn);
                    id = (string)cmd.ExecuteScalar();
                }
            }
            catch (SqlException sce)
            {
                DialogResult dr = MessageBox.Show("Error in conncection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            return id;
        }
        void btnUpload_Click(object sender, EventArgs e)
        {
            int count = 0;
            string involvement = "";
            string[] it = new string[listCrimeBox.SelectedItems.Count];
//            for (int i = 0; i < listCrimeBox.SelectedItems.Count; i++)
//            {
////                involvement += it[i] + "; ";
//                DialogResult drs = MessageBox.Show(it[i]);
//            }
            foreach (DataRowView da in listCrimeBox.SelectedItems)
            {
                involvement += da["crimelist"].ToString() + "; ";
            }
            
            try
            {
                var firstCrime = (DataRowView)txtFirstCrime.SelectedItem;
                var behav = (DataRowView)txtBehaviour.SelectedItem;
                var status = (DataRowView)txtStatus.SelectedItem;
                using (SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=FIR_db; User Id = sa; Password = 2611798"))
                {
                    conn.Open();
                    cmd = new SqlCommand("update record set involvement = @involve, firstcrimedate = @date, firstcrime = @fc,behaviour = @behaviour, stat = @status where profile_id = @id", conn);
                    cmd.Parameters.AddWithValue("@involve", involvement);
                    cmd.Parameters.AddWithValue("@date", txtYearActive.Text);
                    cmd.Parameters.AddWithValue("@fc", firstCrime["crimelist"].ToString());
                    cmd.Parameters.AddWithValue("@behaviour", behav["behaviour"].ToString());
                    cmd.Parameters.AddWithValue("@status", status["status_"].ToString());
                    cmd.Parameters.AddWithValue("@id", txtProfileID.Text);
                    count = (int)cmd.ExecuteNonQuery();
                    if (count == 1)
                    {
                        DialogResult dr = MessageBox.Show("Successfully Uploaded. Do you want to Upload another detail ?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dr == DialogResult.No)
                        {
                            this.Close();
                        }
                        else
                        {
                            panel1.Controls.Remove(tableLayoutPanel2);
                            panel1.Controls.Add(tableLayoutPanel1);
                        }
                    }
                }
            }
            catch (SqlException sce)
            {
                DialogResult dr = MessageBox.Show("Error in sql Connection.", "Error in connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void load(string query, ListBox listb, string itemField, string itemValue)
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
                    listb.DataSource = ds.Tables[0];
                    listb.DisplayMember = itemField;
                    listb.ValueMember = itemValue;
                }
                catch (SqlException exc)
                {
                    DialogResult dr = MessageBox.Show("Error in server. Could not load Designation.", "Error in server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void button_demo(object sender, EventArgs e)
        {
            nextStep();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure.","Close",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
