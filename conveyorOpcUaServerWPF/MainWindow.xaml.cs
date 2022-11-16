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
using System.IO.Ports;
using modbusMotor;
using ConveyorOpcUAServer;
using TripleH;


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
        private void monitor(ushort[] data)
        {
            //m_conveyor.Conveyor.Motor1.Torque.Value = 122;
            
        }

        #endregion

        #region Event handler

        private async void startServerBTN_Click(object sender, RoutedEventArgs e)
        {
            if (!isConnected)
            {
                try
                {
                    bool result = await Task.Run(() => server.Start());
                    if (result)
                    {
                        isConnected = true;
                        startServerBTN.Content = "Stop Server";
                        tcpText.Text = server.Server.GetEndpoints()[0].EndpointUrl;
                    }
                    else
                    {
                        isConnected = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else
            {
                try
                {
                    await Task.Run(() => server.Stop());
                    isConnected = false;
                    startServerBTN.Content = "Start Server";
                    tcpText.Text = "Server is downed";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void copyBTN_Click(object sender, RoutedEventArgs e)
        {
            server.server1.nodeManager.m_conveyor1.Conveyor.Motor1.Torque.Value = 1212;
            Clipboard.SetDataObject(tcpText.Text);
        }
        
        #endregion

        #region Public feild

        public OPCUAServer server = new OPCUAServer("Server.Config.xml");
        public bool isConnected = false;

        public SerialPort port {
            get { return m_port; }
            set {; }
        }


        #endregion

        #region Private field
        private SerialPort m_port = new SerialPort();
        private modbusRtuMotor motor;
        

        #endregion

        private void portComboBox_DropDownOpened(object sender, EventArgs e)
        {
            portComboBox.Items.Clear();

            foreach (string comPort in SerialPort.GetPortNames())
            {
                portComboBox.Items.Add(comPort);
            }
        }

        private void openBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!m_port.IsOpen)
                {
                    m_port.PortName = portComboBox.Text;

                    m_port.BaudRate = Convert.ToInt32( baudComboBox.Text);

                    m_port.Parity = (parityComboBox.SelectedIndex == 0) ? Parity.None :
                                    (parityComboBox.SelectedIndex == 1) ? Parity.Even :
                                    (parityComboBox.SelectedIndex == 2) ? Parity.Odd : 
                                    Parity.None;

                    m_port.DataBits = Convert.ToInt16( bitsComboBox.Text);

                    m_port.StopBits = (bitStopComboBox.SelectedIndex == 0) ? StopBits.None :
                                      (bitStopComboBox.SelectedIndex == 1) ? StopBits.One :
                                      (bitStopComboBox.SelectedIndex == 2) ? StopBits.Two :
                                      StopBits.One;

                    if(motor == null)
                    {
                        motor = new modbusRtuMotor(200, m_port, 1);
                        motor.motorMonitor += new modbusRtuMotor.motorMonitorEventHandler(monitor);
                    }

                    motor.start();

                    openBTN.Content = "Close Port";
                }
                else
                {
                    motor.stop();
                    openBTN.Content = "Open Port";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
