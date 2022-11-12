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
        #region Contructor
        public MainWindow()
        {
            InitializeComponent();


        }
        #endregion

        #region Method

        #endregion

        #region Event handler

        private async void startBTN_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                bool result = await server.Start();
                if (result)
                {
                    isConnected = true;
                }
                else
                {
                    isConnected = false;
                    MessageBox.Show("Cannot start OPCUA-Server by some reasons.");
                }
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
                server.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetDataObject(server.Server.GetEndpoints()[0].EndpointUrl);
        }

        #endregion

        #region Public feild

        public OPCUAServer server = new OPCUAServer("F:/vault of code/vault of c#/ConveyorOpcUAServerWPF/ConveyorOpcUAServerWPF/Server.Config.xml");
        public bool isConnected = false;

        #endregion

        #region Private field

        #endregion

        private void copyBTN_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetDataObject(tcpText.Text);
        }
    }
}
