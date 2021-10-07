using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GetInforUser;

namespace GetInforUser
{
    // Parte do código responsável por mandar para o webservice as informações
    // -- Pegar dados do (XML) sobre as URL´s
    class SetInforClass
    {

        GetInforClass GetInforClass = new GetInforClass();
       
        private static readonly HttpClient Requisicao = new HttpClient();
        string urlCaminhoArquivoLog = @"C:/Users/Ruann/OneDrive/Documentos/GitHub/GetInfor-1-2---Service-Windows/Configurações/ARQUIVO DE LOG.txt";

        private string IPV4 = "";
        private string IPV6 = "";
        private string UserName = "";
        private string HostName = "";
        private string MemoryRAM = "";

        private bool VerifyRequisicaoCadastro = false;
        private bool VerifyRequisicaoRemocao = false;

        private string URLCadastro = "";
        private string URLRemocao = "";


        public void SetInforClassDuol()
        {
            GetInforClass.GetAllValues(ref IPV4, ref IPV6, ref UserName, ref HostName, ref MemoryRAM);

            if ((IPV4.Equals("")) && (IPV6.Equals("")) && (UserName.Equals("")) && (HostName.Equals("")) && (MemoryRAM.Equals("")))
            {
                if (VerifyRequisicaoCadastro.Equals(false))
                {
                    this.RequisicaoCadastro();
                }
                else if (VerifyRequisicaoRemocao.Equals(true))
                {
                    this.RequisicaoRemocao();
                }
            }
        }

         public bool RequisicaoCadastro()
         {
            VerifyRequisicaoCadastro = true;
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

                Requisicao.PutAsync(URLCadastro, content);

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


        public bool RequisicaoRemocao()
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

                Requisicao.PutAsync(URLRemocao, content);

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

        public void TrocaValorRequisicapRemocao()
        {
            VerifyRequisicaoRemocao = true;
            this.SetInforClassDuol();
        }
    }
}
