using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GetInforUser
{
    class SetInforClass
    {

        GetInforClass GetInforClass = new GetInforClass();
        private static readonly HttpClient Requisicao = new HttpClient();
        string URLCadastro = "http://localhost:8081/Cadastro";
        string urlCaminhoArquivoLog = "@/Users/Ruann/OneDrive/Documentos/GitHub/GetInfor-1-2---Service-Windows/Configurações/ARQUIVO DE LOG.txt";

        private string IPV4 = "";
        private string IPV6 = "";
        private string UserName = "";
        private string HostName = "";
        private string MemoryRAM = "";


        public SetInforClass()
        {
            GetInforClass.GetAllValues(ref IPV4, ref IPV6, ref UserName, ref HostName, ref MemoryRAM);

            if ((IPV4 != "") && (IPV6 != "") && (UserName != "") && (HostName != "") && (MemoryRAM != ""))
            {
                this.RequisicaoCadastro();
            }
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

         public bool RequisicaoCadastro()
        {
            try
            {
                var values = new Dictionary<string, string>
                  {
                  { "IPV4", IPV4},
                  { "IPV6", IPV6},
                  { "UserName", UserName},
                  { "HostName",  HostName},
                  { "MemoryRAM", MemoryRAM}
                };

                var content = new StringContent(JsonConvert.SerializeObject(values), Encoding.UTF8, "application/json");

                Requisicao.PutAsync(URLCadastro+"/"+values, content);
                
                return true;
            }
            catch (Exception e)
            {
                StreamWriter vWriter = new StreamWriter(urlCaminhoArquivoLog, true);

                vWriter.WriteLine("----------   Serviço Método GetAllValue   ----------");
                vWriter.WriteLine(DateTime.Now.ToString());
                vWriter.WriteLine("Source : " + e.Source);
                vWriter.WriteLine("Message : " + e.Message);
                vWriter.Flush();
                vWriter.Close();

                return false;
            }
        }
    }
}
