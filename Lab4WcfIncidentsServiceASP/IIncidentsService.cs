using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Lab4WcfIncidentsServiceASP
{
    //*************************************
    //WEB SERVICES (Lab4)(ASP.NET)
    //INTERFACE
    //Dean Jones
    //Jan.18, 2017
    //*************************************

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IIncidentsService" in both code and config file together.
    [ServiceContract]
    public interface IIncidentsService
    {
        // METHOD GET ALL CUSTOMERS
        [OperationContract]
        List<Customer> GetAllCustomers();

        // METHOD GET ALL INCIDENTS (per Technician)
        [OperationContract]
        List<Incident> GetOpenTechIncidents(int techID);

        // METHOD GET ALL INCIDENTS(per Customer)
        [OperationContract]
        List<Incident> GetCustomerIncidents(int customerID);

        // METHOD GET ALL INCIDENTS
        [OperationContract]
        List<Incident> GetAllIncidents();
    }

    // Incident CLASS
    [DataContract]
    public class Incident
    {
        //CONSTRUCTOR
        //public Incident() { }

        //GETTERS AND SETTERS
        [DataMember]
        public int IncidentID { get; set; }
        [DataMember]
        public int CustomerID { get; set; }
        [DataMember]
        public string ProductCode { get; set; }
        [DataMember]
        public int? TechID { get; set; }
        [DataMember]
        public DateTime DateOpened { get; set; }
        [DataMember]
        public DateTime? DateClosed { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }

        //add customer name (Customers table)
        [DataMember]
        public string Name { get; set; }

    }

    // Customer CLASS
    [DataContract]
    public class Customer
    {
        //CONSTRUCTOR
        //public Customer() { }

        //GETTERS AND SETTERS
        [DataMember]
        public int CustomerID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string ZipCode { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Email { get; set; }

    }
}
