using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CryptoBites_FinalProject
{
    public partial class FormSignup : Form
    {
        string filePath = "users.txt";
        Form1 loginForm;

        public FormSignup(Form1 form)
        {
            InitializeComponent();
            loginForm = form;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string username = txtNewUser.Text.Trim();
            string password = txtNewPass.Text.Trim();
            string number = txtNumber.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(number))
            {
                MessageBox.Show("Please fill in all fields!");
                return;
            }

            // Prevent duplicate usernames
            if (File.Exists(filePath))
            {
                var users = File.ReadAllLines(filePath);
                if (users.Any(u => u.Split('|')[0] == username))
                {
                    MessageBox.Show("Username already exists! Choose another.");
                    return;
                }
            }

            File.AppendAllText(filePath,
                username + "|" + password + "|" + number + Environment.NewLine);

            MessageBox.Show("Account created successfully!");
            loginForm.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            loginForm.Show();
            this.Close();
        }

        private void txtNewUser_TextChanged(object sender, EventArgs e) { }
        private void txtNewPass_TextChanged(object sender, EventArgs e) { }
        private void txtNumber_TextChanged(object sender, EventArgs e) { }
        private void FormSignup_Load(object sender, EventArgs e) { }
    }
}
