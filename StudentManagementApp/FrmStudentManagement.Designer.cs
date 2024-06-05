namespace StudentManagementApp
{
    partial class FrmStudentManagement
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
            dtDOB = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtEmail = new TextBox();
            txtName = new TextBox();
            dgvData = new DataGridView();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnSearch = new Button();
            label5 = new Label();
            cboGroupName = new ComboBox();
            cboSearchType = new ComboBox();
            txtSearch = new TextBox();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // dtDOB
            // 
            dtDOB.Location = new Point(323, 88);
            dtDOB.Name = "dtDOB";
            dtDOB.Size = new Size(200, 23);
            dtDOB.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(233, 62);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 1;
            label1.Text = "Full Name :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(233, 32);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 1;
            label2.Text = "Email :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(233, 94);
            label3.Name = "label3";
            label3.Size = new Size(84, 15);
            label3.TabIndex = 1;
            label3.Text = "Date Of Birth : ";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(323, 30);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 2;
            // 
            // txtName
            // 
            txtName.Location = new Point(323, 59);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 23);
            txtName.TabIndex = 2;
            // 
            // dgvData
            // 
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Location = new Point(72, 209);
            dgvData.Name = "dgvData";
            dgvData.Size = new Size(659, 190);
            dgvData.TabIndex = 3;
            dgvData.RowHeaderMouseClick += dgvData_RowHeaderMouseClick;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(259, 165);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(382, 165);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(507, 165);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(602, 61);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(233, 120);
            label5.Name = "label5";
            label5.Size = new Size(84, 15);
            label5.TabIndex = 1;
            label5.Text = "Group Name : ";
            // 
            // cboGroupName
            // 
            cboGroupName.FormattingEnabled = true;
            cboGroupName.Location = new Point(323, 117);
            cboGroupName.Name = "cboGroupName";
            cboGroupName.Size = new Size(200, 23);
            cboGroupName.TabIndex = 5;
            // 
            // cboSearchType
            // 
            cboSearchType.FormattingEnabled = true;
            cboSearchType.Items.AddRange(new object[] { "Name", "Email", "Group" });
            cboSearchType.Location = new Point(683, 62);
            cboSearchType.Name = "cboSearchType";
            cboSearchType.Size = new Size(92, 23);
            cboSearchType.TabIndex = 6;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(602, 30);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(173, 23);
            txtSearch.TabIndex = 2;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(382, 415);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 7;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // FrmStudentManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClose);
            Controls.Add(cboSearchType);
            Controls.Add(cboGroupName);
            Controls.Add(btnSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(dgvData);
            Controls.Add(txtName);
            Controls.Add(txtSearch);
            Controls.Add(txtEmail);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtDOB);
            Name = "FrmStudentManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmStudentManagement";
            Load += FrmStudentManagement_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtDOB;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtEmail;
        private TextBox txtName;
        private DataGridView dgvData;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnSearch;
        private Label label5;
        private ComboBox cboGroupName;
        private ComboBox cboSearchType;
        private TextBox txtSearch;
        private Button btnClose;
    }
}