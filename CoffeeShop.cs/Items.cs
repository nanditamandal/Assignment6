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

namespace CoffeeShop.cs
{
    public partial class Items : Form
    {
        public Items()
        {
            InitializeComponent();
        }

        private void Items_Load(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Additem();
           

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Deleteitem();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Modifyitem();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            Showitem();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Searchitem();
        }
        private void Additem()
        {
            try
            {
                string connectionString = @"Server=NANDITA;DataBase=CoffeeShop;Integrated Security=true";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                string CommandString = @"INSERT INTO Items (ItemName, Price) VALUES('" + nameTextBox.Text + "'," + priceTextBox.Text + ")";

                SqlCommand sqlCommand = new SqlCommand(CommandString, sqlConnection);
                sqlConnection.Open();
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    MessageBox.Show("add successfull..");
                }
                else
                {
                    MessageBox.Show("can not add..");
                }
                 sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("please fill the name and price");
            }
        }
       private void Showitem()
       {
            try
            { 

                string connectionString = @"Server=NANDITA;DataBase=CoffeeShop;Integrated Security=true";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                string CommandString = @"SELECT *FROM Items";

                SqlCommand sqlCommand = new SqlCommand(CommandString, sqlConnection);
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
            
                if (dataTable.Rows.Count > 0)
                {
                    showdataGridView.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("no data for show..");
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("no items are save..");
            }
        }
        private void Deleteitem()
        {
            try
            {
                string connection = @"Server=NANDITA;DataBase=CoffeeShop;Integrated Security=True";
                SqlConnection sqlconnection = new SqlConnection(connection);
                string delete = @"DELETE FROM Items WHERE ID='" + idTextBox.Text + "'";
                SqlCommand command = new SqlCommand(delete, sqlconnection);

                sqlconnection.Open();
                int isExecuted = command.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    MessageBox.Show("delete successfull ..");
                }
                else
                {
                    MessageBox.Show("row can not found");
                }
                sqlconnection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("some thing wrong");
            }

        }
        private void Searchitem()
        {
            try
            {
                string connectionString = @"Server=NANDITA;DataBase=CoffeeShop;Integrated Security=true";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                string CommandString = @"SELECT * FROM Items WHERE ItemName='" + nameTextBox.Text + "'";

                SqlCommand sqlCommand = new SqlCommand(CommandString, sqlConnection);
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
               
                if (dataTable.Rows.Count > 0)
                {
                    showdataGridView.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("no data found..");
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("no item recod in database");
            }
        }
        private void Modifyitem()
        {
            try
            {
                string connection = @"Server=NANDITA;DataBase=CoffeeShop;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connection);

                string modifi = @"UPDATE Items SET ItemName='" + nameTextBox.Text + "', Price=" + priceTextBox.Text + " WHERE ID='" + idTextBox.Text + "'";
                SqlCommand command = new SqlCommand(modifi, sqlConnection);

                sqlConnection.Open();

                int isExecuted = command.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    MessageBox.Show("update is ok..");
                }
                else
                {
                    MessageBox.Show("no data found..");
                }
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("no items recod in database");
            }

        }

        private void priceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void idTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
