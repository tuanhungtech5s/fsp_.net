using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using FunSupply.Common;
using RestSharp;
using FunSupply.DataTranfers;
using Newtonsoft.Json;
using System.Net;

namespace FunSupply
{
    public class Worker
    {
        Thread thread;
        RestClient client;
        public delegate void CompleteHandler(List<AuctionObject> auctions);
        public CompleteHandler onComplete;

        public Worker()
        {
            this.client = new RestClient("https://funsupply.jp/");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }
        public void start()
        {
            AppConfig.getLog().Log("Start Worker!");
            thread = new Thread(new ThreadStart(() => {
                while (AppConfig.ACCEPT_WORKER)
                {
                    AppConfig.getLog().Log("In while ...."+string.Format("PROFILE1 {0} PROFILE1 {1}",AppConfig.STATUS_DRIVERS[0],AppConfig.STATUS_DRIVERS[1]));
                    if (!AppConfig.STATUS_DRIVERS[0] || !AppConfig.STATUS_DRIVERS[1])
                    {
                        AppConfig.getLog().Log("Start send request get Bid");
                        try
                        {
                            var request = new RestRequest("auction-yahoo-bid-api", DataFormat.Json);
                            var response = client.Get(request);
                            List<AuctionObject> auctions = JsonConvert.DeserializeObject<List<AuctionObject>>(response.Content);
                            AppConfig.getLog().Log( string.Format("Success, get {0} item auctions!",auctions.Count));
                            if (onComplete != null)
                            {
                                onComplete(auctions);
                            }
                        }
                        catch (Exception ex)
                        {
                            AppConfig.getLog().Log("Error, "+ex.Message);
                        }
                        
                    }
                    AppConfig.getLog().Log("Sleep 3 second before recall api!");
                    Thread.Sleep(3 * 1000);
                }
            }));
            thread.Start();
        }
    }
}
