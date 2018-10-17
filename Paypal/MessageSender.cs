using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Paypal
{
    public class MessageSender : IMessenger
    {
        public void SendMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void GetRequest(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            using (Stream stream = resp.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    JSonResponse response = JsonConvert.DeserializeObject<JSonResponse>(reader.ReadToEnd());
                    int code = response.code;
                    Console.WriteLine(code);
                }
            }
        }
    }
}
