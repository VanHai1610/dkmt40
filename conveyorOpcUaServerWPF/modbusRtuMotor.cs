using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Timers;

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

        #region Method
        private void checkValue(object? sender, ElapsedEventArgs e)
        {
            if (driver.port.IsOpen)
            {
                getValue();
            }
        }

        public async void getValue()
        {  
            ushort[] datas = await driver.readMotor(1, Modbus.Data.ModbusDataType.HoldingRegister, motorAddress);
            if(motorData != datas)
            {
                motorData = datas;
                if(motorMonitor != null)
                {
                    motorMonitor.Invoke(motorData);
                }
                direction = (motorData[0] == 75 || motorData[0] == 11) ? motorDirection.CW : motorDirection.CCW;
            }
        }

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
        public delegate void motorMonitorEventHandler(ushort[] data);

        public motorMonitorEventHandler motorMonitor;

        private int id;

        private static ushort directionAddress = 8;
        private static ushort outputCurrentAddress = 202;
        private static ushort setSpeedAddress = 13;
        private static ushort outputSpeedAddress = 201;
        private static ushort outputVoltageAddress = 203;
        private static ushort motorTorqueAddress = 207;
        
        private motorDirection direction = motorDirection.CW;

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
                                    motorTorque};
        
        private static ushort[] motorAddress = { 
            directionAddress,
            setSpeedAddress ,
            outputSpeedAddress,
            outputCurrentAddress,
            outputVoltageAddress,
            motorTorqueAddress};


        #endregion

        #region public fields

        public enum motorDirection
        {
            CW,
            CCW
        }

        #endregion

        #region Assessor

        public int SetSpeed { get { return setSpeed; } }
        public int OutputSpeed { get { return outputSpeed; } }
        public motorDirection Direction { get { return direction; } }
        public int OutputVoltage { get { return outputVoltage; } }
        public int OutputCurrent { get { return outputCurrent; } }
        public int Torque { get { return motorTorque; } }

        #endregion

    }

}
