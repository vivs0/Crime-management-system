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
    public partial class main : Form
    {
        public string qury;
        public string quryFIR;
        public string quryUser;
        public static Label log;
        public TabPage FIR = new TabPage();
        public TabPage superAdmin = new TabPage();
        public TableLayoutPanel table;
        public static string credential;
        public static string userLevel;
        public SqlCommand cmd;
        public TextBox name;
        public TextBox firSearch;
        public TextBox UserName;
        public static string profile_id;
        public SqlCommand cmdf;
        public static string FIR_ID;
        public static string complainerName;
        public static string complainerAddress;
        public static string complain;
        public static string complainerMobile;
        public static string incidentDate;
        public static string firDate;
        public static string Accusedname;
        public static string stat1;
        public static string stat2;
        
        public main()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(userLevel))
            {
                Form login = new Login();
                login.ShowDialog();
                if (status.getstatus())
                {
                    btnLogin.Text = "Logout";
                }
            }
            else
            {
                userLevel = null;
                btnLogin.Text = "Login";
                log.Text = null;
                LoaddefaultStatus();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Form fs = new AdminRegistration();
            fs.ShowDialog();
        }

        private void LoaddefaultStatus()
        {
            log = content.lblLogin();
            log.BackColor = Color.Transparent;
            log.ForeColor = Color.White;
            log.Font = new Font("Times New Roman", 11);
            log.Text = "Please Login to use this software";
            splitContainer1.Panel1.Controls.Add(log);
            log.TextChanged += log_TextChanged;
            if (string.IsNullOrEmpty(userLevel))
            {
                btnFIR.Enabled = false;
                btnGrant.Enabled = false;
                btnCriminal.Enabled = false;
            }

        }
        private void main_Load(object sender, EventArgs e)
        {
            LoaddefaultStatus();
        }

        private void log_TextChanged(object sender, EventArgs e) //to enable and disable controls
        {
            if (log.Text == "SA")
            {
                btnFIR.Enabled = true;
                btnGrant.Enabled = true;
                btnCriminal.Enabled = true;
                log.Text = "Super Admin Level. Full Access.";
            }
            else if (log.Text == "AD")
            {
                btnFIR.Enabled = true;
                btnCriminal.Enabled = true;
                btnGrant.Enabled = false;
                log.Text = "Admin Level. Limited Access.";
            }
            else
            {
            }
            
        }
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font fntTab;
            Brush brsback;
            Brush brsFore;
            Brush btn = Brushes.DarkGray;
            if (e.Index == this.tabControl1.SelectedIndex)
            {
                fntTab = new Font(e.Font, FontStyle.Bold);
                brsback = new LinearGradientBrush(e.Bounds, SystemColors.Highlight, SystemColors.Highlight, LinearGradientMode.Horizontal);
                brsFore = Brushes.White;
            }
            else
            {
                fntTab = new Font(e.Font, FontStyle.Bold);
                brsback = Brushes.LightGray;
                brsFore = Brushes.Black;
            }
            e.Graphics.FillRectangle(brsback, e.Bounds);
            Rectangle rectTab = e.Bounds;

            rectTab = new Rectangle(rectTab.X, rectTab.Y + 4, rectTab.Width, rectTab.Height - 4);

            string tname = this.tabControl1.TabPages[e.Index].Text;
            e.Graphics.DrawString("X", e.Font, brsFore, e.Bounds.Right - 15, e.Bounds.Top + 4);
            e.Graphics.DrawString(tname, e.Font, brsFore, e.Bounds.Left + 12, e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < this.tabControl1.TabPages.Count; i++)
            {
                Rectangle r = tabControl1.GetTabRect(i);
                Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 4, 9, 7);
                if (closeButton.Contains(e.Location))
                {
                    if (MessageBox.Show("Are you sure", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        tabControl1.TabPages.RemoveAt(i);
                        break;
                    }
                }
            }
        }
        private void btnCriminal_Click(object sender, EventArgs e)
        {
            qury = "select * from profiles";
            searchCriminal.Name = "CriminalRecord";
            searchCriminal.Text = "Criminal Record".ToString();
            tabControl1.Visible = true;
            searchCriminal.BackColor =SystemColors.Control;

            table = new TableLayoutPanel();
            table.Dock = DockStyle.Fill;
            table.ColumnCount = 1;
            table.RowCount = 2;

            if (tabControl1.TabPages.Count != 0)
            {
                for (int i = 0; i <= tabControl1.TabCount; i++)
                {
                    if (tabControl1.TabPages.Contains(searchCriminal))
                    {
                        tabControl1.SelectTab(searchCriminal);
                    }
                    else
                    {
                        tabControl1.Controls.Add(searchCriminal);
                        searchCriminal.Controls.Add(loadPanelBottom());
                        searchCriminal.Controls.Add(loadPanel());
                        searchCriminal.Controls.Add(loadPanelTop());
                    }
                }
            }
            else
            {
                tabControl1.Controls.Add(searchCriminal);
                searchCriminal.Controls.Add(loadPanelBottom());
                searchCriminal.Controls.Add(loadPanel());
                searchCriminal.Controls.Add(loadPanelTop());
            }
        }
        public Panel loadPanelBottom()
        {
            panelBOttom.BackColor = Color.Transparent;
            panelBOttom.Dock = DockStyle.Fill;
            panelBOttom.Size = new Size(100, 100);
            panelBOttom.TabIndex = 2;
            loadResult();
            panelBOttom.Controls.Add(dataGridView1);
            return panelBOttom;
        }
        void search_Click(object sender, EventArgs e)
        {
        }
        void addRecord_Click(object sender, EventArgs e)
        {
            Form f = new Progress();
            f.ShowDialog();
            Form add = new AddRecord();
            add.ShowDialog();
        }
        public DataGridView loadResult()
        {
            recordSet rs = new recordSet();
            dataGridView1 = rs.dgv();
            dataGridView1.Dock = DockStyle.Top;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            using (SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=FIR_db; User Id = sa; Password = 2611798"))
            {
                try
                {
                    cmd = new SqlCommand(qury, conn);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    dataGridView1.AutoGenerateColumns = false;
                    conn.Open();
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.Columns["colPk"].DataPropertyName = "pk";
                    dataGridView1.Columns["col_profile"].DataPropertyName = "profile_id";
                    dataGridView1.Columns["colFirstName"].DataPropertyName = "firstName";
                    dataGridView1.Columns["colMiddlename"].DataPropertyName = "middleName";
                    dataGridView1.Columns["colLastName"].DataPropertyName = "lastName";
                    dataGridView1.Columns["colNickName"].DataPropertyName = "nickName";
                    dataGridView1.Columns["colDOB"].DataPropertyName = "dob";
                    dataGridView1.Columns["colAddress"].DataPropertyName = "Addresss";
                    dataGridView1.Columns["colState"].DataPropertyName = "states";
                    dataGridView1.Columns["colDistrict"].DataPropertyName = "city";
                    dataGridView1.Columns["colRegion"].DataPropertyName = "subregion";
                    dataGridView1.DataSource = dt;

                }
                catch (SqlException exc)
                {
                    DialogResult dr = MessageBox.Show("Error in server. Could not load Designation.", "Error in server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return dataGridView1;
        }
        public DataGridView loadResult(string q)
        {
            recordSet rs = new recordSet();
            dataGridView1 = rs.dgv();
            dataGridView1.Dock = DockStyle.Top;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            using (SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=FIR_db; User Id = sa; Password = 2611798"))
            {
                try
                {
                    cmd = new SqlCommand(qury, conn);
                    cmd.Parameters.AddWithValue("@a", "%"+name.Text.Trim()+"%");
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    dataGridView1.AutoGenerateColumns = false;
                    conn.Open();
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.Columns["colPk"].DataPropertyName = "pk";
                    dataGridView1.Columns["col_profile"].DataPropertyName = "profile_id";
                    dataGridView1.Columns["colFirstName"].DataPropertyName = "firstName";
                    dataGridView1.Columns["colMiddlename"].DataPropertyName = "middleName";
                    dataGridView1.Columns["colLastName"].DataPropertyName = "lastName";
                    dataGridView1.Columns["colNickName"].DataPropertyName = "nickName";
                    dataGridView1.Columns["colDOB"].DataPropertyName = "dob";
                    dataGridView1.Columns["colAddress"].DataPropertyName = "Addresss";
                    dataGridView1.Columns["colState"].DataPropertyName = "states";
                    dataGridView1.Columns["colDistrict"].DataPropertyName = "city";
                    dataGridView1.Columns["colRegion"].DataPropertyName = "subregion";
                    dataGridView1.DataSource = dt;

                }
                catch (SqlException exc)
                {
                    DialogResult dr = MessageBox.Show("Error in server. Could not load Designation.", "Error in server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return dataGridView1;
        }
        void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Form f = new Progress();
            f.ShowDialog();
            profile_id = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            Form view = new ViewUpdate();
            view.ShowDialog();
        }
        Splitter loadPanel()
        {
            Splitter splitter1 = new Splitter();
            splitter1.BackColor = SystemColors.ControlDarkDark;
            splitter1.Cursor = Cursors.HSplit;
            splitter1.Dock = DockStyle.Top;
            splitter1.Location = new System.Drawing.Point(0, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new System.Drawing.Size(100, 5);
            splitter1.TabIndex = 1;

            return splitter1;
        }
        public Panel loadPanelTop()
        {
//            Panel panelTop = new Panel();
            panelTop.BackColor = SystemColors.ActiveCaption;
            panelTop.Dock = DockStyle.Top;
            panelTop.Size = new Size(100, 70);
            panelTop.TabIndex = 0;
            panelTop.ResumeLayout(true);

            Button addRecord = new Button();
            addRecord.Text = "Add New";
            addRecord.MinimumSize = new Size(75, 50);
            addRecord.Size = new Size(75, 50);
            addRecord.UseVisualStyleBackColor = true;
            addRecord.AutoSize = true;
            addRecord.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            addRecord.Click += addRecord_Click;
            panelTop.Controls.Add(addRecord);

            name = new TextBox();
            name.Font = new Font("Times New Roman", 12);
            name.Size = new Size(140, 20);
            name.Location = new Point(addRecord.Location.X + 185, addRecord.Location.Y + 20);
            name.TextChanged += name_TextChanged;
            panelTop.Controls.Add(name);

            Label search = new Label();
            search.Text = "Search :";
            search.Font = new Font("Times New Roman", 12);
            search.ForeColor = Color.White;
            search.Size = new Size(75, 50);
            search.Location = new Point(addRecord.Location.X + 120, addRecord.Location.Y+25);
            panelTop.Controls.Add(search);

            return panelTop;
        }
        void name_TextChanged(object sender, EventArgs e)
        {
            panelBOttom.Controls.Remove(dataGridView1);
            qury = "select * from profiles where (firstName like @a) or (lastName like @a) or (middlename like @a) or (nickname like @a)";
            cmd.Parameters.AddWithValue("@a", "%" + name.Text.Trim() + "%");
            loadResult(qury);
//            tabControl1.Controls.Remove(searchCriminal);
//            searchCriminal.Controls.Remove(panelBOttom);
//            panelBOttom.Controls.Remove(dataGridView1);
            panelBOttom.Controls.Add(dataGridView1);
            
        }
        private void btnFIR_Click(object sender, EventArgs e)
        {
            string q1 = "select p.c_fir_id, p.complainer_name,p.complainer_father_husband_name,p.complainer_state,p.complainer_city,p.complainer_address,";
            string q2 = "p.complainer_mobile, p.complainer_area, b.fir_city,b.fir_area,b.accused_name,b.incident_date,b.fir_date,b.fir_summary,";
            string q3 = "a.recieved,a.fir_action from complainer p inner join fir_status a on(p.c_fir_id = a.fir_id) inner join fir_complain b on(a.fir_id = b.fir_id) order by b.pk desc";

            quryFIR = q1 + q2 + q3; 
 
            FirRecords.Name = "Firrecords";
            FirRecords.Text = "Fir Records".ToString();
            tabControl1.Visible = true;
            FirRecords.BackColor = SystemColors.Control;

            table = new TableLayoutPanel();
            table.Dock = DockStyle.Fill;
            table.ColumnCount = 1;
            table.RowCount = 2;

            if (tabControl1.TabPages.Count != 0)
            {
                for (int i = 0; i <= tabControl1.TabCount; i++)
                {
                    if (tabControl1.TabPages.Contains(FirRecords))
                    {
                        tabControl1.SelectTab(FirRecords);
                    }
                    else
                    {
                        tabControl1.Controls.Add(FirRecords);
                        FirRecords.Controls.Add(loadPanelBottomFIR());
                        FirRecords.Controls.Add(loadPanelFIR());
                        FirRecords.Controls.Add(loadPanelTopFIR());
                    }
                }
            }
            else
            {
                tabControl1.Controls.Add(FirRecords);
                FirRecords.Controls.Add(loadPanelBottomFIR());
                FirRecords.Controls.Add(loadPanelFIR());
                FirRecords.Controls.Add(loadPanelTopFIR());
            }
        }

        Splitter loadPanelFIR()
        {
            Splitter splitter2 = new Splitter();
            splitter2.BackColor = SystemColors.ControlDarkDark;
            splitter2.Cursor = Cursors.HSplit;
            splitter2.Dock = DockStyle.Top;
            splitter2.Location = new System.Drawing.Point(0, 0);
            splitter2.Name = "splitter1";
            splitter2.Size = new System.Drawing.Size(100, 5);
            splitter2.TabIndex = 1;

            return splitter2;
        }
        public Panel loadPanelTopFIR()
        {
            panelTopFIR.BackColor = SystemColors.ActiveCaption;
            panelTopFIR.Dock = DockStyle.Top;
            panelTopFIR.Size = new Size(100, 70);
            panelTopFIR.TabIndex = 0;
            panelTopFIR.ResumeLayout(true);

            //Button addRecord = new Button();
            //addRecord.Text = "Add New";
            //addRecord.MinimumSize = new Size(75, 50);
            //addRecord.Size = new Size(75, 50);
            //addRecord.UseVisualStyleBackColor = true;
            //addRecord.AutoSize = true;
            //addRecord.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            //addRecord.Click += addRecord_Click;
            //panelTop.Controls.Add(addRecord);

            Label search = new Label();
            search.Text = "Search :";
            search.Font = new Font("Times New Roman", 12);
            search.ForeColor = Color.White;
            search.Size = new Size(75, 50);
            search.Location = new Point(10,10);
            panelTopFIR.Controls.Add(search);

            firSearch = new TextBox();
            firSearch.Font = new Font("Times New Roman", 12);
            firSearch.Size = new Size(140, 20);
            firSearch.Location = new Point(search.Location.X + 90, search.Location.Y);
            firSearch.TextChanged += firSearch_TextChanged;
            panelTopFIR.Controls.Add(firSearch);

            return panelTopFIR;
        }
        void firSearch_TextChanged(object sender, EventArgs e)
        {
            panelBOttomFIR.Controls.Remove(FirGridView);
            string q1 = "select p.c_fir_id, p.complainer_name,p.complainer_father_husband_name,p.complainer_state,p.complainer_city,p.complainer_address,";
            string q2 = "p.complainer_mobile, p.complainer_area, b.fir_city,b.fir_area,b.accused_name,b.incident_date,b.fir_date,b.fir_summary,";
            string q3 = "a.recieved,a.fir_action from complainer p inner join fir_status a on(p.c_fir_id = a.fir_id) inner join fir_complain b on(a.fir_id = b.fir_id) where (p.c_fir_id like @a) or (p.complainer_name like @a) or (p.complainer_mobile like @a) or (b.fir_date like @fdate)";
            string q4 = "order by b.pk desc";

            quryFIR = q1 + q2 + q3 + q4;
            
            cmdf.Parameters.AddWithValue("@a", "%" + firSearch.Text + "%");
            cmdf.Parameters.AddWithValue("@fdate", "%-" + firSearch.Text + "%");
            loadResultFir(quryFIR);
            //            tabControl1.Controls.Remove(searchCriminal);
            //            searchCriminal.Controls.Remove(panelBOttom);
            //            panelBOttom.Controls.Remove(dataGridView1);
            panelBOttomFIR.Controls.Add(FirGridView);
        }
        public Panel loadPanelBottomFIR()
        {
            //            Panel panelBOttom = new Panel();
            panelBOttomFIR.BackColor = Color.Transparent;
            panelBOttomFIR.Dock = DockStyle.Fill;
            panelBOttomFIR.Size = new Size(100, 100);
            panelBOttomFIR.TabIndex = 2;
            loadResultFIR();
            panelBOttomFIR.Controls.Add(FirGridView);
            return panelBOttomFIR;
        }
        public DataGridView loadResultFIR()
        {
            using (SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=FIR_db; User Id = sa; Password = 2611798"))
            {
                try
                {
                    FirGridView.AutoGenerateColumns = false;
                    //string query;
                    //string q1 = "select p.c_fir_id, p.complainer_name,p.complainer_father_husband_name,p.complainer_state,p.complainer_city,p.complainer_address,";
                    //string q2 = "p.complainer_mobile, p.complainer_area, b.fir_city,b.fir_area,b.accused_name,b.incident_date,b.fir_date,b.fir_summary,";
                    //string q3 = "a.recieved,a.fir_action from complainer p inner join fir_status a on(p.c_fir_id = a.fir_id) inner join fir_complain b on(a.fir_id = b.fir_id) order by b.pk desc";
                    //query = q1 + q2 + q3;
                    cmdf = new SqlCommand(quryFIR, conn);
                    SqlDataAdapter sdaf = new SqlDataAdapter(cmdf);
                    conn.Open();
                    DataTable dtf = new DataTable();
                    sdaf.Fill(dtf);

                    FirGridView.Columns["fir_id"].DataPropertyName = "c_fir_id";
                    FirGridView.Columns["complainer_name"].DataPropertyName = "complainer_name";
                    FirGridView.Columns["complainer_city"].DataPropertyName = "complainer_city";
                    FirGridView.Columns["complainer_address"].DataPropertyName = "complainer_address";
                    FirGridView.Columns["complainer_mobile"].DataPropertyName = "complainer_mobile";
                    FirGridView.Columns["complainer_area"].DataPropertyName = "complainer_area";
                    FirGridView.Columns["fir_date"].DataPropertyName = "fir_date";
                    FirGridView.Columns["recieved"].DataPropertyName = "recieved";
                    FirGridView.Columns["fir_action"].DataPropertyName = "fir_action";

                    FirGridView.Columns["fir_summary"].DataPropertyName = "fir_summary";
                    FirGridView.Columns["Complainer_State"].DataPropertyName = "complainer_state";
                    FirGridView.Columns["Accused_name"].DataPropertyName = "accused_name";
                    FirGridView.Columns["incident_date"].DataPropertyName = "incident_date";


                    FirGridView.DataSource = dtf;
                }
                catch (SqlException exc)
                {
                    DialogResult dr = MessageBox.Show("Error in server. Could not load Designation.", "Error in server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return FirGridView;
        }
        public DataGridView loadResultFir(string q)
        {
            using (SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=FIR_db; User Id = sa; Password = 2611798"))
            {
                try
                {
                    cmdf = new SqlCommand(quryFIR, conn);
                    cmdf.Parameters.AddWithValue("@a", "%" + firSearch.Text + "%");
                    cmdf.Parameters.AddWithValue("@fdate", "%-" + firSearch.Text + "%");
                    SqlDataAdapter sdaf = new SqlDataAdapter(cmdf);
                    FirGridView.AutoGenerateColumns = false;
                    conn.Open();
                    DataTable dtf = new DataTable();
                    sdaf.Fill(dtf);

                    FirGridView.Columns["fir_id"].DataPropertyName = "c_fir_id";
                    FirGridView.Columns["complainer_name"].DataPropertyName = "complainer_name";
                    FirGridView.Columns["complainer_city"].DataPropertyName = "complainer_city";
                    FirGridView.Columns["complainer_address"].DataPropertyName = "complainer_address";
                    FirGridView.Columns["complainer_mobile"].DataPropertyName = "complainer_mobile";
                    FirGridView.Columns["complainer_area"].DataPropertyName = "complainer_area";
                    FirGridView.Columns["fir_date"].DataPropertyName = "fir_date";
                    FirGridView.Columns["recieved"].DataPropertyName = "recieved";
                    FirGridView.Columns["fir_action"].DataPropertyName = "fir_action";

                    FirGridView.Columns["fir_summary"].DataPropertyName = "fir_summary";
                    FirGridView.Columns["Complainer_State"].DataPropertyName = "complainer_state";
                    FirGridView.Columns["Accused_name"].DataPropertyName = "accused_name";
                    FirGridView.Columns["incident_date"].DataPropertyName = "incident_date";

                    FirGridView.DataSource = dtf;
                }
                catch (SqlException exc)
                {
                    DialogResult dr = MessageBox.Show("Error in server. Could not load Designation.", "Error in server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return FirGridView;
        }
        void FirGridView_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            string a = FirGridView.Rows[e.RowIndex].Cells["complainer_address"].Value.ToString();
            string b = FirGridView.Rows[e.RowIndex].Cells["complainer_city"].Value.ToString();
            string c = FirGridView.Rows[e.RowIndex].Cells["Complainer_State"].Value.ToString();
            Form f = new Progress();
            f.ShowDialog();

            FIR_ID = FirGridView.Rows[e.RowIndex].Cells["fir_id"].Value.ToString();
            complainerName = FirGridView.Rows[e.RowIndex].Cells["complainer_name"].Value.ToString();
            complainerAddress = a + ", " + b + ", " + c.ToString();
            complain = FirGridView.Rows[e.RowIndex].Cells["fir_summary"].Value.ToString();
            complainerMobile = FirGridView.Rows[e.RowIndex].Cells["complainer_mobile"].Value.ToString();
            incidentDate = FirGridView.Rows[e.RowIndex].Cells["incident_date"].Value.ToString();
            firDate = FirGridView.Rows[e.RowIndex].Cells["fir_date"].Value.ToString();
            Accusedname = FirGridView.Rows[e.RowIndex].Cells["Accused_name"].Value.ToString();
            stat1 = FirGridView.Rows[e.RowIndex].Cells["recieved"].Value.ToString();
            stat2 = FirGridView.Rows[e.RowIndex].Cells["fir_action"].Value.ToString();
            Form viewFir = new FIRDetail();
            viewFir.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            quryUser = "select * from _admin";
            tabControl1.Visible = true;
            table = new TableLayoutPanel();
            table.Dock = DockStyle.Fill;
            table.ColumnCount = 1;
            table.RowCount = 2;
            if (tabControl1.TabPages.Count != 0)
            {
                for (int i = 0; i <= tabControl1.TabCount; i++)
                {
                    if (tabControl1.TabPages.Contains(TabUser))
                    {
                        tabControl1.SelectTab(TabUser);
                    }
                    else
                    {
                        tabControl1.Controls.Add(TabUser);
                        TabUser.Controls.Add(loadPanelBottomUSer());
                        TabUser.Controls.Add(loadPanelUser());
                        TabUser.Controls.Add(loadPanelTopUser());
                    }
                }
            }
            else
            {
                tabControl1.Controls.Add(TabUser);
                TabUser.Controls.Add(loadPanelBottomUSer());
                TabUser.Controls.Add(loadPanelUser());
                TabUser.Controls.Add(loadPanelTopUser());
            }
        }
        Splitter loadPanelUser()
        {
            Splitter splitter2 = new Splitter();
            splitter2.BackColor = SystemColors.ControlDarkDark;
            splitter2.Cursor = Cursors.HSplit;
            splitter2.Dock = DockStyle.Top;
            splitter2.Location = new System.Drawing.Point(0, 0);
            splitter2.Name = "splitter1";
            splitter2.Size = new System.Drawing.Size(100, 5);
            splitter2.TabIndex = 1;

            return splitter2;
        }
        public Panel loadPanelBottomUSer()
        {
            panelBOttomUser.BackColor = Color.Aquamarine;
            panelBOttomUser.Dock = DockStyle.Fill;
            panelBOttomUser.Size = new Size(100, 100);
            panelBOttomUser.TabIndex = 2;

            loadResultUser();
            panelBOttomUser.Controls.Add(dgvUser);
            return panelBOttomUser;
        }
        public Panel loadPanelTopUser()
        {
            panelTopUser.BackColor = SystemColors.ActiveCaption;
            panelTopUser.Dock = DockStyle.Top;
            panelTopUser.Size = new Size(100, 70);
            panelTopUser.TabIndex = 0;
            panelTopUser.ResumeLayout(true);


            Label search = new Label();
            search.Text = "Search :";
            search.Font = new Font("Times New Roman", 12);
            search.ForeColor = Color.White;
            search.Size = new Size(75, 50);
            search.Location = new Point(10, 10);
            panelTopUser.Controls.Add(search);

            UserName = new TextBox();
            UserName.Font = new Font("Times New Roman", 12);
            UserName.Size = new Size(140, 20);
            UserName.Location = new Point(search.Location.X + 90, search.Location.Y);
            UserName.TextChanged += UserName_TextChanged;
            panelTopUser.Controls.Add(UserName);

            return panelTopUser;
        }

        void UserName_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        void dgvUser_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            
        }
        public DataGridView loadResultUser()
        {
            using (SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=FIR_db; User Id = sa; Password = 2611798"))
            {
                try
                {
                    dgvUser.AutoGenerateColumns = false;
                    cmdf = new SqlCommand(quryUser, conn);
                    SqlDataAdapter sdaf = new SqlDataAdapter(cmdf);
                    conn.Open();
                    DataTable dtf = new DataTable();
                    sdaf.Fill(dtf);
                    dgvUser.Columns["PK_user"].DataPropertyName = "admin_id";
                    dgvUser.Columns["User_name"].DataPropertyName = "firstname";
                    dgvUser.Columns["Designation"].DataPropertyName = "Designation";
                    dgvUser.Columns["DOj"].DataPropertyName = "doj";
                    dgvUser.Columns["State"].DataPropertyName = "states";
                    dgvUser.Columns["Roles"].DataPropertyName = "roles";
                    dgvUser.DataSource = dtf;
                }
                catch (SqlException exc)
                {
                    DialogResult dr = MessageBox.Show("Error in server. Could not load Designation.", "Error in server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return dgvUser;
        }
    }
}
