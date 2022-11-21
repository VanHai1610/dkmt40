using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modbus.Device;
using Modbus.Data;
using System.IO.Ports;
using System.Windows;

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

        public void stop()
        {
            wantToStop = true;
        }
        public void write(byte _id, ushort _address, ushort _value, ModbusDataType _type)
        {
                id = _id;
                address = _address;
                value = _value;
                type = _type;
                writeMotor();
        }

        public void writeMotor()
        {
            try
            {
                if(type == ModbusDataType.HoldingRegister)
                {
                    master.WriteSingleRegister(id, address, value);
                    //MessageBox.Show(value.ToString() + "_" + id.ToString() + "_" + address.ToString());
                }
            }
            catch (Exception ex)
            {
                
            }

        
        }
        public ushort[] readMotor(byte slaveID, ModbusDataType dataType, ushort[] points)
        {
            ushort[] num = new ushort[points.Length];
            
            try
            {
                isReading = true;
                
                if(dataType == ModbusDataType.HoldingRegister && port.IsOpen && (!wantToStop || !wantToWrite))
                {
                    for (int i = 0; i < points.Length; i++)
                    {
                        num[i] = master.ReadHoldingRegisters(slaveID, points[i], (ushort)1)[0];
                    }
                }
                isReading = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetHashCode().ToString());
            }
            if (wantToStop)
            {
                port.Close();
                wantToStop = false;
            }
            if (wantToWrite)
            {
                writeMotor();
                wantToWrite = false;
            }
            return num;
        }

        public async Task<ushort[]> readMotorAsync(byte slaveID, ModbusDataType dataType, ushort[] points)
        {
            ushort[] num = new ushort[points.Length];

            try
            {
                List<Task<ushort>> task = new List<Task<ushort>>();
                
                if(dataType == ModbusDataType.HoldingRegister && port.IsOpen && !wantToStop)
                {
                    foreach (ushort p in points)
                    {
                        task.Add(Task.Run(() => master.ReadHoldingRegisters(slaveID, p, 1)[0]));
                    }
                    num = (await Task.WhenAll(task));
                    if (wantToStop)
                    {
                        port.Close();
                        wantToStop = false;
                    }
                }
                return num;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return num;
                
            }
        }

        #endregion

        #region Private fields

        private IModbusSerialMaster master;
        private bool wantToStop = false;
        private bool wantToWrite = false;

        private byte id = 1;
        private ushort address = 0;
        private ushort value = 0;
        private ModbusDataType type = ModbusDataType.HoldingRegister;


        #endregion

        #region Public fields
        //public SerialPort Port { get { return port; } }
        public bool isReading = false;

        public SerialPort port = new SerialPort();

        #endregion

    }

}
