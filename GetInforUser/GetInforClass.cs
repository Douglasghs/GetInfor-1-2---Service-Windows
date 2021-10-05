using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GetInforUser
{
    class GetInforClass
    {
        string urlCaminhoArquivoLog = "@/Users/Ruann/OneDrive/Documentos/GitHub/GetInfor-1-2---Service-Windows/Configurações/ARQUIVO DE LOG.txt";

        private string GetIpAndressIPV4()
        {
            try
            {
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

                var ippaddress = host
                    .AddressList
                    .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
                return ippaddress.ToString();
            }
            catch (SocketException e)
            {
                StreamWriter vWriter = new StreamWriter(urlCaminhoArquivoLog, true);

                vWriter.WriteLine("----------   Serviço Método GetIpAndressIPV4   ----------");
                vWriter.WriteLine(DateTime.Now.ToString());
                vWriter.WriteLine("Source : " + e.Source);
                vWriter.WriteLine("Message : " + e.Message);
                vWriter.Flush();
                vWriter.Close();
                return "";
            }
            catch (Exception e)
            {
                StreamWriter vWriter = new StreamWriter(urlCaminhoArquivoLog, true);

                vWriter.WriteLine("----------   Serviço Método GetIpAndressIPV4   ----------");
                vWriter.WriteLine(DateTime.Now.ToString());
                vWriter.WriteLine("Source : " + e.Source);
                vWriter.WriteLine("Message : " + e.Message);
                vWriter.Flush();
                vWriter.Close();
                return "";
            }
        }

        private string GetIpAndressIPV6()
        {
            try
            {
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

                var ippaddress = host
                    .AddressList
                    .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetworkV6);
                return ippaddress.ToString();
            }
            catch (SocketException e)
            {
                StreamWriter vWriter = new StreamWriter(urlCaminhoArquivoLog, true);

                vWriter.WriteLine("----------   Serviço Método GetIpAndressIPV6   ----------");
                vWriter.WriteLine(DateTime.Now.ToString());
                vWriter.WriteLine("Source : " + e.Source);
                vWriter.WriteLine("Message : " + e.Message);
                vWriter.Flush();
                vWriter.Close();
                return "";
            }
            catch (Exception e)
            {
                StreamWriter vWriter = new StreamWriter(urlCaminhoArquivoLog, true);

                vWriter.WriteLine("----------   Serviço Método GetIpAndressIPV6   ----------");
                vWriter.WriteLine(DateTime.Now.ToString());
                vWriter.WriteLine("Source : " + e.Source);
                vWriter.WriteLine("Message : " + e.Message);
                vWriter.Flush();
                vWriter.Close();
                return "";
            }
        }

        private string GetUserName()
        {
            string Userwindows = "";
            
            try
            {
                string DomainName = System.Environment.UserDomainName;
                string AccountName = System.Environment.UserName.ToLower();
                SelectQuery query = new SelectQuery("select FullName from Win32_UserAccount where domain='" + DomainName + "' and name='" + AccountName + "'");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                foreach (ManagementBaseObject disk in searcher.Get())
                {
                    Userwindows = disk["FullName"].ToString();
                }
                return Userwindows;
            }
            catch (Exception e)
            {
                StreamWriter vWriter = new StreamWriter(urlCaminhoArquivoLog, true);

                vWriter.WriteLine("----------   Serviço Método GetUserName   ----------");
                vWriter.WriteLine(DateTime.Now.ToString());
                vWriter.WriteLine("Source : " + e.Source);
                vWriter.WriteLine("Message : " + e.Message);
                vWriter.Flush();
                vWriter.Close();

                return Userwindows;
            }
        }

        private string GetHostName()
        {
            try
            {
                return Dns.GetHostName();
            }
            catch (Exception e)
            {
                StreamWriter vWriter = new StreamWriter(urlCaminhoArquivoLog, true);

                vWriter.WriteLine("----------   Serviço Método GetHostName   ----------");
                vWriter.WriteLine(DateTime.Now.ToString());
                vWriter.WriteLine("Source : " + e.Source);
                vWriter.WriteLine("Message : " + e.Message);
                vWriter.Flush();
                vWriter.Close();

                return "";
            }
            
        }

        private string GetMemoryRAM()
        {
            try
            {
                string Query = "SELECT Capacity FROM Win32_PhysicalMemory";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(Query);

                UInt64 Capacity = 0;
                foreach (ManagementObject WniPART in searcher.Get())
                {
                    Capacity += Convert.ToUInt64(WniPART.Properties["Capacity"].Value);
                }

                return Capacity.ToString();
            }
            catch(Exception e)
            {
                StreamWriter vWriter = new StreamWriter(urlCaminhoArquivoLog, true);

                vWriter.WriteLine("----------   Serviço Método GetMemoryRAM   ----------");
                vWriter.WriteLine(DateTime.Now.ToString());
                vWriter.WriteLine("Source : " + e.Source);
                vWriter.WriteLine("Message : " + e.Message);
                vWriter.Flush();
                vWriter.Close();

                return "";
            } 
        }


        public string[] GetAllValues()
        {
            string[] valores = new string[5];

            try
            {
                valores[0] = this.GetIpAndressIPV4();
                valores[0] = this.GetIpAndressIPV6();
                valores[0] = this.GetUserName();
                valores[0] = this.GetHostName();
                valores[0] = this.GetMemoryRAM();

                return valores;
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

                return valores;
            }
        }
       
    }
}
