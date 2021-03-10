using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunSupply
{
    public class DataProvicer
    {
        public DataTranfers.AuctionObject getInfoBid()
        {
            var auction = new DataTranfers.AuctionObject();
            auction.Link = "https://page.auctions.yahoo.co.jp/jp/auction/f492821656";
            auction.Price = "2";
            return auction;
        }
    }
}
