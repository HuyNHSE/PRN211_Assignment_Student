using DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace StudentManagementApp
{
    public partial class FrmLogin : Form
    {
        private readonly IUserRepository _userRepository;
        private readonly IServiceProvider _serviceProvider;
        public FrmLogin(IUserRepository userRepository, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _userRepository = userRepository;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var user = _userRepository.GetUser(txtUserName.Text, txtPassword.Text);
                if (user == null)
                {
                    MessageBox.Show("Wrong username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (user.UserRole1 == 1) // Admin
                    {
                        MessageBox.Show("Login successfully as admin");
                        var frmStudentManagement = _serviceProvider.GetRequiredService<FrmStudentManagement>();
                        frmStudentManagement.Show();
                        this.Hide();
                    }
                    else if (user.UserRole1 == 2) // Staff
                    {
                        MessageBox.Show("Login successfully as staff (read-only mode)");
                        var frmStudentManagement = _serviceProvider.GetRequiredService<FrmStudentManagement>();
                        frmStudentManagement.ReadOnlyMode = true; // Đặt chế độ chỉ đọc
                        frmStudentManagement.Show();
                        this.Hide();
                    }
                    else // Không có quyền
                    {
                        MessageBox.Show("You don't have permission !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login Failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void txtPassword_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
