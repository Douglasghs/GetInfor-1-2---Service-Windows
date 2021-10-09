using System;
using System.IO;
using System.Xml;

namespace TesteMetodos2
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load($@"C:/Program Files (x86)/GetInfor_Service/GetInforUser_SETUP/Config.xml");

            XmlNodeList Cadastro = xmlDoc.GetElementsByTagName("UrlCadastro");
            Console.WriteLine(Cadastro[0].InnerText.ToString());

            XmlNodeList Remocao = xmlDoc.GetElementsByTagName("UrlRemocao");
            Console.WriteLine(Remocao[0].InnerText.ToString());
        }
    }
}
