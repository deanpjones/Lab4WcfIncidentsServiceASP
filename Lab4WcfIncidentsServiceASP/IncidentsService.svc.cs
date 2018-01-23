
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
    //SERVICE REFERENCE TO DB FILES
    //Dean Jones
    //Jan.18, 2017
    //*************************************

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "IncidentsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select IncidentsService.svc or IncidentsService.svc.cs at the Solution Explorer and start debugging.
    public class IncidentsService : IIncidentsService
    {
        //METHOD (reference CustomerDB.cs)
        public List<Customer> GetAllCustomers()
        {
            return CustomerDB.GetAllCustomers();
        }

        //METHOD (reference IncidentDB.cs)
        public List<Incident> GetAllIncidents()
        {
            return IncidentDB.GetAllIncidents();
        }

        //METHOD (reference IncidentDB.cs)
        public List<Incident> GetCustomerIncidents(int customerID)
        {
            return IncidentDB.GetCustomerIncidents(customerID);
        }

        //METHOD (reference IncidentDB.cs)
        public List<Incident> GetOpenTechIncidents(int techID)
        {
            return IncidentDB.GetOpenTechIncidents(techID);
        }

    }
}
