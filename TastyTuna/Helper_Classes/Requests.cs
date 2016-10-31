using System;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Collections.Generic;
using TastyTuna.Contracts;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using System.IO;

namespace TastyTuna.Helper_Classes
{
    public class Requests
    {
        public string CreateBranchesRequest(string queryString)
        {
            string UrlRequest = "http://orchestra.emergea.mu:8080/rest/managementinformation/branches";            
            return (UrlRequest);
        }

        public Data.BranchesResponse MakeBranchesRequest(string requestUrl)
        {            
            HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
            request.Credentials = new NetworkCredential("superadmin", "ulan");
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

        public void ProcessBranchesResponse(Data.BranchesResponse BranchesResponse)
        {
            throw new NotImplementedException();
        }
    }
}
