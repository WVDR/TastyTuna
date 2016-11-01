using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TastyTuna.Contracts;
using TastyTuna.Models;

namespace TastyTuna.Models
{
    class Context : BaseModel
    {
        private List<Data.Branches> branches;

        public List<Data.Branches> Branches
        {
            get
            {
                return branches;
            }

            set
            {
                if (value != branches)
                {
                    branches = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private List<Models.Queue> queues;

        public List<Models.Queue> Queues
        {
            get
            {
                return queues;
            }

            set
            {
                if (value != queues)
                {
                    queues = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private List<QueVisit> visits;

        public List<QueVisit> Visits
        {
            get
            {
                return visits;
            }

            set
            {
                if (value != visits)
                {
                    visits = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
