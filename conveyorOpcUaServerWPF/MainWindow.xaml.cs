using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Opc.Ua;
using Opc.Ua.Configuration;
using Opc.Ua.Server;

using ConveyorOpcUAServer;


namespace conveyorOpcUaServerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApplicationInstance m_application =  new ApplicationInstance();
        private StandardServer m_server;
        private ApplicationConfiguration m_configuration;
        public MainWindow()
        {
            InitializeComponent();
            m_application.ApplicationType = ApplicationType.Server;
            m_application.ConfigSectionName = "TriplHServer";

        }
        private void startServer()
        {
            try
            {
                // process and command line arguments.
                if (m_application.ProcessCommandLine())
                {
                    return;
                }

                // check if running as a service.
                if (!Environment.UserInteractive)
                {
                    m_application.StartAsService(new TripleHServer());
                    return;
                }

                // load the application configuration.
                m_application.LoadApplicationConfiguration("F:/vault of code/vault of c#/ConveyorOpcUAServerWPF/ConveyorOpcUAServerWPF/Server.Config.xml", false).Wait();

                // check the application certificate.
                m_application.CheckApplicationInstanceCertificate(false, 0).Wait();

                // start the server.
                m_application.Start(new TripleHServer()).Wait();

                // run the application interactively.
                m_server = m_application.Server as StandardServer;
                m_configuration = m_application.ApplicationConfiguration;
            }
            catch (Exception e)
            {
                string text = "Exception: " + e.Message;
                if (e.InnerException != null)
                {
                    text += "\r\nInner exception: ";
                    text += e.InnerException.Message;
                }
                MessageBox.Show(text, m_application.ApplicationName);
            }
        }
        private void startBTN_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                startServer();
                urlTextBox.Text = m_server.GetEndpoints()[0].EndpointUrl;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void stopBTN_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                m_application.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetDataObject(urlTextBox.Text);
        }
    }
}
