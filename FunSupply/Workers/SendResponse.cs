using FunSupply.Common;
using FunSupply.DataTranfers;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FunSupply.Workers
{
    class SendResponse
    {
        Thread thread;
        RestClient client;

        public SendResponse()
        {
            this.client = new RestClient("https://funsupply.jp/");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }
        public void start(AuctionResult result )
        {
            AppConfig.getLog().Log("Start SendResponse "+result.Id+" !");
            thread = new Thread(new ThreadStart(() => {
                var body = JsonConvert.SerializeObject(result);
                var request = new RestRequest("auction-yahoo-bid-api");
                request.Method = Method.POST;
                request.AddHeader("Accept", "application/json");
                request.Parameters.Clear();
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                var response = client.Execute(request);
                var content = response.Content;
                AppConfig.getLog().Log("Result of SendResponse: " + content);
            }));
            thread.Start();
        }
    }
}
