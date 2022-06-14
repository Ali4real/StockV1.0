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
using StockManagementSystemApplication.UIL;


namespace StockManagementSystemApplication
{
    public partial class ItemsSummary : Form
    {
        ItemsSummeryManager  itemsSummeryManager=new ItemsSummeryManager();
        Category category = new Category();
        Company company = new Company();
        ItemsSummeryClass itemsSummeryClass=new ItemsSummeryClass();
        public ItemsSummary()
        {
           
            InitializeComponent();
            companyComboBox.DataSource = itemsSummeryManager.GetCompanyTable(company);
            categoryComboBox.DataSource = itemsSummeryManager.GetCategoryTable(category);

            categoryComboBox.SelectedItem = null;
           companyComboBox.SelectedItem = null;
           categoryComboBox.Text = "----Select----";
           companyComboBox.Text = "----Select----"; 
            
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





        private void SearchButton_Click(object sender, EventArgs e)
        {
            itemsSummeryClass.CategoryName = categoryComboBox.Text;
            itemsSummeryClass.CompanyName = companyComboBox.Text;

            DataTable dt=new DataTable();
            dt=itemsSummeryManager.GetDataTable(itemsSummeryClass);

            
            foreach (DataRow check in dt.Rows)
            {
                if (check["AvailableQuantity"].ToString() == String.Empty)
                {
                    check["AvailableQuantity"] = 0;
                }
            }
            
            itemSummaryDataGridView.DataSource = dt;



        }

        private void companyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCompanyName = companyComboBox.Text;
            DataTable dt = new DataTable();
            dt = itemsSummeryManager.SetCompanyTable(selectedCompanyName);

           

            if (dt.Rows.Count == 0)
            {
                categoryComboBox.Text = "-----No Category Found-----";
            }
            else
            {
                categoryComboBox.DataSource = dt;
                categoryComboBox.SelectedItem = null;
                categoryComboBox.Text = "----Select----";
            }
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategoryName = categoryComboBox.Text;
            DataTable dt = new DataTable();
            dt = itemsSummeryManager.SetCategoryTable(selectedCategoryName);


            if (dt.Rows.Count == 0)
            {
               companyComboBox.Text="-----No Company Found-----";
            }
            else
            {
              categoryComboBox.DataSource = dt;
              
            }
        }

        private void ItemsSummary_FormClosing(object sender, FormClosingEventArgs e)
        {
             Application.Exit();
        }
    }
}
