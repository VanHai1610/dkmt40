using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using Modbus.Device;
using Modbus.Data;
using System.Threading;

namespace modbusDriver
{
    internal class modbusRtuDriver
    {

        #region Constructor

        public modbusRtuDriver(SerialPort _port)
        {
            port = _port;
            master = ModbusSerialMaster.CreateRtu(port);
        }
        public modbusRtuDriver(string portName, 
                               int baudrate = 9600, 
                               int dataBits = 8, 
                               Parity parity = Parity.None, 
                               StopBits stopBits = StopBits.One)
        {
            port.PortName = portName;
            port.BaudRate = baudrate;
            port.DataBits = dataBits;
            port.Parity = parity;
            port.StopBits = stopBits;

            master = ModbusSerialMaster.CreateRtu(port); 
        }

        #endregion

        #region Method  

        public bool start()
        {
            if (!port.IsOpen)
            {
                port.Open();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool stop()
        {
            if (port.IsOpen)
            {
                port.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<ushort[]> readMotor(byte slaveID, ModbusDataType dataType, ushort[] points)
        {
            ushort[] num = new ushort[points.Length];
            
            if(dataType == ModbusDataType.HoldingRegister)
            {
                for(int i = 0; i < points.Length; i++)
                {
                    Thread.Sleep(2000);
                    num[i] = (await Task.Run(() => master.ReadHoldingRegistersAsync(slaveID, points[i], 1)))[0];
                }
                
            }
            return num;
        }

        #endregion

        #region Private fields

        private SerialPort port = new SerialPort();
        private IModbusSerialMaster master;

        #endregion

        #region Public fields
        public SerialPort Port { get { return port; } }
        public IModbusSerialMaster Master {  get { return master; } }

        #endregion


    }
}
