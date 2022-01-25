using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace bitcoincalculator_tulusa
{
    class Program
    {
        static void Main(string[] args)
        {
            BitCoinRate bitcoin = GetRates();

            Console.WriteLine($"Current rate in {bitcoin.bpi.USD.code}: {bitcoin.bpi.USD.rate_float}");


        }


        public static BitCoinRate GetRates()
        {
            string url = "https://api.coindesk.com/v1/bpi/currentprice.json";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "Get";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            BitCoinRate bitcoin;

            using (var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();
                bitcoin = JsonConvert.DeserializeObject<BitCoinRate>(response);
            }

            return bitcoin;
        }
    }
}
