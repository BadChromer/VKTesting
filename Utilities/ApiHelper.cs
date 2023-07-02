using Newtonsoft.Json;
using RestSharp;
using System.Diagnostics;
using VKAPI.Configurations;
using VKAPI.TestingData;

namespace VKAPI.Utilities
{
    public class ApiHelper
    {
        public static T Execute<T>(RestClient client, RestRequest request, Method method, int interval, int timeout)
        {
            request.AddParameter("access_token", CredentialsData.AccessToken);
            request.AddParameter("v", ApiConfigData.ApiVersion);
            return RequestLimiter<T>(client, request, method, interval, timeout);
        }

        private static T RequestLimiter<T>(RestClient client, RestRequest request, Method method, int interval, int timeout)
        {
            Stopwatch stopWatch = new();
            var intervalSum = interval;
            var endTime = DateTime.Now.AddSeconds(timeout);
            while (true)
            {
                stopWatch.Start();
                if (stopWatch.Elapsed == TimeSpan.FromSeconds(intervalSum))
                {
                    var response = client.Execute(request, method);
                    if (response.IsSuccessful)
                        return JsonConvert.DeserializeObject<T>(response.Content);
                    intervalSum += interval;
                }
                else if (DateTime.Now > endTime)
                    break;
            }
            stopWatch.Reset();
            return JsonConvert.DeserializeObject<T>(client.Execute(request, method).Content);
        }

        public static void DownloadFile(Uri fileUrl, string pathToDownload)
        {
            var request = new RestRequest(fileUrl);
            File.WriteAllBytes(pathToDownload, new RestClient().DownloadData(request));
        }
    }
}
