using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementSystemApplication.BLL;
using StockManagementSystemApplication.Modals;

namespace StockManagementSystemApplication.UIL
{
    public partial class RegisterPage : Form
    {
        public RegisterPage()
        {
            InitializeComponent();
        }
        RegistrationInformation registrationInformation=new RegistrationInformation();
        RegisterManager registerManager = new RegisterManager();
        private void RegisterButton_Click(object sender, EventArgs e)
        {
          

            if (registerManager.ValidateName(firstNameTextBox.Text))
            {
                registrationInformation.FirstName = firstNameTextBox.Text;
            }
            else
            {
                firstNameLabel.ForeColor = Color.Red;
                firstNameLabel.Text = "Enter a valid Name";
                return;
            } 
            if (registerManager.ValidateName(lastNameTextBox.Text))
            {
                registrationInformation.LastName = lastNameTextBox.Text;
            }
            else
            {
                secondNameLabel.ForeColor = Color.Red;
                secondNameLabel.Text = "Enter a valid Name";
                return;
            }

            if (registerManager.ValidateUserName(userNameTextBox.Text))
            {
                registrationInformation.Username = userNameTextBox.Text;
            }
            else
            {
                userNameLabel.ForeColor = Color.Red;
                userNameLabel.Text = "Enter a valid UserName.";
                return;
            }

            if (passwordTextBox.Text.Length < 6)
            {
                passwordLabel.ForeColor = Color.Red;
                passwordLabel.Text = "Password should be atleast 6 digit or character!!!";
                return;
            }
            else
            {
                registrationInformation.Password = passwordTextBox.Text;
            }

            if (registerManager.ValidatEmail(emailTextBox.Text))
            {
                registrationInformation.Email = emailTextBox.Text;
            }
            else
            {
                emailLabel.ForeColor = Color.Red;
                emailLabel.Text = "Enter a valid Email!!!";
                return;
            }
          
            bool isAdded = registerManager.Add(registrationInformation);
            if (isAdded)
            {

                this.Hide();
                HomePage homePage = new HomePage();
                homePage.Show();

            }
            firstNameLabel.Text = String.Empty;
            lastNameTextBox.Text = String.Empty;
            userNameLabel.Text = String.Empty;
            passwordLabel.Text = String.Empty;
            emailLabel.Text = String.Empty;

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogInPage logInPage=new LogInPage();
            logInPage.Show();
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            passwordTextBox.PasswordChar = '*';
        }

        private void RegisterPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        
    }
}
