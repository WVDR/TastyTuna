using System;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Collections.Generic;
using TastyTuna.Contracts;
using System.Text.RegularExpressions;

namespace TastyTuna.Helper_Classes
{
    public class Requests
    {
        public string CreateRequest(string queryString)
        {
            string UrlRequest = "http://orchestra.emergea.mu:8080/rest/managementinformation/branches";            
            return (UrlRequest);
        }

        public Data.Response MakeRequest(string requestUrl)
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
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Data.Response));
                object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                Data.Response jsonResponse
                = objResponse as Data.Response;
                return jsonResponse;
            }            
        }

        public void ProcessResponse(Data.Response BranchesResponse)
        {
            throw new NotImplementedException();
        }
    }
}
