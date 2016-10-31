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
        public Page1()
        {
            InitializeComponent();

            try
            {
                Requests requests = new Requests();
                string locationsRequest = requests.CreateBranchesRequest("");
                Data.BranchesResponse bracnhesResponse = requests.MakeBranchesRequest(locationsRequest);
                requests.ProcessBranchesResponse(bracnhesResponse);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
