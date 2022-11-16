using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modbus.Device;
using Modbus.Data;
using System.IO.Ports;

namespace modbusMotor
{
    public class modbusRtuDriver
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
            try
            {
                List<Task<ushort>> task = new List<Task<ushort>>();
                if(dataType == ModbusDataType.HoldingRegister)
                {
                    foreach (ushort p in points)
                    {
                        task.Add(Task.Run(() => master.ReadHoldingRegisters(slaveID, p, 1)[0]));
                    }
                    num = (await Task.WhenAll(task));
                }
                return num;
            }
            catch (Exception ex)
            {
                return num;
            }
        }

        #endregion

        #region Private fields

        public SerialPort port = new SerialPort();
        private IModbusSerialMaster master;

        #endregion

        #region Public fields
        //public SerialPort Port { get { return port; } }
        public IModbusSerialMaster Master {  get { return master; } }

        #endregion

    }

}
