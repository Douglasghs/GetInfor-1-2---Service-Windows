using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GetInforUser
{
    public partial class Service1 : ServiceBase
    {
        string urlCaminhoArquivoLog = "@/Users/Ruann/OneDrive/Documentos/GitHub/GetInfor-1-2---Service-Windows/Configurações/ARQUIVO DE LOG.txt";
        Timer timer1;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                timer1 = new Timer(new TimerCallback(timer1_Tick), null, 15000, 60000);
            }
            catch (Exception e)
            {
                StreamWriter vWriter = new StreamWriter(urlCaminhoArquivoLog, true);

                vWriter.WriteLine("----------   Serviço Método OnStart   ----------");
                vWriter.WriteLine(DateTime.Now.ToString());
                vWriter.WriteLine("Source : " + e.Source);
                vWriter.WriteLine("Message : " + e.Message);
                vWriter.Flush();
                vWriter.Close();
            }
        }

        protected override void OnStop()
        {
            try
            {
                StreamWriter vWriter = new StreamWriter(urlCaminhoArquivoLog, true);

                vWriter.WriteLine("----------   Serviço Parado   ----------");
                vWriter.WriteLine(DateTime.Now.ToString());
                vWriter.Flush();
                vWriter.Close();
            }
            catch (Exception e)
            {
                StreamWriter vWriter = new StreamWriter(urlCaminhoArquivoLog, true);

                vWriter.WriteLine("----------   Serviço Método OnStop   ----------");
                vWriter.WriteLine(DateTime.Now.ToString());
                vWriter.WriteLine("Source : " + e.Source);
                vWriter.WriteLine("Message : " + e.Message);
                vWriter.Flush();
                vWriter.Close();
            }
        }

        private void timer1_Tick(object sender)
        {
            SetInforClass SetInforClass = new SetInforClass();
        }
    }
}
