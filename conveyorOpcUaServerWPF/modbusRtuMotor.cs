using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Timers;
using Modbus.Data;
using System.Windows;

namespace modbusMotor
{

    public class modbusRtuMotor
    {

        #region Constructor   

        public modbusRtuMotor(int interval, SerialPort port, int idMotor)
        {
            
            driver = new modbusRtuDriver(port);
            driver.start();
            id = idMotor;

            timer = new System.Timers.Timer();
            timer.Interval = interval;
                
            timer.Elapsed += checkValue;
            timer.Start();
            
        }


        #endregion

        #region Write value

        public bool WriteMotor(int value, motorProperty property, int id)
        {
            bool result = false ;
            driver.write(Convert.ToByte(id), motorAddress[((int)property)], (UInt16)value, ModbusDataType.HoldingRegister);
            return result;
        }

        #endregion

        #region Method




        #endregion

        #region Value change event handler

        public delegate void motorMonitorEventHandler(ushort[] data);

        public motorMonitorEventHandler motorMonitor;
        private void checkValue(object? sender, ElapsedEventArgs e)
        {
            timer.Stop();
            if (driver.port.IsOpen)
            {
                getValue();
            }
            timer.Start();
        }

        public void getValue()
        {
            //ushort[] datas = await driver.readMotor(1, Modbus.Data.ModbusDataType.HoldingRegister, motorAddress);

            ushort[] datas = driver.readMotor(1, Modbus.Data.ModbusDataType.HoldingRegister, motorAddress);
            if (motorData != datas)
            {
                motorData = datas;
                if(motorMonitor != null)
                {
                    motorMonitor.Invoke(motorData);
                }
                direction = (motorData[0] == 75 || motorData[0] == 11) ? motorDirection.CW : motorDirection.CCW;
            }
        }


        #endregion

        #region Connection control
        public void stop()
        {
            driver.stop();
        }
        public void start()
        {
            driver.start();
        }
        #endregion

        #region private 

        // Setup timer
        private System.Timers.Timer timer;   

        // Setup modbus driver
        private  modbusRtuDriver driver;

        // Setup callback

        private int id;

        private static ushort directionAddress = 8;
        private static ushort setSpeedAddress = 13;
        private static ushort outputCurrentAddress = 202;
        private static ushort outputSpeedAddress = 201;
        private static ushort outputVoltageAddress = 214;
        private static ushort motorTorqueAddress = 207;
        
        private motorDirection direction = motorDirection.CW;

        private static int maxSpeed;
        private static int minSpeed;

        private static ushort setSpeed = 0;
        private static ushort outputSpeed = 0;
        private static ushort direction2 = 0;
        private static ushort outputVoltage = 0;
        private static ushort outputCurrent = 0;
        private static ushort motorTorque = 0;

        private static ushort[] motorData = { direction2,
                                    setSpeed,
                                    outputSpeed,
                                    outputCurrent,
                                    outputVoltage,
                                    motorTorque };
        
        private ushort[] motorAddress = { 
            directionAddress,
            setSpeedAddress ,
            outputSpeedAddress,
            outputCurrentAddress,
            outputVoltageAddress,
            motorTorqueAddress };

        private ushort[] testAddress = { 7,8,9,10,11,333 };

        #endregion

        #region public fields

        public bool isRunning;

        public enum motorDirection
        {
            CW,
            CCW
        }

        public enum motorProperty
        {
            direction = 0,
            setSpeed = 1, 
            outputSpeed = 2,
            outputCurrent = 3,
            outputVoltage = 4,
            Torque = 5
        }

        #endregion

        #region Assessor
        public int maxMotorSpeed
        {
            get
            {
                return maxSpeed;
            }
            set
            {
                if(value > 3000)
                {
                    maxSpeed = 3000;
                }
                else
                {
                    maxSpeed = value;
                }
                if(maxSpeed < minSpeed)
                {
                    maxSpeed = minSpeed;
                }

            }
        }
        public int minMotorSpeed {
            get
            {
                return minSpeed;
            }
            set
            {
                if(minSpeed < 0)
                {
                    minSpeed = 0;
                }
                else
                {
                    minSpeed = value;
                }
                if(minSpeed > maxSpeed)
                {
                    minSpeed = maxSpeed;
                }
               } 
        }

        public motorDirection Diretion 
        {
            get { return direction; }
        }

        public int SetSpeed { get { return setSpeed; } }
        public int OutputSpeed { get { return outputSpeed; } }
        public motorDirection Direction { get { return direction; } }
        public int OutputVoltage { get { return outputVoltage; } }
        public int OutputCurrent { get { return outputCurrent; } }
        public int Torque { get { return motorTorque; } }

        #endregion

    }

}
