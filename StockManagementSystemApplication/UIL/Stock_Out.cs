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
    public partial class Stock_Out : Form
    {
        List<string> GridViewData = new List<string>();
        private int count = 1;
        Category category=new Category();
        Company company=new Company();
        Item item=new Item();
        StockOutClass stockOut = new StockOutClass();
        StockOutManager stockOutManager = new StockOutManager();
       
        public Stock_Out()
        {
           
            InitializeComponent();


           
            categoryComboBox.DataSource = stockOutManager.GetCategoryTable(category);
            companyComboBox.DataSource = stockOutManager.GetCompanyTable(company);
            itemComboBox.DataSource = stockOutManager.GetItemTable(item);
            categoryComboBox.SelectedItem = null;
            companyComboBox.SelectedItem = null;
            itemComboBox.SelectedItem = null;
            categoryComboBox.Text = "------Select-------";
            companyComboBox.Text = "------Select-------";
            itemComboBox.Text = "------Select-------";

            reorderLabel.Text = String.Empty;
            quantityLabel.Text = String.Empty;

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


        private void itemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItemName = itemComboBox.Text;
            DataTable dt = new DataTable();
            dt = stockOutManager.SetItemTable(selectedItemName);

            if (dt.Rows.Count == 0)
            {

                long number = 0;
                quantityLabel.Text = number.ToString();   
            }
            else
            {
              reorderLabel.Text = dt.Rows[0]["ReorderLevel"].ToString();

                if (dt.Rows[0]["AvailableQuantity"].ToString() == "")
                {
                    quantityLabel.Text = (0).ToString();
                }
                else
                {
                    quantityLabel.Text = dt.Rows[0]["AvailableQuantity"].ToString();
                }

            }
           }

            private void companyComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {

                string selectedCompanyName = companyComboBox.Text;
                string selectedCategoryName = categoryComboBox.Text;
                DataTable dt = new DataTable();
                dt = stockOutManager.SetCompanyTable(selectedCompanyName, selectedCategoryName);
         
                itemComboBox.DataSource = dt;
          
                if (dt.Rows.Count == 0)
                {

                    long number = 0;
                    quantityLabel.Text = number.ToString();
                   // MessageBox.Show("No Item Found!");
                }
                else
                {
            
                   // companyComboBox.DataSource = dt;
                    itemComboBox.DataSource = dt;
                    reorderLabel.Text = dt.Rows[0]["ReorderLevel"].ToString();

                    if (dt.Rows[0]["AvailableQuantity"].ToString() == "")
                    {
                        quantityLabel.Text = (0).ToString();
                    }
                    else
                        quantityLabel.Text = dt.Rows[0]["AvailableQuantity"].ToString();
              
                }
            }

            private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                string selectedCategoryName = categoryComboBox.Text;
                DataTable dt = new DataTable();
                dt = stockOutManager.SetCategoryTable(selectedCategoryName);
                DataTable dt2 = stockOutManager.SetCompany(selectedCategoryName);



                if (dt.Rows.Count == 0)
                {

                    long number = 0;
                    quantityLabel.Text = number.ToString();
                  //  MessageBox.Show("No Item Found!");
                }
                else
                {

                    companyComboBox.DataSource = dt2;
                    itemComboBox.DataSource = dt;
                    reorderLabel.Text = dt.Rows[0]["ReorderLevel"].ToString();
                    if (dt.Rows[0]["AvailableQuantity"].ToString() == "")
                    {
                       quantityLabel.Text = (0).ToString();
                    }
                    else
                    {
                       quantityLabel.Text = dt.Rows[0]["AvailableQuantity"].ToString();
                    }
                 }
            }

            private void AddButton_Click(object sender, EventArgs e)
            {
                 reorderMessageLabel.Text=String.Empty;
                if (categoryComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Please select a Category!!");
                    return;
                }
                   
                stockOut.CategoryName = categoryComboBox.Text;
                  if (companyComboBox.SelectedItem == null)
                  {
                      MessageBox.Show("Please select a Company!!");
                      return;
                  }
                stockOut.CompanyName = companyComboBox.Text;
                  if (categoryComboBox.SelectedItem == null)
                  {
                      MessageBox.Show("Please select an Item!!");
                      return;
                  }
                stockOut.ItemName = itemComboBox.Text;
                bool isTrue = stockOutManager.Validation(stockOutQuantityTextBox.Text);
                if (!isTrue)
                {
                    MessageBox.Show("Please Enter a Valid Number!");
                          return;
                }
                stockOut.Quantity = Convert.ToInt64(stockOutQuantityTextBox.Text);
                stockOut.ReorderLevel = Convert.ToInt64(reorderLabel.Text);
                long availableQuantity= Convert.ToInt64(quantityLabel.Text);
                if (availableQuantity - Convert.ToInt64(stockOutQuantityTextBox.Text) < 0)
                {
                    MessageBox.Show("Out  Of  Stock");
                    return;
                }
                if (availableQuantity - Convert.ToInt64(stockOutQuantityTextBox.Text) < stockOut.ReorderLevel)
                {
                    reorderMessageLabel.ForeColor=Color.Red;
                    reorderMessageLabel.Text = "Check the Stock of the Item!";
                }
                if (count == 1)
                {
                    stockOutDataGridView.Columns.Add("CategoryName", "CategoryName");
                    stockOutDataGridView.Columns.Add("CompanyName", "CompanyName");
                    stockOutDataGridView.Columns.Add("ItemName", "ItemName");
                    stockOutDataGridView.Columns.Add("Quantity", "Quantity");
                    count++;
                }
                stockOutDataGridView.Rows.Add(stockOut.CategoryName, stockOut.CompanyName, stockOut.ItemName, stockOut.Quantity);
                stockOutQuantityTextBox.Text = String.Empty;
                categoryComboBox.Text = "------Select-------";
                companyComboBox.Text = "------Select-------";
                itemComboBox.Text = "------Select-------";
                reorderLabel.Text=String.Empty;
                quantityLabel.Text=String.Empty;
            }

            private void SellButton_Click(object sender, EventArgs e)
            {
                bool isSuccessfull = false;
                foreach (DataGridViewRow row in stockOutDataGridView.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        GridViewData.Add(cell.Value.ToString());
                    }
                    string ItemName = GridViewData[2];
                    string ItemId = stockOutManager.GetItemId(ItemName).ToString();
                    GridViewData.Add(ItemId);
                    GridViewData.Add("Sell");
                    bool  isAdded=stockOutManager.AddStockOut(GridViewData);
                    if (isAdded)
                    {
                        //long quantity = Convert.ToInt64(GridViewData[3]);
                        bool isUpdated=stockOutManager.UpdateTable(GridViewData);
                        if (isUpdated)
                        {
                          isSuccessfull = true;
                        }
                    }

                }
                if (isSuccessfull == true)
                {
                    MessageBox.Show("Stock Out Successfull!");
                }
                stockOutDataGridView.Rows.Clear();

            }

            private void DamageButton_Click(object sender, EventArgs e)
            {
                bool isSuccessfull = false;
                foreach (DataGridViewRow row in stockOutDataGridView.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        GridViewData.Add(cell.Value.ToString());
                    }
                    string ItemName = GridViewData[2];
                    string ItemId = stockOutManager.GetItemId(ItemName).ToString();
                    GridViewData.Add(ItemId);
                    GridViewData.Add("Damage");
                    bool isAdded = stockOutManager.AddStockOut(GridViewData);
                    if (isAdded)
                    {
                        //long quantity = Convert.ToInt64(GridViewData[3]);
                        bool isUpdated = stockOutManager.UpdateTable(GridViewData);
                        if (isUpdated)
                        {
                            isSuccessfull = true;
                        }
                    }

                }
                if (isSuccessfull == true)
                {
                    MessageBox.Show("Stock Out Successfull!");
                }
                stockOutDataGridView.Rows.Clear();

            }

            private void LostButton_Click(object sender, EventArgs e)
            {
                 bool isSuccessfull = false;
                foreach (DataGridViewRow row in stockOutDataGridView.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        GridViewData.Add(cell.Value.ToString());
                    }
                    string ItemName = GridViewData[2];
                    string ItemId = stockOutManager.GetItemId(ItemName).ToString();
                    GridViewData.Add(ItemId);
                    GridViewData.Add("Lost");
                    bool isAdded = stockOutManager.AddStockOut(GridViewData);
                    if (isAdded)
                    {
                        //long quantity = Convert.ToInt64(GridViewData[3]);
                        bool isUpdated = stockOutManager.UpdateTable(GridViewData);
                        if (isUpdated)
                        {
                            isSuccessfull = true;
                        }
                    }

                }
                if (isSuccessfull == true)
                {
                    MessageBox.Show("Stock Out Successfull!");
                }
                stockOutDataGridView.Rows.Clear();
            }

            private void Stock_Out_FormClosing(object sender, FormClosingEventArgs e)
            {
                Application.Exit();
            }
    }
}
