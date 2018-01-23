using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab4WcfIncidentsServiceASP
{
    //*************************************
    //WEB SERVICES (Lab4)(ASP.NET)
    //INCIDENT DATABASE CLASS (C# code)
    //Dean Jones
    //Jan.18, 2017
    //*************************************

    [DataObject(true)]
    public class IncidentDB
    {

        /// <summary>
        /// METHOD GET ALL INCIDENTS (per Technician)
        /// </summary>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Incident> GetOpenTechIncidents(int techID)
        {
            List<Incident> incList = new List<Incident>(); // blank list

            // define connection
            SqlConnection connection = TechSupportDB.GetConnection();

            // define the select query command
            string selectQuery = "SELECT IncidentID, c.CustomerID, c.Name, ProductCode, TechID, DateOpened, DateClosed, Title, Description " +
                                    "FROM Incidents i " +
                                    "INNER JOIN Customers c ON c.CustomerID = i.CustomerID " +
                                    "WHERE TechID = @TechID " +
                                    "AND DateClosed IS NULL " +
                                    "ORDER BY DateOpened ASC;";
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@TechID", techID);
            try
            {
                // open the connection
                connection.Open();

                // execute the query (MULTIPLE ROWS)
                SqlDataReader reader = selectCommand.ExecuteReader();

                // process the result if any
                while (reader.Read()) // if there is incident
                {
                    Incident inc = new Incident(); // new object                   
                    inc.IncidentID = (int)reader["IncidentID"];
                    inc.CustomerID = (int)reader["CustomerID"];       
                    inc.Name = reader["Name"].ToString();
                    inc.ProductCode = reader["ProductCode"].ToString();
                    inc.TechID = (int)reader["TechID"];
                    inc.DateOpened = (DateTime)reader["DateOpened"];
                    inc.Title = reader["Title"].ToString();
                    inc.Description = reader["Description"].ToString();

                    //handle NULL DateTime
                    if(reader.IsDBNull(reader.GetOrdinal("DateClosed")))    //if SQL NULL
                    {
                        inc.DateClosed = null;                              //then return ASP.NET null
                    }
                    else
                    {
                        inc.DateClosed = (DateTime)reader["DateClosed"];    //else return value
                    }                   

                    //add to list
                    incList.Add(inc);
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

            return incList;
        }

        /// <summary>
        /// METHOD GET ALL INCIDENTS (per Customer)
        /// </summary>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Incident> GetCustomerIncidents(int customerID)
        {
            List<Incident> incList = new List<Incident>(); // blank list

            // define connection
            SqlConnection connection = TechSupportDB.GetConnection();

            //SELECT IncidentID, c.Name, ProductCode, TechID, DateOpened, DateClosed, Title, Description
            //      FROM Incidents i
            //      INNER JOIN Customers c ON c.CustomerID = i.CustomerID
            //      WHERE c.CustomerID = 1010;
            // define the select query command
            string selectQuery = "SELECT IncidentID, c.CustomerID, c.Name, ProductCode, TechID, DateOpened, DateClosed, Title, Description " +
                                    "FROM Incidents i " +
                                    "INNER JOIN Customers c ON c.CustomerID = i.CustomerID " +
                                    "WHERE c.CustomerID = @CustomerID;";

            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@CustomerID", customerID);
            try
            {
                // open the connection
                connection.Open();

                // execute the query (MULTIPLE ROWS)
                SqlDataReader reader = selectCommand.ExecuteReader();

                // process the result if any
                while (reader.Read()) // if there is incident
                {
                    Incident inc = new Incident(); // new object                   
                    inc.IncidentID = (int)reader["IncidentID"];
                    inc.CustomerID = (int)reader["CustomerID"];       
                    inc.Name = reader["Name"].ToString();
                    inc.ProductCode = reader["ProductCode"].ToString();                  
                    inc.DateOpened = (DateTime)reader["DateOpened"];
                    inc.Title = reader["Title"].ToString();
                    inc.Description = reader["Description"].ToString();

                    //handle NULL TechID (wasn't needed on Lab3 because parameter was techID)
                    if (reader.IsDBNull(reader.GetOrdinal("TechID")))    //if SQL NULL
                    {                            
                        inc.TechID = null;                               //then return ASP.NET null
                    }
                    else
                    {
                        inc.TechID = (int)reader["TechID"];
                    }

                    //handle NULL DateTime
                    if (reader.IsDBNull(reader.GetOrdinal("DateClosed")))    //if SQL NULL
                    {
                        inc.DateClosed = null;                              //then return ASP.NET null
                    }
                    else
                    {
                        inc.DateClosed = (DateTime)reader["DateClosed"];    //else return value
                    }

                    //add to list
                    incList.Add(inc);
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

            return incList;
        }

        /// <summary>
        /// METHOD GET ALL INCIDENTS
        /// </summary>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Incident> GetAllIncidents()
        {
            List<Incident> incList = new List<Incident>(); // blank list

            // define connection
            SqlConnection connection = TechSupportDB.GetConnection();

            //SELECT IncidentID, c.Name, ProductCode, TechID, DateOpened, DateClosed, Title, Description
            //      FROM Incidents i
            //      INNER JOIN Customers c ON c.CustomerID = i.CustomerID;
            // define the select query command
            string selectQuery = "SELECT IncidentID, c.CustomerID, c.Name, ProductCode, TechID, DateOpened, DateClosed, Title, Description " +
                                    "FROM Incidents i " +
                                    "INNER JOIN Customers c ON c.CustomerID = i.CustomerID " +
                                    "ORDER BY c.Name ASC;";

            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);

            try
            {
                // open the connection
                connection.Open();

                // execute the query (MULTIPLE ROWS)
                SqlDataReader reader = selectCommand.ExecuteReader();

                // process the result if any
                while (reader.Read()) // if there is incident
                {
                    Incident inc = new Incident(); // new object                   
                    inc.IncidentID = (int)reader["IncidentID"];
                    inc.CustomerID = (int)reader["CustomerID"];
                    inc.Name = reader["Name"].ToString();
                    inc.ProductCode = reader["ProductCode"].ToString();
                    inc.DateOpened = (DateTime)reader["DateOpened"];
                    inc.Title = reader["Title"].ToString();
                    inc.Description = reader["Description"].ToString();

                    //handle NULL TechID (wasn't needed on Lab3 because parameter was techID)
                    if (reader.IsDBNull(reader.GetOrdinal("TechID")))    //if SQL NULL
                    {
                        inc.TechID = null;                               //then return ASP.NET null
                    }
                    else
                    {
                        inc.TechID = (int)reader["TechID"];
                    }

                    //handle NULL DateTime
                    if (reader.IsDBNull(reader.GetOrdinal("DateClosed")))    //if SQL NULL
                    {
                        inc.DateClosed = null;                              //then return ASP.NET null
                    }
                    else
                    {
                        inc.DateClosed = (DateTime)reader["DateClosed"];    //else return value
                    }

                    //add to list
                    incList.Add(inc);
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

            return incList;
        }
    }
}