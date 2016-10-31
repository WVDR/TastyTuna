using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace TastyTuna.Contracts
{
    public class Data
    {
        public partial class BranchesResponse
        {
            [System.Runtime.Serialization.DataMemberAttribute()]
            public Branches[] branches;
        }

        // Type created for JSON at <<root>> --> branches
        [System.Runtime.Serialization.DataContractAttribute(Name = "branches")]
        public partial class Branches
        {
            [System.Runtime.Serialization.DataMemberAttribute()]
            public int id;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string name;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public int customersWaiting;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public int openServicePoints;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public int maxWaitingTime;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public int averageWaitingTime;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public int totalWaitingTime;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public int customersBeingServed;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public Parameters parameters;
        }

        // Type created for JSON at <<root>> --> parameters
        [System.Runtime.Serialization.DataContractAttribute(Name = "parameters")]
        public partial class Parameters
        {

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string description;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string address1;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string address2;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string longitude;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string latitude;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string address3;

            [System.Runtime.Serialization.DataMemberAttribute(Name = "reset.time")]
            public string reset_002E_time;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string postcode;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string city;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string country;
        }

        // Type created for JSON at <<root>>
        [System.Runtime.Serialization.DataContractAttribute()]
        public partial class QueuesResponse
        {
            [System.Runtime.Serialization.DataMemberAttribute()]
            public Queues[] queues;
        }

        // Type created for JSON at <<root>> --> queues
        [System.Runtime.Serialization.DataContractAttribute(Name = "queues")]
        public partial class Queues
        {
            [System.Runtime.Serialization.DataMemberAttribute()]
            public int id;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public int branchId;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string name;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string queueType;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string branchName;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public int customersWaiting;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public int openServicePoints;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public int waitingTime;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public int appointmentWaitingTime;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public double estimatedWaitingTime;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public int customersServed;
        }


        // Type created for JSON at <<root>>
        [System.Runtime.Serialization.DataContractAttribute()]
        public partial class VisitsResponse
        {

            [System.Runtime.Serialization.DataMemberAttribute()]
            public Visits[] visits;
        }

        // Type created for JSON at <<root>> --> visits
        [System.Runtime.Serialization.DataContractAttribute(Name = "visits")]
        public partial class Visits
        {

            [System.Runtime.Serialization.DataMemberAttribute()]
            public int waitingTime;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string ticketNumber;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string customerName;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public object appointmentWaitingTime;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string serviceName;
        }

    }
}
