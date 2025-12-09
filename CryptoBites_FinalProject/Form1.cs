using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CryptoBites_FinalProject
{
    public partial class Form1 : Form
    {
        private string filePath = "users.txt"; // Storage file for accounts

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text.Trim();
            string password = textpassword.Text.Trim();


            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter username and password!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists(filePath))
            {
                MessageBox.Show("No accounts found. Please sign up first!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var users = File.ReadAllLines(filePath);

            bool valid = users.Any(u =>
            {
                var parts = u.Split('|');
                return parts.Length >= 2 && parts[0] == username && parts[1] == password;
            });

            if (valid)
            {
                MessageBox.Show("Login successful!", "Welcome to CryptoBites", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Open Cart after login
                Cart cartForm = new Cart(username);

                // When Cart closes, close login form as well
                cartForm.FormClosed += (s, args) => this.Hide();

                cartForm.Show();
                this.Hide(); // Hide login form while Cart is open
            }
            else
            {
                MessageBox.Show("Incorrect username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            FormSignup signupForm = new FormSignup(this);
            signupForm.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
       
        }
    }
