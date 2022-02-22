using bpmdemoapi.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace BPMAPI.OtherApi
{
    public class MyClientApi
    {
        public static async Task<int> OptClientApi(string webapiUrl,BPMModels models)
        {
            var httpResponseMsg = new HttpResponseMessage();

            using (var httpClient = new HttpClient())
            {
                httpResponseMsg = await httpClient.PostAsync<BPMModels>(webapiUrl, models, new JsonMediaTypeFormatter());
            }
            var taskid = int.Parse(httpResponseMsg.Content.ReadAsAsync<string>().Result);
            return taskid;
        }
    }
}
