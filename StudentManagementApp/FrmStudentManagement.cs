using BusinessObject.Models;
using BusinessObject.ViewModels;
using DataAccess.Repositories.Interfaces;
using System.ComponentModel;

namespace StudentManagementApp
{
    public partial class FrmStudentManagement : Form
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentGroupRepository _studentGroupRepository;
        public bool ReadOnlyMode { get; set; }
        public static int Id = -1;
        public FrmStudentManagement(IStudentRepository studentRepository, IStudentGroupRepository studentGroupRepository)
        {
            _studentGroupRepository = studentGroupRepository;
            _studentRepository = studentRepository;
            InitializeComponent();
        }

        private void ClearText()
        {
            txtEmail.Text = string.Empty;
            txtName.Text = string.Empty;
            cboGroupName.Text = string.Empty;
            dtDOB.Text = string.Empty;
        }

        private void LoadData()
        {
            var groups = _studentGroupRepository.GetGroups();
            cboGroupName.DataSource = groups;
            cboGroupName.DisplayMember = "GroupName";
            cboGroupName.ValueMember = "Id";

            var students = _studentRepository.GetStudentDetails();
            dgvData.DataSource = new BindingList<StudentDetails>(students.ToList());
            if (dgvData.Columns["Id"] != null)
            {
                dgvData.Columns["Id"].Visible = false;
            }
        }
        private void DisableEditingControls()
        {
            // Vô hiệu hóa các txt
            txtName.Enabled = false;
            txtEmail.Enabled = false;
            // Vô hiệu hóa các nút
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            cboGroupName.Enabled = false;
            dtDOB.Enabled = false;
        }
        private void FrmStudentManagement_Load(object sender, EventArgs e)
        {
            // Kiểm tra nếu chế độ chỉ đọc được kích hoạt
            if (ReadOnlyMode)
            {
                // Vô hiệu hóa các điều khiển chỉnh sửa trên form
                DisableEditingControls();
            }
            LoadData();
            ClearText();
        }

        private void dgvData_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Cách 1

            var selectedStudent = (StudentDetails)dgvData.Rows[e.RowIndex].DataBoundItem;
            Id = selectedStudent.Id;
            txtEmail.Text = selectedStudent.Email ?? string.Empty;
            txtName.Text = selectedStudent.FullName ?? string.Empty;
            dtDOB.Text = selectedStudent.DateOfBirth.ToString();
            cboGroupName.Text = selectedStudent.GroupName;

            //Cách 2

            //txtEmail.Text = dgvData.Rows[e.RowIndex].Cells[1].Value == DBNull.Value ? "" : dgvData.Rows[e.RowIndex].Cells[1].Value.ToString();
            //txtName.Text = dgvData.Rows[e.RowIndex].Cells[2].Value == DBNull.Value ? "" : dgvData.Rows[e.RowIndex].Cells[2].Value.ToString();
            //dtDOB.Text = dgvData.Rows[e.RowIndex].Cells[3].Value == DBNull.Value ? "" : Convert.ToDateTime(dgvData.Rows[e.RowIndex].Cells[3].Value).ToString();
            //cboGroupName.Text = dgvData.Rows[e.RowIndex].Cells[4].Value == DBNull.Value ? "" : dgvData.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedGroup = (StudentGroup)cboGroupName.SelectedItem;
                if (selectedGroup == null)
                {
                    MessageBox.Show("Group not existed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var student = new Student
                {
                    FullName = txtName.Text,
                    Email = txtEmail.Text,
                    DateOfBirth = DateTime.Parse(dtDOB.Text),
                    GroupId = selectedGroup.Id
                };

                var result = _studentRepository.GetStudentByEmail(student.Email);
                if (result != null)
                {
                    MessageBox.Show("Email is existed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _studentRepository.AddStudent(student);
                MessageBox.Show("Add successfully");
                LoadData();
                ClearText();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Add Failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Id > 0)
                {
                    var selectedGroup = (StudentGroup)cboGroupName.SelectedItem;
                    if (selectedGroup == null)
                    {
                        MessageBox.Show("Group not existed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var student = _studentRepository.GetStudentById(Id);
                    if (student != null)
                    {
                        student.FullName = txtName.Text;
                        student.Email = txtEmail.Text;
                        student.DateOfBirth = DateTime.Parse(dtDOB.Text);
                        student.GroupId = selectedGroup.Id;
                        _studentRepository.UpdateStudent(student);
                        MessageBox.Show("Update successfully");
                        LoadData();
                        ClearText();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Update Failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvData.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvData.SelectedRows)
                    {
                        int id = (int)row.Cells[0].Value;
                        DialogResult result = MessageBox.Show("Do you want to delete this ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            _studentRepository.DeleteStudent(id);
                            MessageBox.Show("Delete successfully");
                        }
                    }
                    LoadData();
                    ClearText();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Delete Failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    LoadData();
                    ClearText();
                    return;
                }

                var searchType = cboSearchType.SelectedItem.ToString();
                IEnumerable<StudentDetails> students;

                if (searchType == "Name")
                {
                    students = _studentRepository.GetStudentsByName(txtSearch.Text);
                }
                else if (searchType == "Email")
                {
                    students = _studentRepository.GetStudentByEmail(txtSearch.Text);
                }
                else if (searchType == "Group")
                {
                    students = _studentRepository.GetStudentsByGroupName(txtSearch.Text);
                }
                else
                {
                    MessageBox.Show("Please select a valid search type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dgvData.DataSource = new BindingList<StudentDetails>(students.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search Failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }
    }
}
