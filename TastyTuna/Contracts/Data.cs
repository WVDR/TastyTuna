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
        [DataContract]
        public class Response
        {
            [DataMember(Name = "id")]
            public string Id { get; set; }
            [DataMember(Name = "name")]
            public string Name { get; set; }
            [DataMember(Name = "customersWaiting")]
            public int CustomersWaiting { get; set; }
            [DataMember(Name = "openServicePoints")]
            public string OpenServicePoints { get; set; }
            [DataMember(Name = "maxWaitingTime")]
            public string MaxWaitingTime { get; set; }
            [DataMember(Name = "averageWaitingTime")]
            public string[] AverageWaitingTime { get; set; }
            [DataMember(Name = "totalWaitingTime")]
            public string TotalWaitingTime { get; set; }
            [DataMember(Name = "customersBeingServed")]
            public string CustomersBeingServed { get; set; }
            [DataMember(Name = "totalWaitingTime")]            
            public Parameters[] Parameters { get; set; }
        }


        [DataContract]
        public class Parameters
        {
            [DataMember(Name = "description")]
            public string Description { get; set; }
            [DataMember(Name = "address1")]
            public string Address1 { get; set; }
            [DataMember(Name = "address2")]
            public string Address2 { get; set; }
            [DataMember(Name = "longitude")]
            public long Longitude { get; set; }
            [DataMember(Name = "latitude")]
            public long Latitude { get; set; }
            [DataMember(Name = "address3")]
            public long Address3 { get; set; }
            [DataMember(Name = "reset.time")]
            public long ResetTime { get; set; }
            [DataMember(Name = "postcode")]
            public long postcode { get; set; }
            [DataMember(Name = "city")]
            public long City { get; set; }
            [DataMember(Name = "country")]
            public long Country { get; set; }
        }

    }
}
