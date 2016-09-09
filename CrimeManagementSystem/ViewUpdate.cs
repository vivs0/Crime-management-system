using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;
using System.Drawing.Imaging;

namespace CrimeManagementSystem
{
    public partial class ViewUpdate : Form
    {
        public ViewUpdate()
        {
            InitializeComponent();
        }
        
        SqlCommand cmd;
        string stateID_profile;
        string districtID_profile;
        byte[] image;
        string imagePath;
        MemoryStream stream;
        private void ViewUpdate_Paint(object sender, PaintEventArgs e)
        {
        }

        private void ViewUpdate_Load(object sender, EventArgs e)
        {
            lblprofil.Text = main.profile_id;
            load();
            btnhide();
            hideUnusable();
            //label14.Text = stateID_profile;
            //label15.Text = districtID_profile;
        }

        void hideUnusable()
        {
            panel2.Controls.Remove(dateDob);
            panel2.Controls.Remove(dateFirstCrime);
            panel2.Controls.Remove(comboArea);
            panel2.Controls.Remove(comboBehaviour);
            panel2.Controls.Remove(comboDistrict);
            panel2.Controls.Remove(comboStates);
            panel2.Controls.Remove(comboStatus);
            panel2.Controls.Remove(comboArea);
            panel2.Controls.Remove(listInvolve);
            panel2.Controls.Remove(comboFirstCrime);
        }
        void load()
        {
            using (SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=FIR_db; User Id = sa; Password = 2611798"))
            {
                try
                {
                    cmd = new SqlCommand("select * from profiles p inner join record a on (p.profile_id = a.profile_id) where p.profile_id = @a", conn);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@a", lblprofil.Text);
                    conn.Open();
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    firstName.Text = ds.Tables[0].Rows[0]["firstName"].ToString();
                    middleName.Text = ds.Tables[0].Rows[0]["middleName"].ToString();
                    lastName.Text = ds.Tables[0].Rows[0]["lastName"].ToString();
                    NickName.Text = ds.Tables[0].Rows[0]["NickName"].ToString();
                    dob.Text =  ds.Tables[0].Rows[0]["dob"].ToString();
                    addresss.Text = ds.Tables[0].Rows[0]["addresss"].ToString();
                    states.Text = ds.Tables[0].Rows[0]["states"].ToString();
                    city.Text = ds.Tables[0].Rows[0]["city"].ToString();
                    subRegion.Text = ds.Tables[0].Rows[0]["subregion"].ToString();
                    involvement.Text = ds.Tables[0].Rows[0]["involvement"].ToString();
                    FirstCrimeDate.Text = ds.Tables[0].Rows[0]["FirstCrimeDate"].ToString();
                    FirstCrime.Text = ds.Tables[0].Rows[0]["FirstCrime"].ToString();
                    Behaviour.Text = ds.Tables[0].Rows[0]["behaviour"].ToString();
                    stat.Text = ds.Tables[0].Rows[0]["stat"].ToString();
                    stateID_profile = ds.Tables[0].Rows[0]["stateid"].ToString();
                    districtID_profile = ds.Tables[0].Rows[0]["districtid"].ToString();
                    image = new byte[0];
                    image = (byte[])ds.Tables[0].Rows[0]["profilePic"];
                    stream = new MemoryStream(image);
                    pictureBox1.Image = Image.FromStream(stream);
                }
                catch (SqlException exc)
                {
                    DialogResult dr = MessageBox.Show("Error in server. Could not load Designation.", "Error in server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        void btnhide()
        {
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
        }
        void updateThis(string tableName, string columnName, string textBoxValue)
        {
            using (SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=FIR_db; User Id = sa; Password = 2611798"))
            {
                //try
                {
                    string query = string.Format("update {0} set {1} = @b where profile_id= @c",tableName,columnName);
                    cmd = new SqlCommand(query, conn);
                    conn.Open();
//                    cmd.Parameters.AddWithValue("@a", columnName);
                    cmd.Parameters.AddWithValue("@b", textBoxValue);
                    cmd.Parameters.AddWithValue("@c", lblprofil.Text);
                    cmd.ExecuteNonQuery();
                }
                //catch (SqlException exc)
                //{
                //    DialogResult dr = MessageBox.Show("Error in server. Could not load Designation.", "Error in server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }

        private void txtFname_Click(object sender, EventArgs e)
           {
            firstName.ReadOnly = false;
            firstName.BackColor = Color.White;
            firstName.ForeColor = Color.Black;
            button15.Visible = true;
        }

        private void txtFname_MouseClick(object sender, MouseEventArgs e)
        {
            firstName.ReadOnly = false;
            firstName.ForeColor = Color.Black;
            firstName.BackColor = Color.White;
        }
        private void middleName_MouseClick(object sender, MouseEventArgs e)
        {
            middleName.ReadOnly = false;
            middleName.BackColor = Color.White;
            middleName.ForeColor = Color.Black;
            button2.Visible = true;
        }

        private void lastName_MouseClick(object sender, MouseEventArgs e)
        {
            lastName.ReadOnly = false;
            lastName.BackColor = Color.White;
            lastName.ForeColor = Color.Black;
            button3.Visible = true;
        }

        private void NickName_MouseClick(object sender, MouseEventArgs e)
        {
            NickName.ReadOnly = false;
            NickName.BackColor = Color.White;
            NickName.ForeColor = Color.Black;
            button4.Visible = true;
        }

        private void dob_MouseClick(object sender, MouseEventArgs e)
        {
            panel2.Controls.Remove(dob);
            panel2.Controls.Add(dateDob);
            dateDob.Enabled = true;
            dateDob.Location = new Point(154, 162);
            button5.Visible = true;
        }

        private void addresss_MouseClick(object sender, MouseEventArgs e)
        {
            addresss.ReadOnly = false;
            addresss.BackColor = Color.White;
            addresss.ForeColor = Color.Black;
            button6.Visible = true;
        }

        private void states_MouseClick(object sender, MouseEventArgs e)
        {
            panel2.Controls.Remove(states);
            panel2.Controls.Add(comboStates);
            load("select * from states", comboStates, "stateName", "stateId");
            comboStates.Enabled = true;
            comboStates.Location = new Point(154, 313);
            button7.Visible = true;
        }

        private void city_MouseClick(object sender, MouseEventArgs e)
        {
            panel2.Controls.Remove(city);
            panel2.Controls.Add(comboDistrict);
            load("select * from districts where stateid = @a", comboDistrict, "DistrictName", "DistrictId",stateID_profile);
            comboDistrict.Enabled = true;
            comboDistrict.Location = new Point(154, 347);
            button8.Visible = true;
        }

        private void subRegion_MouseClick(object sender, MouseEventArgs e)
        {
            panel2.Controls.Remove(subRegion);
            panel2.Controls.Add(comboArea);
            load("select * from subregions where districtid = @a", comboArea, "subregionname", "subregionid",districtID_profile);
            comboArea.Enabled = true;
            comboArea.Location = new Point(154, 381);
            button9.Visible = true;
        }

        private void stat_MouseClick(object sender, MouseEventArgs e)
        {
            panel2.Controls.Remove(stat);
            panel2.Controls.Add(comboStatus);
            load("select * from stat", comboStatus, "status_", "id");
            comboStatus.Enabled = true;
            comboStatus.Location = new Point(154, 415);
            button14.Visible = true;
        }

        private void involvement_MouseClick(object sender, MouseEventArgs e)
        {
            panel2.Controls.Remove(involvement); 
            panel2.Controls.Add(listInvolve);
            load("select * from crime", listInvolve, "crimeList", "id");
            listInvolve.Location = new Point(involvement.Location.X, involvement.Location.Y);
            button10.Visible = true;
        }

        private void FirstCrimeDate_MouseClick(object sender, MouseEventArgs e)
        {
            panel2.Controls.Remove(FirstCrimeDate);
            panel2.Controls.Add(dateFirstCrime);
            dateFirstCrime.Enabled = true;
            dateFirstCrime.Location = new Point(FirstCrimeDate.Location.X, FirstCrimeDate.Location.Y);
            button11.Visible = true;
        }

        private void FirstCrime_MouseClick(object sender, MouseEventArgs e)
        {
            panel2.Controls.Remove(FirstCrime);
            panel2.Controls.Add(comboFirstCrime);
            load("select * from crime", comboFirstCrime, "crimelist", "id");
            comboFirstCrime.Enabled = true;
            comboFirstCrime.Location = new Point(FirstCrime.Location.X, FirstCrime.Location.Y);
            button12.Visible = true;
        }

        private void Behaviour_MouseClick(object sender, MouseEventArgs e)
        {
            panel2.Controls.Remove(Behaviour);
            panel2.Controls.Add(comboBehaviour);
            load("select * from behaviourList", comboBehaviour, "behaviour", "id");
            comboBehaviour.Enabled = true;
            comboBehaviour.Location = new Point(Behaviour.Location.X,Behaviour.Location.Y);
            button13.Visible = true;
        }
    
        private void button15_Click(object sender, EventArgs e)
        {
            updateThis("profiles", "firstName", firstName.Text);
            firstName.ReadOnly = true;
            firstName.BackColor = SystemColors.ControlDarkDark;
            firstName.ForeColor = Color.White;
            button15.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            updateThis("profiles", "middleName", middleName.Text);
            middleName.ReadOnly = true;
            middleName.BackColor = SystemColors.ControlDarkDark;
            middleName.ForeColor = Color.White;
            button2.Hide();
            //mn
        }

        private void button3_Click(object sender, EventArgs e)
        {
            updateThis("profiles", "lastName", lastName.Text);
            lastName.ReadOnly = true;
            lastName.BackColor = SystemColors.ControlDarkDark;
            lastName.ForeColor = Color.White;
            button3.Hide();

            //ln
        }
        private void button4_Click(object sender, EventArgs e)
        {
            updateThis("profiles", "nickName", NickName.Text);
            NickName.ReadOnly = true;
            NickName.BackColor = SystemColors.ControlDarkDark;
            NickName.ForeColor = Color.White;
            button4.Hide();
            //nic
        }

        private void button5_Click(object sender, EventArgs e)
        {
            updateThis("profiles", "dob", dateDob.Text);
            dob.ReadOnly = true;
            dob.BackColor = SystemColors.ControlDarkDark;
            dob.ForeColor = Color.White;
            panel2.Controls.Remove(dateDob);
            dob.Text = dateDob.Text;
            panel2.Controls.Add(dob);
            button5.Hide();
            //dob
        }

        private void button6_Click(object sender, EventArgs e)
        {
            updateThis("profiles", "addresss", addresss.Text);
            addresss.ReadOnly = true;
            addresss.BackColor = SystemColors.ControlDarkDark;
            addresss.ForeColor = Color.White;
            button6.Hide();
            //add
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=FIR_db; User Id = sa; Password = 2611798"))
            {
                try
                {
                    var rowdata = (DataRowView)comboStates.SelectedItem;
                    string query = "update profiles set states = @a, stateid = @b where profile_id = @c";
                    cmd = new SqlCommand(query, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@a", rowdata["stateName"].ToString());
                    cmd.Parameters.AddWithValue("@b", Convert.ToInt16(comboStates.SelectedValue));
                    cmd.Parameters.AddWithValue("@c", lblprofil.Text);
                    cmd.ExecuteNonQuery();
                    states.Text = rowdata["stateName"].ToString();
                }
                catch (SqlException exc)
                {
                    DialogResult dr = MessageBox.Show("Error in server. Could not load Designation.", "Error in server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    panel2.Controls.Remove(comboStates);
                    panel2.Controls.Add(states);
                    states.ReadOnly = true;
                    states.BackColor = SystemColors.ControlDarkDark;
                    states.ForeColor = Color.White;
                    button7.Hide();
                }
            }
            //state
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=FIR_db; User Id = sa; Password = 2611798"))
            {
                try
                {
                    var rowdata = (DataRowView)comboDistrict.SelectedItem;
                    string query = "update profiles set city = @a, districtId = @b where profile_id = @c";
                    cmd = new SqlCommand(query, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@a", rowdata["DistrictName"].ToString());
                    cmd.Parameters.AddWithValue("@b", Convert.ToInt16(comboDistrict.SelectedValue));
                    cmd.Parameters.AddWithValue("@c", lblprofil.Text);
                    cmd.ExecuteNonQuery();
                    city.Text = rowdata["DistrictName"].ToString();
                }
                catch (SqlException exc)
                {
                    DialogResult dr = MessageBox.Show("Error in server. Could not load Designation.", "Error in server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    panel2.Controls.Remove(comboDistrict);
                    panel2.Controls.Add(city);
                    city.ReadOnly = true;
                    city.BackColor = SystemColors.ControlDarkDark;
                    city.ForeColor = Color.White;
                    button8.Hide();
                }
            }
            //city
        }

        private void button9_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=FIR_db; User Id = sa; Password = 2611798"))
            {
                try
                {
                    var rowdata = (DataRowView)comboArea.SelectedItem;
                    string query = "update profiles set subregion = @a where profile_id = @c";
                    cmd = new SqlCommand(query, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@a", rowdata["subregionname"].ToString());
                    cmd.Parameters.AddWithValue("@c", lblprofil.Text);
                    cmd.ExecuteNonQuery();
                    subRegion.Text = rowdata["subregionname"].ToString();
                }
                catch (SqlException exc)
                {
                    DialogResult dr = MessageBox.Show("Error in server. Could not load Designation.", "Error in server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    panel2.Controls.Remove(comboArea);
                    panel2.Controls.Add(subRegion);
                    subRegion.ReadOnly = true;
                    subRegion.BackColor = SystemColors.ControlDarkDark;
                    subRegion.ForeColor = Color.White;
                    button9.Hide();
                }
            }
            //area
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
        private void button14_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=FIR_db; User Id = sa; Password = 2611798"))
            {
                try
                {
                    var rowdata = (DataRowView)comboStatus.SelectedItem;
                    string query = "update record set stat = @a where profile_id = @c";
                    cmd = new SqlCommand(query, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@a", rowdata["status_"].ToString());
                    cmd.Parameters.AddWithValue("@c", lblprofil.Text);
                    cmd.ExecuteNonQuery();
                    stat.Text = rowdata["status_"].ToString();
                }
                catch (SqlException exc)
                {
                    DialogResult dr = MessageBox.Show("Error in server. Could not load Designation.", "Error in server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    panel2.Controls.Remove(comboStatus);
                    panel2.Controls.Add(stat);
                    stat.ReadOnly = true;
                    stat.BackColor = SystemColors.ControlDarkDark;
                    stat.ForeColor = Color.White;
                    button14.Hide();
                }
            }
            //status
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string involv = "";
            string[] it = new string[listInvolve.SelectedItems.Count];
            foreach (DataRowView da in listInvolve.SelectedItems)
            {
                involv += da["crimelist"].ToString() + "; ";
            }
            try
            {
                using (SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=FIR_db; User Id = sa; Password = 2611798"))
                {
                    conn.Open();
                    cmd = new SqlCommand("update record set involvement = @involve where profile_id = @a", conn);
                    cmd.Parameters.AddWithValue("@involve", involv);
                    cmd.Parameters.AddWithValue("@a", lblprofil.Text);
                    cmd.ExecuteNonQuery();
                    involvement.Text = involv;
                }
            }
            catch (SqlException sce)
            {
                DialogResult dr = MessageBox.Show("Error in sql Connection.", "Error in connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                panel2.Controls.Remove(listInvolve);
                panel2.Controls.Add(involvement);
                involvement.ReadOnly = true;
                involvement.BackColor = SystemColors.ControlDarkDark;
                involvement.ForeColor = Color.White;
                button10.Hide();
            }
            //involve
        }

        private void button11_Click(object sender, EventArgs e)
        {
            updateThis("record", "firstCrimeDate", dateFirstCrime.Text);
            panel2.Controls.Remove(dateFirstCrime);
            FirstCrimeDate.Text = dateFirstCrime.Text;
            panel2.Controls.Add(FirstCrimeDate);
            FirstCrimeDate.ReadOnly = true;
            FirstCrimeDate.BackColor = SystemColors.ControlDarkDark;
            FirstCrimeDate.ForeColor = Color.White;
            button11.Hide();
            //firstdate
        }

        private void button12_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=FIR_db; User Id = sa; Password = 2611798"))
            {
                try
                {
                    var rowdata = (DataRowView)comboFirstCrime.SelectedItem;
                    string query = "update record set firstCrime = @a where profile_id = @c";
                    cmd = new SqlCommand(query, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@a", rowdata["crimeList"].ToString());
                    cmd.Parameters.AddWithValue("@c", lblprofil.Text);
                    cmd.ExecuteNonQuery();
                    FirstCrime.Text = rowdata["crimeList"].ToString();
                }
                catch (SqlException exc)
                {
                    DialogResult dr = MessageBox.Show("Error in server. Could not load Designation.", "Error in server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    panel2.Controls.Remove(comboFirstCrime);
                    panel2.Controls.Add(FirstCrime);
                    FirstCrime.ReadOnly = true;
                    FirstCrime.BackColor = SystemColors.ControlDarkDark;
                    FirstCrime.ForeColor = Color.White;
                    button12.Hide();
                }
            }
            //first crime
        }

        private void button13_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=FIR_db; User Id = sa; Password = 2611798"))
            {
                try
                {
                    var rowdata = (DataRowView)comboBehaviour.SelectedItem;
                    string query = "update record set behaviour = @a where profile_id = @c";
                    cmd = new SqlCommand(query, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@a", rowdata["behaviour"].ToString());
                    cmd.Parameters.AddWithValue("@c", lblprofil.Text);
                    cmd.ExecuteNonQuery();
                    Behaviour.Text = rowdata["behaviour"].ToString();
                }
                catch (SqlException exc)
                {
                    DialogResult dr = MessageBox.Show("Error in server. Could not load Designation.", "Error in server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    panel2.Controls.Remove(comboBehaviour);
                    panel2.Controls.Add(Behaviour);
                    Behaviour.ReadOnly = true;
                    Behaviour.BackColor = SystemColors.ControlDarkDark;
                    Behaviour.ForeColor = Color.White;
                    button13.Hide();
                }
            }
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
                    cmd.Parameters.Add("@a",para);
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

        private void comboStates_SelectionChangeCommitted(object sender, EventArgs e)
        {
            stateID_profile = comboStates.SelectedValue.ToString();
            load("select districtid, districtName from districts where stateid=@a", comboDistrict, "districtname", "districtid",stateID_profile);
        }

        private void comboDistrict_SelectionChangeCommitted(object sender, EventArgs e)
        {
            districtID_profile = comboDistrict.SelectedValue.ToString();
            load("select SubRegionName, SubRegionId from SubRegions where districtid=@a", comboArea, "SubRegionName", "SubRegionId", districtID_profile);
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            hideUnusable();
            btnhide();
            load();
            firstName.ReadOnly = true;
            firstName.BackColor = SystemColors.ControlDarkDark;
            firstName.ForeColor = Color.White;
            button15.Hide();

            middleName.ReadOnly = true;
            middleName.BackColor = SystemColors.ControlDarkDark;
            middleName.ForeColor = Color.White;
            button2.Hide();
            lastName.ReadOnly = true;
            lastName.BackColor = SystemColors.ControlDarkDark;
            lastName.ForeColor = Color.White;
            button3.Hide();
            NickName.ReadOnly = true;
            NickName.BackColor = SystemColors.ControlDarkDark;
            NickName.ForeColor = Color.White;
            button4.Hide();
            dob.ReadOnly = true;
            dob.BackColor = SystemColors.ControlDarkDark;
            dob.ForeColor = Color.White;
            panel2.Controls.Remove(dateDob);
            dob.Text = dateDob.Text;
            panel2.Controls.Add(dob);
            button5.Hide();
            addresss.ReadOnly = true;
            addresss.BackColor = SystemColors.ControlDarkDark;
            addresss.ForeColor = Color.White;
            button6.Hide();
            panel2.Controls.Remove(comboStates);
            panel2.Controls.Add(states);
            states.ReadOnly = true;
            states.BackColor = SystemColors.ControlDarkDark;
            states.ForeColor = Color.White;
            button7.Hide();
            panel2.Controls.Remove(comboDistrict);
            panel2.Controls.Add(city);
            city.ReadOnly = true;
            city.BackColor = SystemColors.ControlDarkDark;
            city.ForeColor = Color.White;
            button8.Hide();
            panel2.Controls.Remove(comboArea);
            panel2.Controls.Add(subRegion);
            subRegion.ReadOnly = true;
            subRegion.BackColor = SystemColors.ControlDarkDark;
            subRegion.ForeColor = Color.White;
            button9.Hide();

            panel2.Controls.Remove(comboStatus);
            panel2.Controls.Add(stat);
            stat.ReadOnly = true;
            stat.BackColor = SystemColors.ControlDarkDark;
            stat.ForeColor = Color.White;
            button14.Hide();
            panel2.Controls.Remove(listInvolve);
            panel2.Controls.Add(involvement);
            involvement.ReadOnly = true;
            involvement.BackColor = SystemColors.ControlDarkDark;
            involvement.ForeColor = Color.White;
            button10.Hide();
            panel2.Controls.Remove(dateFirstCrime);
            panel2.Controls.Add(FirstCrimeDate);
            FirstCrimeDate.ReadOnly = true;
            FirstCrimeDate.BackColor = SystemColors.ControlDarkDark;
            FirstCrimeDate.ForeColor = Color.White;
            button11.Hide();
            panel2.Controls.Remove(comboFirstCrime);
            panel2.Controls.Add(FirstCrime);
            FirstCrime.ReadOnly = true;
            FirstCrime.BackColor = SystemColors.ControlDarkDark;
            FirstCrime.ForeColor = Color.White;
            button12.Hide();
            panel2.Controls.Remove(comboBehaviour);
            panel2.Controls.Add(Behaviour);
            Behaviour.ReadOnly = true;
            Behaviour.BackColor = SystemColors.ControlDarkDark;
            Behaviour.ForeColor = Color.White;
            button13.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            if (open.ShowDialog() == DialogResult.OK)
            {
                imagePath = open.FileName;
            }
            pictureBox1.Image = new Bitmap(imagePath);
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

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Server=.\\sqlexpress;DataBase=fir_db;User Id = sa;Password=2611798"))
                {
                    cmd = new SqlCommand("update profiles set profilepic = @a where profile_id = @b", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@a", imageUpload());
                    cmd.Parameters.AddWithValue("@b", lblprofil.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException sce)
            {
                DialogResult dr = MessageBox.Show("Error in internet connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (BadImageFormatException bie)
            {
                DialogResult dr = MessageBox.Show("image is not supported.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                panel2.Controls.Remove(button16);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
