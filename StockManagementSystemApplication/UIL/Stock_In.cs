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
    public partial class Stock_In : Form
    {
        Category category=new Category();
        Company company=new Company();
        Item item=new Item();
        StockInManager stockInManager = new StockInManager();
        public Stock_In()
        {
            InitializeComponent();

           
            categoryComboBox.DataSource = stockInManager.GetCategoryTable(category);
           
            companyComboBox.DataSource = stockInManager.GetCompanyTable(company);
            itemComboBox.DataSource = stockInManager.GetItemTable(item);
            categoryComboBox.SelectedItem = null;
            companyComboBox.SelectedItem = null;
            itemComboBox.SelectedItem = null;
            categoryComboBox.Text = "------Select--------";
            companyComboBox.Text = "------Select--------";
            itemComboBox.Text = "------Select--------";
            reorderLevelLabel.Text=String.Empty;
            availableQuantityLabel.Text=String.Empty;

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






        private void SaveButton_Click(object sender, EventArgs e)
        {
            StockInClass stockIn = new StockInClass();
            if (itemComboBox.SelectedItem == null)
            {
                MessageBox.Show("Plaease select an Item");
                return;
            }
            if (categoryComboBox.SelectedItem == null)
            {
                MessageBox.Show("Plaease select an Category");
                return;
            }
            if (companyComboBox.SelectedItem == null)
            {
                MessageBox.Show("Plaease select an Company");
                return;
            }
            stockIn.ItemName = itemComboBox.Text;

            stockIn.ItemId = stockInManager.GetItemId(stockIn);
         
           
            stockIn.AvailableQuantity = Convert.ToInt32(availableQuantityLabel.Text);
            bool isTrue=stockInManager.Validation(quantityTextBox.Text);
            if (!isTrue)
            {
                MessageBox.Show("Please Enter a Valid Number!");
                return;
            }
            stockIn.StockInQuantity = Convert.ToInt32(quantityTextBox.Text);
            stockIn.AvailableQuantity += stockIn.StockInQuantity;
            bool isAdded = stockInManager.Update(stockIn);
            if (isAdded)
            {
                MessageBox.Show("Stock In Succesful!");
                quantityTextBox.Text=String.Empty;
                
            }
            else
            {
                MessageBox.Show("Stock In Failed!");
            }
            categoryComboBox.Text = "------Select--------";
            companyComboBox.Text = "------Select--------";
            itemComboBox.Text = "------Select--------";
            reorderLevelLabel.Text = String.Empty;
            availableQuantityLabel.Text = String.Empty;

         }

        private void itemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItemName = itemComboBox.Text;
            DataTable dt = new DataTable();
            dt = stockInManager.SetItemTable(selectedItemName);

            // itemComboBox.DataSource = dt;

            if (dt.Rows.Count == 0)
            {
                long number = 0;
                availableQuantityLabel.Text = number.ToString();
            }
            else
            {
              //  itemComboBox.DataSource = dt;
                reorderLevelLabel.Text = dt.Rows[0]["ReorderLevel"].ToString();

                if (dt.Rows[0]["AvailableQuantity"].ToString() == "")
                {
                    availableQuantityLabel.Text = (0).ToString();
                }
                else
                {
                    availableQuantityLabel.Text = dt.Rows[0]["AvailableQuantity"].ToString();
                }

            }
        }

            private void companyComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {

                string selectedCompanyName = companyComboBox.Text;
               string selectedCategoryName = categoryComboBox.Text;
                DataTable dt = new DataTable();
                dt = stockInManager.SetCompanyTable(selectedCompanyName, selectedCategoryName);
               DataTable dt2 = stockInManager.SetCompany(selectedCategoryName);
         
              //  itemComboBox.DataSource = dt;
          
                if (dt.Rows.Count == 0)
                {

                    long number = 0;
                    availableQuantityLabel.Text = number.ToString();
                  
                }
                else
                {
            
                  // companyComboBox.DataSource = dt2;
                    itemComboBox.DataSource = dt;
                    reorderLevelLabel.Text = dt.Rows[0]["ReorderLevel"].ToString();

                    if (dt.Rows[0]["AvailableQuantity"].ToString() == "")
                    {
                        availableQuantityLabel.Text = (0).ToString();
                    }
                    else
                        availableQuantityLabel.Text = dt.Rows[0]["AvailableQuantity"].ToString();

                }
            }

            private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                string selectedCategoryName = categoryComboBox.Text;
              //  string selectedCompanyName = companyComboBox.Text;
                DataTable dt = new DataTable();
                dt = stockInManager.SetCategoryTable(selectedCategoryName);
                DataTable dt2 = stockInManager.SetCompany(selectedCategoryName);

                if (dt.Rows.Count == 0)
                {
                    long number = 0;
                    availableQuantityLabel.Text = number.ToString();
                }
                else
                {

                    companyComboBox.DataSource = dt2;
                    itemComboBox.DataSource = dt;
                    reorderLevelLabel.Text = dt.Rows[0]["ReorderLevel"].ToString();
                    if (dt.Rows[0]["AvailableQuantity"].ToString() == "")
                    {
                        availableQuantityLabel.Text = (0).ToString();
                    }
                    else
                    {
                        availableQuantityLabel.Text = dt.Rows[0]["AvailableQuantity"].ToString();
                    }
                }
              }


            private void Stock_In_FormClosing(object sender, FormClosingEventArgs e)
            {   
                 Application.Exit();
            }
    }
}
