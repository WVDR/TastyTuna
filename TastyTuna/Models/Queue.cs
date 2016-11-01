using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TastyTuna.Models
{
    public class Queue
    {
        public int id { get; set; }
        public int branchId { get; set; }
        public string name { get; set; }
        public string queueType { get; set; }
        public string branchName { get; set; }
        public int customersWaiting { get; set; }
        public int openServicePoints { get; set; }
        public int waitingTime { get; set; }
        public int appointmentWaitingTime { get; set; }
        public double estimatedWaitingTime { get; set; }
        public int customersServed { get; set; }
    }
}
