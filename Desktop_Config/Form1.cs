using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Desktop_Config
{
    public partial class Form1 : Form
    {
        string n1, n2;
        string urlCaminhoArquivoLog = @"C:/Program Files (x86)/GetInfor_Service/GetInforUser_SETUP/ARQUIVO DE LOG.txt";


        public Form1()
        {
            try
            {
                InitializeComponent();

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load($@"C:/Program Files (x86)/GetInfor_Service/GetInforUser_SETUP/Config.xml");

                XmlNodeList Cadastro = xmlDoc.GetElementsByTagName("UrlCadastro");
                textBoxURLCadastro.Text = Cadastro.Item(0).InnerText;
                n1 = Cadastro.Item(0).InnerText;

                XmlNodeList Remocao = xmlDoc.GetElementsByTagName("UrlRemocao");
                textBoxURLRemocao.Text = Remocao.Item(0).InnerText;
                n2 = Remocao.Item(0).InnerText;
            }
            catch (Exception e)
            {
                StreamWriter vWriter = new StreamWriter(urlCaminhoArquivoLog, true);

                vWriter.WriteLine("----------   Serviço Método Form1   ----------");
                vWriter.WriteLine(DateTime.Now.ToString());
                vWriter.WriteLine("Source : " + e.Source);
                vWriter.WriteLine("Message : " + e.Message);
                vWriter.WriteLine("Source : " + e);
                vWriter.Flush();
                vWriter.Close();
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load($@"C:/Program Files (x86)/GetInfor_Service/GetInforUser_SETUP/Config.xml");

                if ((textBoxURLCadastro.Text != "") && (textBoxURLRemocao.Text != ""))
                {
                    XmlNodeList Cadastro = xmlDoc.GetElementsByTagName("UrlCadastro");
                    Cadastro.Item(0).InnerText = textBoxURLCadastro.Text;

                    XmlNodeList Remocao = xmlDoc.GetElementsByTagName("UrlRemocao");
                    Remocao.Item(0).InnerText = textBoxURLRemocao.Text;
                }
                else
                {
                    XmlNodeList Cadastro = xmlDoc.GetElementsByTagName("UrlCadastro");
                    Cadastro.Item(0).InnerText = n1;

                    XmlNodeList Remocao = xmlDoc.GetElementsByTagName("UrlRemocao");
                    Remocao.Item(0).InnerText = n2;
                }

                xmlDoc.Save($@"C:/Program Files (x86)/GetInfor_Service/GetInforUser_SETUP/Config.xml");

                Close();
            }
            catch(Exception a)
            {
                StreamWriter vWriter = new StreamWriter(urlCaminhoArquivoLog, true);

                vWriter.WriteLine("----------   Serviço Método buttonSalvar_Click   ----------");
                vWriter.WriteLine(DateTime.Now.ToString());
                vWriter.WriteLine("Source : " + a.Source);
                vWriter.WriteLine("Message : " + a.Message);
                vWriter.WriteLine("Source : " + a);
                vWriter.Flush();
                vWriter.Close();
            }
        }
    }
}
