using StockManagementSystemApplication.BLL;
using StockManagementSystemApplication.Modals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementSystemApplication.UIL;

namespace StockManagementSystemApplication
{
    public partial class LogInPage : Form
    {
        
        public LogInPage()
        {
            InitializeComponent();
        }

        public void LogInButton_Click(object sender, EventArgs e)
        {

            LogInPageClass login = new LogInPageClass();
            if (usernameTextBox.Text == null || usernameTextBox.Text.Length <4 || passwordTextBox.Text == null || passwordTextBox.Text.Length <6)
            {
                MessageBox.Show("Ivalied Username or Password \n Please Try again");
                return;
            }
            else 
            {
                login.Username = usernameTextBox.Text;
                login.Password = passwordTextBox.Text;
            }
            LogInPageManager loginmanager = new LogInPageManager();
            bool isAdded = loginmanager.Check(login);
            if (isAdded)
            {
                
                this.Hide();
                HomePage homePage = new HomePage();
                homePage.Show();
                
                usernameTextBox.Clear();
                passwordTextBox.Clear();
                
            }
            else 
            {
                MessageBox.Show("Wrong username or password");
                return;
            }
            
           
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterPage registerPage = new RegisterPage();
            registerPage.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LogInPage_Load(object sender, EventArgs e)
        {

        }
    }
}
