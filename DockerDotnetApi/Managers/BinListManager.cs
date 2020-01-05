using DockerDotnetApi.Models.BinList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace DockerDotnetApi.Managers
{
    public class BinListManager : IManageBinList
    {
        public IssuerInformation PaymentCardCost(string bin)
        {
            if (bin == null)
                throw new ArgumentNullException();

            if (!bin.Trim().All(c => char.IsNumber(c)))
                throw new ArgumentException("Make sure you enter a valid BIN/IIN number.");

            using (WebClient web = new WebClient())
            {
                try
                {
                    string json = web.DownloadString("https://lookup.binlist.net/" + bin);

                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(IssuerInformation));

                    var issuerInfo =
                        (IssuerInformation)serializer.ReadObject(new MemoryStream(Encoding.Default.GetBytes(json)));

                    return issuerInfo;
                }
                catch (WebException ex)
                {
                    string addInfo = string.Format("No results for {0}. Make sure you enter a valid BIN/IIN number. --- ", bin);
                    throw new WebException(addInfo + ex.Message, ex, ex.Status, ex.Response);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
