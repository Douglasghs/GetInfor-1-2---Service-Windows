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
    // Parte do código responsável por pegar as informações necessárias da máquina
    public class GetInforClass
    {
        string urlCaminhoArquivoLog = @"C:/Users/Ruann/OneDrive/Documentos/GitHub/GetInfor-1-2---Service-Windows/Configurações/ARQUIVO DE LOG.txt";

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

                return "";
            }
            catch (Exception e)
            {
                StreamWriter vWriter = new StreamWriter(urlCaminhoArquivoLog, true);

                vWriter.WriteLine("----------   Serviço Método GetIpAndressIPV4   ---------- " + DateTime.Now.ToString());
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

                vWriter.WriteLine("----------   Serviço Método GetIpAndressIPV6   ---------- " + DateTime.Now.ToString());
                vWriter.WriteLine("Source : " + e.Source);
                vWriter.WriteLine("Message : " + e.Message);
                vWriter.Flush();
                vWriter.Close();
                return "";
            }
            catch (Exception e)
            {
                StreamWriter vWriter = new StreamWriter(urlCaminhoArquivoLog, true);

                vWriter.WriteLine("----------   Serviço Método GetIpAndressIPV6   ---------- " + DateTime.Now.ToString());
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

                vWriter.WriteLine("----------   Serviço Método GetUserName   ---------- " + DateTime.Now.ToString());
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

                vWriter.WriteLine("----------   Serviço Método GetHostName   ---------- " + DateTime.Now.ToString());
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

                vWriter.WriteLine("----------   Serviço Método GetMemoryRAM   ---------- " + DateTime.Now.ToString());
                vWriter.WriteLine("Source : " + e.Source);
                vWriter.WriteLine("Message : " + e.Message);
                vWriter.Flush();
                vWriter.Close();

                return "";
            } 
        }


        public void GetAllValues(ref string IPV4, ref string IPV6, ref string UserName, ref string HostName, ref string MemoryRAM)
        {
            try
            {
                IPV4 = this.GetIpAndressIPV4();
                IPV6 = this.GetIpAndressIPV6();
                UserName = this.GetUserName();
                HostName = this.GetHostName();
                MemoryRAM = this.GetMemoryRAM();
            }
            catch (Exception e)
            {
                StreamWriter vWriter = new StreamWriter(urlCaminhoArquivoLog, true);

                vWriter.WriteLine("----------   Serviço Método GetAllValue   ---------- " + DateTime.Now.ToString());
                vWriter.WriteLine("Source : " + e.Source);
                vWriter.WriteLine("Message : " + e.Message);
                vWriter.Flush();
                vWriter.Close();
            }
        }
       
    }
}
