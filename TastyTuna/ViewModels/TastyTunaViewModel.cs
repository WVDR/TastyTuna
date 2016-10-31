using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TastyTuna.Models;

namespace TastyTuna.ViewModels
{
    class TastyTunaViewModel : BaseModel
    {
        public TastyTunaViewModel()
        {
            DataContext = new Context();
        }
        private Context datacontext;

        public Context DataContext
        {
            get
            {
                return datacontext;
            }
            set
            {
                if (value != datacontext)
                {
                    datacontext = value;
                    NotifyPropertyChanged();
                }
            }
        }

    }
}
