using StockManagementSystemApplication.BLL;
using StockManagementSystemApplication.Modals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementSystemApplication.UIL;

namespace StockManagementSystemApplication
{
    public partial class CompanySetup : Form
    {
        CompanyManager companyManager = new CompanyManager();
        Company company = new Company();
        public CompanySetup()
        {
            InitializeComponent();
            CompanyDataGridView.DataSource = companyManager.Show();
        }

        //*****************************************************************//
        private void companySetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CompanySetup company = new CompanySetup();
            company.Show();
        }

        private void categorySetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CatagorySetup catagory = new CatagorySetup();
            catagory.Show();
        }

        private void itemSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ItemSetup items = new ItemSetup();
            items.Show();
        }

        private void stokInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Stock_In stockin = new Stock_In();
            stockin.Show();
        }

        private void stockOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Stock_Out stockout = new Stock_Out();
            stockout.Show();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SalesDates sales = new SalesDates();
            sales.Show();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ItemsSummary search = new ItemsSummary();
            this.Close();
            search.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogInPage logout = new LogInPage();
            logout.Show();
        }

        private void setupCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CatagorySetup catagory = new CatagorySetup();
            catagory.Show();
        }

        private void setupCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CompanySetup company = new CompanySetup();
            company.Show();
        }

        private void setupItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ItemSetup items = new ItemSetup();
            items.Show();
        }

        private void stockInToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Stock_In stockin = new Stock_In();
            stockin.Show();

        }

        private void stockOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Stock_Out stockout = new Stock_Out();
            stockout.Show();
        }

        private void searchAndViewItemsSummaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ItemsSummary summary = new ItemsSummary();
            summary.Show();
        }

        private void salesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SalesDates sales = new SalesDates();
            sales.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("yes or no?",
                          "Stock Management System",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            { return; }
        }

        private void searchAndViewItemsSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ItemsSummary search = new ItemsSummary();
            search.Show();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("yes or no?",
                          "Stock Management System",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            { return; }
        }
        //*****************************************************************//

        private void SaveButton_Click(object sender, EventArgs e)
        {

            company.CompanyName =CompanyNameTextBox.Text;
            if (companyManager.Validation(company.CompanyName))
            {
                bool isAdded = companyManager.Add(company);
                if (isAdded)
                {
                    DataTable dt = companyManager.Show();
                    CompanyDataGridView.DataSource = dt;
                    CompanyNameTextBox.Text = String.Empty;
                }
                else
                {
                    MessageBox.Show("Cateegory already Registered!");
                }
            }

            else
            {
                MessageBox.Show("Invalid Category Name. Use atleast One Letter!!!");
            }
          

          
            

        }

        private void CompanySetup_FormClosing(object sender, FormClosingEventArgs e)
        {
           Application.Exit();
        }
    }
}
