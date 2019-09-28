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
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Addorder();
            
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            Showorder();
            
        }
        private void Addorder()
        {
            try
            {
                string connection = @"Server=NANDITA;DataBase=CoffeeShop;Integrated Security=True";
                SqlConnection sqlconnection = new SqlConnection(connection);

                string insert = @"INSERT INTO Orders(Quantity, Name , ItemName)VALUES(" + quantityTextBox.Text + ",'" + customerNameTextBox.Text + "','" + itemNameTextBox.Text + "')";
                SqlCommand command = new SqlCommand(insert, sqlconnection);

                sqlconnection.Open();
                int isExecuted=command.ExecuteNonQuery();
                if(isExecuted>0)
                {
                    MessageBox.Show("order added..");
                }
                else
                {
                    MessageBox.Show("quantity or name or item name can not empty..");
                }


                sqlconnection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("order can not added..");
            }
        }
        private void Showorder()
        {
            try
            {
                string connection = @"Server=NANDITA;DataBase=CoffeeShop;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connection);

                string show = @"SELECT Orders.ID,Orders.Name, Customers.Address, Customers.Contact,Orders.ItemName, Items.Price,Orders.Quantity,(Orders.Quantity*Items.Price) As TotalPrice FROM Orders, Customers, Items WHERE Orders.Name=Customers.Name AND Orders.ItemName=Items.ItemName";
                SqlCommand command = new SqlCommand(show, sqlConnection);

                sqlConnection.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
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
                MessageBox.Show("order can not show..");
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Updateorder();

        }
        private void Updateorder()
        {
            try
            {
                string connection = @"Server=NANDITA;DataBase=CoffeeShop;Integrated Security=True";
                SqlConnection sqlconnection = new SqlConnection(connection);

                string query = @"UPDATE Orders SET Quantity="+quantityTextBox.Text+", Name='"+customerNameTextBox.Text+"', ItemName='"+itemNameTextBox.Text+"'WHERE ID="+idTextBox.Text+"";
                SqlCommand command = new SqlCommand(query, sqlconnection);

                sqlconnection.Open();
                int isExecuted = command.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    MessageBox.Show("order updatede..");
                }
                else
                {
                    MessageBox.Show("quantity or name or item name can not empty..");
                }


                sqlconnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("order can not updated..");
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Deleteorder();
        }
        private void Deleteorder()
        {
            try
            {
                string connection = @"Server=NANDITA;DataBase=CoffeeShop;Integrated Security=True";
                SqlConnection sqlconnection = new SqlConnection(connection);
                string query = @"DELETE FROM Orders WHERE ID='" + idTextBox.Text + "'";
                SqlCommand command = new SqlCommand(query, sqlconnection);

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

        private void searchButton_Click(object sender, EventArgs e)
        {
            Searchorder();
        }
        private void Searchorder()
        {
            try
            {
                string connectionString = @"Server=NANDITA;DataBase=CoffeeShop;Integrated Security=true";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string show = @"SELECT Orders.ID,Orders.Name, Customers.Address, Customers.Contact,Orders.ItemName, Items.Price,Orders.Quantity,(Orders.Quantity*Items.Price) As TotalPrice FROM Orders, Customers, Items WHERE Orders.Name=Customers.Name AND Orders.ItemName=Items.ItemName AND Order.Name='" + customerNameTextBox.Text + "'";

                SqlCommand sqlCommand = new SqlCommand(show, sqlConnection);
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
                MessageBox.Show("no order recod in database");
            }

        }

        private void quantityTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
