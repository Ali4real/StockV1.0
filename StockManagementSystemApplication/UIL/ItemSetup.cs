using StockManagementSystemApplication.BLL;
using StockManagementSystemApplication.Modals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementSystemApplication.UIL;

namespace StockManagementSystemApplication
{
    public partial class ItemSetup : Form
    {
        ItemsManager itemManager = new ItemsManager();
        Item item = new Item();
        public ItemSetup()
        {
            InitializeComponent();
            companyComboBox.DataSource = itemManager.GetCompany(item);
            catagoryComboBox.DataSource = itemManager.GetCatagory(item);
            catagoryComboBox.SelectedItem = null;
            companyComboBox.SelectedItem = null;
            catagoryComboBox.Text = "------Select--------";
            companyComboBox.Text = "------Select--------";

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
           
            item.ItemName = ItemNameTextBox.Text;
            item.CategoryName = catagoryComboBox.Text;
            item.CompanyName = companyComboBox.Text;
            if (ReordertextBox.Text == String.Empty)
            {
                item.ReorderLevel = 0;
            }
            else if (itemManager.Validation(ReordertextBox.Text))
            {
                item.ReorderLevel = Convert.ToInt32(ReordertextBox.Text);
            }
            else
            {
                MessageBox.Show("Enter a valid number!!");
                return;
            }
            item.CategoryId = itemManager.GetCatagoryId(item);
            item.CompanyId = itemManager.GetCompanyId(item);

            bool isAdded = itemManager.Add(item);
            if (isAdded)
            {
                MessageBox.Show("Item Added");
                catagoryComboBox.Text = "------Select--------";
                companyComboBox.Text = "------Select--------";
                ReordertextBox.Text=String.Empty;
                ItemNameTextBox.Text=String.Empty;
            }
            else
            {
                MessageBox.Show("Item already Registered!");
            }

        }

        private void catagoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string selectedCategoryName = catagoryComboBox.Text;
            //DataTable dt = new DataTable();
            //dt = itemManager.SetCategoryTable(selectedCategoryName);




            //if (dt.Rows.Count == 0)
            //{
            //    companyComboBox.Text = "----No Company  Set----";
            //}
            //else
            //{

            //    companyComboBox.DataSource = dt;

            //}
        }

        private void companyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string selectedCompanyName = companyComboBox.Text;
            //DataTable dt = new DataTable();
            //dt = itemManager.SetCompanyTable(selectedCompanyName);

            //if (dt.Rows.Count == 0)
            //{

            //    catagoryComboBox.Text = "----No Company  Setup----";
            //}
            //else
            //{

            //    companyComboBox.DataSource = dt;

            //}
        }

        private void ItemSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
       
    }
}
