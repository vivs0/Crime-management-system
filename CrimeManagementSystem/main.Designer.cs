namespace CrimeManagementSystem
{
    partial class main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGrant = new System.Windows.Forms.Button();
            this.btnFIR = new System.Windows.Forms.Button();
            this.btnCriminal = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewUser = new System.Windows.Forms.DataGridView();
            this.searchCriminal = new System.Windows.Forms.TabPage();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBOttom = new System.Windows.Forms.Panel();
            this.dtl = new System.Data.DataTable();
            this.FirGridView = new System.Windows.Forms.DataGridView();
            this.fir_id = new System.Windows.Forms.DataGridViewLinkColumn();
            this.complainer_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.complainer_area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.complainer_city = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.complainer_mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.complainer_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Complainer_State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fir_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fir_action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fir_summary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recieved = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Accused_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.incident_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirRecords = new System.Windows.Forms.TabPage();
            this.panelBOttomFIR = new System.Windows.Forms.Panel();
            this.panelBOttomUser = new System.Windows.Forms.Panel();
            this.panelTopFIR = new System.Windows.Forms.Panel();
            this.panelTopUser = new System.Windows.Forms.Panel();
            this.TabUser = new System.Windows.Forms.TabPage();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.PK_user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Designation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Roles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirGridView)).BeginInit();
            this.TabUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splitContainer1.Panel1.BackgroundImage = global::CrimeManagementSystem.Properties.Resources._1;
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.btnGrant);
            this.splitContainer1.Panel1.Controls.Add(this.btnFIR);
            this.splitContainer1.Panel1.Controls.Add(this.btnCriminal);
            this.splitContainer1.Panel1.Controls.Add(this.btnRegister);
            this.splitContainer1.Panel1.Controls.Add(this.btnLogin);
            this.splitContainer1.Panel1MinSize = 40;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(958, 497);
            this.splitContainer1.SplitterDistance = 99;
            this.splitContainer1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Image = global::CrimeManagementSystem.Properties.Resources.EnglishLogo;
            this.pictureBox1.Location = new System.Drawing.Point(893, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 94);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(408, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 72);
            this.button1.TabIndex = 0;
            this.button1.Text = "Super Admin";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGrant
            // 
            this.btnGrant.Location = new System.Drawing.Point(327, 3);
            this.btnGrant.Name = "btnGrant";
            this.btnGrant.Size = new System.Drawing.Size(75, 72);
            this.btnGrant.TabIndex = 0;
            this.btnGrant.Text = "Grant Privelages";
            this.btnGrant.UseVisualStyleBackColor = true;
            // 
            // btnFIR
            // 
            this.btnFIR.Location = new System.Drawing.Point(246, 3);
            this.btnFIR.Name = "btnFIR";
            this.btnFIR.Size = new System.Drawing.Size(75, 72);
            this.btnFIR.TabIndex = 0;
            this.btnFIR.Text = "FIR";
            this.btnFIR.UseVisualStyleBackColor = true;
            this.btnFIR.Click += new System.EventHandler(this.btnFIR_Click);
            // 
            // btnCriminal
            // 
            this.btnCriminal.Location = new System.Drawing.Point(165, 3);
            this.btnCriminal.Name = "btnCriminal";
            this.btnCriminal.Size = new System.Drawing.Size(75, 72);
            this.btnCriminal.TabIndex = 0;
            this.btnCriminal.Text = "Criminal Records";
            this.btnCriminal.UseVisualStyleBackColor = true;
            this.btnCriminal.Click += new System.EventHandler(this.btnCriminal_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(84, 3);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 72);
            this.btnRegister.TabIndex = 0;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(3, 3);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 72);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tabControl1
            // 
//            this.tabControl1.Controls.Add(this.TabUser);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(30, 3);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(958, 394);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            this.tabControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseDown);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridViewUser
            // 
            this.dataGridViewUser.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewUser.Name = "dataGridViewUser";
            this.dataGridViewUser.Size = new System.Drawing.Size(240, 150);
            this.dataGridViewUser.TabIndex = 0;
            // 
            // searchCriminal
            // 
            this.searchCriminal.Location = new System.Drawing.Point(0, 0);
            this.searchCriminal.Name = "searchCriminal";
            this.searchCriminal.Size = new System.Drawing.Size(200, 100);
            this.searchCriminal.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(200, 100);
            this.panelTop.TabIndex = 0;
            // 
            // panelBOttom
            // 
            this.panelBOttom.Location = new System.Drawing.Point(0, 0);
            this.panelBOttom.Name = "panelBOttom";
            this.panelBOttom.Size = new System.Drawing.Size(200, 100);
            this.panelBOttom.TabIndex = 0;
            // 
            // FirGridView
            // 
            this.FirGridView.AllowUserToAddRows = false;
            this.FirGridView.AllowUserToDeleteRows = false;
            this.FirGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.FirGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fir_id,
            this.complainer_address,
            this.complainer_area,
            this.complainer_city,
            this.complainer_mobile,
            this.complainer_name,
            this.Complainer_State,
            this.fir_date,
            this.fir_action,
            this.fir_summary,
            this.recieved,
            this.Accused_name,
            this.incident_date});
            this.FirGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FirGridView.Location = new System.Drawing.Point(0, 0);
            this.FirGridView.Name = "FirGridView";
            this.FirGridView.ReadOnly = true;
            this.FirGridView.Size = new System.Drawing.Size(240, 150);
            this.FirGridView.TabIndex = 0;
            this.FirGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FirGridView_CellContentClick);
            // 
            // fir_id
            // 
            this.fir_id.HeaderText = "FIR ID";
            this.fir_id.Name = "fir_id";
            this.fir_id.ReadOnly = true;
            // 
            // complainer_address
            // 
            this.complainer_address.HeaderText = "Complainer\'s Address";
            this.complainer_address.Name = "complainer_address";
            this.complainer_address.ReadOnly = true;
            // 
            // complainer_area
            // 
            this.complainer_area.HeaderText = "Area";
            this.complainer_area.Name = "complainer_area";
            this.complainer_area.ReadOnly = true;
            // 
            // complainer_city
            // 
            this.complainer_city.HeaderText = "City";
            this.complainer_city.Name = "complainer_city";
            this.complainer_city.ReadOnly = true;
            // 
            // complainer_mobile
            // 
            this.complainer_mobile.HeaderText = "Mobile";
            this.complainer_mobile.Name = "complainer_mobile";
            this.complainer_mobile.ReadOnly = true;
            // 
            // complainer_name
            // 
            this.complainer_name.HeaderText = "Complainer\'s Name";
            this.complainer_name.Name = "complainer_name";
            this.complainer_name.ReadOnly = true;
            // 
            // Complainer_State
            // 
            this.Complainer_State.HeaderText = "State";
            this.Complainer_State.Name = "Complainer_State";
            this.Complainer_State.ReadOnly = true;
            // 
            // fir_date
            // 
            this.fir_date.HeaderText = "FIR date";
            this.fir_date.Name = "fir_date";
            this.fir_date.ReadOnly = true;
            // 
            // fir_action
            // 
            this.fir_action.HeaderText = "Status2";
            this.fir_action.Name = "fir_action";
            this.fir_action.ReadOnly = true;
            // 
            // fir_summary
            // 
            this.fir_summary.HeaderText = "Summary";
            this.fir_summary.Name = "fir_summary";
            this.fir_summary.ReadOnly = true;
            // 
            // recieved
            // 
            this.recieved.HeaderText = "Status1";
            this.recieved.Name = "recieved";
            this.recieved.ReadOnly = true;
            // 
            // Accused_name
            // 
            this.Accused_name.HeaderText = "Accused Name";
            this.Accused_name.Name = "Accused_name";
            this.Accused_name.ReadOnly = true;
            // 
            // incident_date
            // 
            this.incident_date.HeaderText = "Incident Date";
            this.incident_date.Name = "incident_date";
            this.incident_date.ReadOnly = true;
            // 
            // FirRecords
            // 
            this.FirRecords.Location = new System.Drawing.Point(0, 0);
            this.FirRecords.Name = "FirRecords";
            this.FirRecords.Size = new System.Drawing.Size(200, 100);
            this.FirRecords.TabIndex = 0;
            // 
            // panelBOttomUser
            // 
            this.panelBOttomUser.Location = new System.Drawing.Point(0, 0);
            this.panelBOttomUser.Name = "panelBOttomUser";
            this.panelBOttomUser.Size = new System.Drawing.Size(200, 100);
            this.panelBOttomUser.TabIndex = 0;
            // 
            // panelBOttomFIR
            // 
            this.panelBOttomFIR.Location = new System.Drawing.Point(0, 0);
            this.panelBOttomFIR.Name = "panelBOttomFIR";
            this.panelBOttomFIR.Size = new System.Drawing.Size(200, 100);
            this.panelBOttomFIR.TabIndex = 0;
            // 
            // panelTopFIR
            // 
            this.panelTopFIR.Location = new System.Drawing.Point(0, 0);
            this.panelTopFIR.Name = "panelTopFIR";
            this.panelTopFIR.Size = new System.Drawing.Size(200, 100);
            this.panelTopFIR.TabIndex = 0;
            // 
            // panelTopUser
            // 
            this.panelTopUser.Location = new System.Drawing.Point(0, 0);
            this.panelTopUser.Name = "panelTopUser";
            this.panelTopUser.Size = new System.Drawing.Size(200, 100);
            this.panelTopUser.TabIndex = 0;
            // 
            // TabUser
            // 
//            this.TabUser.Controls.Add(this.dgvUser);
            this.TabUser.Location = new System.Drawing.Point(4, 22);
            this.TabUser.Name = "TabUser";
            this.TabUser.Padding = new System.Windows.Forms.Padding(3);
            this.TabUser.Size = new System.Drawing.Size(950, 368);
            this.TabUser.TabIndex = 0;
            this.TabUser.Text = "tabPage1";
            this.TabUser.UseVisualStyleBackColor = true;
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToAddRows = false;
            this.dgvUser.AllowUserToDeleteRows = false;
            this.dgvUser.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PK_user,
            this.User_name,
            this.Designation,
            this.DOj,
            this.State,
            this.Roles});
            this.dgvUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUser.Location = new System.Drawing.Point(0, 0);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.ReadOnly = true;
            this.dgvUser.Size = new System.Drawing.Size(240,150);
            this.dgvUser.TabIndex = 0;
            this.dgvUser.CellContentClick += dgvUser_CellContentClick;
            // 
            // PK_user
            // 
            this.PK_user.HeaderText = "ID";
            this.PK_user.Name = "PK_user";
            this.PK_user.ReadOnly = true;
            // 
            // User_name
            // 
            this.User_name.HeaderText = "Name";
            this.User_name.Name = "User_name";
            this.User_name.ReadOnly = true;
            // 
            // Designation
            // 
            this.Designation.HeaderText = "Designation";
            this.Designation.Name = "Designation";
            this.Designation.ReadOnly = true;
            // 
            // DOj
            // 
            this.DOj.HeaderText = "Joining Date";
            this.DOj.Name = "DOj";
            this.DOj.ReadOnly = true;
            // 
            // State
            // 
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            // 
            // Roles
            // 
            this.Roles.HeaderText = "Permission";
            this.Roles.Name = "Roles";
            this.Roles.ReadOnly = false;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.BackgroundImage = global::CrimeManagementSystem.Properties.Resources._1;
            this.ClientSize = new System.Drawing.Size(958, 497);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main";
            this.Text = "FIR and Criminal Database";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.main_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirGridView)).EndInit();
            this.TabUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridViewUser;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnFIR;
        private System.Windows.Forms.Button btnCriminal;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnGrant;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage searchCriminal;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBOttom;
        private System.Data.DataTable dtl;
        //FIR TABPAGE
        private System.Windows.Forms.TabPage FirRecords;
        private System.Windows.Forms.DataGridView FirGridView;
        private System.Windows.Forms.Panel panelTopFIR;
        private System.Windows.Forms.Panel panelTopUser;
        private System.Windows.Forms.Panel panelBOttomFIR;
        private System.Windows.Forms.Panel panelBOttomUser;
        private System.Windows.Forms.DataGridViewLinkColumn fir_id;

        private System.Windows.Forms.DataGridViewTextBoxColumn complainer_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn complainer_city;
        private System.Windows.Forms.DataGridViewTextBoxColumn complainer_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn complainer_mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn complainer_area;
        private System.Windows.Forms.DataGridViewTextBoxColumn fir_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn recieved;
        private System.Windows.Forms.DataGridViewTextBoxColumn fir_action;
        private System.Windows.Forms.DataGridViewTextBoxColumn fir_summary;
        private System.Windows.Forms.DataGridViewTextBoxColumn Complainer_State;
        private System.Windows.Forms.DataGridViewTextBoxColumn Accused_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn incident_date;


        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage TabUser;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn PK_user;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Designation;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOj;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn Roles;
        
    }
}