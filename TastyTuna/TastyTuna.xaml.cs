using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Runtime.Serialization.Json;
using TastyTuna.Helper_Classes;
using TastyTuna.Contracts;

namespace TastyTuna
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        ViewModels.TastyTunaViewModel _viewModel = new ViewModels.TastyTunaViewModel();
        public Page1()
        {
            InitializeComponent();

            try
            {
                //Process requests: 
                Requests request = new Requests();

                //Branches
                string branchesRequest = request.CreateBranchesRequest();
                Data.BranchesResponse bracnhesResponse = request.MakeBranchesRequest(branchesRequest);
                _viewModel.DataContext.Branches = request.ProcessBranchesResponse(bracnhesResponse);

                //Queues
                foreach (Data.Branches branch in _viewModel.DataContext.Branches)
                {
                    string queuesRequest = request.CreateQueuesRequest(branch.id.ToString());
                    Data.QueuesResponse queuesResponse = request.MakeQueuesRequest(queuesRequest);
                    if (_viewModel.DataContext.Queues == null)
                    {
                        _viewModel.DataContext.Queues = request.ProcessQueuesResponse(queuesResponse);
                    }
                    else
                    {
                        _viewModel.DataContext.Queues.AddRange(request.ProcessQueuesResponse(queuesResponse));
                    }
                    
                }


                //Visits (must also be able to refresh)
                foreach (Models.Queue que in _viewModel.DataContext.Queues)
                {
                    string visitRequest = request.CreateVisitsRequest(que.branchId.ToString(), que.id.ToString());
                    Data.VisitsResponse visitsResponse = request.MakeVisitsRequest(visitRequest);

                    if (_viewModel.DataContext.Visits == null)
                    {
                        _viewModel.DataContext.Visits = request.ProcessVisitsResponse(que, visitsResponse);
                    }
                    else
                    {
                        _viewModel.DataContext.Visits.AddRange(request.ProcessVisitsResponse(que, visitsResponse));
                    }
                }

                DataContext = _viewModel;                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void CheckVisits(Models.Queue que)
        {
            Requests request = new Requests();
            string visitRequest = request.CreateVisitsRequest(que.branchId.ToString(), que.id.ToString());
            Data.VisitsResponse visitsResponse = request.MakeVisitsRequest(visitRequest);

            _viewModel.DataContext.Visits = request.ProcessVisitsResponse(que, visitsResponse);            
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckVisits((Models.Queue)e.AddedItems[0]);
        }
    }
}
