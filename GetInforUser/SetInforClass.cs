using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GetInforUser
{
    class SetInforClass
    {

        GetInforClass GetInforClass = new GetInforClass();

        private string URL = "";
        private string IPV4 = "";
        private string IPV6 = "";
        private string UserName = "";
        private string HostName = "";
        private string MemoryRAM = "";


        public SetInforClass()
        {
            GetInforClass.GetAllValues(ref IPV4, ref IPV6, ref UserName, ref HostName, ref MemoryRAM);
        }

        /*public static async Task GetDadosWebServiceAsync()
        {
            HttpResponseMessage response = await HttpClient.GetAsync(paisesUrl);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Status Code do Response : {(int)response.StatusCode} {response.ReasonPhrase}");
                string responseBodyAsText = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Recebidos payload de {responseBodyAsText.Length} caracteres");
                Console.WriteLine();
                Console.WriteLine(responseBodyAsText);
            }
        }*/

        public  async Task SetInforWebService()
        {
            HttpResponseMessage response = await HttpClient.GetAsync(URL);
        }
    }
}
