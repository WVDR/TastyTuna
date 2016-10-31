using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TastyTuna.Models
{
    public class QueVisits
    {
        /// <summary>
        /// The main reason for creating the class is to have a coupling being between the branch,que and visits
        /// </summary>
        public int branchId;

        /// <summary>
        /// The main reason for creating the class is to have a coupling being between the branch,que and visits
        /// </summary>
        public int queId;
        
        public int waitingTime;
        
        public string ticketNumber;
        
        public string customerName;
        
        public object appointmentWaitingTime;
        
        public string serviceName;
    }
}
