using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab4WcfIncidentsServiceASP
{
    //*************************************
    //WEB SERVICES (Lab4)(ASP.NET)
    //CUSTOMER DATABASE CLASS (C# code)
    //Dean Jones
    //Jan.17, 2017
    //*************************************

    [DataObject(true)]
    public class CustomerDB
    {

        /// <summary>
        /// retrieves ALL customer
        /// </summary>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Customer> GetAllCustomers()
        {
           
            List<Customer> custList = new List<Customer>(); // blank list

            // define connection
            SqlConnection connection = TechSupportDB.GetConnection();

            // define the select query command
            //SELECT * FROM Customers
            //WHERE CustomerID = 1002;
            string selectQuery = "SELECT CustomerID, Name, Address, City, State, ZipCode, Phone, Email " +
                                    "FROM Customers " +
                                    "ORDER BY Name;";

            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);

            try
            {
                // open the connection
                connection.Open();

                // execute the query
                SqlDataReader reader = selectCommand.ExecuteReader();

                // process the result if any
                while (reader.Read()) // if there is technician
                {
                    Customer cust = new Customer();
                    cust.CustomerID = (int)(reader["CustomerID"]);
                    cust.Name = reader["Name"].ToString();
                    cust.Address = reader["Address"].ToString();
                    cust.City = reader["City"].ToString();
                    cust.State = reader["State"].ToString();
                    cust.ZipCode = reader["ZipCode"].ToString();                    

                    //null phone
                    if (reader.IsDBNull(reader.GetOrdinal("Phone")))        //if SQL NULL
                    {
                        cust.Phone = null;                                  //then return ASP.NET null
                    }
                    else
                    {
                        cust.Phone = reader["Phone"].ToString();            //else return value
                    }

                    //null email
                    if (reader.IsDBNull(reader.GetOrdinal("Email")))        //if SQL NULL
                    {
                        cust.Email = null;                              //then return ASP.NET null
                    }
                    else
                    {
                        cust.Email = reader["Email"].ToString();            //else return value
                    }

                    //add to list
                    custList.Add(cust);
                }
            }
            catch (Exception ex)
            {
                throw ex; // let the form handle it
            }
            finally
            {
                connection.Close(); // close connecto no matter what
            }

            return custList;
        }
    }
}