namespace CrimeManagementSystem
{
    partial class demo
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.FirGridView = new System.Windows.Forms.DataGridView();
            this.fir_id = new System.Windows.Forms.DataGridViewLinkColumn();
            this.complainer_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.complainer_father_husband_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.complainer_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.complainer_city = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.complainer_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.complainer_mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.complainer_area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fir_city = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fir_area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accused_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.incident_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fir_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fir_summary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recieved = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fir_action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.FirGridView)).BeginInit();
            this.SuspendLayout();
            //  
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(365, 240);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // FirGridView
            // 
            this.FirGridView.AllowUserToAddRows = false;
            this.FirGridView.AllowUserToDeleteRows = false;
            this.FirGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.FirGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FirGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fir_id,
            this.complainer_name,
            this.complainer_father_husband_name,
            this.complainer_state,
            this.complainer_city,
            this.complainer_address,
            this.complainer_mobile,
            this.complainer_area,
            this.fir_city,
            this.fir_area,
            this.accused_name,
            this.incident_date,
            this.fir_date,
            this.fir_summary,
            this.recieved,
            this.fir_action});
            this.FirGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FirGridView.Location = new System.Drawing.Point(0, 0);
            this.FirGridView.Name = "FirGridView";
            this.FirGridView.ReadOnly = true;
            this.FirGridView.Size = new System.Drawing.Size(930, 533);
            this.FirGridView.TabIndex = 0;
            // 
            // fir_id
            // 
            this.fir_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fir_id.HeaderText = "FIR ID";
            this.fir_id.Name = "fir_id";
            this.fir_id.ReadOnly = true;
            // 
            // complainer_name
            // 
            this.complainer_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.complainer_name.HeaderText = "Name";
            this.complainer_name.Name = "complainer_name";
            this.complainer_name.ReadOnly = true;
            // 
            // complainer_father_husband_name
            // 
            this.complainer_father_husband_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.complainer_father_husband_name.HeaderText = "Column1";
            this.complainer_father_husband_name.Name = "complainer_father_husband_name";
            this.complainer_father_husband_name.ReadOnly = true;
            this.complainer_father_husband_name.Visible = false;
            // 
            // complainer_state
            // 
            this.complainer_state.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.complainer_state.HeaderText = "Column1";
            this.complainer_state.Name = "complainer_state";
            this.complainer_state.ReadOnly = true;
            this.complainer_state.Visible = false;
            // 
            // complainer_city
            // 
            this.complainer_city.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.complainer_city.HeaderText = "City";
            this.complainer_city.Name = "complainer_city";
            this.complainer_city.ReadOnly = true;
            // 
            // complainer_address
            // 
            this.complainer_address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.complainer_address.HeaderText = "Address";
            this.complainer_address.Name = "complainer_address";
            this.complainer_address.ReadOnly = true;
            // 
            // complainer_mobile
            // 
            this.complainer_mobile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.complainer_mobile.HeaderText = "Mobile";
            this.complainer_mobile.Name = "complainer_mobile";
            this.complainer_mobile.ReadOnly = true;
            // 
            // complainer_area
            // 
            this.complainer_area.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.complainer_area.HeaderText = "Area";
            this.complainer_area.Name = "complainer_area";
            this.complainer_area.ReadOnly = true;
            // 
            // fir_city
            // 
            this.fir_city.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fir_city.HeaderText = "Column1";
            this.fir_city.Name = "fir_city";
            this.fir_city.ReadOnly = true;
            this.fir_city.Visible = false;
            // 
            // fir_area
            // 
            this.fir_area.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fir_area.HeaderText = "Column1";
            this.fir_area.Name = "fir_area";
            this.fir_area.ReadOnly = true;
            this.fir_area.Visible = false;
            // 
            // accused_name
            // 
            this.accused_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.accused_name.HeaderText = "Column1";
            this.accused_name.Name = "accused_name";
            this.accused_name.ReadOnly = true;
            this.accused_name.Visible = false;
            // 
            // incident_date
            // 
            this.incident_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.incident_date.HeaderText = "Column1";
            this.incident_date.Name = "incident_date";
            this.incident_date.ReadOnly = true;
            this.incident_date.Visible = false;
            // 
            // fir_date
            // 
            this.fir_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fir_date.HeaderText = "Fir Date";
            this.fir_date.Name = "fir_date";
            this.fir_date.ReadOnly = true;
            // 
            // fir_summary
            // 
            this.fir_summary.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fir_summary.HeaderText = "Summary";
            this.fir_summary.Name = "fir_summary";
            this.fir_summary.ReadOnly = true;
            // 
            // recieved
            // 
            this.recieved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.recieved.HeaderText = "status1";
            this.recieved.Name = "recieved";
            this.recieved.ReadOnly = true;
            // 
            // fir_action
            // 
            this.fir_action.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fir_action.HeaderText = "status2";
            this.fir_action.Name = "fir_action";
            this.fir_action.ReadOnly = true;
            // 
            // demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(930, 533);
            this.Controls.Add(this.FirGridView);
            this.Name = "demo";
            this.Text = "demo";
            this.Load += new System.EventHandler(this.demo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FirGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView FirGridView;
        private System.Windows.Forms.DataGridViewLinkColumn fir_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn complainer_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn complainer_father_husband_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn complainer_state;
        private System.Windows.Forms.DataGridViewTextBoxColumn complainer_city;
        private System.Windows.Forms.DataGridViewTextBoxColumn complainer_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn complainer_mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn complainer_area;
        private System.Windows.Forms.DataGridViewTextBoxColumn fir_city;
        private System.Windows.Forms.DataGridViewTextBoxColumn fir_area;
        private System.Windows.Forms.DataGridViewTextBoxColumn accused_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn incident_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn fir_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn fir_summary;
        private System.Windows.Forms.DataGridViewTextBoxColumn recieved;
        private System.Windows.Forms.DataGridViewTextBoxColumn fir_action;

    }
}