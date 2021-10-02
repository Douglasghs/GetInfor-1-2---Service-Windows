using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GetInforUser
{
    class GetInforClass
    {
        string urlCaminhoArquivoLog = "@/Users/Ruann/OneDrive/Documentos/GitHub/GetInfor-1-2---Service-Windows/Configurações/ARQUIVO DE LOG.txt";
        string IpAndress;
        string userName;
        string hostName;

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
            return "https://social.msdn.microsoft.com/Forums/en-US/673ebd25-2700-4ece-b0b1-fbd1e6a03020/how-to-get-current-user-name-enivronmentusername-not-working?forum=csharplanguage";
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

       
    }
}
