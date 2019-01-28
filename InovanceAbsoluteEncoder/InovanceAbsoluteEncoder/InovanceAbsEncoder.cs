using System;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Text;

namespace InovanceAbsoluteEncoder
{
    public class InovanceAbsEncoderReader
    {
        private SerialPort serialPort = new SerialPort();

        public InovanceAbsEncoderReader(string portName = "COM3", int baudRate = 57600, int dataBits = 8, StopBits stopBits = StopBits.Two, Parity parity = Parity.None)
        {
            serialPort.PortName = portName;
            serialPort.BaudRate = baudRate;
            serialPort.DataBits = dataBits;
            serialPort.StopBits = stopBits;
            serialPort.Parity = parity;
        }

        /// <summary>
        /// Open RS232 serial port.
        /// </summary>
        public void OpenSerialPort()
        {
            try
            {
                serialPort.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(serialPort.PortName + " open failed, detail: " + ex.Message);
            }
        }

        /// <summary>
        /// Get Inovance absolute encoder value by id.
        /// </summary>
        /// <param name="id">Can be retrieve from driver digital panel</param>
        /// <returns></returns>
        public int GetMotorAbsEncoderValue(int id)
        {
            #region Generate serial port command.

            //Data to be sent.
            byte[] byteBuffer = new Byte[8];

            //Servo driver ID.
            byte servoId = 0;
            try
            {
                servoId = Convert.ToByte(id);
            }
            catch (Exception)
            {
                throw new Exception("invalid servo id");
            }           
            byteBuffer[0] = servoId;

            //Function code: reading.
            byteBuffer[1] = 0x03;

            //Current absolute encoder position.
            UInt16 adr = 0x0B07;
            byteBuffer[2] = (byte)(adr >> 8);
            byteBuffer[3] = (byte)(((byte)(adr) / 16 * 10) + ((byte)(adr) % 16));

            //Data size?
            UInt16 size = 2;
            byteBuffer[4] = (byte)(size >> 8);
            byteBuffer[5] = (byte)(size);

            //Generate CRC checking code.
            byteBuffer[6] = (byte)(GenerateCRC(byteBuffer));
            byteBuffer[7] = (byte)(GenerateCRC(byteBuffer) >> 8);
            #endregion

            #region Send command to get encoder value.

            try
            {
                //Request encoder data.
                StringBuilder ret = new StringBuilder();
                foreach (byte b in byteBuffer)
                {
                    //{0:X2} 大写
                    ret.AppendFormat("{0:x2}", b);
                }
                var hex = ret.ToString();
                serialPort.Write(byteBuffer, 0, byteBuffer.Length);
            }
            catch (Exception ex)
            {
                throw new Exception(serialPort.PortName + " send failed, detail: " + ex.Message);
            }
            #endregion

            #region Wait for encoder value.

            //Delay 100 millisecond, serial port is slow.
            Thread.Sleep(100);
            byte[] byteRead = new byte[serialPort.BytesToRead];
            if (byteRead.Length != 9)
            {
                throw new Exception("Encoder data error, data lenght not equal to night");
            }

            serialPort.Read(byteRead, 0, byteRead.Length);
            #endregion

            #region Calculate encoder value and return.
            int AbsEncoderValue = (int)((byteRead[5] * 256 + byteRead[6]) * 65536 + byteRead[3] * 256 + byteRead[4]);

            return AbsEncoderValue; 
            #endregion
        }

        /// <summary>
        /// Calculate serial port CRC value.
        /// </summary>
        /// <param name="Buffer"></param>
        /// <returns></returns>
        private uint GenerateCRC(byte[] Buffer)
        {
            uint CRC_data;
            byte i;
            byte j = 0;
            CRC_data = 0xFFFF;
            while (j < Buffer.Length - 2)
            {
                CRC_data ^= Buffer[j];
                for (i = 0; i < 8; i++)
                {
                    if ((CRC_data & 0x0001) == 0x0001)
                    {
                        CRC_data >>= 1;
                        CRC_data ^= 0xA001;
                    }
                    else
                    {
                        CRC_data >>= 1;
                    }
                }
                j++;
            }
            return CRC_data;
        }
    }
}
