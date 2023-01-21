using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace assignment4_OOP
{
    internal class customer1
    {
        private static string mycon = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }

        private const string InsertQuery = "Insert Into customer(CompanyName,ContactName,Phone) Values(@CompanyName, @ContactName, @Phone)";

        //Insert
        public bool InsertCustomer(customer1 customer)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(mycon))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(InsertQuery, con))
                {
                    com.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
                    com.Parameters.AddWithValue("@ContactName", customer.ContactName);
                    com.Parameters.AddWithValue("@Phone", customer.Phone);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }

        //Update 

        private const string UpdateQuery = "Update customer set CompanyName=@CompanyName,ContactName=@ContactName,Phone=@Phone where CustomerID=@CustomerID";
        public bool UpdateCustomer(customer1 customer)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(mycon))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(UpdateQuery, con))
                {
                    com.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                    com.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
                    com.Parameters.AddWithValue("@ContactName", customer.ContactName);
                    com.Parameters.AddWithValue("@Phone", customer.Phone);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }

        //Delete

        private const string DeleteQuery = "Delete from customer where CustomerID=@CustomerID";
        public bool DeleteCustomer(customer1 customer)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(mycon))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(DeleteQuery, con))
                {
                    com.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                    com.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
                    com.Parameters.AddWithValue("@ContactName", customer.ContactName);
                    com.Parameters.AddWithValue("@Phone", customer.Phone);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }

        //Show

        private const string SelectQuery = "Select * from customer";
        public DataTable GetEmployees()
        {
            var datatable = new DataTable();
            using (SqlConnection con = new SqlConnection(mycon))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(SelectQuery, con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(com))
                    {
                        adapter.Fill(datatable);
                    }
                }
            }
            return datatable;
        }
    }




}

