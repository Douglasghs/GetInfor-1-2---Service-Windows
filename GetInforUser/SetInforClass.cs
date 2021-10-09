using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GetInforUser
{
    // Parte do código responsável por mandar para o webservice as informações
    // -- Pegar dados do (XML) sobre as URL´s
    class SetInforClass
    {

        GetInforClass GetInforClass = new GetInforClass();

        private static readonly HttpClient Requisicao = new HttpClient();
        string urlCaminhoArquivoLog = @"C:/Program Files (x86)/GetInfor_Service/GetInforUser_SETUP/ARQUIVO DE LOG.txt";

        private string IPV4 = "";
        private string IPV6 = "";
        private string UserName = "";
        private string HostName = "";
        private string MemoryRAM = "";

        private bool VerifyRequisicaoCadastro = false;
        private bool VerifyRequisicaoRemocao = false;

        private string URLCadastro = "";
        private string URLRemocao = "";

        public void SetInforClassRR()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load($@"C:/Program Files (x86)/GetInfor_Service/GetInforUser_SETUP/Config.xml");

                XmlNodeList Cadastro = xmlDoc.GetElementsByTagName("UrlCadastro");
                URLCadastro = Cadastro[0].InnerText.ToString();

                XmlNodeList Remocao = xmlDoc.GetElementsByTagName("UrlRemocao");
                URLRemocao = Remocao[0].InnerText.ToString();

                StreamWriter vWriter = new StreamWriter(urlCaminhoArquivoLog, true);

                vWriter.WriteLine("----------   Serviço Método SetInforClass   ---------- " + DateTime.Now.ToString());
                vWriter.WriteLine("URLCadastro : " + URLCadastro);
                vWriter.WriteLine("URLRemocao : " + URLRemocao);
                vWriter.Flush();
                vWriter.Close();
            }
            catch (Exception e)
            {
                StreamWriter vWriter = new StreamWriter(urlCaminhoArquivoLog, true);

                vWriter.WriteLine("----------   Serviço Método SetInforClass   ----------");
                vWriter.WriteLine(DateTime.Now.ToString());
                vWriter.WriteLine("Source : " + e.Source);
                vWriter.WriteLine("Message : " + e.Message);
                vWriter.WriteLine("Source : " + e);
                vWriter.Flush();
                vWriter.Close();
            }
        }


        public void SetInforClassDuol()
        {
           try
            {
                GetInforClass.GetAllValues(ref IPV4, ref IPV6, ref UserName, ref HostName, ref MemoryRAM);
                this.SetInforClassRR();

                if ((IPV4 != "") && (IPV6 != "") && (UserName != "") && (HostName != "") && (MemoryRAM != ""))
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

                StreamWriter vWriter = new StreamWriter(urlCaminhoArquivoLog, true);

                vWriter.WriteLine("----------   Serviço Método SetInforClassDuol   ---------- " + DateTime.Now.ToString());

                vWriter.WriteLine("IPV4 : " + IPV4);
                vWriter.WriteLine("IPV6 : " + IPV6);
                vWriter.WriteLine("UserName : " + UserName);
                vWriter.WriteLine("HostName : " + HostName);
                vWriter.WriteLine("MemoryRAM : " + MemoryRAM);
                vWriter.Flush();
                vWriter.Close();
            }
            catch (Exception e)
            {
                StreamWriter vWriter = new StreamWriter(urlCaminhoArquivoLog, true);

                vWriter.WriteLine("----------   Serviço Método SetInforClassDuol   ----------");
                vWriter.WriteLine(DateTime.Now.ToString());
                vWriter.WriteLine("Source : " + e.Source);
                vWriter.WriteLine("Message : " + e.Message);
                vWriter.Flush();
                vWriter.Close();
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

                StreamWriter vWriter = new StreamWriter(urlCaminhoArquivoLog, true);

                vWriter.WriteLine("----------   Serviço Método RequisicaoCadastro   ---------- " + DateTime.Now.ToString());
                vWriter.Flush();
                vWriter.Close();

                return true;
            }
            catch (Exception e)
            {
                StreamWriter vWriter = new StreamWriter(urlCaminhoArquivoLog, true);

                vWriter.WriteLine("----------   Serviço Método RequisicaoCadastro   ----------");
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

                StreamWriter vWriter = new StreamWriter(urlCaminhoArquivoLog, true);

                vWriter.WriteLine("----------   Serviço Método RequisicaoRemocao   ---------- " + DateTime.Now.ToString());
                vWriter.Flush();
                vWriter.Close();

                return true;
            }
            catch (Exception e)
            {
                StreamWriter vWriter = new StreamWriter(urlCaminhoArquivoLog, true);

                vWriter.WriteLine("----------   Serviço Método RequisicaoRemocao   ----------");
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
