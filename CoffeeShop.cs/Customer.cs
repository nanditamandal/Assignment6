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
    public partial class Customer : Form
    {
        

        public Customer()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Add();
            
        }
        private void showButton_Click(object sender, EventArgs e)
        {
            Showcustomer();

        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Deletecustomer();
        }
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            Modificustomer();

        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            Searchcustomer();
        }
        private void Add()
        {
            try
            {
                string connection = @"Server=NANDITA;DataBase=CoffeeShop;Integrated Security=True";
                SqlConnection sqlconnection = new SqlConnection(connection);
                string insert = @"INSERT INTO Customers(Name, Address , Contact)VALUES('" + NametextBox.Text + "', '" + AddresstextBox.Text + "','" + contactTextBox.Text + "')";
                SqlCommand command = new SqlCommand(insert, sqlconnection);
                
                sqlconnection.Open();
                int isExecuted= command.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    MessageBox.Show("Add successfull ..");
                }
                else
                {
                    MessageBox.Show("may be name duplicate..");
                }


                sqlconnection.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show("please insert name address and contact..");
            }
        }


       
        private void Showcustomer()
        {
            try
            {
                string connection = @"Server=NANDITA;DataBase=CoffeeShop;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connection);

                string show = @"SELECT * FROM Customers";
                SqlCommand command = new SqlCommand(show, sqlConnection);

                sqlConnection.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if(dataTable.Rows.Count>0)
                {
                    showdataGridView.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("no data found..");
                }
                
                sqlConnection.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show("no customer recod in database");
            }

        }

        
        private void Deletecustomer()
        {

            try
            {
                string connection = @"Server=NANDITA;DataBase=CoffeeShop;Integrated Security=True";
                SqlConnection sqlconnection = new SqlConnection(connection);
                string delete = @"DELETE FROM Customers WHERE ID='"+idTextBox.Text+"'";
                SqlCommand command = new SqlCommand(delete, sqlconnection);

                sqlconnection.Open();
                int isExecuted=command.ExecuteNonQuery();
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
        private void Modificustomer()
        {
            try
            {
                string connection = @"Server=NANDITA;DataBase=CoffeeShop;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connection);

                string modifi =@"UPDATE Customers SET Name='" + NametextBox.Text + "', Address='" +AddresstextBox.Text + "',Contact='"+contactTextBox.Text+"' WHERE ID='" + idTextBox.Text + "'";
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
                MessageBox.Show("no customer recod in database");
            }

        }
        private void Searchcustomer()
        {
            try
            {
                string connectionString = @"Server=NANDITA;DataBase=CoffeeShop;Integrated Security=true";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                string CommandString = @"SELECT * FROM Customers WHERE Name='" + NametextBox.Text + "'";

                SqlCommand sqlCommand = new SqlCommand(CommandString, sqlConnection);
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                //showdataGridView.DataSource = dataTable;
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
            catch(Exception ex)
            {
                MessageBox.Show("no customer recod in database");
            }
            
        }

        private void idTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void contactTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
