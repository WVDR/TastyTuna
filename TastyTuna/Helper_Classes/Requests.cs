using System;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Collections.Generic;
using TastyTuna.Contracts;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using System.IO;
using TastyTuna.Models;

namespace TastyTuna.Helper_Classes
{
    public class Requests
    {
        // /Branches
        public string CreateBranchesRequest(string queryString = "")
        {
            if (queryString == string.Empty)
            {
                string UrlRequest = Properties.Settings.Default.BranchesUrl;
                return (UrlRequest);
            }
            else
            {
                string UrlRequest = Properties.Settings.Default.BranchesUrl + "/" + queryString;
                return (UrlRequest);
            }
        }

        public Data.BranchesResponse MakeBranchesRequest(string requestUrl)
        {            
            HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
            request.Credentials = new NetworkCredential(Properties.Settings.Default.UriUserName, Properties.Settings.Default.UriPassword);
            
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(String.Format(
                    "Server error (HTTP {0}: {1}).",
                    response.StatusCode,
                    response.StatusDescription));

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string objText = reader.ReadToEnd();
                    objText = "{\"branches\":" + objText + "}";
                    object objResponse = (Data.BranchesResponse)js.Deserialize(objText, typeof(Data.BranchesResponse));
                    Data.BranchesResponse jsonResponse
                    = objResponse as Data.BranchesResponse;
                    return jsonResponse;
                }                    
            }            
        }

        public List<Data.Branches> ProcessBranchesResponse(Data.BranchesResponse branchesResponse)
        {
            List<Data.Branches> branches = new List<Data.Branches>();
            foreach (Data.Branches branch in branchesResponse.branches)
            {
                branches.Add(branch);
            }
            return branches;
        }

        // /Branches/id/queues
        public string CreateQueuesRequest(string queryString)
        {
            string UrlRequest = Properties.Settings.Default.BranchesUrl + "/" +  queryString + "/queues";
            return (UrlRequest);
        }

        public Data.QueuesResponse MakeQueuesRequest(string requestUrl)
        {
            HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
            request.Credentials = new NetworkCredential(Properties.Settings.Default.UriUserName, Properties.Settings.Default.UriPassword);

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(String.Format(
                    "Server error (HTTP {0}: {1}).",
                    response.StatusCode,
                    response.StatusDescription));

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string objText = reader.ReadToEnd();
                    objText = "{\"queues\":" + objText + "}";
                    object objResponse = (Data.QueuesResponse)js.Deserialize(objText, typeof(Data.QueuesResponse));
                    Data.QueuesResponse jsonResponse
                    = objResponse as Data.QueuesResponse;
                    return jsonResponse;
                }
            }
        }

        public List<Models.Queue> ProcessQueuesResponse(Data.QueuesResponse queuesResponse)
        {
            List<Models.Queue> queues = new List<Models.Queue>();
            foreach (Data.Queues queue in queuesResponse.queues)
            {
                queues.Add( new Models.Queue
                {
                    id = queue.id,
                    branchId = queue.branchId,
                    name = queue.name,
                    queueType = queue.queueType,
                    branchName = queue.branchName,
                    customersWaiting = queue.customersWaiting,
                    openServicePoints = queue.openServicePoints,
                    waitingTime = queue.waitingTime,
                    appointmentWaitingTime = queue.appointmentWaitingTime,
                    estimatedWaitingTime = queue.estimatedWaitingTime,
                    customersServed = queue.customersServed
                });
            }
            return queues;
        }

        // /Branches/branchId/queues/queId/visits
        public string CreateVisitsRequest(string branchQueryString, string queQueryString)
        {
            string UrlRequest = Properties.Settings.Default.BranchesUrl + "/" + branchQueryString + "/queues/" + queQueryString + "/visits";
            return (UrlRequest);
        }

        public Data.VisitsResponse MakeVisitsRequest(string requestUrl)
        {
            HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
            request.Credentials = new NetworkCredential(Properties.Settings.Default.UriUserName, Properties.Settings.Default.UriPassword);

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(String.Format(
                    "Server error (HTTP {0}: {1}).",
                    response.StatusCode,
                    response.StatusDescription));

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string objText = reader.ReadToEnd();
                    objText = "{\"visits\":" + objText + "}";
                    object objResponse = (Data.VisitsResponse)js.Deserialize(objText, typeof(Data.VisitsResponse));
                    Data.VisitsResponse jsonResponse
                    = objResponse as Data.VisitsResponse;
                    return jsonResponse;
                }
            }
        }

        public List<QueVisit> ProcessVisitsResponse(Models.Queue queuesResponse, Data.VisitsResponse visitsResponse)
        {
            List<QueVisit> visits = new List<QueVisit>();
            foreach (Data.Visits visit in visitsResponse.visits)
            {
                visits.Add(new QueVisit
                {
                    branchId = queuesResponse.branchId,
                    queId = queuesResponse.branchId,
                    waitingTime = visit.waitingTime,
                    ticketNumber = visit.ticketNumber,
                    customerName = visit.customerName,
                    appointmentWaitingTime = visit.appointmentWaitingTime,
                    serviceName =visit.serviceName
                });
            }
            return visits;
        }


    }
}
